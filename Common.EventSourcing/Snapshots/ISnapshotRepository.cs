﻿using CodeWright.Common.EventSourcing.Models;

namespace CodeWright.Common.EventSourcing.Snapshots;


/// <summary>
/// Storage for event sourcing snapshots
/// </summary>
public interface ISnapshotRepository<TModel>
    where TModel : IDomainObject
{
    /// <summary>
    /// Fetch the snapshot by ID, tenantID
    /// </summary>
    Task<Snapshot<TModel>?> GetAsync(ObjectId id, TenantId tenantId);

    /// <summary>
    /// Save the snapshot with a specified version
    /// </summary>
    Task SaveAsync(TModel model, long version);
}
