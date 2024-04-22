---
_layout: landing
---

# Introduction

![NuGet Version](https://img.shields.io/nuget/v/Qrtix.Paging?logo=nuget)
![NuGet Downloads](https://img.shields.io/nuget/dt/Qrtix.Paging?style=flat&logo=nuget)
![GitHub Repo stars](https://img.shields.io/github/stars/Q-rtix/Paging?style=flat&logo=github)

The **Qrtix.Paging** library provides a robust solution for managing paginated collections of items in .NET
applications. Pagination is a common requirement in software development, especially for applications dealing with large
datasets or implementing user interfaces that display data in manageable chunks.

This library introduces the `PagedList<T>` class, which extends the functionality of the base `Pager` class and
implements the `IPagedList<T>` interface. This class encapsulates a paginated list of items along with essential
pagination information such as total item count, current page number, and page size.

By leveraging the `PagedList<T>` class, developers can efficiently handle pagination logic, simplifying the process of
fetching, navigating, and displaying data in a paginated manner. Whether it's rendering paginated data in web
applications, API responses, or any other scenario where data needs to be chunked for better user experience or
performance optimization, this library provides a versatile solution.

Key features of the **Qrtix.Paging** library include:

1. **Flexible Pagination:** The library offers flexibility in configuring pagination parameters such as page size and
   current page number, enabling developers to adapt pagination to diverse use cases and application requirements.
2. **Efficient Data Retrieval:** With the ability to efficiently fetch items for the current page from a data source, the
   `PagedList<T>` class optimizes data retrieval operations, ensuring optimal performance even with large datasets.
3. **Serialization Support:** The library supports JSON serialization, facilitating seamless integration with web APIs and
   serialization frameworks. Conditional compilation ensures compatibility with different JSON serialization libraries,
   enhancing interoperability across various development environments.
4. **Convenient Initialization:** Developers can easily create instances of the `PagedList<T>` class using constructors
   tailored for different scenarios, including initialization from a data source or based on existing pagination
   information.
5. **Enhanced Usability:** The `PagedList<T>` class exposes properties and methods for retrieving pagination metadata,
   iterating through items in the current page, and checking for emptiness, offering enhanced usability and versatility.

In summary, the **Qrtix.Paging** library empowers developers to implement efficient pagination solutions in their .NET
applications, streamlining the management and presentation of large datasets while maintaining flexibility and ease of
use. Whether it's building scalable web applications, APIs, or data-driven interfaces, this library serves as a valuable
tool for managing paginated data effectively.