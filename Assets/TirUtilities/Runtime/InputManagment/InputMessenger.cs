#if ENABLE_LEGACY_INPUT_MANAGER
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

namespace TirUtilities.InputManagment
{
    using TirUtilities.Extensions;
    ///<!--
    /// InputMessenger.cs
    /// 
    /// Project:  TirUtilities
    ///        
    /// Author :  Devon Wilson
    /// Company:  Black Phoenix Software
    /// Created:  Jan 15, 2020
    /// Updated:  Oct 21, 2021
    /// -->
    /// <summary>
    /// Use to send messages to all components in the object's hierarchy using the legacy input
    /// manager.  This provided a centralized location to handle all user input.
    /// </summary>
    /// <remarks>
    /// Each binding has events that can be used to emit signals if you want the input managed by
    /// this class to influence other scenes.
    /// </remarks>
    [AddComponentMenu("TirUtilities/InputManagment/Input Messenger"), DisallowMultipleComponent]
    public class InputMessenger : MonoBehaviour
    {
        #region Fields

        [SerializeField, Tooltip("Send messages for specific keys.")] 
        private List<KeyboardBinding> _keyboardBindings;

        [SerializeField, Tooltip("Send input from axes in the Input Manager.")] 
        private List<AxisBinding> _axisBindings;

        /// <summary> Used to provide the message names for the help box. </summary>
        [SerializeField, HideInInspector]
        private List<string> _messages = new List<string>();

        #endregion

        #region Set Message Names
#if UNITY_EDITOR
        private void OnValidate()
        {
            if (_keyboardBindings == null || _keyboardBindings.Count <= 0) return;

            _messages.Clear();

            _keyboardBindings.ForEach(bind =>
            {
                var message = TrimWhitespace(bind.Name);

                _messages.AddRange(new string[] { $"On{message}Down", $"On{message}Held", $"On{message}Down" });
            });
            _axisBindings.ForEach(bind =>
            {
                var message = TrimWhitespace(bind.Axis);

                _messages.AddRange(new string[] { $"On{message}", $"On{message}Raw" });
            });
        }
#endif 
        #endregion

        private void Update() => BroadcastMessages();

        /// <summary>
        /// Broadcast messages for each <see cref="KeyboardBinding"/> and <see cref="AxisBinding"/>.
        /// </summary>
        private void BroadcastMessages()
        {
            if (_keyboardBindings == null || _keyboardBindings.Count <= 0) return;

            _keyboardBindings.ForEach(bind => Broadcast(bind));

            if (_axisBindings == null || _axisBindings.Count <= 0) return;

            _axisBindings.ForEach(bind => Broadcast(bind));
        }

        private void Broadcast(AxisBinding bind)
        {
            var message = TrimWhitespace(bind.Axis);

            BroadcastMessage($"On{message}", bind.Value, SendMessageOptions.DontRequireReceiver);
            bind.OnAxis.SafeInvoke(bind.Value);

            BroadcastMessage($"On{message}", bind.RawValue, SendMessageOptions.DontRequireReceiver);
            bind.OnAxisRaw.SafeInvoke(bind.RawValue);
        }

        private void Broadcast(KeyboardBinding bind)
        {
            var message = TrimWhitespace(bind.Name);

            if (bind.KeyDown)
            {
                BroadcastMessage($"On{message}Down", SendMessageOptions.DontRequireReceiver);
                bind.OnKeyDown.SafeInvoke();
            }
            if (bind.KeyHeld)
            {
                BroadcastMessage($"On{message}Held", SendMessageOptions.DontRequireReceiver);
                bind.OnKeyHeld.SafeInvoke();
            }
            if (bind.KeyUp)
            {
                BroadcastMessage($"On{message}Up", SendMessageOptions.DontRequireReceiver);
                bind.OnKeyUp.SafeInvoke();
            }
        }

        private static string TrimWhitespace(string value) => Regex.Replace(value, @"\s+", "");
    }

    #region Custom Inspector
#if UNITY_EDITOR
    [UnityEditor.CustomEditor(typeof(InputMessenger))]
    public sealed class InputMessagerInspector : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            var messages = serializedObject.FindProperty("_messages");

            var boxContent = "Will BroadcastMessage() to GameObject:  ";

            if (messages != null && messages.arraySize > 0)
            {
                for (int i = 0; i < messages.arraySize; i++)
                    boxContent +=
                        $"{messages.GetArrayElementAtIndex(i).stringValue}{(i != messages.arraySize - 1 ? ", " : " ")}";

            }
            UnityEditor.EditorGUILayout.HelpBox(boxContent, UnityEditor.MessageType.None);
        }
    }
#endif
    #endregion
} 
#endif