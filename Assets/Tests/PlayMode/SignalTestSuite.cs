using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using TirUtilities.Signals;
using UnityEngine;
using UnityEngine.TestTools;

namespace TirUtilities.Runtime.Tests
{
    public class SignalTestSuite
    {
        public class BaseSignalTests
        {
            [UnityTest]
            public IEnumerator _01_DescriptionIsEmptyAndAccessableByDefault()
            {
                var inst = ScriptableObject.CreateInstance<Signal>();

                yield return new WaitForEndOfFrame();

                Assert.IsTrue(inst.Description == string.Empty);
                Object.DestroyImmediate(inst);
            }
        }

        public class SignalTests
        {
            [UnityTest]
            public IEnumerator _01_AddReceiverCorrectlyAddsAnAction()
            {
                var inst = ScriptableObject.CreateInstance<Signal>();

                void Pass() => Assert.Pass();

                inst.AddReceiver(Pass);

                yield return new WaitForEndOfFrame();

                inst.Emit();

                Object.DestroyImmediate(inst);
            }

            [UnityTest]
            public IEnumerator _02_RemoveReceiverCorrectlyRemovesTheGivenAction()
            {
                var inst = ScriptableObject.CreateInstance<Signal>();

                void Fail() => Assert.Fail();

                inst.AddReceiver(Fail);
                inst.RemoveReceiver(Fail);

                yield return new WaitForEndOfFrame();

                inst.Emit();

                Assert.Pass();

                Object.DestroyImmediate(inst);
            }
        }

        public class BoolSignalTests
        {
            [UnityTest]
            public IEnumerator _01_AddReceiverCorrectlyAddsAnAction()
            {
                var inst = ScriptableObject.CreateInstance<BoolSignal>();

                void Pass(bool val) => Assert.IsTrue(val);

                inst.AddReceiver(Pass);

                yield return new WaitForEndOfFrame();

                inst.Emit(true);

                Object.DestroyImmediate(inst);
            }

            [UnityTest]
            public IEnumerator _02_RemoveReceiverCorrectlyRemovesTheGivenAction()
            {
                var inst = ScriptableObject.CreateInstance<BoolSignal>();

                void Fail(bool val) => Assert.Fail();

                inst.AddReceiver(Fail);
                inst.RemoveReceiver(Fail);

                yield return new WaitForEndOfFrame();

                inst.Emit(false);

                Assert.Pass();

                Object.DestroyImmediate(inst);
            }
        }

    }
}
