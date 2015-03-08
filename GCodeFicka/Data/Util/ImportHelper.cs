using System;
using System.IO;
using System.Collections.Generic;
namespace Data
{
	public static class ImportHelper
	{
		public static CommandList ImportGCode(string filePath)
		{
			CommandList list = new CommandList () {
				Commands = new List<Command>()

			};

			var lines = File.ReadAllLines (filePath);

			foreach (var line in lines) {
				Command tempCommand = new Command ();

				if (line.Contains ("G")) {
					tempCommand.Type = GCodeType.G;
					if (line.Contains ("Z")) {
						tempCommand.InnerType = InnerType.JustZ;
					} else if (line.Contains ("X") || line.Contains ("Y") || line.Contains ("Z")) {
						tempCommand.InnerType = InnerType.Move;
					} 
				} else {
					tempCommand.Type = GCodeType.M;
				}
				tempCommand.RawCommand = line;
				list.Commands.Add (tempCommand);
			}
			return list;
		}
	}
}

