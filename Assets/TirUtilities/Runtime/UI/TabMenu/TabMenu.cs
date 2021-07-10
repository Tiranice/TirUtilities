using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TirUtilities.Signals;
using UnityEngine;
using UnityEngine.UI;

namespace TirUtilities.UI.Experimental
{
    ///<!--
    /// TabMenu.cs
    /// 
    /// Project:  TirUtilities
    ///        
    /// Author :  Devon Wilson
    /// Created:  July 03, 2021
    /// Updated:  July 03, 2021
    /// -->
    /// <summary>
    ///
    /// </summary>
    public class TabMenu : MonoBehaviour
    {
        #region Data Structures

        #endregion

        #region Inspector Fields

        [SerializeField] private GameObject _tabPanel;
        [DisplayOnly, SerializeField]
        private List<Button> _tabButtons;

        #endregion

        #region Events & Signals

        [SerializeField] private GameObjectSignal _gameObjectSignal;

        #endregion

        #region Unity Messages

        private void OnValidate()
        {
            _tabButtons = _tabPanel.GetComponentsInChildren<Button>().Where(button => button.CompareTag("GameController")).ToList();
            _tabButtons.Sort((i, j) => i.transform.GetSiblingIndex().CompareTo(j.transform.GetSiblingIndex()));
        }

        private void Start() => _gameObjectSignal.AddReceiver(ChangeTab);

        private void OnDestroy() => _gameObjectSignal.RemoveReceiver(ChangeTab);

        #endregion
    
        #region Private Methods
    
        private void ChangeTab(GameObject target)
        {
            foreach (var button in _tabButtons) button.transform.GetChild(1).gameObject.SetActive(false);
            target.SetActive(true);
        }

        #endregion

        #region Public Methods

        #endregion

        #region Private Properties

        #endregion

        #region Public Properties

        #endregion
    }
}