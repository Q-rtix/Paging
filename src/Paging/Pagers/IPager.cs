namespace Paging.Pagers;

/// <summary>
/// Represents a pager that handles pagination logic.
/// </summary>
public interface IPager
{
	#region Properties

	/// <summary>
	/// Total number of datasets within the data-source.
	/// </summary>
	/// <value>
	/// Total number of datasets within the data-source.
	/// </value>
	int PageCount { get; }

	/// <summary>
	/// Total number of objects contained within the datasets.
	/// </summary>
	/// <value>
	/// Total number of objects contained within the data-source.
	/// </value>
	int TotalItemCount { get; }

	/// <summary>
	/// One-based index of this subset within the data-source, zero if the data-source is empty.
	/// </summary>
	/// <value>
	/// One-based index of this subset within the data-source, zero if the data-source is empty.
	/// </value>
	int PageNumber { get; }

	/// <summary>
	/// Maximum size any individual subset.
	/// </summary>
	/// <value>
	/// Maximum size any individual subset.
	/// </value>
	int PageSize { get; }

	/// <summary>
	/// Returns true if the data-source is not empty and PageNumber is less than or equal to PageCount and this
	/// is NOT the first subset within the data-source.
	/// </summary>
	/// <value>
	/// Returns true if the data-source is not empty and PageNumber is less than or equal to PageCount and this
	/// is NOT the first subset within the data-source.
	/// </value>
	bool HasPreviousPage { get; }

	/// <summary>
	/// Returns true if the data-source is not empty and PageNumber is less than or equal to PageCount and this
	/// is NOT the last subset within the data-source.
	/// </summary>
	/// <value>
	/// Returns true if the data-source is not empty and PageNumber is less than or equal to PageCount and this
	/// is NOT the last subset within the data-source.
	/// </value>
	bool HasNextPage { get; }

	/// <summary>
	/// Returns true if the data-source is not empty and PageNumber is less than or equal to PageCount and this
	/// is the first subset within the data-source.
	/// </summary>
	/// <value>
	/// Returns true if the data-source is not empty and PageNumber is less than or equal to PageCount and this
	/// is the first subset within the data-source.
	/// </value>
	bool IsFirstPage { get; }

	/// <summary>
	/// Returns true if the data-source is not empty and PageNumber is less than or equal to PageCount and this
	/// is the last subset within the data-source.
	/// </summary>
	/// <value>
	/// Returns true if the data-source is not empty and PageNumber is less than or equal to PageCount and this
	/// is the last subset within the data-source.
	/// </value>
	bool IsLastPage { get; }

	#endregion
}