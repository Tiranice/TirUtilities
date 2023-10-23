using NUnit.Framework;

using UnityEditor;

using UnityEngine;
using UnityEngine.TestTools;

namespace TirUtilities.Runtime.Tests
{
    using TirUtilities.Generics;
    using static UnityEngine.GraphicsBuffer;

    public class GenericsTestSuite
    {
        protected class MonoSingletonTests
        {
            [Test]
            public void _00_CreatesNewGameObjectWhenNoneExists() => 
                Assert.That(TestSingleton.Instance, Is.Not.Null);
            [Test]
            public void _01_ResourceSingletonWithBadPathPausesExecution()
            {
                LogAssert.Expect(
                    LogType.Error,
                    $"The Resource Singleton {typeof(BadPathSingleton)} was not found in any resources folder!");
                Assert.That(BadPathSingleton.Instance, Is.Null);
                Assert.That(EditorApplication.isPaused, Is.True);
                EditorApplication.isPaused = false;
            }

            [Test]
            public void _02_ResourceSingletonLoadsCorrectly()
            {
                Assert.That(TestResourceSingleton.Instance.gameObject.name, Is.EqualTo($"(Resource Global Singleton) Test Resource Singleton(Clone)"));
            }

            public class TestSingleton : MonoSingleton<TestSingleton> { }

            [ResourceSingleton("Bad Path")]
            public class BadPathSingleton : MonoSingleton<BadPathSingleton> { }
        }
    }
}
