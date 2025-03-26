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
///     You should have received a copy of the GNU Lesser General Public License
///     along with this program.  If not, see <https://www.gnu.org/licenses/>.
///-->

namespace TirUtilities
{
    ///<!--
    /// IState.cs
    ///
    /// Project:  TirUtilities
    ///
    /// Author :  Devon Wilson
    /// Company:  Black Phoenix Creative
    /// Created:  June 06, 2021
    /// Updated:  Aug. 22, 2021
    /// -->
    /// <summary>
    /// Implement this interface on object that should be states in a <see cref="StateMachine"/>.
    /// </summary>
    public interface IState<T> where T : StateMachine
    {
#if UNITY_2020_2_OR_NEWER        
        public void EnterState(T stateMachine);
        public void ExitState(T stateMachine);
        public void UpdateState(T stateMachine);
#else
        void EnterState(T stateMachine);
        void ExitState(T stateMachine);
        void UpdateState(T stateMachine);
#endif
    }
}