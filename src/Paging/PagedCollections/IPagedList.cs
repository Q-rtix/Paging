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
}