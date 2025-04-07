using System.Collections;
using System.Collections.Generic;
using System.Linq;

using NUnit.Framework;

using UnityEditor;
using UnityEditor.SceneManagement;

using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.SearchService;
using UnityEngine.TestTools;

using UnityEngineInternal;

namespace TirUtilities.Runtime.Tests
{
    using TirUtilities.LevelManagement;
    using TirUtilities.Signals;
    public class LevelManagementTestSuite
    {
        protected static LevelLoadSignal _levelLoadSignal;

        protected static readonly string _SignalName = "Level Management Load Signal";
        protected static readonly string _ActiveScene = "Assets/Tests/Test Resources/Scenes/Level Management Test.unity";
        protected static readonly string _AdditiveScene = "Assets/Tests/Test Resources/Scenes/Level Management Test 1.unity";

        protected static readonly LevelData _DummyLevelData = new LevelData("Dummy Active");
        protected static readonly LevelData _DummyAdditiveLevelData = 
            new LevelData("Dummy Active", new List<string> {"Additive 1", "Additive 2" });

        protected class LevelDataTests
        {
            [Test]
            public void _00_AdditiveSceneEqualityIsCorrect()
            {
                Assert.That(_DummyAdditiveLevelData.Equals(_DummyLevelData), Is.False);
                Assert.That(_DummyAdditiveLevelData.Equals(_DummyAdditiveLevelData), Is.True);
#pragma warning disable CS1718 // Comparison made to same variable
                Assert.That(_DummyAdditiveLevelData == _DummyAdditiveLevelData, Is.True);
#pragma warning restore CS1718 // Comparison made to same variable
                Assert.That(_DummyAdditiveLevelData != _DummyLevelData, Is.True);
            }
        }

        protected class LevelLoadSignalTests
        {
            #region Tests

            [Test]
            public void _00_SignalExists()
            {
                _levelLoadSignal = TestUtilities.LoadScriptableObject<LevelLoadSignal>(_SignalName);
                Assert.NotNull(_levelLoadSignal);
            }

            [Test]
            public void _01_ActiveSceneIsCorrect()
            {
                Assert.That(_levelLoadSignal.ActiveScene, Is.EqualTo(_ActiveScene));
            }

            [Test]
            public void _02_AdditiveSceneIsCorrect()
            {
                Assert.That(_levelLoadSignal.AdditiveScenes.Count, Is.EqualTo(1));
                Assert.That(_levelLoadSignal.AdditiveScenes[0], Is.EqualTo(_AdditiveScene));
            }

            [Test]
            public void _03_CanRegisterReceivers()
            {
                _levelLoadSignal.AddReceiver(PassReceiver);
                _levelLoadSignal.Emit();
                _levelLoadSignal.RemoveReceiver(PassReceiver);
            }

            [Test]
            public void _04_CanUnregisterReceivers()
            {
                _levelLoadSignal.AddReceiver(FailReceiver);
                _levelLoadSignal.RemoveReceiver(FailReceiver);
                _levelLoadSignal.Emit();
            }

            [Test]
            public void _05_CanEmitCustomDataReceivers()
            {
                _levelLoadSignal.AddReceiver(CustomDataReceiver);
                _levelLoadSignal.Emit(_DummyLevelData);
                _levelLoadSignal.RemoveReceiver(CustomDataReceiver);
            }

            #endregion

            private void PassReceiver(LevelData data) => Assert.That(data.ActiveScene, Is.EqualTo(_levelLoadSignal.ActiveScene));

            private void FailReceiver(LevelData _) => Assert.Fail();

            private void CustomDataReceiver(LevelData data) => Assert.That(data.Equals(_DummyLevelData));
        }
    
        protected class LevelLoaderTests
        {
            [UnityTest]
            public IEnumerator _00_CanLoadSceneFromLevelData()
            {
                yield return LevelLoader.LoadLevelDataAsync(new LevelData(_ActiveScene));

                Assert.That(SceneManager.GetActiveScene().path, Is.EqualTo(_ActiveScene));
            }

            [UnityTest]
            public IEnumerator _01_CanLoadMultipleScenesFromLevelData()
            {
                var levelData = new LevelData(_ActiveScene, new List<string>() { _AdditiveScene });
                yield return LevelLoader.LoadLevelDataAsync(levelData);

                Assert.That(SceneManager.sceneCount, Is.EqualTo(levelData.SceneCount));
                Assert.That(SceneManager.GetActiveScene().path, Is.EqualTo(_ActiveScene));
                Assert.That(SceneManager.GetSceneAt(1).path, Is.EqualTo(_AdditiveScene));
            }

            [UnityTest]
            public IEnumerator _02_OnLoadCompleteIsCalledWhenScenesAreLoaded()
            {
                var levelData = new LevelData(_ActiveScene, new List<string>() { _AdditiveScene });
                LevelLoader.OnLoadComplete += LevelLoader_OnLoadComplete;

                yield return LevelLoader.LoadLevelDataAsync(levelData);

                LevelLoader.OnLoadComplete -= LevelLoader_OnLoadComplete;
            }

            private void LevelLoader_OnLoadComplete()
            {
                Assert.That(SceneManager.GetActiveScene().path, Is.EqualTo(_ActiveScene));
                Assert.That(SceneManager.GetSceneAt(1).path, Is.EqualTo(_AdditiveScene));
            }
        }
    
        protected class LevelSystemTests
        {
            [Test]
            public void _00_SuccessfullyGetsLevelLoadSignals()
            {
                var signals = Resources.FindObjectsOfTypeAll<LevelLoadSignal>().ToList();

                Assert.That(LevelSystem.Instance.LevelLoadSignals.Count, Is.EqualTo(signals.Count));

                for (int i = 0; i < signals.Count; i++)
                {
                    Assert.That(LevelSystem.Instance.LevelLoadSignals[i], Is.EqualTo(signals[i]));
                }
            }
        }
    }
}
