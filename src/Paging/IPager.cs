// ReSharper disable once CheckNamespace
namespace Qrtix.Paging;

public interface IPager
{
	/// <summary>
    /// Total number of subsets within the superset.
    /// </summary>
    /// <value>
    /// Total number of subsets within the superset.
    /// </value>
    int PageCount { get; }

    /// <summary>
    /// Total number of objects contained within the superset.
    /// </summary>
    /// <value>
    /// Total number of objects contained within the superset.
    /// </value>
    int TotalItemCount { get; }

    /// <summary>
    /// One-based index of this subset within the superset, zero if the superset is empty.
    /// </summary>
    /// <value>
    /// One-based index of this subset within the superset, zero if the superset is empty.
    /// </value>
    int PageNumber { get; }

    /// <summary>
    /// Maximum size any individual subset.
    /// </summary>
    /// <value>
    /// Maximum size any individual subset.
    /// </value>
    int PageSize { get; }

    /// <summary>
    /// Returns true if the superset is not empty and PageNumber is less than or equal to PageCount and this
    /// is NOT the first subset within the superset.
    /// </summary>
    /// <value>
    /// Returns true if the superset is not empty and PageNumber is less than or equal to PageCount and this
    /// is NOT the first subset within the superset.
    /// </value>
    bool HasPreviousPage { get; }

    /// <summary>
    /// Returns true if the superset is not empty and PageNumber is less than or equal to PageCount and this
    /// is NOT the last subset within the superset.
    /// </summary>
    /// <value>
    /// Returns true if the superset is not empty and PageNumber is less than or equal to PageCount and this
    /// is NOT the last subset within the superset.
    /// </value>
    bool HasNextPage { get; }

    /// <summary>
    /// Returns true if the superset is not empty and PageNumber is less than or equal to PageCount and this
    /// is the first subset within the superset.
    /// </summary>
    /// <value>
    /// Returns true if the superset is not empty and PageNumber is less than or equal to PageCount and this
    /// is the first subset within the superset.
    /// </value>
    bool IsFirstPage { get; }

    /// <summary>
    /// Returns true if the superset is not empty and PageNumber is less than or equal to PageCount and this
    /// is the last subset within the superset.
    /// </summary>
    /// <value>
    /// Returns true if the superset is not empty and PageNumber is less than or equal to PageCount and this
    /// is the last subset within the superset.
    /// </value>
    bool IsLastPage { get; }
}