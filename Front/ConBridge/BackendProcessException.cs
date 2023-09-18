using System;


namespace AlbaLilium.Nliois.ConBridge;


internal class BackendProcessException : Exception {

	public BackendProcessException() : base() { }

	public BackendProcessException(string? message) : base(message) {}

	public BackendProcessException(string? message, Exception? innerException) : base(message, innerException) {}

}
