﻿/// Copyright 2016 Kopano b.v.
/// 
/// This program is free software: you can redistribute it and/or modify
/// it under the terms of the GNU Affero General Public License, version 3,
/// as published by the Free Software Foundation.
/// 
/// This program is distributed in the hope that it will be useful,
/// but WITHOUT ANY WARRANTY; without even the implied warranty of
/// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
/// GNU Affero General Public License for more details.
/// 
/// You should have received a copy of the GNU Affero General Public License
/// along with this program.If not, see<http://www.gnu.org/licenses/>.
/// 
/// Consult LICENSE file for details

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acacia.Stubs
{
    public interface IStore : IDisposable
    {
        /// <summary>
        /// Returns the root folder.
        /// </summary>
        /// <returns>The root folder. The caller is responsible for disposing.</returns>
        IFolder GetRootFolder();

        /// <summary>
        /// Returns a default folder.
        /// </summary>
        /// <returns>The default folder. The caller is responsible for disposing.</returns>
        IFolder GetDefaultFolder(DefaultFolder folder);
        /// <summary>
        /// Returns GetDefaultFolder.EntryID, for simplified memory manaement
        /// </summary>
        string GetDefaultFolderId(DefaultFolder folder);

        /// <summary>
        /// Returns a special folder.
        /// </summary>
        /// <returns>The special folder. The caller is responsible for disposing.</returns>
        IFolder GetSpecialFolder(SpecialFolder folder);

        IItem GetItemFromID(string id);
        string DisplayName { get; }
        string StoreID { get; }

        bool IsFileStore { get; }
        string FilePath { get; }

        void EmptyDeletedItems();
    }
}
