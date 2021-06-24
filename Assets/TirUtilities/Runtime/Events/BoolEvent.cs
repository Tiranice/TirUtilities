using UnityEngine;
using UnityEngine.Events;

namespace TirUtilities.CustomEvents
{
    /// <summary>
    /// Passes a bool and a GameObject to its listeners.
    /// </summary>
    [System.Serializable]
    public class BoolEvent : UnityEvent<bool, GameObject> { }
}