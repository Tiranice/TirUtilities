using UnityEngine;
using UnityEngine.Events;

#if UNITY_EDITOR
using UnityEditor.SceneManagement;
#endif

namespace TirUtilities.Signals
{
    using TirUtilities.Extensions;
    using TirUtilities.LevelManagment;

    ///<!--
    /// LevelLoadSignal.cs
    /// 
    /// Project:  TirUtilities
    /// 
    /// Author :  Devon Wilson
    /// Created:  May 05, 2021
    /// Updated:  Sep. 01, 2021
    /// -->
    /// <summary>
    /// Signal that emits a copy of a <see cref="LevelData"/> value.
    /// </summary>
    [CreateAssetMenu(menuName = "Signals/Level Load Signal")]
    public class LevelLoadSignal : SignalBase
    {
        #region Inspector Fields

        /// <summary>
        /// The scenes that will be loaded when the signal is emitted.
        /// </summary>
        [Tooltip("The scenes that will be loaded when the signal is emitted.")]
        [SerializeField] private LevelData _levelData;

        #endregion

        #region Public Properties

        public string ActiveScene => _levelData.ActiveScene;

        #endregion

        #region Actions

        /// <summary>
        /// Invoked in <see cref="Emit">Emit</see>, calling receivers.
        /// </summary>
        [SerializeField] private UnityAction<LevelData> _OnEmit;

        #endregion

        #region Public Methods

        /// <summary>
        /// Register a callback function to be invoked when this signal is <see cref="Emit">Emitted</see>.
        /// </summary>
        /// <param name="receiver">The callback to be invoked.</param>
        public virtual void AddReceiver(UnityAction<LevelData> receiver) => _OnEmit += receiver;

        /// <summary>
        /// Unregister a callback function.
        /// </summary>
        /// <param name="receiver">The callback function.</param>
        public virtual void RemoveReceiver(UnityAction<LevelData> receiver) => _OnEmit -= receiver;

        /// <summary>
        /// Emit this signal to all receivers, calling their 
        /// <see cref="AddReceiver(UnityAction{LevelData})">Registered Callbacks</see>.
        /// </summary>
        public virtual void Emit() => _OnEmit.SafeInvoke(_levelData);

        #endregion

        #region Editor
#if UNITY_EDITOR
        /// <summary>
        /// EDITOR ONLY!!!  Prompts the user to save changes, then loads the level data.
        /// </summary>
        [ContextMenu(nameof(LoadLevelData))]
        public void LoadLevelData()
        {
            EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
            EditorSceneManager.OpenScene(_levelData.ActiveScene);
            foreach (var scene in _levelData.AdditiveScenes)
                EditorSceneManager.OpenScene(scene, OpenSceneMode.Additive);
        }
#endif
        #endregion
    }
}
