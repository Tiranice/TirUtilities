using System.Collections.Generic;

using UnityEngine;

namespace TirUtilities.Core
{
    ///<!--
    /// Destructor.cs
    /// 
    /// Project:  TirUtilities
    ///        
    /// Author :  Devon Wilson
    /// Company:  Black Phoenix Software
    /// Created:  Jul 02, 2022
    /// Updated:  Jul 02, 2022
    /// -->
    /// <summary>
    /// Deactivates its target game objects on the given unity message.
    /// </summary>
    [AddComponentMenu("TirUtilities/Core/Deactivator")]
    public class Deactivator : MonoBehaviour
    {
        [System.Serializable]
        private enum TargetMessage { Awake, Start, OnEnable, }

        [SerializeField] private TargetMessage _targetMessage;
        [Space]
        [SerializeField] private List<GameObject> _targets;
        [Space]
        [SerializeField] private bool _destroyInBuilds = false;

        private void Awake()
        {
            if (_targetMessage is TargetMessage.Awake)
                Deactivate();
        }

        private void Start()
        {
            if (_targetMessage is TargetMessage.Start)
                Deactivate();
        }

        private void OnEnable()
        {
            if (_targetMessage is TargetMessage.OnEnable)
                Deactivate();
        }

        [ContextMenu(nameof(Deactivate))]
        public void Deactivate()
        {
            if (_destroyInBuilds && !Application.isEditor)
            {
                _targets?.ForEach(t => Destroy(t));
                return;
            }
            _targets?.ForEach(t => t.SetActive(false));
        }

        /// <summary>
        /// For use with <c>TriggerVolume</c>.
        /// </summary>
        /// <param name="_"></param>
        /// <param name="target"></param>
        public void DeactivateTarget(bool _, GameObject target) => target.SetActive(false);
    }
}