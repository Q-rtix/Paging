using System.Collections;
using System.Text.Json.Serialization;
using Paging.Pagers;

namespace Paging.PagedCollections;

/// <summary>
/// Represents a paged list of items along with pagination information.
/// </summary>
/// <typeparam name="T">The type of items in the paged list.</typeparam>
public sealed class PagedList<T> : Pager, IPagedList<T>
{
	[JsonInclude]
	private readonly T[] _dataset;

	#region Constructors

	/// <summary>
	/// Creates an empty instance of the <see cref="T:Paging.PagedCollections.PagedList`1" /> class with the specified <paramref name="pageSize"/>.
	/// </summary>
	/// <param name="pageSize">The number of items per page. Defaults to 10 if not specified.</param>
	/// <returns>An empty instance of the <see cref="T:Paging.PagedCollections.PagedList`1" /> class with the given <paramref name="pageSize"/>.</returns>
	public static PagedList<T> Empty(int pageSize = 10)
		=> new(Array.Empty<T>(), 1, pageSize);

	/// <summary>
	/// Creates an empty instance of the <see cref="T:Paging.PagedCollections.PagedList`1" /> class based on the pager information.
	/// Uses an empty data source and constructs the paged list with the pager's info.
	/// </summary>
	/// <param name="pager">The pager containing information about the current page, page size, etc.</param>
	/// <returns>An empty instance of the <see cref="T:Paging.PagedCollections.PagedList`1" /> class based on the provided <paramref name="pager"/>.</returns>
	public static PagedList<T> Empty(IPager pager)
		=> new(Array.Empty<T>(), pager);

