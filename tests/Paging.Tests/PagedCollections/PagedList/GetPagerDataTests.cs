using FluentAssertions;
using Paging.PagedCollections;

namespace Paging.Tests.PagedCollections.PagedList;

public class GetPagerDataTests
{
	[Fact]
	public void GetPagerData()
	{
		// Arrange
		var pager = Lab.DataSources.Pagers.PageNumberFirst;
		var pagedList = new PagedList<int>(
			Lab.DataSources.IntegerLists.Items50,
			pager
		);
		
		// Act
		var newPager = pagedList.GetPagerData();
		
		// Assert
		newPager.IsFirstPage.Should().Be(pager.IsFirstPage);
		newPager.IsLastPage.Should().Be(pager.IsLastPage);
		newPager.PageNumber.Should().Be(pager.PageNumber);
		newPager.PageSize.Should().Be(pager.PageSize);
		newPager.TotalItemCount.Should().Be(pager.TotalItemCount);
		newPager.PageCount.Should().Be(pager.PageCount);
		newPager.HasPreviousPage.Should().Be(pager.HasPreviousPage);
		newPager.HasNextPage.Should().Be(pager.HasNextPage);
	}
}