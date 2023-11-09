namespace TirUtilities
{
    ///<!--
    /// UnityMessag.cs
    /// 
    /// Project:  TirUtilities
    ///        
    /// Author :  Devon Wilson
    /// Company:  Black Phoenix Software
    /// Created:  Aug 01, 2022
    /// Updated:  Aug 01, 2022
    /// -->
    /// <summary>
    /// Enum named for the most common Unity Messages.
    /// </summary>
    [System.Serializable]
    public enum UnityMessage
    {
        None,
        Awake,
        Start,
        OnEnable,
        Update,
        FixedUpdate,
        LateUpdate,
        OnDisable,
        OnDestroy,
    }
}