	/// <summary>
	/// Initializes a new instance of the <see cref="T:Paging.PagedCollections.PagedList`1" /> class with the provided <paramref name="dataSource"/>,
	/// <paramref name="pageNumber"/>, and <paramref name="pageSize"/>.
	/// Sets the total item count based on the count of the provided data source or to 0 if the data source is empty.
	/// Constructs the <see cref="T:Paging.PagedCollections.PagedList`1" /> by retrieving the items for the specified page from the data source.
	/// </summary>
	/// <param name="dataSource">The collection of items to paginate.</param>
	/// <param name="pageNumber">The current page number.</param>
	/// <param name="pageSize">The number of items per page.</param>
	/// <exception cref="ArgumentNullException">Thrown when the <paramref name="dataSource"/> is null.</exception>
	public PagedList(IEnumerable<T> dataSource, int pageNumber, int pageSize)
		: base(pageNumber, pageSize, dataSource?.Count() ?? 0)
	{
		if (dataSource == null) throw new ArgumentNullException(nameof(dataSource), "dataSource cannot be null.");
		var skip = (pageNumber - 1) * pageSize;

		_dataset = dataSource.Skip(skip).Take(pageSize).ToArray();
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="T:Paging.PagedCollections.PagedList`1" /> class with the provided
	/// <paramref name="dataSource"/> and <paramref name="pager"/>.
	/// Constructs the paged list by retrieving the items for the specified page from the data source.
	/// </summary>
	/// <param name="dataSource">The collection of items to paginate.</param>
	/// <param name="pager">The pager containing information about the current page, page size, etc.</param>
	/// <exception cref="ArgumentNullException">Thrown when the <paramref name="dataSource"/> is null.</exception>
	public PagedList(IEnumerable<T> dataSource, IPager pager)
		: this(dataSource, pager.PageNumber, pager.PageSize)
	{
	}

	#endregion

	#region IPagedList Properties

	/// <summary>
	/// Gets a value indicating whether the <see cref="T:Paging.PagedCollections.PagedList`1" /> is empty based on the total item count.
	/// </summary>
	/// <value>True if the <see cref="T:Paging.PagedCollections.PagedList`1" /> has no items; otherwise, false.</value>
	public bool IsEmpty => TotalItemCount == 0;

	/// <summary>
	/// Gets the count of items in the current page of the <see cref="T:Paging.PagedCollections.PagedList`1" />.
	/// </summary>
	/// <value>The number of elements contained in the <see cref="T:Paging.PagedCollections.PagedList`1" />.</value>
	public int Count => _dataset.Length;

	#endregion

	#region IPagedList implementation

	/// <summary>
	/// Retrieves a copied data from the current <see cref="T:Paging.PagedCollections.PagedList`1" />.
	/// </summary>
	/// <returns>A copied data from the current <see cref="T:Paging.PagedCollections.PagedList`1" />.</returns>
	public IPager GetPagerData() => new Pager(this);

	/// <summary>
	/// Returns an enumerator that iterates through the collection of items in the current page of the <see cref="T:Paging.PagedCollections.PagedList`1" />.
	/// </summary>
	/// <returns>A <see cref="T:System.Collections.Generic.List`1.Enumerator" /> for the <see cref="T:Paging.PagedCollections.PagedList`1" />.</returns>
	public IEnumerator<T> GetEnumerator()
	{
		return new Enumerator(this);
	}

	/// <summary>
	/// Gets the item at the specified index in the current page of the <see cref="T:Paging.PagedCollections.PagedList`1" />.
	/// </summary>
	/// <param name="index">The zero-based index of the item to get or set.</param>
	/// <returns>The item at the specified index in the current page.</returns>
	public T this[int index] => _dataset[index];

	#endregion

	#region Enumerator

	/// <summary>Enumerates the elements of a <see cref="T:Paging.PagedCollections.PagedList`1"/>.</summary>
	public struct Enumerator : IEnumerator<T>
	{
#nullable disable
		private readonly PagedList<T> _list;
		private int _index;

		internal Enumerator(PagedList<T> list)
		{
			_list = list;
			_index = 0;
			Current = default(T);
		}

		/// <summary>Releases all resources used by the <see cref="T:Paging.PagedCollections.PagedList`1.Enumerator" />.</summary>
		public void Dispose()
		{
		}

		/// <summary>Advances the enumerator to the next element of the <see cref="T:System.Collections.Generic.List`1" />.</summary>
		/// <exception cref="T:System.InvalidOperationException">The collection was modified after the enumerator was created.</exception>
		/// <returns>
		/// <see langword="true" /> if the enumerator was successfully advanced to the next element; <see langword="false" /> if the enumerator has passed the end of the collection.</returns>
		public bool MoveNext()
		{
			var list = _list;

			if ((uint)_index >= (uint)list.PageCount)
				return MoveNextRare();

			Current = list._dataset[_index];
			++_index;
			return true;
		}

		private bool MoveNextRare()
		{
			_index = _list.PageCount + 1;
			Current = default;
			return false;
		}

#nullable enable
		/// <summary>Gets the element at the current position of the enumerator.</summary>
		/// <returns>The element in the <see cref="T:Paging.PagedCollections.PagedList`1" /> at the current position of the enumerator.</returns>
		public T Current { get; private set; }

		/// <summary>Gets the element at the current position of the enumerator.</summary>
		/// <exception cref="T:System.InvalidOperationException">The enumerator is positioned before the first element of the collection or after the last element.</exception>
		/// <returns>The element in the <see cref="T:Paging.PagedCollections.PagedList`1" /> at the current position of the enumerator.</returns>
		object? IEnumerator.Current
		{
			get
			{
				if (_index == 0 || _index == _list.PageCount + 1)
					throw new InvalidOperationException("Invalid Operation Enumerator Operation Can't Happen");
				return Current;
			}
		}

		/// <summary>Sets the enumerator to its initial position, which is before the first element in the collection.</summary>
		/// <exception cref="T:System.InvalidOperationException">The collection was modified after the enumerator was created.</exception>
		void IEnumerator.Reset()
		{
			_index = 0;
			Current = default;
		}
	}

	#endregion
}