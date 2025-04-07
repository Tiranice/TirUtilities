using System.Collections.Generic;
using System.Linq;

using UnityEngine;

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

namespace TirUtilities.LevelManagement
{
    using TirUtilities.Extensions;
    using TirUtilities.Generics;
    using TirUtilities.LevelManagement.Experimental;
    using TirUtilities.Signals;

    ///<!--
    /// LevelSystem.cs
    ///
    /// Project:  TirUtilities
    ///
    /// Author :  Devon Wilson
    /// Company:  Black Phoenix Creative
    /// Created:  May 05, 2021
    /// Updated:  Feb 22, 2024
    /// -->
    /// <summary>
    /// Handles the loading of <see cref="LevelData"/> emitted from <see cref="LevelLoadSignal"/>
    /// assets.
    /// </summary>
    public class LevelSystem : MonoSingleton<LevelSystem>
    {
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
        public IReadOnlyList<LevelLoadSignal> LevelLoadSignals => _levelLoadSignals;


        [Tooltip("Emitted when the level loader finishes."), SerializeField]
        private Signal _loadCompleteSignal;

        [SerializeField] private LevelLoadSignal _mainMenuLoadSignal;

        [SerializeField, DisplayOnly] private LevelLoadSignal _lastSignalEmitted;
        public LevelLoadSignal LastSignalEmitted => _lastSignalEmitted;

        #endregion

        #region Unity Messages

        private void Awake() => Wakeup();

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
            _levelLoadSignals = Resources.FindObjectsOfTypeAll<LevelLoadSignal>().ToList();

            foreach (var signal in _levelLoadSignals)
                signal.AddReceiver(LevelLoadSignalReceiver);

            if (_shouldLoadRootOnAwake)
                StartCoroutine(LevelLoader.LoadLevelDataAsync(_rootLevelData));

            LevelLoader.OnLoadComplete += OnLoadComplete__EmitSignal;
        }

        /// <summary> Removes event listeners and signal receivers. </summary>
        protected override void Teardown()
        {
            foreach (var signal in _levelLoadSignals)
                signal.RemoveReceiver(LevelLoadSignalReceiver);

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
        private void LevelLoadSignalReceiver(LevelData levelData)
        {
            _lastSignalEmitted = _levelLoadSignals.First(s => s.LevelDataEquals(levelData));

            if (_loadingScreen.NotNull())
                StartCoroutine(_loadingScreen.Show(LevelLoader.LoadLevelDataAsync(levelData)));
            else
                StartCoroutine(LevelLoader.LoadLevelDataAsync(levelData));
        }

        #endregion

        #region Load Methods

        /// <summary> Emits the main menu load signal if one is assigned. </summary>
        /// <returns><c>false</c> if the main menu load signal is null.  Otherwise <c>true</c>.</returns>
        public bool TryLoadMainMenu()
        {
            if (_mainMenuLoadSignal.IsNull()) return false;

            _mainMenuLoadSignal.Emit();
            return true;
        }

        /// <summary> Reemits <c>_lastSignalEmitted</c>. </summary>
        public void ReloadLastLevel()
        {
            if (_lastSignalEmitted.NotNull())
                _lastSignalEmitted.Emit();
        }

        #endregion

        public bool MainMenuIsLoaded => _mainMenuLoadSignal.ActiveSceneIsLoaded;

        #region Editor
#if UNITY_EDITOR
        // Fetch all of the level load signals in the resources folder.
        private void OnValidate() =>
            _levelLoadSignals = Resources.FindObjectsOfTypeAll<LevelLoadSignal>().ToList();
#endif
        #endregion
    }
}