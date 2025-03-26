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