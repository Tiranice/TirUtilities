using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

///<!--
/// IObjectPool.cs
/// 
/// Project:  TirUtilities
///        
/// Author :  Devon Wilson
/// Company:  Black Phoenix Software
/// Created:  Nov 06, 2021
/// Updated:  Nov 06, 2021
/// -->
/// <summary>
///
/// </summary>
public interface IObjectPool<TClass> where TClass : class
{
    bool TryRequest(out TClass item);

    void Return(TClass item);

    int ActiveCount { get; }
    int InactiveCount { get; }
}

public class ObjectPool<T> : IDisposable, IObjectPool<T> where T : class
{
    private readonly ConcurrentBag<T> _bagOfHolding;
    private readonly HashSet<T> _activeSet;

    private readonly Func<T> _generator;
    private readonly Action<T> _requestCallback;
    private readonly Action<T> _returnCallback;
    private readonly Action<T> _destroyCallback;

    private readonly int _maxSize;

    public int Count => ActiveCount + InactiveCount;
    public int ActiveCount => _activeSet.Count;
    public int InactiveCount => _bagOfHolding.Count;

    #region Constructors

    public ObjectPool(Func<T> generator,
              Action<T> requestCallback,
              Action<T> returnCallback,
              Action<T> destroyCallback,
              int maxSize = 10_000)
    {
        _generator = generator ?? throw new ArgumentNullException(nameof(generator));
        if (maxSize <= 0)
            throw new ArgumentException("Max size must be grater than zero(0)", nameof(maxSize));
        _maxSize = maxSize;

        _bagOfHolding = new ConcurrentBag<T>();
        _activeSet = new HashSet<T>();

        _requestCallback = requestCallback;
        _returnCallback = returnCallback;
        _destroyCallback = destroyCallback;
    }

    public ObjectPool(Func<T> generator,
                      Action<T> requestCallback,
                      Action<T> returnCallback,
                      Action<T> destroyCallback,
                      IEnumerable<T> prepooledObjects,
                      int maxSize = 10_000) : this(generator, requestCallback, returnCallback, destroyCallback)
    {
        if (maxSize < prepooledObjects.Count())
            throw new ArgumentException("Max size must be grater than or equal to the number of prepooled objects.", nameof(maxSize));
        _maxSize = maxSize;

        foreach (T obj in prepooledObjects) _bagOfHolding.Add(obj);
    } 

    #endregion

    #region Request & Return

    private T Request() => _bagOfHolding.TryTake(out T item) ? item : _generator();

    public bool TryRequest(out T item)
    {
        if (_activeSet.Count >= _maxSize || _isDisposing)
        {
            item = default;
            return false;
        }

        item = Request();

        _activeSet.Add(item);

        _requestCallback?.Invoke(item);

        return true;
    }

    public void Return(T item)
    {
        if (_bagOfHolding.Count > 0 && _bagOfHolding.Contains(item))
            throw new InvalidOperationException($"Attempted to return an object that is currently in the pool.");

        if (!_activeSet.Contains(item))
            throw new InvalidOperationException($"Attempted to return an object that is not managed by this pool.");

        _returnCallback?.Invoke(item);

        _activeSet.Remove(item);
        _bagOfHolding.Add(item);
    }

    #endregion

    #region Disposal

    private bool _isDisposed;
    private bool _isDisposing = false;

    private void Dispose(bool disposing)
    {
        _isDisposing = true;

        if (!_isDisposed)
        {
            if (disposing)
            {
                while (_bagOfHolding.TryTake(out T result))
                    _destroyCallback(result);

                foreach (T item in _activeSet)
                    _destroyCallback?.Invoke(item);
            }

            _isDisposed = true;
        }
    }

    public void Dispose() => Dispose(disposing: true);

    #endregion
}