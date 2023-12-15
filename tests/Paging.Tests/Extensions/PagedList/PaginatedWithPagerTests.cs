using FluentAssertions;
using Paging.Extensions;

namespace Paging.Tests.Extensions.PagedList;

public class PaginatedWithPagerTests
{
	[Fact]
	public void Paginated()
	{
		// Act
		var pagedList = Lab.DataSources.IntegerLists.Items50.Paginated(Lab.DataSources.Pagers.PageNumberFirst);
		
		// Assert
		pagedList.PageNumber.Should().Be(2);
		pagedList.PageSize.Should().Be(10);
		pagedList.TotalItemCount.Should().Be(50);
		pagedList.Count.Should().Be(10);
		pagedList.IsLastPage.Should().BeFalse();
		pagedList.IsFirstPage.Should().BeFalse();
		pagedList.HasPreviousPage.Should().BeTrue();
		pagedList.HasNextPage.Should().BeTrue();
	}
}