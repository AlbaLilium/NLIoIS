using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Diagnostics;


namespace AlbaLilium.Nliois.ConBridge;


/// <summary>
/// (parent process transceiver)
/// Uses stdin and stdout of a child proess for
/// inter-process communication in a standardized manner.
/// 
/// Not recommended for serious projects:
/// - There is a parent/child relation ship.
/// - It uses stdin, stdout.
/// </summary>
public class ConsoleTransceiver {

	readonly Process process;

	/// <inheritdoc cref="ConsoleTransceiver"/>
	/// <remarks>
	/// Only takes a reference to the streams.
	/// Does not take ownership/disposes of them.
	/// </remarks>
	public ConsoleTransceiver(StreamReader stdout, StreamWriter stdin) { 
		//todo
	}

}
