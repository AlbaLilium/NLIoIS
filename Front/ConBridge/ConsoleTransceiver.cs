using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Diagnostics;


namespace AlbaLilium.Nliois.ConBridge;


/// <summary>
/// (parent process transceiver)
/// Uses stdin and stdout of a child process for
/// inter-process communication in a standardized manner.
/// 
/// Be cautious of this for serious projects:
/// - There is a parent/child relation ship.
/// - It uses stdin, stdout.
/// Consider other approaches.
/// </summary>
public class ConsoleTransceiver {

	readonly StreamReader stdout;
	readonly StreamWriter stdin;

	/// <inheritdoc cref="ConsoleTransceiver"/>
	/// <remarks>
	/// Only takes a reference to the streams.
	/// Does not take ownership/disposes of them.
	/// </remarks>
	public ConsoleTransceiver(StreamReader stdout, StreamWriter stdin) {
		this.stdin = stdin;
		this.stdout = stdout;
	}

}
