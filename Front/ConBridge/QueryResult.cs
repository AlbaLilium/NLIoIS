using System;


namespace AlbaLilium.Nliois.ConBridge;


public record QueryResult<T> {

	/// <summary>True of query was processed without errors</summary>
	public required bool IsSuccess { get; init; }

	/// <summary>Error message if there was an error. Null for success.</summary>
	public string? ErrorMessage { get; init; } = null;

	/// <summary>Response to the query. Default (may be null) for error.</summary>
	public T? Response { get; init; } = default;

}
