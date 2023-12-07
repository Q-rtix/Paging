# Pagination Library 

This C# library provides functionality for implementing paginated lists.

## Table Of Contents

- [Installation](#installation)
- [PaginatedList<T> Class](#paginatedlistt-class)
  - [Properties](#properties)
  - [Constructors](#constructors)
- [PaginatedListExtensions Class](#paginatedlistextension-class)
  - [Static Methods](#static-methods)
- [How to use the `PaginatedList<T>` class](#how-to-use-the-paginatedlistt-class)

## Installation

Using the NuGet package manager console within Visual Studio run the following command:

```
Install-Package QDev.CSharp.Pagination.PaginatedList
```

Or using the .NET Core CLI from a terminal window:

```
dotnet add package QDev.CSharp.Pagination.PaginatedList
```

## PaginatedList<T> Class

Represents a paginated list of items.

### Properties

| Property          | Description                                                             |
|-------------------|-------------------------------------------------------------------------|
| `PageIndex`       | Gets the current index page.                                            |
| `TotalPages`      | Gets the total number of pages.                                         |
| `TotalCount`      | Gets the total number of items.                                         |
| `HasPreviousPage` | Gets a value indicating whether the paginated list has a previous page. |
| `HasNextPage`     | Gets a value indicating whether the paginated list has a next page.     |

### Constructors

| Constructor                                                                   | Description                                                 |
|-------------------------------------------------------------------------------|-------------------------------------------------------------|
| `PaginatedList(IEnumerable<T> items, int count, int pageIndex, int pageSize)` | Initializes a new instance of the `PaginatedList<T>` class. |

#### Example
```csharp
var items = GetList(); // this return a huge list of items of intergers
var paginatedList = new PaginatedList<int>(items, count, pageIndex, pageSize);
```

## PaginatedListExtension Class

### Static Methods

| Method                                                                                                | Description                                                            |
|-------------------------------------------------------------------------------------------------------|------------------------------------------------------------------------|
| `Create(IQueryable<T> source, int pageIndex, int pageSize)`                                           | Creates a new instance of the `PaginatedList<T>` class.                |
| `CreateAsync(IQueryable<T> source, int pageIndex, int pageSize, CancellationToken cancellationToken)` | Asynchronously creates a new instance of the `PaginatedList<T>` class. |

> **Note:** Replace `T` with the actual type of the items you want to paginate.

#### Example
```csharp
var items = GetList(); // this return a huge list of items of intergers
var paginatedList = PaginatedList<int>.Create(source, pageIndex, pageSize);
var paginatedListAsync = await PaginatedList<int>.CreateAsync(source, pageIndex, pageSize, cancellationToken);
```

### How to use the `PaginatedList<T>` class

Here's an example of how to use the `PaginatedList<T>` class:

```csharp
// Create a sample list of items
var items = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

// Set the pagination parameters
int pageIndex = 1;
int pageSize = 3;

// Create a paginated list
var pl1 = new PaginatedList<int>(items, pageIndex, pageSize); // using the constructor
var pl2 = items.ToPaginatedList(pageIndex, pageSize); // using the `ToPaginatedList` extension method

// Access the paginated list properties
Console.WriteLine($"Page {pl1.PageIndex} of {pl1.TotalPages}");
Console.WriteLine($"Total Items: {pl1.TotalCount}");

// Iterate through the paginated list
foreach (var item in pl1)
{
    Console.WriteLine(item);
}

// Check if the paginated list has a previous or next page
if (pl1.HasPreviousPage)
{
    Console.WriteLine("Has Previous Page");
}

if (pl1.HasNextPage)
{
    Console.WriteLine("Has Next Page");
}
```
