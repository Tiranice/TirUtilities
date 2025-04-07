using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Events;

///<!--
///     Copyright (C) 2025  Devon Wilson
///
///     This program is free software: you can redistribute it and/or modify
///     it under the terms of the GNU Lesser General Public License as published
///     by the Free Software Foundation, either version 3 of the License, or
///     (at your option) any later version.
///
///     This program is distributed in the hope that it will be useful,
///     but WITHOUT ANY WARRANTY; without even the implied warranty of
///     MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
///     GNU Lesser General Public License for more details.
///
///     You should have received a copy of the GNU General Public License
///     along with this program.  If not, see <https://www.gnu.org/licenses/>.
///-->

namespace TirUtilities.UI
{
    using TirUtilities.Extensions;
    ///<!--
    /// MessagePanel.cs
    ///
    /// Project:  TirUtilities
    ///
    /// Author :  Devon Wilson
    /// Company:  Black Phoenix Creative
    /// Created:  Mar 27, 2021
    /// Updated:  Apr 02, 2021
    /// -->
    /// <summary>
    /// A UI panel that displays TMP text elements and moves through them in order.
    /// </summary>
    [AddComponentMenu("TirUtilities/UI/Message Panel")]
    public class MessagePanel : MonoBehaviour
    {
        [Tooltip("The UI panel that holds the messages.")]
        [SerializeField] private GameObject _messagePanel;

        [Tooltip("A list of messages in the order that they should be displayed.")]
        [SerializeField] private List<GameObject> _messages = new();

        /// <summary> The index of the message currently being displayed. </summary>
        private int _listPosistion = 0;

        /// <summary> 
        /// Invoked after the <see cref="_messagePanel">Message Panel</see> is deactivated. 
        /// </summary>
        public UnityEvent OnMessagePanelClosed;

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
    }
}
