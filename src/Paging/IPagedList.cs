// ReSharper disable once CheckNamespace
namespace Qrtix.Paging;

public interface IPagedList<out T> : IPager, IReadOnlyList<T>
{
	/// <summary>
	/// One-based index of the first item in the paged subset, zero if the superset is empty or PageNumber
	/// is greater than PageCount.
	/// </summary>
	/// <value>
	/// One-based index of the first item in the paged subset, zero if the superset is empty or PageNumber
	/// is greater than PageCount.
	/// </value>
	int FirstItemOnPage { get; }

	/// <summary>
	/// One-based index of the last item in the paged subset, zero if the superset is empty or PageNumber
	/// is greater than PageCount.
	/// </summary>
	/// <value>
	/// One-based index of the last item in the paged subset, zero if the superset is empty or PageNumber
	/// is greater than PageCount.
	/// </value>
	int LastItemOnPage { get; }
}