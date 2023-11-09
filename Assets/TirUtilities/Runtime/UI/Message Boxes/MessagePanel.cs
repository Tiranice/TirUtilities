using System.Collections.Generic;
using TirUtilities.Extensions;
using UnityEngine;
using UnityEngine.Events;

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
    /// A UI panel that displays TMP text elements and moves through them in order.
    /// </summary>
    [AddComponentMenu("TirUtilities/UI/Message Panel")]
    public class MessagePanel : MonoBehaviour
    {
        #region Inspector Fields

        [Tooltip("The UI panel that holds the messages.")]
        [SerializeField] private GameObject _messagePanel;

        [Tooltip("A list of messages in the order that they should be displayed.")]
        [SerializeField] private List<GameObject> _messages = new List<GameObject>();

        #endregion

        #region Private Fields

        /// <summary> The index of the message currently being displayed. </summary>
        private int _listPosistion = 0;

        #endregion

        #region Events

        /// <summary> 
        /// Invoked after the <see cref="_messagePanel">Message Panel</see> is deactivated. 
        /// </summary>
        public UnityEvent OnMessagePanelClosed;

        #endregion

        #region Public Methods

        /// <summary>
        /// Activates the next message in the <see cref="_messages">Messages</see> list.
        /// </summary>
        /// <remarks>
        /// If called when the final message is active, the <see cref="_messagePanel">Message Panel</see>
        /// is deactivated and <see cref="OnMessagePanelClosed">On Message Panel Closed</see> is
        /// invoked.
        /// </remarks>
        public void NextMessage()
        {
            if (_listPosistion < _messages.Count - 1)
            {
                _messages[_listPosistion].SetActive(false);
                _listPosistion++;
                _messages[_listPosistion].SetActive(true);

                return;
            }

            _messagePanel.SetActive(false);
            OnMessagePanelClosed.SafeInvoke();
        }

        #endregion
    }
}
