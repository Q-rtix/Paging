using Paging.PagedCollections;
using Paging.Pagers;

namespace Paging.Extensions;

/// <summary>
/// Provides extension methods for creating instances of the PagedList&lt;T&gt; class.
/// </summary>
public static class PagedListExtensions
{
	/// <summary>
	/// Create a new instance of the <see cref="T:Paging.PagedCollections.PagedList`1" /> class with the provided <paramref name="dataSource"/>,
	/// <paramref name="pageNumber"/>, and <paramref name="pageSize"/>.
	/// Sets the total item count based on the count of the provided data source or to 0 if the data source is empty.
	/// Constructs the <see cref="T:Paging.PagedCollections.PagedList`1" /> by retrieving the items for the specified page from the data source.
	/// </summary>
	/// <param name="dataSource">The collection of items to paginate.</param>
	/// <param name="pageNumber">The current page number.</param>
	/// <param name="pageSize">The number of items per page.</param>
	/// <exception cref="ArgumentNullException">Thrown when the <paramref name="dataSource"/> is null.</exception>
	public static PagedList<T> Paginated<T>(this IEnumerable<T> dataSource, int pageNumber, int pageSize) 
		=> new(dataSource, pageNumber, pageSize);
	
	/// <summary>
	/// Create a new instance of the <see cref="T:Paging.PagedCollections.PagedList`1" /> class with the provided
	/// <paramref name="dataSource"/> and <paramref name="pager"/>.
	/// Constructs the paged list by retrieving the items for the specified page from the data source.
	/// </summary>
	/// <param name="dataSource">The collection of items to paginate.</param>
	/// <param name="pager">The pager containing information about the current page, page size, etc.</param>
	/// <exception cref="ArgumentNullException">Thrown when the <paramref name="dataSource"/> is null.</exception>
	public static PagedList<T> Paginated<T>(this IEnumerable<T> dataSource, IPager pager)
		=> new(dataSource, pager);
	
}