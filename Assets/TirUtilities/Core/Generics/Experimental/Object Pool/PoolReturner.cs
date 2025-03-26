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
///     You should have received a copy of the GNU Lesser General Public License
///     along with this program.  If not, see <https://www.gnu.org/licenses/>.
///-->

namespace TirUtilities.Core.Experimental
{

    ///<!--
    /// PoolReturner.cs
    ///
    /// Project:  Prototype 4
    ///
    /// Author :  Devon Wilson
    /// Company:  Black Phoenix Creative
    /// Created:  Sep 29, 2021
    /// Updated:  Sep 29, 2021
    /// -->
    /// <summary>
    ///
    /// </summary>
    public class PoolReturner : MonoBehaviour
    {
        public void Return(GameObject target)
        {
            if (target.TryGetComponent(out IPoolable poolable))
                poolable.Return();
        }

        public void ReturnFromTriggerVolume(bool entered, GameObject target)
        {
            if (!entered) return;

            if (target.TryGetComponent(out IPoolable poolable))
                poolable.Return();
        }
    }
}