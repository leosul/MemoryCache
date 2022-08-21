﻿namespace CachingApp.Interfaces;

public interface ICacheStore
{
    void Add<TItem>(TItem item, ICacheKey<TItem> key, TimeSpan? expirationTime = null);

    TItem Get<TItem>(ICacheKey<TItem> key) where TItem : class;

    void Remove<TItem>(ICacheKey<TItem> key);
}
