using System.Collections;
using Paging.Pagers;

namespace Paging.PagedCollections;

public sealed class PagedList<T> : Pager, IPagedList<T>
{
	private readonly List<T> _subset;
	
	#region Constructors

	public PagedList(IQueryable<T> dataset, int pageNumber, int pageSize)
		: base(pageNumber, pageSize, dataset?.Count() ?? 0)
	{
		if (TotalItemCount <= 0 || dataset == null)
			throw new ArgumentNullException(nameof(dataset), "source cannot be null.");
		
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
		_subset = new List<T>();
		_subset.AddRange(dataset.Skip(skip).Take(pageSize));
	}

	#endregion

	#region IPagedList Properties

	public Pager Pager => new (this);
	
	public int Count => _subset.Count;
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
		return _subset.GetEnumerator();
	}

	public T this[int index] => _subset[index];

	#endregion
	
}