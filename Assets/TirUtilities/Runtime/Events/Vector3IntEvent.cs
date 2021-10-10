using UnityEngine;
using UnityEngine.Events;

namespace TirUtilities.CustomEvents
{
    ///<!--
    /// Vector3IntEvent.cs
    /// 
    /// Project:  TirUtilities
    ///        
    /// Author :  Devon Wilson
    /// Company:  Black Phoenix Software
    /// Created:  Oct 10, 2021
    /// Updated:  Oct 10, 2021
    /// -->
    /// <summary>
    /// A Unity Event that passes a Vector3Int to its listeners.
    /// </summary>
    [System.Serializable]
    public class Vector3IntEvent : UnityEvent<Vector3Int> { }
}
