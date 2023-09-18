using System;
using System.IO;
using System.Diagnostics;


namespace AlbaLilium.Nliois.ConBridge;


/// <summary>
/// A class that repersent a child process that can communicate.
/// Internally holds and uses a <see cref="ConsoleTransceiver"/>.
/// </summary>
public class BackendProcess : IDisposable {

	#region //// Disposable

	private bool isDisposed;

	protected virtual void Dispose(bool disposeManaged) {

		if (isDisposed) return;

		if (disposeManaged) {
			// Dispose managed
			ChildProcess.Kill();
			ChildProcess.Dispose();
		}

		// Set to null
		ChildProcess = null!;
		Transceiver = null!;

		// Dispose unmanaged
		// (none)

		isDisposed = true;
	}

	~BackendProcess() {
		Dispose(false);
	}

	public void Dispose() {
		Dispose(disposeManaged: true);
		GC.SuppressFinalize(this);
	}

	#endregion

	protected Process ChildProcess;
	public ConsoleTransceiver Transceiver { get; private set; }

	/// <inheritdoc cref="BackendProcess"/>
	public BackendProcess() {

		const string pathToBack = @"..\..\..\..\..\Back";
		const string startingScript = "main.py";
		const string executingCommand = "python";

		// Set-up process
		ProcessStartInfo info = new() {
			FileName = executingCommand,
			WorkingDirectory = pathToBack,
			RedirectStandardInput = true,
			RedirectStandardOutput = true,
			RedirectStandardError = true,
			UseShellExecute = false
		};
		info.ArgumentList.Add(startingScript);

		ChildProcess = Process.Start(info) ?? throw new BackendProcessException("Cannot start backend process");
		
		// Set-up transiver
		Transceiver = new ConsoleTransceiver(ChildProcess.StandardOutput, ChildProcess.StandardInput);

	}

}
