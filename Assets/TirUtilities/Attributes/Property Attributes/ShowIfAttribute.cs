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
    /// ShowIfAttribute.cs
    ///
    /// Project:  TirUtilities
    ///
    /// Author :  Devon Wilson
    /// Company:  Black Phoenix Creative
    /// Created:  Nov 02, 2021
    /// Updated:  Mar 03, 2022
    /// -->
    /// <summary>
    /// Shows the decorated field if the named member enum or bool is equal to the given target.
    /// </summary>
    /// <example>
    /// <code>
    ///     [System.Serializable]
    ///     public enum RouteType { LevelSignal, Application, MenuState, }
    ///
    ///     [SerializeField]
    ///     private RouteType _routeType = RouteType.LevelSignal;
    ///
    ///     [SerializeField, ShowIf(nameof(_routeType), RouteType.LevelSignal)]
    ///     private LevelLoadSignal _targetLevel;
    /// </code>
    /// </example>
    [System.AttributeUsage(System.AttributeTargets.Field, Inherited = false, AllowMultiple = true)]
    public sealed class ShowIfAttribute : PropertyAttribute
    {
        public string TargetName { get; }
        public object TargetValue { get; }

        public ShowIfAttribute(string targetName) => TargetName = targetName;

        public ShowIfAttribute(string targetName, object targetValue) : this(targetName) =>
            TargetValue = targetValue;

        public ShowIfAttribute(string targetName, bool targetValue) : this(targetName) =>
            TargetValue = targetValue;
    }
}