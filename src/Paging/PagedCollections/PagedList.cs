using System.Collections;
using Paging.Pagers;

namespace Paging.PagedCollections;

public sealed class PagedList<T> : Pager, IPagedList<T>
{
	private readonly List<T> _dataset = [];

	#region Constructors

	public static PagedList<T> Empty(int pageSize = 10)
		=> new(Array.Empty<T>(), 1, pageSize);

	public static PagedList<T> Empty(IPager pager)
		=> new(Array.Empty<T>(), pager);

	public PagedList(IEnumerable<T> dataSource, int pageNumber, int pageSize)
		: base(pageNumber, pageSize, dataSource?.Count() ?? 0)
			=> GetPage(
				dataSource ?? throw new ArgumentNullException(nameof(dataSource), "dataSource cannot be null."),
				pageNumber,
				pageSize
			);

	public PagedList(IEnumerable<T> dataSource, IPager pager)
		: this(dataSource, pager.PageNumber, pager.PageSize)
	{
	}

	#endregion

	#region IPagedList Properties

	public bool IsEmpty => TotalItemCount == 0;
	public int Count => _dataset.Count;

	#endregion

	#region IPagedList implementation

	public Pager GetPagerData() => new(this);

	IEnumerator IEnumerable.GetEnumerator()
	{
		yield return GetEnumerator();
	}

	public IEnumerator<T> GetEnumerator()
	{
		return _dataset.GetEnumerator();
	}

	public T this[int index] => _dataset[index];

	#endregion

	#region Private Methods

	private void GetPage(IEnumerable<T> dataSource, int pageNumber, int pageSize)
	{
		var skip = (pageNumber - 1) * pageSize;
		_dataset.AddRange(dataSource.Skip(skip).Take(pageSize));
	}

	#endregion
}