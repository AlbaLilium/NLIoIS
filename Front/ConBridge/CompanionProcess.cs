using System;
using System.Diagnostics;


namespace AlbaLilium.Nliois.ConBridge;


/// <summary>
/// A class that repersent a child process that can communicate.
/// Internally holds and uses a <see cref="ConsoleTransceiver"/>.
/// </summary>
public class CompanionProcess : IDisposable {

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

	~CompanionProcess() {
		Dispose(false);
	}

	public void Dispose() {
		Dispose(disposeManaged: true);
		GC.SuppressFinalize(this);
	}

	#endregion

	protected Process ChildProcess;
	protected ConsoleTransceiver Transceiver;

	/// <inheritdoc cref="CompanionProcess"/>
	public CompanionProcess(string childProcessFilename) {

		// Set-up process
		ProcessStartInfo info = new() {
			FileName = childProcessFilename,
			RedirectStandardInput = true,
			RedirectStandardOutput = true,
			UseShellExecute = false
		};

		ChildProcess = Process.Start(info) ?? throw new ArgumentException($"Cannot start process {childProcessFilename}", nameof(childProcessFilename));

		// Set-up transiver
		Transceiver = new ConsoleTransceiver(ChildProcess.StandardOutput, ChildProcess.StandardInput);

	}

}
