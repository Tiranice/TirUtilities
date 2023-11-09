using System;

namespace TirUtilities.Experimental
{
    ///<!--
    /// Singleton.cs
    /// 
    /// Project:  TirUtilities
    ///        
    /// Author :  Devon Wilson
    /// Created:  May 15, 2021
    /// Updated:  May 15, 2021
    /// -->
    /// <summary>
    /// This is intended only as an example. DO NOT USE!!!
    /// </summary>
    public sealed class Singleton
    {
        #region Singleton Instance

        private static readonly Lazy<Singleton> _Lazy = new Lazy<Singleton>(() => new Singleton());

        public static Singleton Instance { get => _Lazy.Value; }

        public static bool Exists { get => _Lazy.IsValueCreated; }

        #endregion

        #region Constructor

        private Singleton() { }

        #endregion
    }
}