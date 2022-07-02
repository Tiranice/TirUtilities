using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace TirUtilities.Core.Experimental
{
    ///<!--
    /// ObjectPool.cs
    /// 
    /// Project:  TirUtilities
    ///        
    /// Author :  Devon Wilson
    /// Company:  BlackPhoenixSoftware
    /// Created:  Sep 28, 2021
    /// Updated:  Oct 01, 2021
    /// -->
    /// <summary>
    ///
    /// </summary>
    public sealed class ObjectPool<T> : IDisposable
    {
        #region Fields

        private readonly ConcurrentBag<T> _bagOfHolding;
        private readonly Func<T> _generator;
        private readonly int _maxSize;
        private readonly HashSet<T> _managedSet = new HashSet<T>();
        private readonly Action<T> _disposalCallback;

        #endregion

        #region Public Properties

        public IReadOnlyList<T> BagOfHolding => (IReadOnlyList<T>)_bagOfHolding;

        public int MaxSize => _maxSize;

        public IReadOnlyCollection<T> ManagedSet => _managedSet;

        #endregion

        #region Constructor

        public ObjectPool(IEnumerable<T> prepooledItems, Func<T> generator, Action<T> disposer, int maxSize = 50)
        {
            _bagOfHolding = new ConcurrentBag<T>(prepooledItems ?? throw new ArgumentNullException(nameof(prepooledItems)));
            _generator = generator ?? throw new ArgumentNullException(nameof(generator));
            _disposalCallback = disposer ?? throw new ArgumentNullException(nameof(disposer));
            _maxSize = maxSize;
        }

        #endregion

        #region Request & Release

        private T Request() => _bagOfHolding.TryTake(out T item) ? item : _generator();

        public bool TryRequest(out T item)
        {
            if (_managedSet.Count >= _maxSize || _isDisposing)
            {
                item = default;
                return false;
            }

            item = Request();
            _managedSet.Add(item);
            return true;
        }

        public void Return(T item) => _bagOfHolding.Add(item);

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
                        _ = result;

                    foreach (T item in _managedSet)
                        _disposalCallback?.Invoke(item);
                }

                _isDisposed = true;
            }
        }

        public void Dispose() => Dispose(disposing: true);

        #endregion
    }
}