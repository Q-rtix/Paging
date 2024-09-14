using Paging.Abstractions;

namespace Paging.Pagers;

/// <summary>
/// Represents a pager that handles pagination logic.
/// </summary>
public class Pager : IPager
{
	#region Constructors

	/// <summary>
	/// Initializes a new instance of the <see cref="Paging.Pagers.Pager"/> class with the provided parameters.
	/// Calculates page-related attributes such as total page count and sets flags indicating the presence of previous,
	/// next, first, and last pages based on the provided page number, page size, and total item count.
	/// </summary>
	/// <param name="pageNumber">The current page number.</param>
	/// <param name="pageSize">The number of items per page.</param>
	/// <param name="totalItemCount">The total number of items across all pages.</param>
	public Pager(int pageNumber, int pageSize, int totalItemCount)
	{
		Validator(pageNumber, pageSize, totalItemCount);

		PageNumber = pageNumber;
		PageSize = pageSize;
		TotalItemCount = totalItemCount;

		PageCount = TotalItemCount > 0
			? (TotalItemCount + PageSize - 1) / PageSize
			: 0;

		var pageNumberIsValid = PageCount > 0 && PageNumber <= PageCount;

		HasPreviousPage = pageNumberIsValid && PageNumber > 1;
		HasNextPage = pageNumberIsValid && PageNumber < PageCount;
		IsFirstPage = pageNumberIsValid && PageNumber == 1;
		IsLastPage = pageNumberIsValid && PageNumber == PageCount;
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="Paging.Pagers.Pager"/> class based on an existing pager instance with an optional update to the total item count.
	/// Constructs a new pager with the same page number, page size, and either the provided new total item count or the total item count of the source pager.
	/// </summary>
	/// <param name="source">The existing pager to create a new instance from.</param>
	/// <param name="newTotalItemCount">
	/// The optional new total item count. If provided, updates the total item count;
	/// otherwise, uses the total item count from the source pager.
	/// </param>
	public Pager(IPager source, int? newTotalItemCount = null)
		: this(source.PageNumber, source.PageSize, newTotalItemCount ?? source.TotalItemCount)
	{
	}

	#endregion

	#region IPager Properties

	/// <summary>
	/// Total number of datasets within the data-source.
	/// </summary>
	/// <value>
	/// Total number of datasets within the data-source.
	/// </value>
	public int PageCount { get; }

	/// <summary>
	/// Total number of objects contained within the datasets.
	/// </summary>
	/// <value>
	/// Total number of objects contained within the data-source.
	/// </value>
	public int TotalItemCount { get; }

	/// <summary>
	/// One-based index of this dataset within the data-source, zero if the data-source is empty.
	/// </summary>
	/// <value>
	/// One-based index of this dataset within the data-source, zero if the data-source is empty.
	/// </value>
	public int PageNumber { get; private set; }

	/// <summary>
	/// Maximum size any individual dataset.
	/// </summary>
	/// <value>
	/// Maximum size any individual dataset.
	/// </value>
	public int PageSize { get; }

	/// <summary>
	/// Returns true if the data-source is not empty and PageNumber is less than or equal to PageCount and this
	/// is NOT the first dataset within the data-source.
	/// </summary>
	/// <value>
	/// Returns true if the data-source is not empty and PageNumber is less than or equal to PageCount and this
	/// is NOT the first dataset within the data-source.
	/// </value>
	public bool HasPreviousPage { get; private set; }

	/// <summary>
	/// Returns true if the data-source is not empty and PageNumber is less than or equal to PageCount and this
	/// is NOT the last dataset within the data-source.
	/// </summary>
	/// <value>
	/// Returns true if the data-source is not empty and PageNumber is less than or equal to PageCount and this
	/// is NOT the last dataset within the data-source.
	/// </value>
	public bool HasNextPage { get; private set; }

	/// <summary>
	/// Returns true if the data-source is not empty and PageNumber is less than or equal to PageCount and this
	/// is the first dataset within the data-source.
	/// </summary>
	/// <value>
	/// Returns true if the data-source is not empty and PageNumber is less than or equal to PageCount and this
	/// is the first dataset within the data-source.
	/// </value>
	public bool IsFirstPage { get; private set; }

	/// <summary>
	/// Returns true if the data-source is not empty and PageNumber is less than or equal to PageCount and this
	/// is the last dataset within the data-source.
	/// </summary>
	/// <value>
	/// Returns true if the data-source is not empty and PageNumber is less than or equal to PageCount and this
	/// is the last dataset within the data-source.
	/// </value>
	public bool IsLastPage { get; private set; }

	#endregion

	#region Private methods

	private static void Validator(int pageNumber, int pageSize, int totalItemCount)
	{
		if (pageNumber < 1)
			throw new ArgumentOutOfRangeException(null, $"pageNumber = {pageNumber}. PageNumber cannot be below 1.");

		if (pageSize < 1)
			throw new ArgumentOutOfRangeException(null, $"pageSize = {pageSize}. PageSize cannot be less than 1.");

		if (totalItemCount < 0)
			throw new ArgumentOutOfRangeException(
				null,
				$"totalItemCount = {totalItemCount}. TotalItemCount cannot be less than 0."
			);
	}

	#endregion
}