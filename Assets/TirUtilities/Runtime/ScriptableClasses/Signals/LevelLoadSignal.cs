using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

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
    /// Updated:  Sep 22, 2021
    /// -->
    /// <summary> Signal that emits a copy of a <see cref="LevelData"/> value. </summary>
    [CreateAssetMenu(menuName = "Signals/Level Load Signal", order = 21)]
    public class LevelLoadSignal : SignalBase, ISignal<LevelData>
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
        public IReadOnlyList<string> AdditiveScenes => _levelData.AdditiveScenes;

        #endregion

        #region Actions

        /// <summary> Invoked in <see cref="Emit(LevelData)"/>, calling receivers. </summary>
        [SerializeField] protected UnityAction<LevelData> _OnEmit;

        #endregion

        #region Public Methods

        /// <summary>
        /// Register a callback function to be invoked when <see cref="Emit(LevelData)"/> is called.
        /// </summary>
        /// <param name="receiver">The callback to be invoked.</param>
        public virtual void AddReceiver(UnityAction<LevelData> receiver) => _OnEmit += receiver;

        /// <summary> Unregister a callback function. </summary>
        /// <param name="receiver">The callback function.</param>
        public virtual void RemoveReceiver(UnityAction<LevelData> receiver) => _OnEmit -= receiver;

        /// <summary>
        /// Emit this signal to all receivers, calling methods registered with 
        /// <see cref="AddReceiver(UnityAction{LevelData})"/>.
        /// </summary>
        /// <remarks>
        /// Emits <see cref="_levelData"/>.
        /// </remarks>
        public virtual void Emit() => _OnEmit.SafeInvoke(_levelData);

        /// <summary>
        /// Emit this signal to all receivers, calling methods registered with 
        /// <see cref="AddReceiver(UnityAction{LevelData})"/>.
        /// </summary>
        /// <remarks>
        /// Emits the passed level data.  Prefer use of <see cref="Emit"/>.
        /// </remarks>
        public virtual void Emit(LevelData levelData) => _OnEmit.SafeInvoke(levelData);

        #endregion

        #region Editor
#if UNITY_EDITOR
        /// <summary>
        /// EDITOR ONLY!!!  Prompts the user to save changes, then loads the level data.
        /// </summary>
        [ContextMenu(nameof(LoadLevelData))]
        public void LoadLevelData()
        {
            if (ActiveScene == string.Empty || ActiveScene == null) return;

            EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
            EditorSceneManager.OpenScene(_levelData.ActiveScene);
            foreach (var scene in _levelData.AdditiveScenes)
                EditorSceneManager.OpenScene(scene, OpenSceneMode.Additive);
        }
#endif
        #endregion
    }
}
