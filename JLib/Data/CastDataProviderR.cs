﻿namespace JLib.Data;

public class CastDataProviderR<TFrom, TTo> : ISourceDataProviderR<TTo>
    where TFrom : TTo, IDataObject
    where TTo : IDataObject
{
    private readonly IDataProviderR<TFrom> _srcProvider;

    public CastDataProviderR(IDataProviderR<TFrom> srcProvider)
    {
        _srcProvider = srcProvider;
    }
    public IQueryable<TTo> Get() => _srcProvider.Get().Cast<TTo>();
}