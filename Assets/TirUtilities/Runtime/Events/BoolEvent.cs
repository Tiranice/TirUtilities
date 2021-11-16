using UnityEngine.Events;

namespace TirUtilities.CustomEvents
{
    ///<!--
    /// BoolEvent.cs
    /// 
    /// Project:  TirUtilities
    ///        
    /// Author :  Devon Wilson
    /// Company:  Black Phoenix Software
    /// Created:  Oct 10, 2021
    /// Updated:  Oct 10, 2021
    /// -->
    /// <summary>
    /// A Unity Event that passes a bool to its listeners.
    /// </summary>
    [System.Serializable]
    public class BoolEvent : UnityEvent<bool> { }
}
