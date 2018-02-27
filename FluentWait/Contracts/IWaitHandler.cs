using System;
using System.Collections.Generic;
using System.Text;

namespace FluentWait.Contracts
{
    public interface IWaitHandler
    {
        /// <summary>
        /// Froms the specified seconds.
        /// </summary>
        /// <param name="seconds">The seconds.</param>
        void From(TimeSpan seconds);

        IWaitHandler SetTimeout(TimeSpan timeoutInSeconds);

        IWaitHandler SetPollingInterval(TimeSpan timeoutInSeconds);

        /// <summary>
        /// Untils the specified condition.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="condition">The condition.</param>
        /// <param name="errorMessage">The error message.</param>
        /// <returns></returns>
        Result<TResult> Until<TResult>(Func<TResult> condition);

    }
}
