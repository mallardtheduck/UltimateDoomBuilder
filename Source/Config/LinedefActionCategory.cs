
#region ================== Copyright (c) 2007 Pascal vd Heiden

/*
 * Copyright (c) 2007 Pascal vd Heiden, www.codeimp.com
 * This program is released under GNU General Public License
 * 
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 * 
 */

#endregion

#region ================== Namespaces

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using CodeImp.DoomBuilder.IO;
using CodeImp.DoomBuilder.Data;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;
using CodeImp.DoomBuilder.Rendering;

#endregion

namespace CodeImp.DoomBuilder.Config
{
	public class LinedefActionCategory : IDisposable, IComparable<LinedefActionCategory>
	{
		#region ================== Constants

		#endregion

		#region ================== Variables

		// Category properties
		private string name;

		// Actions
		private List<LinedefActionInfo> actions;

		// Disposing
		private bool isdisposed = false;

		#endregion

		#region ================== Properties

		public string Name { get { return name; } }
		public List<LinedefActionInfo> Actions { get { return actions; } }
		public bool IsDisposed { get { return isdisposed; } }

		#endregion

		#region ================== Constructor / Disposer

		// Constructor
		public LinedefActionCategory(string name)
		{
			// Initialize
			this.name = name;
			this.actions = new List<LinedefActionInfo>();

			// We have no destructor
			GC.SuppressFinalize(this);
		}

		// Diposer
		public void Dispose()
		{
			// Not already disposed?
			if(!isdisposed)
			{
				// Clean up
				actions = null;
				
				// Done
				isdisposed = true;
			}
		}

		#endregion

		#region ================== Methods

		// This adds an action to this category
		public void Add(LinedefActionInfo a)
		{
			// Make it so.
			actions.Add(a);
		}

		// This compares against another action category
		public int CompareTo(LinedefActionCategory other)
		{
			return string.Compare(this.name, other.name);
		}
		
		#endregion
	}
}
