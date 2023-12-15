using FluentAssertions;
using Paging.PagedCollections;
using Paging.Pagers;

namespace Paging.Tests.PagedCollections.PagedList;

public class PagedListConstructorsTests
{
	private readonly Pager _pager = new(1, 10, 50);
	private readonly List<int> _validList =
	[
		1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24,
		25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50
	];
	private readonly List<int> _emptyList = [];

	#region Happy Paths

	[Fact]
	public void ParamConstructor_UsingParametersValid_PagedListCreated()
	{
		// Act 
		var pagedList = new PagedList<int>(_validList, _pager.PageNumber, _pager.PageSize);
		
		// Assert
		pagedList.Should().NotBeNull();
		pagedList.IsEmpty.Should().BeFalse();
		pagedList.PageNumber.Should().Be(_pager.PageNumber);
		pagedList.PageSize.Should().Be(_pager.PageSize);
		pagedList.TotalItemCount.Should().Be(_pager.TotalItemCount);
		pagedList.PageCount.Should().Be(_pager.PageCount);
		pagedList.HasPreviousPage.Should().BeFalse();
		pagedList.HasNextPage.Should().BeTrue();
		pagedList.IsFirstPage.Should().BeTrue();
		pagedList.IsLastPage.Should().BeFalse();
	}
	
	[Fact]
	public void ParamConstructor_NonNullButEmptyDataSource_EmptyPagedListCreated()
	{
		// Act
		var pagedList = new PagedList<int>(_emptyList, _pager.PageNumber, _pager.PageSize);

		// Assert
		pagedList.Should().NotBeNull();
		pagedList.Count.Should().Be(0);
		pagedList.IsEmpty.Should().BeTrue();
		pagedList.PageNumber.Should().Be(_pager.PageNumber);
		pagedList.PageSize.Should().Be(_pager.PageSize);
		pagedList.TotalItemCount.Should().Be(0);
		pagedList.PageCount.Should().Be(0);
		pagedList.HasPreviousPage.Should().BeFalse();
		pagedList.HasNextPage.Should().BeFalse();
		pagedList.IsFirstPage.Should().BeFalse();
		pagedList.IsLastPage.Should().BeFalse();
	}
	
	[Fact]
	public void ParamConstructor_UsingPagerValid_PagedListCreated()
	{
		// Act
		var pagedList = new PagedList<int>(_validList, _pager);
		
		// Assert
		pagedList.Should().NotBeNull();
		pagedList.IsEmpty.Should().BeFalse();
		pagedList.PageNumber.Should().Be(_pager.PageNumber);
		pagedList.PageSize.Should().Be(_pager.PageSize);
		pagedList.TotalItemCount.Should().Be(_pager.TotalItemCount);
		pagedList.PageCount.Should().Be(_pager.PageCount);
		pagedList.HasPreviousPage.Should().BeFalse();
		pagedList.HasNextPage.Should().BeTrue();
		pagedList.IsFirstPage.Should().BeTrue();
		pagedList.IsLastPage.Should().BeFalse();
	}
	
	[Fact]
	public void ParamConstructor_NonNullButEmptyDataSourceAndPagerValid_EmptyPagedListCreated()
	{
		// Act
		var pagedList = new PagedList<int>(_emptyList, _pager);

		// Assert
		pagedList.Should().NotBeNull();
		pagedList.Count.Should().Be(0);
		pagedList.IsEmpty.Should().BeTrue();
		pagedList.PageNumber.Should().Be(_pager.PageNumber);
		pagedList.PageSize.Should().Be(_pager.PageSize);
		pagedList.TotalItemCount.Should().Be(0);
		pagedList.PageCount.Should().Be(0);
		pagedList.HasPreviousPage.Should().BeFalse();
		pagedList.HasNextPage.Should().BeFalse();
		pagedList.IsFirstPage.Should().BeFalse();
		pagedList.IsLastPage.Should().BeFalse();
	}

	[Fact]
	public void EmptyConstructor_EmptyPagedListCreated()
	{
		// Act
		var emptyPagedList = PagedList<int>.Empty(20);
		
		// Assert
		emptyPagedList.Should().NotBeNull();
		emptyPagedList.Count.Should().Be(0);
		emptyPagedList.IsEmpty.Should().BeTrue();
		emptyPagedList.PageNumber.Should().Be(1);
		emptyPagedList.PageSize.Should().Be(20);
		emptyPagedList.TotalItemCount.Should().Be(0);
		emptyPagedList.PageCount.Should().Be(0);
		emptyPagedList.HasPreviousPage.Should().BeFalse();
		emptyPagedList.HasNextPage.Should().BeFalse();
		emptyPagedList.IsFirstPage.Should().BeFalse();
		emptyPagedList.IsLastPage.Should().BeFalse();
	}

	#endregion

	#region Edge Cases
	
	[Fact]
	public void ParamConstructor_WhenDataSourceIsNull_ThrowsArgumentNullException()
	{
		// Arrange
		List<int>? dataSource = null;

		// Act
		Action act = () => new PagedList<int>(dataSource, _pager.PageNumber, _pager.PageSize);
		
		// Assert
		act.Should().Throw<ArgumentNullException>()
			.WithMessage("source cannot be null. (Parameter 'dataSource')");
	}
	
	[Fact]
	public void ParamConstructor_UsingAPagerValid_WhenDataSourceIsNull_ThrowsArgumentNullException()
	{
		// Arrange
		List<int>? dataSource = null;

		// Act
		Action act = () => new PagedList<int>(dataSource, _pager);
		
		// Assert
		act.Should().Throw<ArgumentNullException>()
			.WithMessage("source cannot be null. (Parameter 'dataSource')");
	}

	#endregion
}