using System;

namespace Data
{
	public class Command
	{
		public Command ()
		{
		}
		public GCodeType Type{ get; set;}
		public InnerType InnerType{ get; set;}
		public string RawCommand{get;set;}

		public override string ToString ()
		{
			return RawCommand;
		}
		
	}
}

