namespace TirUtilities
{
    ///<!--
    /// UnityMessageFlags.cs
    /// 
    /// Project:  TirUtilities
    ///        
    /// Author :  Devon Wilson
    /// Company:  Black Phoenix Software
    /// Created:  Aug 01, 2022
    /// Updated:  Aug 01, 2022
    /// -->
    /// <summary>
    /// Flags named for the most used Unity Messages.
    /// </summary>
    [System.Serializable, System.Flags]
    public enum UnityMessageFlags
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