namespace CodeWright.Common.Ids;

/// <summary>
/// Base class for all strongly typed IDs
/// </summary>
/// <typeparam name="T">The underlying ID type</typeparam>
/// <param name="Value"></param>
public abstract record StronglyTypedId<T>(T Value)
    where T : notnull, IEquatable<T>
{
    public override string ToString() => Value?.ToString() ?? "null";
}
