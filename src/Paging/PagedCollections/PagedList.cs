using System.Collections;
using Paging.Pagers;

namespace Paging.PagedCollections;

public sealed class PagedList<T> : Pager, IPagedList<T>
{
	private readonly List<T> _dataset;
	
	#region Constructors

	public PagedList(IQueryable<T> dataSource, int pageNumber, int pageSize)
		: base(pageNumber, pageSize, dataSource?.Count() ?? 0)
	{
		if (TotalItemCount <= 0 || dataSource == null)
			throw new ArgumentNullException(nameof(dataSource), "source cannot be null.");
		
		var pageNumberIsGood = PageCount > 0 && PageNumber <= PageCount;
		var numberOfFirstItemOnPage = (PageNumber - 1) * PageSize + 1;
		var numberOfLastItemOnPage = numberOfFirstItemOnPage + PageSize - 1;
		
		FirstItemOnPage = pageNumberIsGood ? numberOfFirstItemOnPage : 0;
		LastItemOnPage = pageNumberIsGood
			? numberOfLastItemOnPage > TotalItemCount
				? TotalItemCount
				: numberOfLastItemOnPage
			: 0;

		var skip = (pageNumber - 1) * pageSize;
		_dataset = new List<T>();
		_dataset.AddRange(dataSource.Skip(skip).Take(pageSize));
	}
    
    public PagedList(IQueryable<T> dataSource, IPager pager)
		: base(pager)
	{
		if (TotalItemCount <= 0 || dataSource == null)
			throw new ArgumentNullException(nameof(dataSource), "source cannot be null.");
		
		var pageNumberIsGood = PageCount > 0 && PageNumber <= PageCount;
		var numberOfFirstItemOnPage = (PageNumber - 1) * PageSize + 1;
		var numberOfLastItemOnPage = numberOfFirstItemOnPage + PageSize - 1;
		
		FirstItemOnPage = pageNumberIsGood ? numberOfFirstItemOnPage : 0;
		LastItemOnPage = pageNumberIsGood
			? numberOfLastItemOnPage > TotalItemCount
				? TotalItemCount
				: numberOfLastItemOnPage
			: 0;

		var skip = (PageNumber - 1) * PageSize;
		_dataset = new List<T>();
		_dataset.AddRange(dataSource.Skip(skip).Take(PageSize));
    }

	#endregion

	#region IPagedList Properties

	public Pager Pager => new (this);
	
	public int Count => _dataset.Count;
	public int FirstItemOnPage { get; }
	public int LastItemOnPage { get; }

	#endregion

	#region IPagedList implementation

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