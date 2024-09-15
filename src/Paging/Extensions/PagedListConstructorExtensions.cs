using Paging.Abstractions;
using Paging.Pagers;

namespace Paging.Extensions;

/// <summary>
/// Provides extension methods for creating instances of the PagedList class.
/// </summary>
public static class PagedListConstructorExtensions
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
	public static PagedList<T> Paginate<T>(this IEnumerable<T> dataSource, int pageNumber, int pageSize) => new PagedList<T>(dataSource, pageNumber, pageSize);

	/// <summary>
	/// Create a new instance of the <see cref="T:Paging.PagedCollections.PagedList`1" /> class with the provided
	/// <paramref name="dataSource"/> and <paramref name="pager"/>.
	/// Constructs the paged list by retrieving the items for the specified page from the data source.
	/// </summary>
	/// <param name="dataSource">The collection of items to paginate.</param>
	/// <param name="pager">The pager containing information about the current page, page size, etc.</param>
	/// <exception cref="ArgumentNullException">Thrown when the <paramref name="dataSource"/> is null.</exception>
	public static PagedList<T> Paginate<T>(this IEnumerable<T> dataSource, IPager pager) => new PagedList<T>(dataSource, pager);

	/// <summary>
	/// Create a new instance of the <see cref="T:Paging.PagedCollections.PagedList`1" /> class with the provided
	/// <paramref name="dataSource"/>, <paramref name="pageNumber"/>, <paramref name="pageSize"/>, and <paramref name="selector"/>.
	/// Constructs the paged list by retrieving the items for the specified page from the data source and mapping them using the selector.
	/// </summary>
	/// <param name="dataSource">The collection of items to paginate.</param>
	/// <param name="pageNumber">The current page number.</param>
	/// <param name="pageSize">The number of items per page.</param>
	/// <param name="selector">The function to map items from the input type to the output type.</param>
	/// <typeparam name="TIn">The type of the items in the data source.</typeparam>
	/// <typeparam name="TOut">The type of the items in the resulting paged list.</typeparam>
	/// <returns>A new instance of the <see cref="T:Paging.PagedCollections.PagedList`1" /> class.</returns>
	/// <exception cref="ArgumentNullException">Thrown when the <paramref name="dataSource"/> is null.</exception>
	public static PagedList<TOut> Paginate<TIn, TOut>(this IEnumerable<TIn> dataSource, int pageNumber, int pageSize, Func<TIn, TOut> selector)
		=> dataSource.Select(selector).Paginate(pageNumber, pageSize);

	/// <summary>
	/// Create a new instance of the <see cref="T:Paging.PagedCollections.PagedList`1" /> class with the provided
	/// <paramref name="dataSource"/>, <paramref name="pager"/>, and <paramref name="selector"/>.
	/// Constructs the paged list by retrieving the items for the specified page from the data source and mapping them using the selector.
	/// </summary>
	/// <param name="dataSource">The collection of items to paginate.</param>
	/// <param name="pager">The pager containing information about the current page, page size, etc.</param>
	/// <param name="selector">The function to map items from the input type to the output type.</param>
	/// <typeparam name="TIn">The type of the items in the data source.</typeparam>
	/// <typeparam name="TOut">The type of the items in the resulting paged list.</typeparam>
	/// <returns>A new instance of the <see cref="T:Paging.PagedCollections.PagedList`1" /> class.</returns>
	/// <exception cref="ArgumentNullException">Thrown when the <paramref name="dataSource"/> is null.</exception>
	public static PagedList<TOut> Paginate<TIn, TOut>(this IEnumerable<TIn> dataSource, IPager pager, Func<TIn, TOut> selector)
		=> dataSource.Select(selector).Paginate(pager);
}
