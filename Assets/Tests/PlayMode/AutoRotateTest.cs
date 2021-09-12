using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using TirUtilities.Automation;
using UnityEngine;
using UnityEngine.TestTools;

namespace TirUtilities.Runtime.Tests
{
    public class AutoRotateTest
    {
        private GameObject _gameObject;
        private AutoRotate _autoRotate;

        [UnityTest]
        public IEnumerator _01_ShouldStartToggledOn()
        {
            _gameObject = new GameObject();
            _autoRotate = _gameObject.AddComponent<AutoRotate>();

            yield return new WaitForEndOfFrame();

            Assert.IsTrue(_autoRotate.IsRotating);
        }

        [UnityTest]
        public IEnumerator _02_ShouldNotRotateWhenRotationIsToggledOff()
        {
            _autoRotate.SetIsRotating(false);

            var rot = _gameObject.transform.rotation;

            yield return new WaitForSeconds(2.0f);

            Assert.AreEqual(rot, _gameObject.transform.rotation);
        }


        [UnityTearDown]
        public void AutoRotateTearDown()
        {
            Object.DestroyImmediate(_autoRotate);
            Object.DestroyImmediate(_gameObject);
        }
    }
}
