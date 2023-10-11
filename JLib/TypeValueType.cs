﻿using System.Reflection;
using JLib.Attributes;
using JLib.Exceptions;
using Serilog.Events;

namespace JLib;

/// <summary>
/// allows a <see cref="ITypeValueType"/> to run code after the navigation has been initialized but before it will be validated
/// <br/>can be used to set properties which are derived from Attributes on navigated types
/// </summary>
public interface IPostNavigationInitializedType : ITypeValueType
{
    void Initialize(IExceptionManager exceptions);
}

public interface IValidatedType : ITypeValueType
{
    void Validate(ITypeCache cache, TvtValidator value);
}
public interface IDataObjectType : ITypeValueType { }
public interface IMappedDataObjectType : IDataObjectType
{
    EntityType SourceEntity { get; }
    PropertyPrefix? PropertyPrefix { get; }
    bool ReverseMap { get; }
}
public interface ITypeValueType
{
    public string Name => Value.Name;
    Type Value { get; }
    public bool HasCustomAutoMapperProfile { get; }
}
[Unmapped]
public abstract partial record TypeValueType(Type Value) : ValueType<Type>(Value), ITypeValueType
{
    public string Name => Value.Name;

    protected InvalidTypeException NewInvalidTypeException(string message)
        => new(GetType(), Value, message);

    public bool HasCustomAutoMapperProfile => Value.GetCustomAttributes().Any(a => a is ICustomProfileAttribute);

}