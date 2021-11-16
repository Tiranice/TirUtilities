using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace TirUtilities.LevelManagment
{
    using TirUtilities.LevelManagment.Experimental;
    using TirUtilities.Extensions;
    using TirUtilities.Signals;
    ///<!--
    /// LevelSystem.cs
    /// 
    /// Project:  TirUtilities
    ///        
    /// Author :  Devon Wilson
    /// Created:  May 05, 2021
    /// Updated:  Sep 22, 2021
    /// -->
    /// <summary>
    /// Handles the loading of <see cref="LevelData"/> emitted from <see cref="LevelLoadSignal"/>
    /// assets.
    /// </summary>
    public class LevelSystem : MonoBehaviour
    {
        #region Singleton Instance

        private static LevelSystem _Instance;
        private static readonly object _Lock = new object();

        #endregion

        #region Inspector Fields

        [Header("Initialization")]
        [Tooltip("The root level data will be loaded on awake if this is checked."), SerializeField]
        private bool _shouldLoadRootOnAwake = false;
        [Tooltip("This should contain all of the scenes needed when the game first starts."), SerializeField]
        private LevelData _rootLevelData;

        [Header("Loading Screen")]
        [Tooltip("The loading screen that will fade in and out as loading starts and completes."), SerializeField]
        private LoadingScreen _loadingScreen;

        #endregion

        #region Events & Signals

        [Header("Signals")]
        [Tooltip("Emit one to load its level data.\nLoaded from the resources folder."), SerializeField]
        private List<LevelLoadSignal> _levelLoadSignals;
        [Tooltip("Emitted when the level loader finishes."), SerializeField]
        private Signal _loadCompleteSignal;

        #endregion

        #region Unity Messages

        private void Awake() => Wakeup();

        private void OnDestroy() => Teardown();

        #endregion

        #region Setup & Teardown

        /// <summary>
        /// Runs setup that must occur at awake time.
        /// <list type="bullet">
        ///     <item> Assigns receivers to the level load signals. </item>
        ///     <item> Loads the root level data if needed. </item>
        ///     <item> Sends this game object to DontDestroyOnLoad. </item>
        /// </list>
        /// </summary>
        private void Wakeup()
        {
            lock (_Lock)
            {
                if (_Instance == null)
                {
                    SetupInstance();
                    return;
                }
                Destroy(gameObject);
            }

            void SetupInstance()
            {
                _Instance = this;
                DontDestroyOnLoad(gameObject);

                _levelLoadSignals = Resources.FindObjectsOfTypeAll<LevelLoadSignal>().ToList();

                foreach (var signal in _levelLoadSignals)
                    signal.AddReceiver(LevelLoadSignalReceicer);

                if (_shouldLoadRootOnAwake)
                    StartCoroutine(LevelLoader.LoadLevelDataAsync(_rootLevelData));

                LevelLoader.OnLoadComplete += OnLoadComplete__EmitSignal;
            }
        }

        /// <summary> Removes event listeners and signal receivers. </summary>
        private void Teardown()
        {
            foreach (var signal in _levelLoadSignals)
                signal.RemoveReceiver(LevelLoadSignalReceicer);

            LevelLoader.OnLoadComplete -= OnLoadComplete__EmitSignal;
        }

        #endregion

        #region Listeners & Receivers

        /// <summary> 
        /// Hides the loading screen and emits the <see cref="_loadCompleteSignal"/>.
        /// </summary>
        private void OnLoadComplete__EmitSignal()
        {
            if (_loadingScreen.NotNull())
                StartCoroutine(_loadingScreen.Hide());

            if (_loadCompleteSignal.NotNull())
                _loadCompleteSignal.Emit();
        }

        /// <summary>
        /// Shows the loading screen and loads the passed level data.
        /// </summary>
        /// <param name="levelData"> The scenes to be loaded. </param>
        private void LevelLoadSignalReceicer(LevelData levelData)
        {
            if (_loadingScreen.NotNull())
                StartCoroutine(_loadingScreen.Show(LevelLoader.LoadLevelDataAsync(levelData)));
            else
                StartCoroutine(LevelLoader.LoadLevelDataAsync(levelData));
        }

        #endregion

        #region Public Properties

        public static LevelSystem Instance => _Instance;

        public IReadOnlyList<LevelLoadSignal> LevelLoadSignals => _levelLoadSignals;

        #endregion

        #region Editor
#if UNITY_EDITOR
        // Fetch all of the level load signals in the resources folder.
        private void OnValidate() => 
            _levelLoadSignals = Resources.FindObjectsOfTypeAll<LevelLoadSignal>().ToList();
#endif
        #endregion
    }
}