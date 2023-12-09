using FluentAssertions;
using Paging.Pagers;

namespace PagingTests.PagerTests;

public class PagerCopyConstructorTests
{
	#region Happy path

	[Fact]
	public void Test_CopyConstructor_CreatedSuccessfully()
	{
		// Arrange
		var pager = new Pager(1, 10, 100);
		
		// Act
		var copy = new Pager(pager);
		
		// Assert
		copy.Should().NotBeNull();
		copy.PageNumber.Should().Be(pager.PageNumber);
		copy.PageSize.Should().Be(pager.PageSize);
		copy.TotalItemCount.Should().Be(pager.TotalItemCount);
		copy.PageCount.Should().Be(pager.PageCount);
		copy.HasPreviousPage.Should().Be(pager.HasPreviousPage);
		copy.HasNextPage.Should().Be(pager.HasNextPage);
		copy.IsFirstPage.Should().Be(pager.IsFirstPage);
		copy.IsLastPage.Should().Be(pager.IsLastPage);
	}

	#endregion

	#region Edge cases

	[Fact]
	public void Test_PagerNull_ThrowsNullReferenceException()
	{
		// Arrange
		var pager = new Pager(1, 10, 100);
		
		// Act
		Action act = () => new Pager(null);
		
		// Assert
		act.Should().Throw<NullReferenceException>();
	}

	#endregion
}