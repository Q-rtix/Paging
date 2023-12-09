using FluentAssertions;
using Paging.Pagers;

namespace PagingTests.PagerTests;

public class PagerParametersConstructorTests
{
	#region Happy Path

	// Constructor initializes PageNumber, PageSize, TotalItemCount, PageCount, HasPreviousPage, HasNextPage, IsFirstPage, IsLastPage
	[Fact]
	public void Test_ParametersValid_CreatedSuccessfully()
	{
		// Arrange
		const int pageNumber = 1;
		const int pageSize = 10;
		const int totalItemCount = 100;
		
		// Act
		var pager = new Pager(pageNumber, pageSize, totalItemCount);
		
		// Assert
		pager.Should().NotBeNull();
		pager.PageNumber.Should().Be(1);
		pager.PageSize.Should().Be(10);
		pager.TotalItemCount.Should().Be(totalItemCount);
		pager.PageCount.Should().Be(10);
		pager.HasPreviousPage.Should().BeFalse();
		pager.HasNextPage.Should().BeTrue();
		pager.IsFirstPage.Should().BeTrue();
		pager.IsLastPage.Should().BeFalse();
	}
	
	// PageCount is 0 and all other parameters are valid
	[Fact]
	public void Test_PageCountIsZero_CreatedSuccessfully()
	{
		// Arrange
		const int pageNumber = 1;
		const int pageSize = 10;
		const int totalItemCount = 0;

		// Act
		var pager = new Pager(pageNumber, pageSize, totalItemCount);

		// Assert
		pager.PageCount.Should().Be(0);
		pager.PageNumber.Should().Be(pageNumber);
		pager.PageSize.Should().Be(pageSize);
		pager.TotalItemCount.Should().Be(totalItemCount);
		pager.HasPreviousPage.Should().BeFalse();
		pager.HasNextPage.Should().BeFalse();
		pager.IsFirstPage.Should().BeFalse();
		pager.IsLastPage.Should().BeFalse();
	}
	
	// TotalItemCount is 0 and all other parameters are valid
	[Fact]
	public void Test_TotalItemCountIsZeroAndOtherParametersAreValid_CreatedSuccessfully()
	{
		// Arrange
		const int pageNumber = 1;
		const int pageSize = 10;
		const int totalItemCount = 0;

		// Act
		var pager = new Pager(pageNumber, pageSize, totalItemCount);

		// Assert
		pager.PageCount.Should().Be(0);
		pager.TotalItemCount.Should().Be(0);
		pager.PageNumber.Should().Be(1);
		pager.PageSize.Should().Be(10);
		pager.HasPreviousPage.Should().BeFalse();
		pager.HasNextPage.Should().BeFalse();
		pager.IsFirstPage.Should().BeFalse();
		pager.IsLastPage.Should().BeFalse();
	}

	#endregion

	#region Edge Cases

	// PageNumber is less than 1
	[Fact]
	public void Test_PageNumberLessThan1_ThrowsArgumentOutOfRangeException()
	{
		// Arrange
		const int pageNumber = -1;
		const int pageSize = 10;
		const int totalItemCount = 50;

		// Act & Assert
		Action act = () => new Pager(pageNumber, pageSize, totalItemCount);

		act.Should().Throw<ArgumentOutOfRangeException>()
			.WithMessage("pageNumber = -1. PageNumber cannot be below 1.");
	}

	// PageSize is less than 1
	[Fact]
	public void Test_PageSizeLessThan1_ThrowsArgumentOutOfRangeException()
	{
		// Arrange
		const int pageNumber = 2;
		const int pageSize = -1;
		const int totalItemCount = 50;

		// Act & Assert
		Action act = () => new Pager(pageNumber, pageSize, totalItemCount);

		act.Should().Throw<ArgumentOutOfRangeException>()
			.WithMessage("pageSize = -1. PageSize cannot be less than 1.");
	}

	// TotalItemCount is less than 0
	[Fact]
	public void Test_TotalItemCountLessThan0_ThrowsArgumentOutOfRangeException()
	{
		// Arrange
		const int pageNumber = 2;
		const int pageSize = 10;
		const int totalItemCount = -1;

		// Act & Assert
		Action act = () => new Pager(pageNumber, pageSize, totalItemCount);

		act.Should().Throw<ArgumentOutOfRangeException>()
			.WithMessage("totalItemCount = -1. TotalItemCount cannot be less than 0.");
	}

	#endregion
}