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

namespace TirUtilities.Experimental
{
    ///<!--
    /// QuittingState.cs
    ///
    /// Project:  TirUtilities
    ///
    /// Author :  Devon Wilson
    /// Company:  Black Phoenix Creative
    /// Created:  June 15, 2021
    /// Updated:  July 09, 2021
    /// -->
    /// <summary>
    /// Quits the game or exits play mode in the editor.
    /// </summary>
    public sealed class QuittingState : ApplicationState
    {
        public override void EnterState(ApplicationStateMachine stateMachine)
        {
            stateMachine.CurrentState = this;

#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#elif PLATFORM_WEBGL
#else
            UnityEngine.Application.Quit();
#endif
        }
    }
}