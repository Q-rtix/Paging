using Paging.Pagers;

namespace Paging.PagedCollections;

public interface IPagedList<out T> : IPager, IReadOnlyList<T>
{
	/// <summary>
	/// Returns true if this paged list is empty.
	/// </summary>
	/// <value>
	/// Returns true if this paged list is empty.
	/// </value>
	bool IsEmpty { get; }

	///<summary>
	/// Gets a copy of the pager of this paged list.
	///</summary>
	///<returns>A copy of the pager of this paged list.</returns>
	Pager GetPagerData();

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