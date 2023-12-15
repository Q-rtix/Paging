namespace Paging.Pagers;

/// <summary>
/// Represents a pager that handles pagination logic.
/// </summary>
public class Pager : IPager
{
	#region Constructors

    public Pager(int pageNumber, int pageSize, int totalItemCount)
    {
        ParametersValidator(pageNumber, pageSize, totalItemCount);
    
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
	/// One-based index of this subset within the data-source, zero if the data-source is empty.
	/// </summary>
	/// <value>
	/// One-based index of this subset within the data-source, zero if the data-source is empty.
	/// </value>
	public int PageNumber { get; private set; }

	/// <summary>
	/// Maximum size any individual subset.
	/// </summary>
	/// <value>
	/// Maximum size any individual subset.
	/// </value>
	public int PageSize { get; }
	
	/// <summary>
	/// Returns true if the data-source is not empty and PageNumber is less than or equal to PageCount and this
	/// is NOT the first subset within the data-source.
	/// </summary>
	/// <value>
	/// Returns true if the data-source is not empty and PageNumber is less than or equal to PageCount and this
	/// is NOT the first subset within the data-source.
	/// </value>
	public bool HasPreviousPage { get; private set; }

	/// <summary>
	/// Returns true if the data-source is not empty and PageNumber is less than or equal to PageCount and this
	/// is NOT the last subset within the data-source.
	/// </summary>
	/// <value>
	/// Returns true if the data-source is not empty and PageNumber is less than or equal to PageCount and this
	/// is NOT the last subset within the data-source.
	/// </value>
	public bool HasNextPage { get; private set; }

	/// <summary>
	/// Returns true if the data-source is not empty and PageNumber is less than or equal to PageCount and this
	/// is the first subset within the data-source.
	/// </summary>
	/// <value>
	/// Returns true if the data-source is not empty and PageNumber is less than or equal to PageCount and this
	/// is the first subset within the data-source.
	/// </value>
	public bool IsFirstPage { get; private set; }

	/// <summary>
	/// Returns true if the data-source is not empty and PageNumber is less than or equal to PageCount and this
	/// is the last subset within the data-source.
	/// </summary>
	/// <value>
	/// Returns true if the data-source is not empty and PageNumber is less than or equal to PageCount and this
	/// is the last subset within the data-source.
	/// </value>
	public bool IsLastPage { get; private set; }

	#endregion

	#region IPager Methods

	/// <summary>
	/// Moves to the next page from the current page.
	/// Updates the current page number to the next page within the available page range.
	/// If the current page number is already the last page, the method doesn't take any action.
	/// </summary>
	public void Next()
		=> MoveForward(1);
	
	/// <summary>
	/// Moves forward by the specified number of pages from the current page.
	/// Updates the current page number by moving forward a certain number of pages within the available page range.
	/// If the provided page number is greater than the total page count, the method sets the page number to the last available page.
	/// </summary>
	/// <param name="movePagesForward">The number of pages to move forward from the current page.</param>
	public void MoveForward(int movePagesForward)
		=> GoToPage(PageNumber + movePagesForward);

	/// <summary>
	/// Moves to the previous page from the current page.
	/// Updates the current page number to the previous page within the available page range.
	/// If the current page number is already the first page (1), the method doesn't take any action.
	/// </summary>
	public void Previous()
		=> MoveBackward(1);
	
	/// <summary>
	/// Moves backward by the specified number of pages from the current page.
	/// Updates the current page number by moving back a certain number of pages within the available page range.
	/// If the provided number of pages to move is less than 1, sets the page number to 1.
	/// </summary>
	/// <param name="movePagesBackward">The number of pages to move backward from the current page.</param>
	public void MoveBackward(int movePagesBackward)
		=> GoToPage(PageNumber - movePagesBackward);

	/// <summary>
	/// Navigates to the first page within the available page range.
	/// Sets the current page number to the first page.
	/// </summary>
	public void First()
		=> GoToPage(1);

	/// <summary>
	/// Navigates to the last page within the available page range.
	/// Sets the current page number to the last available page.
	/// </summary>
	public void Last()
		=> GoToPage(PageCount);

	/// <summary>
	/// Navigates to the specified page number within the available page range.
	/// Updates the current page number and adjusts flags indicating the presence of previous, next, first, and last pages.
	/// If the provided page number is less than 1, the method sets the page number to 1.
	/// If the provided page number is greater than the total page count, the method sets the page number to the last available page.
	/// </summary>
	/// <param name="pageNumber">The page number to navigate to.</param>
	public void GoToPage(int pageNumber)
	{
		var newPageNumber = pageNumber < 1 
			? 1 
			: pageNumber > PageCount
				? PageCount
				: pageNumber;

		PageNumber = newPageNumber;
		
		HasPreviousPage = PageNumber > 1;
		HasNextPage = PageNumber < PageCount;
		IsFirstPage = PageNumber == 1;
		IsLastPage =  PageNumber == PageCount;
	}

	#endregion

	#region Private methods

	private static void ParametersValidator(int pageNumber, int pageSize, int totalItemCount)
	{
		if (pageNumber < 1)
			throw new ArgumentOutOfRangeException(null, $"pageNumber = {pageNumber}. PageNumber cannot be below 1.");

		if (pageSize < 1)
			throw new ArgumentOutOfRangeException(null, $"pageSize = {pageSize}. PageSize cannot be less than 1.");

		if (totalItemCount < 0)
			throw new ArgumentOutOfRangeException(null, $"totalItemCount = {totalItemCount}. TotalItemCount cannot be less than 0.");
	}

	#endregion
}