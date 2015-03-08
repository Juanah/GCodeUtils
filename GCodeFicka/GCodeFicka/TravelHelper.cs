using System;
using Data;
using System.Collections.Generic;
namespace GCodeFicka
{
	public static class TravelHelper
	{

		public static void GenerateTravel(CommandList code,double travelFeetRate,double cutRate,double low, double high)
		{
			CommandList result = new CommandList () {
				Commands = new List<Command>()
			};

			foreach (var command in code.Commands) {

				if (command.Type == GCodeType.G) {
					if (command.InnerType == InnerType.JustZ) {

						double zValue = GetZValue (command.RawCommand);

						if (zValue == low) {
							Command lower = new Command () {
								RawCommand = String.Format("G1 F{0}",cutRate)
							};
							result.Commands.Add (lower);
						}

						if (zValue == high) {
							Command higher = new Command () {
								RawCommand = String.Format("G1 F{0}",travelFeetRate)
							};
							result.Commands.Add (higher);
						}
					}
				}
				result.Commands.Add (command);
			}
			ExportHelper.Export (Environment.CurrentDirectory + "\\travel.gcode", result);
		}


		private static double GetZValue(string line)
		{
			//G1 Z0.1600
			string clean = line.Replace ("G1", "").Replace ("Z", "").Trim ();
			return Convert.ToDouble (clean);
		}


	}
}

