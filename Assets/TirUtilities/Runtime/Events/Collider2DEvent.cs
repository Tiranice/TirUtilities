using UnityEngine;
using UnityEngine.Events;

namespace TirUtilities.CustomEvents
{
    ///<!--
    /// Collider2DEvent.cs
    /// 
    /// Project:  TirUtilities
    ///        
    /// Author :  Devon Wilson
    /// Company:  Black Phoenix Software
    /// Created:  Oct 10, 2021
    /// Updated:  Oct 10, 2021
    /// -->
    /// <summary>
    /// A Unity Event that passes a Collider2D to its listeners.
    /// </summary>
    [System.Serializable]
    public class Collider2DEvent : UnityEvent<Collider2D> { }
}
