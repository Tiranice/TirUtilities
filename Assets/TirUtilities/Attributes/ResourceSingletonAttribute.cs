namespace TirUtilities.Generics
{
    ///<!--
    /// ResourceSingletonAttribute.cs
    /// 
    /// Project:  TirUtilities
    ///        
    /// Author :  Devon Wilson
    /// Company:  Black Phoenix Creative
    /// Created:  Apr 19, 2022
    /// Updated:  Apr 19, 2022
    /// -->
    /// <summary>
    /// Use to set the path to the prefab of a <c>MonoSingleton</c>.
    /// </summary>
    /// <example>
    ///     <code>
    ///     // Located at Resources/Singletons/Example Singleton.prefab
    ///     [ResourceSingleton("Singletons/Example Singleton")]
    ///     public class ExampleSingleton : MonoSingleton&lt;ExampleSingleton&gt;
    ///     {
    ///         public void DoStuff()
    ///         {
    ///             //  Does stuff
    ///         }
    ///     }
    ///     
    ///     public class StuffDoer : MonoBehaviour
    ///     {
    ///         private void Awake()
    ///         {
    ///             ExampleSingleton.Instance.DoStuff();
    ///         }
    ///     }
    ///     </code>
    /// </example>
    [System.AttributeUsage(System.AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
    public sealed class ResourceSingletonAttribute : System.Attribute
    {
        public readonly string resourceFilePath;

        public ResourceSingletonAttribute(string path) => resourceFilePath = path;
    }
}