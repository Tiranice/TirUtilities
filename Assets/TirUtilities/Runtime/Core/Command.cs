namespace TirUtilities.Experimental
{
    ///<!--
    /// Command.cs
    /// 
    /// Project:  TirUtilities
    ///        
    /// Author :  Devon Wilson
    /// Created:  May 15, 2021
    /// Updated:  May 15, 2021
    /// -->
    /// <summary>
    ///
    /// </summary>
    public abstract class Command
    {
        public abstract void Execute();
        public abstract void Undo();
    }
}