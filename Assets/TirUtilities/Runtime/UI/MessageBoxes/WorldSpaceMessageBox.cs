using TirUtilities.Extensions;
using TirUtilities.Signals;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace TirUtilities.UI
{
    ///<!--
    /// MessagePanel.cs
    /// 
    /// Project:  TirUtilities
    /// 
    /// Author :  Devon Wilson
    /// Created:  Mar. 27, 2021
    /// Updated:  April 02, 2021
    /// -->
    /// <summary>
    /// A world space UI panel that holds TMP text and links to another message.
    /// </summary>
    [RequireComponent(typeof(UIBillboard))]
    public class WorldSpaceMessageBox : MonoBehaviour
    {
        #region Inspector Fields

        [Tooltip("Whether or not this message is the first in a chain.")]
        [SerializeField] private bool _isFirstMessage = false;
        [Space(2)]

        [Header("Child UI Elements")]
        [Tooltip("The button that dismisses this message & opens the next one.")]
        [SerializeField] private Button _dismissButton;
        [Tooltip("The panel that the text appears in.")]
        [SerializeField] private GameObject _panel;
        [Space(2)]

        [Header("Relatives")]
        [Tooltip("This game object will be activated when the message box is closed.")]
        [SerializeField] private WorldSpaceMessageBox _nextMessage;

        #endregion

        #region Private Fields

        /// <summary> The text of the message is stored as part of this object. </summary>
        private UIBillboard _billboard;

        #endregion

        #region Events & Signals

        [Header("Events & Signals")]
        ///<summary> Invoked when this message is <see cref="DismissMessages">Dismissed</see>.</summary>
        public UnityEvent OnMessageBoxDismissed;

        [Tooltip("When this signal is received this message will be activated.")]
        [SerializeField] private Signal _openWhenSignalRecieved;

        #endregion

        #region Properties

        /// <summary> Whether or not this is the first message in a chain. </summary>
        public bool IsFirstMessage { get => _isFirstMessage; }

        /// <summary> The text stored in this message's <see cref="_billboard">Billboard</see>. </summary>
        public string Text { get => _billboard.NotNull() ? _billboard.Text : string.Empty; }

        #endregion

        #region Unity Messages

        private void OnValidate() => TryGetComponent(out _billboard);

        private void Start() => Setup();

        private void OnDestroy() => Teardown();

        #endregion

        #region Setup & Teardown

        /// <summary>
        /// Cache the <see cref="_dismissButton">Dismiss Button</see> & setup event listeners.
        /// </summary>
        private void Setup()
        {
            if (_dismissButton.IsNull())
                _dismissButton = GetComponentInChildren<Button>();

            _dismissButton.onClick.AddListener(DismissMessages);

            _openWhenSignalRecieved.AddReceiver(() => _panel.SetActive(true));
        }

        private void Teardown()
        {
            if (_dismissButton.NotNull())
                _dismissButton.onClick.RemoveListener(DismissMessages);
            _openWhenSignalRecieved.RemoveReceiver(() => _panel.SetActive(true));
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Deactivate this message's game object, activate the <see cref="_nextMessage">Next Message</see>,
        /// & invoke <see cref="OnMessageBoxDismissed">On Message Box Dismissed</see>.
        /// </summary>
        private void DismissMessages()
        {
            gameObject.SetActive(false);
            ActivateNextMessage();

            OnMessageBoxDismissed.SafeInvoke();
        }

        /// <summary>
        /// Activates <see cref="_nextMessage">Next Message</see> if it exists.
        /// </summary>
        private void ActivateNextMessage()
        {
            if (_nextMessage.NotNull())
                _nextMessage.gameObject.SetActive(true);
        }

        #endregion

        #region Factory

        /// <summary>
        /// UNFINISHED
        /// </summary>
        /// <param name="text"></param>
        /// <param name="nextMessage"></param>
        /// <returns></returns>
        public static WorldSpaceMessageBox CreateMessageBox(string text, GameObject nextMessage = null)
        {
            var box = new GameObject();
            box.AddComponent<UIBillboard>();
            box.AddComponent<WorldSpaceMessageBox>();

            return box.GetComponent<WorldSpaceMessageBox>();
        }

        #endregion
    }
}
