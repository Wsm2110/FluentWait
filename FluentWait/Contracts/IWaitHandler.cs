using System;
using System.Collections.Generic;
using System.Text;

namespace FluentWait.Contracts
{
    /// <summary>
    /// 
    /// </summary>
    public interface IWaitHandler
    {
        /// <summary>
        /// Waits the specified duration.
        /// </summary>
        /// <param name="seconds">The seconds.</param>
        void From(TimeSpan seconds);

        /// <summary>
        /// Sets the timeout.
        /// </summary>
        /// <param name="timeoutInSeconds">The timeout in seconds.</param>
        /// <returns></returns>
        IWaitHandler SetTimeout(TimeSpan timeoutInSeconds);

        /// <summary>
        /// Sets the polling interval.
        /// </summary>
        /// <param name="timeoutInSeconds">The timeout in seconds.</param>
        /// <returns></returns>
        IWaitHandler SetPollingInterval(TimeSpan timeoutInSeconds);

        /// <summary>
        /// Untils the specified condition.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="condition">The condition.</param>
        /// <returns></returns>
        Result<TResult> Until<TResult>(Func<TResult> condition);
    }
}
