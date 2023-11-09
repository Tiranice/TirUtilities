using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace TirUtilities.UI
{
    ///<!--
    /// TabButton.cs
    /// 
    /// Project:  TirUtilities
    /// 
    /// Author :  Devon Wilson  
    /// Created:  Oct. 08, 2020
    /// Updated:  Feb. 22, 2021
    /// -->
    /// <summary>
    /// Derived from code written by Matt Gambell https://youtu.be/211t6r12XPQ
    /// 
    /// Contains all of the pointer event logic.
    /// </summary>
    [RequireComponent(typeof(Image))]
    public class TabButton : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler, IPointerExitHandler
    {
        #region Inspector Field

        [SerializeField] private TabGroup _tabGroup;
        public Image Background { get; private set; }

        #endregion

        #region EVENTS

        public UnityEvent onTabSelected;
        public UnityEvent onTabDeselected;

        #endregion

        #region UNITY_MESSAGES

        private void Start()
        {
            Background = GetComponent<Image>();
            _tabGroup.Subscribe(this);
        }

        #endregion UNITY_MESSAGES

        #region POINTER_EVENTS

        public void OnPointerEnter(PointerEventData eventData) => _tabGroup.OnTabEnter(this);

        public void OnPointerClick(PointerEventData eventData) => _tabGroup.OnTabSelected(this);

        public void OnPointerExit(PointerEventData eventData) => _tabGroup.OnTabExit();

        #endregion

        #region CALLBACKS

        /// <summary>
        /// Invokes onTabSelected.
        /// </summary>
        public void Select() => onTabSelected.Invoke();

        /// <summary>
        /// Invokes onTabDeselected.
        /// </summary>
        public void Deselect() => onTabDeselected.Invoke();

        #endregion
    }
}