using UnityEngine;

namespace TirUtilities.Signals
{
    ///<!--
    /// StringSignalEmitter.cs
    /// 
    /// Project:  TirUtilities
    ///        
    /// Author :  Devon Wilson
    /// Company:  Black Phoenix Software
    /// Created:  Aug 01, 2022
    /// Updated:  Aug 01, 2022
    /// -->
    /// <summary>
    /// Emits the text area over the given <see cref="StringSignal"/> whenever the selected 
    /// <see cref="UnityMessage"/> is broadcast.
    /// </summary>
    [AddComponentMenu("TirUtilities/Signals/Emitters/String Signal Emitter")]
    public class StringSignalEmitter : SignalEmitterBase<StringSignal, string>
    {
        [SerializeField, TextArea] private string _text;

        protected override string Data => _text;
    }
}