using System;
using System.Collections.Generic;
using System.IO;

namespace Data
{
	public static class ExportHelper
	{

		public static void Export(string filename,CommandList list)
		{
			List<string> lines = new List<string> ();

			foreach (var command in list.Commands) {
				lines.Add (command.ToString ());
			}

			File.WriteAllLines (filename,lines);
		}

	}
}

