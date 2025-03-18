using System.Collections.Generic;
using System.IO;

using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor.SceneManagement;
#endif

namespace TirUtilities.Signals
{
    using TirUtilities.Extensions;
    using TirUtilities.LevelManagement;

    ///<!--
    /// LevelLoadSignal.cs
    /// 
    /// Project:  TirUtilities
    /// 
    /// Author :  Devon Wilson
    /// Company:  Black Phoenix Creative
    /// Created:  May 05, 2021
    /// Updated:  Feb 22, 2024
    /// -->
    /// <summary> Signal that emits a copy of a <see cref="LevelData"/> value. </summary>
    [CreateAssetMenu(menuName = "Signals/Level Load Signal", order = 60)]
    public class LevelLoadSignal : SignalBase<LevelData>, ISignal<LevelData>
    {
        #region Inspector Fields

        /// <summary>
        /// The scenes that will be loaded when the signal is emitted.
        /// </summary>
        [Tooltip("The scenes that will be loaded when the signal is emitted.")]
        [SerializeField] private LevelData _levelData;
        public LevelData GetLevelData => _levelData;

        #endregion

        #region Level Data

        public string LevelName => string.IsNullOrWhiteSpace(_levelData.LevelName)
            ? ActiveSceneName : _levelData.LevelName;
        public string ActiveScene => _levelData.ActiveScene;
        public string ActiveSceneName => Path.GetFileNameWithoutExtension(ActiveScene);
        public bool ActiveSceneIsLoaded => SceneManager.GetSceneByPath(ActiveScene).isLoaded;
        public IReadOnlyList<string> AdditiveScenes => _levelData.AdditiveScenes;

        public bool LevelDataEquals(LevelData other) => _levelData.Equals(other);

        #endregion

        #region Signal Methods

        /// <summary>
        /// Register a callback function to be invoked when <see cref="Emit(LevelData)"/> is called.
        /// </summary>
        /// <param name="receiver">The callback to be invoked.</param>
        public override void AddReceiver(UnityAction<LevelData> receiver) => _OnEmit += receiver;

        /// <summary> Unregister a callback function. </summary>
        /// <param name="receiver">The callback function.</param>
        public override void RemoveReceiver(UnityAction<LevelData> receiver) => _OnEmit -= receiver;

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
        public override void Emit(LevelData levelData) => _OnEmit.SafeInvoke(levelData);

        #endregion

        #region Editor
#if UNITY_EDITOR
        /// <summary>
        /// EDITOR ONLY!!!  Prompts the user to save changes, then loads the level data.
        /// </summary>
        [ContextMenu(nameof(LoadLevelData)), UnityEngine.TestTools.ExcludeFromCoverage]
        public void LoadLevelData()
        {
            if (ActiveScene == string.Empty || ActiveScene == null) return;

            if (!EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo()) return;

            EditorSceneManager.OpenScene(_levelData.ActiveScene);
            foreach (var scene in _levelData.AdditiveScenes)
                EditorSceneManager.OpenScene(scene, OpenSceneMode.Additive);
        }
#endif
        #endregion
    }
}
