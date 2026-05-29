using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

///<!--
///     Copyright (C) 2026  Devon Wilson
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
///     You should have received a copy of the GNU Lesser General Public License
///     along with this program.  If not, see <https://www.gnu.org/licenses/>.
///-->

namespace TirUtilities.Editor
{
    ///<!--
    /// URLMenuItems.cs
    /// 
    /// Project:  TirUtilities
    /// 
    /// Author :  AuthorName
    /// Company:  Black Phoenix Creative
    /// Created:  May 27, 2026
    /// Updated:  May 27, 2026
    /// -->
    /// <summary>
    /// 
    /// </summary>
    internal class URLMenuItems : EditorWindow
    {
        private const string _RootPath = "Tools/TirUtilities/Help/";

        [MenuItem(_RootPath + "GitHub")]
        internal static void LinkToGitHub() => Application.OpenURL("https://github.com/Tiranice/TirUtilities");


        [MenuItem(_RootPath + "Documentation")]
        internal static void LinkToDocumentation() => Application.OpenURL("https://tiranice.github.io/TirUtilities/");
    }
}