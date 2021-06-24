using UnityEngine;
using UnityEngine.Events;

namespace TirUtilities.CustomEvents
{
    ///<!--
    /// GameObjectEvent.cs
    /// 
    /// Project:  TirUtilities
    ///        
    /// Author :  Devon Wilson
    /// Created:  Mar. 31, 2021
    /// Updated:  Mar. 31, 2021
    /// -->
    /// <summary>
    /// A Unity Event that passes a game object to its listeners.
    /// </summary>
    public class GameObjectEvent : UnityEvent<GameObject> { }
}