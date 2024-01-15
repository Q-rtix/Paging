using FluentAssertions;
using Paging.Extensions;

namespace Paging.Tests.UnitTests.PagedCollections.PagedList;

public class ThisIndexTests
{
	[Theory]
	[MemberData(nameof(ValidIndexes))]
	public void DirectIndexing_WithValidIndexes_ReturnsTheItemIndexed(int index)
	{
		// Arrange 
		var list = Lab.DataSources.IntegerLists.Items50;
		var pagedList = list.Paginated(Lab.DataSources.Pagers.PageNumberFirst);
		
		// Act
		var item = pagedList[index];
		
		// Assert
		item.Should().Be(list[index]);
	}
	
	[Theory]
	[MemberData(nameof(InvalidIndexes))]
	public void DirectIndexing(int index)
	{
		// Arrange 
		var pagedList = Lab.DataSources.IntegerLists.Items50.Paginated(Lab.DataSources.Pagers.PageNumberFirst);
		
		// Act
		var act = () =>
		{
			var item = pagedList[index];
		};
		
		// Assert
		act.Should().Throw<IndexOutOfRangeException>();
	}

	public static IEnumerable<object[]> ValidIndexes => new List<object[]>
	{
		new object[] { 0 },
		new object[] { 3 },
		new object[] { Lab.DataSources.Pagers.PageNumberFirst.PageCount },
	};
	
	public static IEnumerable<object[]> InvalidIndexes => new List<object[]>
	{
		new object[] { -1 },
		new object[] { Lab.DataSources.Pagers.PageNumberFirst.PageCount + 5 }
	};
}