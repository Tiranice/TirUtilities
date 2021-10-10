namespace TirUtilities.Controllers.Experimental
{
    ///<!--
    /// ISelectable.cs
    /// 
    /// Project:  TirUtilities
    ///        
    /// Author :  Devon Wilson
    /// Company:  BlackPhoenixSoftware
    /// Created:  Oct 01, 2021
    /// Updated:  Oct 01, 2021
    /// -->
    /// <summary>
    ///
    /// </summary>
    public interface ISelectable
    {
        event System.Action OnSelected;
        event System.Action OnDeselected;

        void Select();
        void Deselect();
    }
}