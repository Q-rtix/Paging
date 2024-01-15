using FluentAssertions;
using Paging.Pagers;

namespace Paging.Tests.UnitTests.Pagers;

public class PagerConstructorsTests
{
	#region Happy Path

	// Constructor initializes PageNumber, PageSize, TotalItemCount, PageCount, HasPreviousPage, HasNextPage, IsFirstPage, IsLastPage
	[Fact]
	public void ParamConstructor_ParametersValid_CreatedSuccessfully()
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
	public void ParamConstructor_PageCountIsZero_CreatedSuccessfully()
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
	public void ParamConstructor_TotalItemCountIsZeroAndOtherParametersAreValid_CreatedSuccessfully()
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
	
	[Fact]
	public void CopyConstructor_CreatedSuccessfully()
	{
		// Arrange
		var pager = Lab.DataSources.Pagers.PageNumberFirst;
		
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
	
	[Fact]
	public void CopyConstructor_WithNewTotalItemCount_CreatedSuccessfully()
	{
		// Arrange
		var pager = Lab.DataSources.Pagers.PageNumberFirst;
		
		// Act
		var copy = new Pager(pager, 25);
		
		// Assert
		copy.Should().NotBeNull();
		copy.PageNumber.Should().Be(pager.PageNumber);
		copy.PageSize.Should().Be(pager.PageSize);
		copy.TotalItemCount.Should().Be(25);
		copy.PageCount.Should().Be(3);
		copy.HasPreviousPage.Should().Be(pager.HasPreviousPage);
		copy.HasNextPage.Should().Be(pager.HasNextPage);
		copy.IsFirstPage.Should().Be(pager.IsFirstPage);
		copy.IsLastPage.Should().Be(pager.IsLastPage);
	}

	#endregion

	#region Edge Cases

	// PageNumber is less than 1
	[Fact]
	public void ParamConstructor_PageNumberLessThan1_ThrowsArgumentOutOfRangeException()
	{
		// Arrange
		const int pageNumber = -1;
		const int pageSize = 10;
		const int totalItemCount = 50;

		// Act
		Action act = () => new Pager(pageNumber, pageSize, totalItemCount);

		// Assert
		act.Should().Throw<ArgumentOutOfRangeException>()
			.WithMessage("pageNumber = -1. PageNumber cannot be below 1.");
	}

	// PageSize is less than 1
	[Fact]
	public void ParamConstructor_PageSizeLessThan1_ThrowsArgumentOutOfRangeException()
	{
		// Arrange
		const int pageNumber = 2;
		const int pageSize = -1;
		const int totalItemCount = 50;

		// Act
		Action act = () => new Pager(pageNumber, pageSize, totalItemCount);

		// Assert
		act.Should().Throw<ArgumentOutOfRangeException>()
			.WithMessage("pageSize = -1. PageSize cannot be less than 1.");
	}

	// TotalItemCount is less than 0
	[Fact]
	public void ParamConstructor_TotalItemCountLessThan0_ThrowsArgumentOutOfRangeException()
	{
		// Arrange
		const int pageNumber = 2;
		const int pageSize = 10;
		const int totalItemCount = -1;

		// Act
		Action act = () => new Pager(pageNumber, pageSize, totalItemCount);

		// Assert
		act.Should().Throw<ArgumentOutOfRangeException>()
			.WithMessage("totalItemCount = -1. TotalItemCount cannot be less than 0.");
	}
	
	[Fact]
	public void CopyConstructor_PagerNull_ThrowsNullReferenceException()
	{
		// Act
		Action act = () => new Pager(null);
		
		// Assert
		act.Should().Throw<NullReferenceException>();
	}

	#endregion
}