namespace Paging.Pagers;

public class Pager : IPager
{
	#region Constructors

	protected internal Pager() { }

	protected internal Pager(int pageNumber, int pageSize, int totalItemCount)
	{
		if (pageNumber < 1)
			throw new ArgumentOutOfRangeException(nameof(pageNumber), $"pageNumber = {pageNumber}. PageNumber cannot be below 1.");

		if (pageSize < 1)
			throw new ArgumentOutOfRangeException(nameof(pageSize), $"pageSize = {pageSize}. PageSize cannot be less than 1.");

		if (totalItemCount < 0)
			throw new ArgumentOutOfRangeException(nameof(totalItemCount), $"totalItemCount = {totalItemCount}. TotalItemCount cannot be less than 0.");
		
		PageNumber = pageNumber;
		PageSize = pageSize;
		TotalItemCount = totalItemCount;
		
		PageCount = TotalItemCount > 0
			? (int)Math.Ceiling(TotalItemCount / (double)PageSize)
			: 0;

		var pageNumberIsGood = PageCount > 0 && PageNumber <= PageCount;

		HasPreviousPage = pageNumberIsGood && PageNumber > 1;
		HasNextPage = pageNumberIsGood && PageNumber < PageCount;
		IsFirstPage = pageNumberIsGood && PageNumber == 1;
		IsLastPage = pageNumberIsGood && PageNumber == PageCount;
	}

	protected internal Pager(IPager source)
	{
		PageNumber = source.PageNumber;
		PageSize = source.PageSize;
		TotalItemCount = source.TotalItemCount;
		PageCount = source.PageCount;
		HasPreviousPage = source.HasPreviousPage;
		HasNextPage = source.HasNextPage;
		IsFirstPage = source.IsFirstPage;
		IsLastPage = source.IsLastPage;
	}

	#endregion

	#region IPager implementation

	public int PageCount { get; }
	public int TotalItemCount { get; }
	public int PageNumber { get; }
	public int PageSize { get; }
	public bool HasPreviousPage { get; }
	public bool HasNextPage { get; }
	public bool IsFirstPage { get; }
	public bool IsLastPage { get; }

	#endregion
}