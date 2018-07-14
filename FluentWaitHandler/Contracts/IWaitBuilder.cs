using System;
using System.Collections.Generic;
using System.Text;

namespace FluentWait.Contracts
{

    /// <summary>
    /// 
    /// </summary>
    public interface IWaitBuilder
    {
        /// <summary>
        /// Determines whether the specified execute is true.
        /// </summary>
        /// <param name="execute">The execute.</param>
        /// <returns></returns>
        IResult<bool> IsTrue(Func<bool> execute);

        /// <summary>
        /// Determines whether [is not null] [the specified execute].
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="execute">The execute.</param>
        /// <returns></returns>
        IResult<TResult> IsNotNull<TResult>(Func<TResult> execute) where TResult : class;

        /// <summary>
        /// Determines whether the specified execute is any.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="execute">The execute.</param>
        /// <returns></returns>
        IResult<bool> IsAny<T>(Func<IEnumerable<T>> execute);
    }
}
