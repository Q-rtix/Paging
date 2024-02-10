# Using PagedList

The `PagedList` class in the Qrtix.Paging library provides a convenient way to paginate large collections of data efficiently. Here's how you can use it:

## Instantiate a PagedList:

```csharp
// Assuming you have a list of items named 'sourceList' and a page size of 10
var pagedList = new PagedList<T>(sourceList, pageNumber, pageSize);
```

## Access Paginated Data:

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

## Retrieve Pagination Information:

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

