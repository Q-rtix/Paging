using System.Collections;
using Paging.Pagers;

namespace Paging.PagedCollections;

public sealed class PagedList<T> : Pager, IPagedList<T>
{
	private readonly List<T> _dataset;
	
	#region Constructors

	public static PagedList<T> Empty(int pageSize = 10)
		=> new(Array.Empty<T>(), 1, pageSize);

	public PagedList(IQueryable<T> dataSource, int pageNumber, int pageSize)
		: base(pageNumber, pageSize, dataSource?.Count() ?? 0)
	{
		if (TotalItemCount < 0 || dataSource == null)
			throw new ArgumentNullException(nameof(dataSource), "source cannot be null.");

		var skip = (pageNumber - 1) * pageSize;
		_dataset = new List<T>();
		_dataset.AddRange(dataSource.Skip(skip).Take(pageSize));
	}
	
	public PagedList(IEnumerable<T> dataSource, int pageNumber, int pageSize)
		: base(pageNumber, pageSize, dataSource?.Count() ?? 0)
	{
		if (dataSource == null)
			throw new ArgumentNullException(nameof(dataSource), "source cannot be null.");

		var skip = (pageNumber - 1) * pageSize;
		_dataset = new List<T>();
		_dataset.AddRange(dataSource.Skip(skip).Take(pageSize));
	}
    
    public PagedList(IQueryable<T> dataSource, IPager pager)
		: base(pager)
	{
		if (TotalItemCount <= 0 || dataSource == null)
			throw new ArgumentNullException(nameof(dataSource), "source cannot be null.");
	
		var skip = (PageNumber - 1) * PageSize;
		_dataset = new List<T>();
		_dataset.AddRange(dataSource.Skip(skip).Take(PageSize));
    }
	
	public PagedList(IEnumerable<T> dataSource, IPager pager)
		: base(pager)
	{
		if (TotalItemCount <= 0 || dataSource == null)
			throw new ArgumentNullException(nameof(dataSource), "source cannot be null.");

		var skip = (PageNumber - 1) * PageSize;
		_dataset = new List<T>();
		_dataset.AddRange(dataSource.Skip(skip).Take(PageSize));
	}

	#endregion

	#region IPagedList Properties
	
	public bool IsEmpty => TotalItemCount == 0;
	public int Count => _dataset.Count;

	#endregion

	#region IPagedList implementation
	
	public Pager GetPagerData() => new (this);

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
	
}