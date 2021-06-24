using System.Collections.Generic;
using System.Linq;
using TirUtilities.Extensions;
using TirUtilities.Signals;
using UnityEngine;
using UnityEngine.UI;

namespace TirUtilities.LevelManagment
{
    ///<!--
    /// LevelSystem.cs
    /// 
    /// Project:  TirUtilities
    ///        
    /// Author :  Devon Wilson
    /// Created:  May 05, 2021
    /// Updated:  May 15, 2021
    /// -->
    /// <summary>
    ///
    /// </summary>
    public class LevelSystem : MonoBehaviour
    {
        #region Singleton Instance

        private static LevelSystem _Instance;
        private static readonly object _Lock = new object();

        #endregion

        #region Inspector Fields

        [Header("Initialization")]
        [Tooltip("This should contain all of the scenes needed when the game first starts.")]
        [SerializeField] private LevelData _rootLevelData;

        [Header("Loading Screen")]
        [Tooltip("This should be a child image that is faded in an out by the level loader.")]
        [SerializeField] private Image _loadingScreen;

        #endregion

        #region Private Fields

        private bool _isLoading = false;

        #endregion

        #region Events & Signals

        [Header("Signals")]
        [SerializeField] private List<LevelLoadSignal> _levelLoadSignals;
        [SerializeField] private Signal _loadCompleteSignal;

        #endregion

        #region Unity Messages

        private void Awake() => Wakeup();

        private void Update() => UpdateLoadingScreen();

        private void OnDestroy() => Teardown();

        #endregion

        #region Setup & Teardown

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

                StartCoroutine(LevelLoader.LoadLevelDataAsync(_rootLevelData));

                LevelLoader.OnLoadComplete += OnLoadComplete__EmitSignal;
            }
        }


        private void Teardown()
        {
            foreach (var signal in _levelLoadSignals)
                signal.RemoveReceiver(LevelLoadSignalReceicer);
        }

        #endregion

        #region Private Methods

        private void UpdateLoadingScreen()
        {
            if (_isLoading)
                _loadingScreen.color = Color.Lerp(_loadingScreen.color, Color.black, Time.deltaTime);
            else
                _loadingScreen.color = Color.Lerp(_loadingScreen.color, Color.clear, Time.deltaTime);
        }

        #endregion

        #region Listeners & Receivers

        private void OnLoadComplete__EmitSignal()
        {
            _isLoading = false;
            if (_loadCompleteSignal.NotNull())
                _loadCompleteSignal.Emit();
        }

        private void LevelLoadSignalReceicer(LevelData levelData) => 
            StartCoroutine(LevelLoader.LoadLevelDataAsync(levelData));

        #endregion

        #region Editor
#if UNITY_EDITOR
        private void OnValidate()
        {
            _levelLoadSignals = Resources.FindObjectsOfTypeAll<LevelLoadSignal>().ToList();
        }
#endif
        #endregion
    }
}