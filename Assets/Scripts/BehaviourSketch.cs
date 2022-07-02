using TirUtilities.Generics;

using UnityEngine;

public class BehaviourSketch : MonoBehaviour
{
}

[ResourceSingleton("Singletons/Example Singleton")]
public class ExampleSingleton : MonoSingleton<ExampleSingleton>
{
    public void DoStuff()
    {
        //  Does stuff
    }
}

public class StuffDoer : MonoBehaviour
{
    private void Awake()
    {
        ExampleSingleton.Instance.DoStuff();
    }
}
