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

using Acacia.Stubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Acacia.Utils
{
    public class ComRelease : IDisposable
    {
        private readonly List<object> objects = new List<object>();

        public Type Add<Type>(Type t)
        {
            objects.Add(t);
            return t;
        }

        public Type Remove<Type>(Type t)
        {
            objects.Remove(t);
            return t;
        }

        public void Dispose()
        {
            foreach (object o in objects)
                Release(o);
            objects.Clear();
        }

        private static bool? _enabled;

        private static bool Enabled
        {
            get
            {
                if (!_enabled.HasValue)
                {
                    _enabled = GlobalOptions.INSTANCE.COMRelease;
                }
                return _enabled.Value;
            }
        }

        public static void Release(params object[] objs)
        {
            foreach (object o in objs)
                Release(o);
        }

        public static void Release(object o)
        {
            if (!Enabled)
                return;
            if (o == null || !Marshal.IsComObject(o))
                return;

            Marshal.ReleaseComObject(o);
        }
    }
}
