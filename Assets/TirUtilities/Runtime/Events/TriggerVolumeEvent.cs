using UnityEngine;
using UnityEngine.Events;

namespace TirUtilities.CustomEvents
{
    ///<!--
    /// TriggerVolumeEvent.cs
    /// 
    /// Project:  TirUtilities
    ///        
    /// Author :  Devon Wilson
    /// Company:  Black Phoenix Software
    /// Created:  Mar 31, 2021
    /// Updated:  Oct 10, 2021
    /// -->
    /// <summary>
    /// A Unity Event that passes the entered state and target from a 
    /// <see cref="Detection.TriggerVolume"/> to its listeners.
    /// </summary>
    [System.Serializable]
    public class TriggerVolumeEvent : UnityEvent<bool, GameObject> { }
}
