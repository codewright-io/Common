﻿using CodeWright.Common.EventSourcing.Models;

namespace CodeWright.Common.EventSourcing.EntityFramework;

/// <summary>
/// A basic repository for saving domain objects.
/// </summary>
/// <typeparam name="T"></typeparam>
/// <typeparam name="TFactory"></typeparam>
public class BasicDomainObjectRepository<T, TFactory> : IDomainRepository<T>
    where T : IDomainObject
    where TFactory : IDomainObjectFactory<T>, new()
{
    private readonly IEventStore _eventStore;
    private readonly IEventBus _eventBus;

    /// <summary>
    /// Create an instance of a BasicDomainObjectRepository
    /// </summary>
    public BasicDomainObjectRepository(IEventStore eventStore, IEventBus eventBus)
    {
        _eventStore = eventStore;
        _eventBus = eventBus;
    }

    /// <summary>
    /// Get the domain entity
    /// </summary>
    public async Task<T?> GetByIdAsync(ObjectId id, TenantId tenantId, TypeId typeId)
    {
        const int limit = 100;
        var domainEvents = await _eventStore.GetByIdAsync(id, tenantId, typeId, -1, limit);
        var factory = new TFactory();
        var domainObject = factory.CreateFromEvents(domainEvents);
        while (domainObject != null && domainEvents.Count() == limit)
        {
            domainEvents = await _eventStore.GetByIdAsync(id, tenantId, typeId, -1, limit);
            factory.UpdateFromEvents(domainObject, domainEvents);
        }
        domainObject?.StartQueuing();

        return domainObject;
    }

    /// <summary>
    /// Save the domain entity
    /// </summary>
    /// <param name="item">The domain object to save</param>
    public async Task SaveAsync(T item)
    {
        var domainEvents = item.StopQueuing();

        // Save to event store
        await _eventStore.SaveAsync(domainEvents);

        // Send to event bus
        await _eventBus.SendAsync(domainEvents);
    }
}
