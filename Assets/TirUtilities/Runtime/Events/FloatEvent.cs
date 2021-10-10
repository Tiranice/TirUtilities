using UnityEngine.Events;

namespace TirUtilities.CustomEvents
{
    ///<!--
    /// FloatEvent.cs
    /// 
    /// Project:  TirUtilities
    ///        
    /// Author :  Devon Wilson
    /// Company:  Black Phoenix Software
    /// Created:  Oct 10, 2021
    /// Updated:  Oct 10, 2021
    /// -->
    /// <summary>
    /// A Unity Event that passes a float to its listeners.
    /// </summary>
    [System.Serializable]
    public class FloatEvent : UnityEvent<float> { }
}
