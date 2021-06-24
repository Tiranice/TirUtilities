using TirUtilities.Extensions;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace TirUtilities.UI
{
    ///<!--
    /// UIMessageBox.cs
    /// 
    /// Project:  TirUtilities
    /// 
    /// Author :  Devon Wilson
    /// Created:  Mar. 29, 2021
    /// Updated:  Mar. 29, 2021
    /// -->
    /// <summary>
    ///
    /// </summary>
    public class UIMessageBox : MonoBehaviour
    {
        #region Inspector Fields

        [SerializeField][TextArea] private string _text;
        [Space(2)]

        [SerializeField] private Button _dismissButton;
        [Space(2)]

        [SerializeField] private TextMeshProUGUI _textUGUI;
        [SerializeField] private TextMeshProUGUI _icon;
        [Space(2)]

        #endregion

        #region Events

        public UnityEvent OnDissmissed;

        #endregion

        #region Unity Messages

        private void OnValidate()
        {
            if (_textUGUI.NotNull())
                _textUGUI.text = _text;
        }

        private void Start() => _dismissButton.onClick.AddListener(() => gameObject.SetActive(false));

        #endregion
    }
}