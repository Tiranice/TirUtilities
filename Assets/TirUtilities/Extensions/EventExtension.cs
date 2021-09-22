using UnityEngine.Events;

namespace TirUtilities.Extensions
{
    ///<!--
    /// EventExtension.cs
    /// 
    /// Project:  TirUtilities
    /// 
    /// Author :  Devon Wilson
    /// Created:  Mar 27, 2021
    /// Updated:  Sep 22, 2021
    /// -->
    /// <summary>
    /// A set of extension methods for UnityActions and UnityEvents.
    /// </summary>
    public static class EventExtension
    {
        #region Unity Event

        /// <summary>
        /// Invokes the event if it has listeners.
        /// </summary>
        /// <param name="unityEvent">This event.</param>
        /// <returns>True if the invocation was successful, otherwise false.</returns>
        public static bool SafeInvoke(this UnityEvent unityEvent)
        {
            if (unityEvent.IsNull()) return false;

            unityEvent.Invoke();
            return true;
        }

        /// <summary>
        /// Shorthand for a <c>unityEvent == null</c>.
        /// </summary>
        /// <param name="unityEvent">This event.</param>
        /// <returns>The result of <c>unityEvent == null</c></returns>
        public static bool IsNull(this UnityEvent unityEvent) => unityEvent == null;

        /// <summary>
        /// Shorthand for a <c>unityEvent != null</c>.
        /// </summary>
        /// <param name="unityEvent">This event.</param>
        /// <returns>The result of <c>unityEvent != null</c></returns>
        public static bool NotNull(this UnityEvent unityEvent) => unityEvent != null;

        #endregion

        #region Unity Event <T0>

        /// <summary>
        /// Invokes the event if it has listeners.
        /// </summary>
        /// <param name="unityEvent">This event.</param>
        /// <param name="target">The target to be passed to listeners.</param>
        /// <returns>True if the invocation was successful, otherwise false.</returns>
        public static bool SafeInvoke<T0>(this UnityEvent<T0> unityEvent, T0 target)
        {
            if (unityEvent.IsNull()) return false;

            unityEvent.Invoke(target);
            return true;
        }

        /// <summary>
        /// Shorthand for a <c>unityEvent == null</c>.
        /// </summary>
        /// <param name="unityEvent">This event.</param>
        /// <returns>The result of <c>unityEvent == null</c></returns>
        public static bool IsNull<T0>(this UnityEvent<T0> unityEvent) => unityEvent == null;

        /// <summary>
        /// Shorthand for a <c>unityEvent != null</c>.
        /// </summary>
        /// <param name="unityEvent">This event.</param>
        /// <returns>The result of <c>unityEvent != null</c></returns>
        public static bool NotNull<T0>(this UnityEvent<T0> unityEvent) => unityEvent != null;

        #endregion

        #region Unity Event <T0, T1>

        /// <summary>
        /// Invokes the event if it has listeners.
        /// </summary>
        /// <param name="unityEvent">This event.</param>
        /// <param name="target0">The first target to be passed to listeners.</param>
        /// <param name="target1">The second target to be passed to listeners.</param>
        /// <returns>True if the invocation was successful, otherwise false.</returns>
        public static bool SafeInvoke<T0, T1>(this UnityEvent<T0, T1> unityEvent, T0 target0, T1 target1)
        {
            if (unityEvent.IsNull()) return false;

            unityEvent.Invoke(target0, target1);
            return true;
        }

        /// <summary>
        /// Shorthand for a <c>unityEvent == null</c>.
        /// </summary>
        /// <param name="unityEvent">This event.</param>
        /// <returns>The result of <c>unityEvent == null</c></returns>
        public static bool IsNull<T0, T1>(this UnityEvent<T0, T1> unityEvent) => unityEvent == null;

        /// <summary>
        /// Shorthand for a <c>unityEvent != null</c>.
        /// </summary>
        /// <param name="unityEvent">This event.</param>
        /// <returns>The result of <c>unityEvent != null</c></returns>
        public static bool NotNull<T0, T1>(this UnityEvent<T0, T1> unityEvent) => unityEvent != null;

        #endregion

        #region Unity Action

        /// <summary>
        /// Invokes the action if it has listeners.
        /// </summary>
        /// <param name="action">This event.</param>
        /// <returns>True if the invocation was successful, otherwise false.</returns>
        public static bool SafeInvoke(this UnityAction action)
        {
            if (action.IsNull()) return false;

            action.Invoke();
            return true;
        }

        /// <summary>
        /// Shorthand for a <c>action == null</c>.
        /// </summary>
        /// <param name="unityEvent">This action.</param>
        /// <returns>The result of <c>action == null</c></returns>
        public static bool IsNull(this UnityAction action) => action == null;

        /// <summary>
        /// Shorthand for a <c>action != null</c>.
        /// </summary>
        /// <param name="unityEvent">This action.</param>
        /// <returns>The result of <c>action != null</c></returns>
        public static bool NotNull(this UnityAction action) => action != null;

        #endregion

        #region Unity Action <T0>

        /// <summary>
        /// Invokes the action if it has listeners.
        /// </summary>
        /// <typeparam name="T0">The type of the action's parameter.</typeparam>
        /// <param name="action">This action</param>
        /// <param name="target0">Parameter 0</param>
        /// <returns>True if the invocation was successful, otherwise false.</returns>
        public static bool SafeInvoke<T0>(this UnityAction<T0> action, T0 target0)
        {
            if (action.IsNull()) return false;

            action.Invoke(target0);
            return true;
        }

        /// <summary>
        /// Shorthand for a <c>action == null</c>.
        /// </summary>
        /// <param name="unityEvent">This action.</param>
        /// <returns>The result of <c>action == null</c></returns>
        public static bool IsNull<T0>(this UnityAction<T0> action) => action == null;

        /// <summary>
        /// Shorthand for a <c>action != null</c>.
        /// </summary>
        /// <param name="unityEvent">This action.</param>
        /// <returns>The result of <c>action != null</c></returns>
        public static bool NotNull<T0>(this UnityAction<T0> action) => action != null;

        #endregion

        #region Unity Action <T0, T1>

        /// <summary>
        /// Invokes the action if it has listeners.
        /// </summary>
        /// <typeparam name="T0">The type of the action's first parameter.</typeparam>
        /// <typeparam name="T1">The type of the action's second parameter.</typeparam>
        /// <param name="action">This action</param>
        /// <param name="target0">Parameter 0</param>
        /// <param name="target1">Parameter 1</param>
        /// <returns>True if the invocation was successful, otherwise false.</returns>
        public static bool SafeInvoke<T0, T1>(this UnityAction<T0, T1> action, T0 target0, T1 target1)
        {
            if (action.IsNull()) return false;

            action.Invoke(target0, target1);
            return true;
        }

        /// <summary>
        /// Shorthand for a <c>action == null</c>.
        /// </summary>
        /// <param name="unityEvent">This action.</param>
        /// <returns>The result of <c>action == null</c></returns>
        public static bool IsNull<T0, T1>(this UnityAction<T0, T1> action) => action == null;

        /// <summary>
        /// Shorthand for a <c>action != null</c>.
        /// </summary>
        /// <param name="unityEvent">This action.</param>
        /// <returns>The result of <c>action != null</c></returns>
        public static bool NotNull<T0, T1>(this UnityAction<T0, T1> action) => action != null;

        #endregion
    }
}
