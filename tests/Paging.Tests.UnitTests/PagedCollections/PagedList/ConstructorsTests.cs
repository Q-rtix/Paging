using FluentAssertions;
using Paging.PagedCollections;
using Paging.Pagers;

namespace Paging.Tests.UnitTests.PagedCollections.PagedList;

public class ConstructorsTests
{
	#region Happy Paths

	[Fact]
	public void ParamConstructor_UsingParametersValid_PagedListCreated()
	{
		// Arrange
		var list = Lab.DataSources.IntegerLists.Items50;
		var pager = Lab.DataSources.Pagers.PageNumberFirst;
		
		// Act 
		var pagedList = new PagedList<int>(list, pager.PageNumber, pager.PageSize);
		
		// Assert
		pagedList.Should().NotBeNull();
		pagedList.IsEmpty.Should().BeFalse();
		pagedList.PageNumber.Should().Be(pager.PageNumber);
		pagedList.PageSize.Should().Be(pager.PageSize);
		pagedList.TotalItemCount.Should().Be(pager.TotalItemCount);
		pagedList.PageCount.Should().Be(pager.PageCount);
		pagedList.HasPreviousPage.Should().BeFalse();
		pagedList.HasNextPage.Should().BeTrue();
		pagedList.IsFirstPage.Should().BeTrue();
		pagedList.IsLastPage.Should().BeFalse();
	}
	
	[Fact]
	public void ParamConstructor_NonNullButEmptyDataSource_EmptyPagedListCreated()
	{
		// Arrange
		var emptyList = Lab.DataSources.IntegerLists.Empty;
		var pager = Lab.DataSources.Pagers.PageNumberFirst;
		
		// Act
		var pagedList = new PagedList<int>(emptyList, pager.PageNumber, pager.PageSize);

		// Assert
		pagedList.Should().NotBeNull();
		pagedList.Count.Should().Be(0);
		pagedList.IsEmpty.Should().BeTrue();
		pagedList.PageNumber.Should().Be(pager.PageNumber);
		pagedList.PageSize.Should().Be(pager.PageSize);
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
		// Arrange
		var pager = Lab.DataSources.Pagers.PageNumberFirst;
		var list = Lab.DataSources.IntegerLists.Items50;
		
		// Act
		var pagedList = new PagedList<int>(list, pager);
		
		// Assert
		pagedList.Should().NotBeNull();
		pagedList.IsEmpty.Should().BeFalse();
		pagedList.PageNumber.Should().Be(pager.PageNumber);
		pagedList.PageSize.Should().Be(pager.PageSize);
		pagedList.TotalItemCount.Should().Be(pager.TotalItemCount);
		pagedList.PageCount.Should().Be(pager.PageCount);
		pagedList.HasPreviousPage.Should().BeFalse();
		pagedList.HasNextPage.Should().BeTrue();
		pagedList.IsFirstPage.Should().BeTrue();
		pagedList.IsLastPage.Should().BeFalse();
	}
	
	[Fact]
	public void ParamConstructor_NonNullButEmptyDataSourceAndPagerValid_EmptyPagedListCreated()
	{
		// Arrange
		var emptyList = Lab.DataSources.IntegerLists.Empty;
		var pager = Lab.DataSources.Pagers.PageNumberFirst;
		
		// Act
		var pagedList = new PagedList<int>(emptyList, pager);

		// Assert
		pagedList.Should().NotBeNull();
		pagedList.Count.Should().Be(0);
		pagedList.IsEmpty.Should().BeTrue();
		pagedList.PageNumber.Should().Be(pager.PageNumber);
		pagedList.PageSize.Should().Be(pager.PageSize);
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
	
	[Fact]
	public void EmptyCopyConstructor_EmptyPagedListCreated()
	{
		// Act
		var emptyPagedList = PagedList<int>.Empty(Lab.DataSources.Pagers.PageNumberFirst);
		
		// Assert
		emptyPagedList.Should().NotBeNull();
		emptyPagedList.Count.Should().Be(0);
		emptyPagedList.IsEmpty.Should().BeTrue();
		emptyPagedList.PageNumber.Should().Be(1);
		emptyPagedList.PageSize.Should().Be(Lab.DataSources.Pagers.PageNumberFirst.PageSize);
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
		var pager = Lab.DataSources.Pagers.PageNumberFirst;

		// Act
		Action act = () => new PagedList<int>(dataSource, pager.PageNumber, pager.PageSize);
		
		// Assert
		act.Should().Throw<ArgumentNullException>()
			.WithMessage("dataSource cannot be null. (Parameter 'dataSource')");
	}
	
	[Fact]
	public void ParamConstructor_UsingAPagerValid_WhenDataSourceIsNull_ThrowsArgumentNullException()
	{
		// Arrange
		List<int>? dataSource = null;

		// Act
		Action act = () => new PagedList<int>(dataSource, Lab.DataSources.Pagers.PageNumberFirst);
		
		// Assert
		act.Should().Throw<ArgumentNullException>()
			.WithMessage("dataSource cannot be null. (Parameter 'dataSource')");
	}

	#endregion
}