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

	#region Methods

	/// <summary>
	/// Moves to the next page from the current page.
	/// Updates the current page number to the next page within the available page range.
	/// If the current page number is already the last page, the method doesn't take any action.
	/// </summary>
	void Next();
	
	/// <summary>
	/// Moves forward by the specified number of pages from the current page.
	/// Updates the current page number by moving forward a certain number of pages within the available page range.
	/// If the provided page number is greater than the total page count, the method sets the page number to the last available page.
	/// </summary>
	/// <param name="movePagesForward">The number of pages to move forward from the current page.</param>
	void MoveForward(int movePagesForward);
	
	/// <summary>
	/// Moves to the previous page from the current page.
	/// Updates the current page number to the previous page within the available page range.
	/// If the current page number is already the first page (1), the method doesn't take any action.
	/// </summary>
	void Previous();
	
	/// <summary>
	/// Moves backward by the specified number of pages from the current page.
	/// Updates the current page number by moving back a certain number of pages within the available page range.
	/// If the provided number of pages to move is less than 1, sets the page number to 1.
	/// </summary>
	/// <param name="movePagesBackward">The number of pages to move backward from the current page.</param>
	void MoveBackward(int movePagesBackward);
	
	/// <summary>
	/// Navigates to the first page within the available page range.
	/// Sets the current page number to the first page.
	/// </summary>
	void First();
	
	/// <summary>
	/// Navigates to the last page within the available page range.
	/// Sets the current page number to the last available page.
	/// </summary>
	void Last();
	
	/// <summary>
	/// Navigates to the specified page number within the available page range.
	/// Updates the current page number and adjusts flags indicating the presence of previous, next, first, and last pages.
	/// If the provided page number is less than 1, the method sets the page number to 1.
	/// If the provided page number is greater than the total page count, the method sets the page number to the last available page.
	/// </summary>
	/// <param name="pageNumber">The page number to navigate to.</param>
	void GoToPage(int pageNumber);
	

	#endregion
}