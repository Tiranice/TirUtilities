using UnityEngine;

namespace TirUtilities.Extensions
{
    ///<!--
    /// RigidbodyExtensions.cs
    /// 
    /// Project:  TirUtilities
    ///        
    /// Author :  Devon Wilson
    /// Created:  April 20, 2021
    /// Updated:  June 18, 2021
    /// -->
    /// <summary>
    /// Extension methods for Unity rigidbodies.
    /// </summary>
    public static class RigidbodyExtensions
    {
        /// <summary> Set velocity and angular velocity to zero. </summary>
        /// <param name="rigidbody">This rigidbody.</param>
        public static void CancelAllVelocity(this Rigidbody rigidbody)
        {
            rigidbody.velocity = Vector3.zero;
            rigidbody.angularVelocity = Vector3.zero;
        }
    }
}