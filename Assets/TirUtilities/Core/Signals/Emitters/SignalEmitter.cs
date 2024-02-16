using UnityEngine;

namespace TirUtilities.Signals
{
    ///<!--
    /// SignalEmitter.cs
    /// 
    /// Project:  TirUtilities
    ///        
    /// Author :  Devon Wilson
    /// Company:  Black Phoenix Software
    /// Created:  Aug 01, 2022
    /// Updated:  Aug 01, 2022
    /// -->
    /// <summary>
    /// Emits the given signal whenever the selected <see cref="UnityMessage"/> is broadcast.
    /// </summary>
    [AddComponentMenu("TirUtilities/Signals/Emitters/Signal Emitter")]
    public class SignalEmitter : SignalEmitterBase<Signal>
    {
    }
}