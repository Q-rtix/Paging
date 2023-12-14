﻿namespace Paging.Pagers;

public class Pager : IPager
{
	#region Constructors

    public Pager(int pageNumber, int pageSize, int totalItemCount)
    {
        ParametersValidator(pageNumber, pageSize, totalItemCount);
    
        PageNumber = pageNumber;
        PageSize = pageSize;
        TotalItemCount = totalItemCount;
    
        PageCount = TotalItemCount > 0
            ? (TotalItemCount + PageSize - 1) / PageSize
            : 0;

        var pageNumberIsValid = PageCount > 0 && PageNumber <= PageCount;

        HasPreviousPage = pageNumberIsValid && PageNumber > 1;
        HasNextPage = pageNumberIsValid && PageNumber < PageCount;
        IsFirstPage = pageNumberIsValid && PageNumber == 1;
        IsLastPage = pageNumberIsValid && PageNumber == PageCount;
    }

	public Pager(IPager source, int? newTotalItemCount = null)
		: this(source.PageNumber, source.PageSize, newTotalItemCount ?? source.TotalItemCount)
	{
		
	}
	
	#endregion
	
	#region IPager Properties

	/// <summary>
	/// Total number of datasets within the data-source.
	/// </summary>
	/// <value>
	/// Total number of datasets within the data-source.
	/// </value>
	public int PageCount { get; }
	
	/// <summary>
	/// Total number of objects contained within the datasets.
	/// </summary>
	/// <value>
	/// Total number of objects contained within the data-source.
	/// </value>
	public int TotalItemCount { get; }
	
	/// <summary>
	/// One-based index of this subset within the data-source, zero if the data-source is empty.
	/// </summary>
	/// <value>
	/// One-based index of this subset within the data-source, zero if the data-source is empty.
	/// </value>
	public int PageNumber { get; private set; }

	/// <summary>
	/// Maximum size any individual subset.
	/// </summary>
	/// <value>
	/// Maximum size any individual subset.
	/// </value>
	public int PageSize { get; }
	
	/// <summary>
	/// Returns true if the data-source is not empty and PageNumber is less than or equal to PageCount and this
	/// is NOT the first subset within the data-source.
	/// </summary>
	/// <value>
	/// Returns true if the data-source is not empty and PageNumber is less than or equal to PageCount and this
	/// is NOT the first subset within the data-source.
	/// </value>
	public bool HasPreviousPage { get; private set; }

	/// <summary>
	/// Returns true if the data-source is not empty and PageNumber is less than or equal to PageCount and this
	/// is NOT the last subset within the data-source.
	/// </summary>
	/// <value>
	/// Returns true if the data-source is not empty and PageNumber is less than or equal to PageCount and this
	/// is NOT the last subset within the data-source.
	/// </value>
	public bool HasNextPage { get; private set; }

	/// <summary>
	/// Returns true if the data-source is not empty and PageNumber is less than or equal to PageCount and this
	/// is the first subset within the data-source.
	/// </summary>
	/// <value>
	/// Returns true if the data-source is not empty and PageNumber is less than or equal to PageCount and this
	/// is the first subset within the data-source.
	/// </value>
	public bool IsFirstPage { get; private set; }

	/// <summary>
	/// Returns true if the data-source is not empty and PageNumber is less than or equal to PageCount and this
	/// is the last subset within the data-source.
	/// </summary>
	/// <value>
	/// Returns true if the data-source is not empty and PageNumber is less than or equal to PageCount and this
	/// is the last subset within the data-source.
	/// </value>
	public bool IsLastPage { get; private set; }

	#endregion

	#region IPager Methods

	public void Next(int movePagesForward = 1)
		=> GoToPage(PageNumber + movePagesForward);

	public void Previous(int movePagesBackward = 1)
		=> GoToPage(PageNumber - movePagesBackward);

	public void First()
		=> GoToPage(1);

	public void Last()
		=> GoToPage(PageCount);

	public void GoToPage(int pageNumber)
	{
		var newPageNumber = pageNumber < 1 
			? 1 
			: pageNumber > PageCount
				? PageCount
				: pageNumber;

		PageNumber = newPageNumber;
		
		HasPreviousPage = PageNumber > 1;
		HasNextPage = PageNumber < PageCount;
		IsFirstPage = PageNumber == 1;
		IsLastPage =  PageNumber == PageCount;
	}

	#endregion

	#region Private methods

	private static void ParametersValidator(int pageNumber, int pageSize, int totalItemCount)
	{
		if (pageNumber < 1)
			throw new ArgumentOutOfRangeException(null, $"pageNumber = {pageNumber}. PageNumber cannot be below 1.");

		if (pageSize < 1)
			throw new ArgumentOutOfRangeException(null, $"pageSize = {pageSize}. PageSize cannot be less than 1.");

		if (totalItemCount < 0)
			throw new ArgumentOutOfRangeException(null, $"totalItemCount = {totalItemCount}. TotalItemCount cannot be less than 0.");
	}

	#endregion
}