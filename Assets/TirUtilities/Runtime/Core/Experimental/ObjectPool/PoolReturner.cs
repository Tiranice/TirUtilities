using UnityEngine;

namespace TirUtilities.Core.Experimental
{

    ///<!--
    /// PoolReturner.cs
    /// 
    /// Project:  Prototype 4
    ///        
    /// Author :  Devon Wilson
    /// Company:  Black Phoenix Software
    /// Created:  Sep 29, 2021
    /// Updated:  Sep 29, 2021
    /// -->
    /// <summary>
    ///
    /// </summary>
    public class PoolReturner : MonoBehaviour
    {
        public void Return(GameObject target)
        {
            if (target.TryGetComponent(out IPoolable poolable))
                poolable.Return();
        }

        public void ReturnFromTriggerVolume(bool entered, GameObject target)
        {
            if (!entered) return;

            if (target.TryGetComponent(out IPoolable poolable))
                poolable.Return();
        }
    }
}