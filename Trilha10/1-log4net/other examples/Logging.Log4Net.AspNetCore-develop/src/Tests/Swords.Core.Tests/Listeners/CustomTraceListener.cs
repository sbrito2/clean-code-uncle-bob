﻿using System.Collections.Generic;
using System.Diagnostics;

namespace Swords.Core.Tests.Listeners
{
	internal class CustomTraceListener : TraceListener
	{
		public CustomTraceListener()
			=> this.Messages = new List<string>();

		public IList<string> Messages { get; set; }

		public override void Write(string message)
			=> this.Messages.Add(message);

		public override void WriteLine(string message)
			=> this.Write(message);
	}
}