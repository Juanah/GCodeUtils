using System;
using System.IO;
using Data;

namespace GCodeFicka
{
	class MainClass
	{

		static double  defaultcutSpeed = 30.000;
		static double  defaultTravel = 150.000;
		static double  defaultlowPoint = 1600;
		static double  defaulthighPoint = 15000;

		static string defaultPath = @"C:\Users\Jonas-Work\Documents\Niggah.gcode";
		public static void Main (string[] args)
		{
			CommandList list = ImportHelper.ImportGCode (defaultPath); 
			/*
			Console.WriteLine ("Cut Geschwindigkeit eingeben");
			double cutSpeed = Convert.ToDouble (Console.ReadLine ());
			Console.WriteLine ("Travel Geschwindigkeit eingeben");
			double travelSpeed = Convert.ToDouble (Console.ReadLine ());

			Console.WriteLine ("Lowpoint:");
			double lowPoint = Convert.ToDouble (Console.ReadLine ());
			Console.WriteLine ("HighPoint");
			double highpoint = Convert.ToDouble (Console.ReadLine ());
*/

			TravelHelper.GenerateTravel (list, defaultTravel, defaultcutSpeed, defaultlowPoint, defaulthighPoint);
		}
	}
}
