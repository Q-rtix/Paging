using Paging.Pagers;

namespace Paging.PagedCollections;

/// <summary>
/// Represents a paged list of items along with pagination information.
/// </summary>
/// <typeparam name="T">The type of items in the paged list.</typeparam>
public interface IPagedList<out T> :
	IPager, 
	IReadOnlyList<T>
{
	/// <summary>
	/// Gets a value indicating whether the <see cref="T:Paging.PagedCollections.IPagedList`1" /> is empty based on the total item count.
	/// </summary>
	/// <value>True if the <see cref="T:Paging.PagedCollections.IPagedList`1" /> has no items; otherwise, false.</value>
	bool IsEmpty { get; }

	/// <summary>
	/// Retrieves a copied data from the current <see cref="T:Paging.PagedCollections.IPagedList`1" />.
	/// </summary>
	/// <returns>A copied data from the current <see cref="T:Paging.PagedCollections.IPagedList`1" />.</returns>
	IPager GetPagerData();
}