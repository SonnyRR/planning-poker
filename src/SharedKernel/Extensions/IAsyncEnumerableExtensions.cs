namespace PlanningPoker.SharedKernel.Extensions
{
    using Ardalis.GuardClauses;

    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public static class IAsyncEnumerableExtensions
    {
        /// <summary>
        /// Creates a list from an async-enumerable sequence.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements in the source sequence.</typeparam>
        /// <param name="source">The source async-enumerable sequence to get a list of elements for.</param>
        /// <param name="cancellationToken">The optional cancellation token to be used for cancelling the sequence at any time.</param>
        /// <returns>An async-enumerable sequence containing a single element with a list containing all the elements of the source sequence.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is null.</exception>
        /// <remarks>The return type of this operator differs from the corresponding operator on IEnumerable in order to retain asynchronous behavior.</remarks>
        public static ValueTask<List<TSource>> ToListAsync<TSource>(this IAsyncEnumerable<TSource> source, CancellationToken cancellationToken = default)
        {
            Guard.Against.Null(source, nameof(source));

            return Core(source, cancellationToken);

            static async ValueTask<List<TSource>> Core(IAsyncEnumerable<TSource> source, CancellationToken cancellationToken)
            {
                var list = new List<TSource>();

                await foreach (var item in source.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    list.Add(item);
                }

                return list;
            }
        }
    }
}