using System;
using UnityEngine;

namespace TirUtilities
{
    ///<!--
    /// ShowIfAttribute.cs
    /// 
    /// Project:  TirUtilities
    ///        
    /// Author :  Devon Wilson
    /// Company:  Black Phoenix Software
    /// Created:  Nov 02, 2021
    /// Updated:  Nov 02, 2021
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
    [AttributeUsage(AttributeTargets.Field)]
    public class ShowIfAttribute : PropertyAttribute
    {
        public string TargetName { get; }
        public object TargetValue { get; }

        private ShowIfAttribute(string targetName) => TargetName = targetName;

        public ShowIfAttribute(string targetName, object targetValue) : this(targetName) =>
            TargetValue = targetValue;

        public ShowIfAttribute(string targetName, bool targetValue) : this(targetName) =>
            TargetValue = targetValue;

    }
}