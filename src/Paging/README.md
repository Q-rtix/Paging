# Paging Library

This C# library provides functionality for implementing paged lists.
Consult the online [documentation](https://qrtix769.github.io/Paging/) for more details.

- [Getting Started](#getting-started)
- [Using PagedList](#using-pagedlist)
- [Contributing](#contributing)


## Getting Started

Using the NuGet package manager console within Visual Studio run the following command:

```
Install-Package Qrtix.Paging
```

Or using the .NET Core CLI from a terminal window:

```
dotnet add package Qrtix.Paging
```

## Using PagedList

The `PagedList` class in the Qrtix.Paging library provides a convenient way to paginate large collections of data efficiently. Here's how you can use it:

### Instantiate a PagedList:

```csharp
// Assuming you have a list of items named 'sourceList' and a page size of 10
var pagedList = new PagedList<T>(sourceList, pageNumber, pageSize);
```

### Access Paginated Data:

You can access the data in the paged list using indexers or enumeration:

```csharp
// Accessing items using indexer
var item = pagedList[index];

// Enumerating through the paged list
foreach (var item in pagedList)
{
    // Process each item
}

// Using for loop
for (int i = 0; i < pagedList.Count; i++)
{
    var item = pagedList[i];
    // Process each item
}
```

### Retrieve Pagination Information:

You can also retrieve pagination-related information such as the total number of pages, total items, etc.:

```csharp
// Total number of items
var totalItems = pagedList.TotalItemCount;

// Total number of pages
var totalPages = pagedList.PageCount;

// Current page number
var currentPage = pagedList.PageNumber;

// Page size
var pageSize = pagedList.PageSize;
```

## Contributing

**Did you find a bug?**

- Ensure the bug was not already reported by searching on GitHub
  under [Issues](https://github.com/Qrtix769/Paging/issues).
- If you're unable to find an open issue addressing the
  problem, [open a new one](https://github.com/Qrtix769/Paging/issues/new). Be sure to include a title and clear
  description, as much relevant information as possible, and a code sample or an executable test case demonstrating the
  expected behavior that is not occurring.

**Did you write a patch that fixes a bug?**

- Open a new GitHub pull request with the patch.
- Ensure the PR description clearly describes the problem and solution. Include the relevant issue number if applicable.

**Do you intend to add a new feature or change an existing one?**

- First suggest your change in the [Paging ideas page](https://github.com/Qrtix769/Paging/discussions/categories/ideas)
  for discussion.
- There are no fixed rules on what should and shouldn't be in this library, but some features are more valuable than
  others, and some require long-term maintenance that outweighs the value of the feature. So please get sign-off from
  the
  project leader (Carlos J. Ortiz) before putting in an excessive amount of work.

**Do you have questions about the source code?**

- Ask any question about how to use Paging in
  the [Paging discussion page](https://github.com/Qrtix769/Paging/discussions/new?category=q-a).