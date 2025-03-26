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

namespace TirUtilities
{
    ///<!--
    /// DisplayOnlyAttribute.cs
    ///
    /// Project:  TirUtilities
    ///
    /// Author :  Devon Wilson
    /// Company:  Black Phoenix Creative
    /// Created:  Mar. 31, 2021
    /// Updated:  Mar. 31, 2021
    /// -->
    /// <summary>
    /// The decorated field is be displayed in the inspector, but cannot be edited.
    /// </summary>
    /// <remarks>
    /// Property drawer:  TirUtilities/Editor/PropertyDrawers/DisplayOnlyDrawer.cs
    /// </remarks>
    public class DisplayOnlyAttribute : PropertyAttribute { }
}
