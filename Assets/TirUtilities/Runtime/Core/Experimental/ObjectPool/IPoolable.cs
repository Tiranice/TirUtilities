using System;

namespace TirUtilities.Core.Experimental
{
    ///<!--
    /// IPoolable.cs
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
    public interface IPoolable
    {
        event Action ReturnAction;

        void Return();
    }
}