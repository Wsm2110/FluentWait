using FluentWait.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FluentWait
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="FluentWait.Contracts.IWaitBuilder" />
    public class WaitBuilder : IWaitBuilder
    {

        #region Fields

        /// <summary>
        /// The wait handler
        /// </summary>
        private IWaitHandler _waitHandler;

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="WaitBuilder"/> class.
        /// </summary>
        /// <param name="waitHandler">The wait handler.</param>
        public WaitBuilder(IWaitHandler waitHandler)
        {
            _waitHandler = waitHandler;
        }

        /// <summary>
        /// Determines whether the specified execute is any.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="execute">The execute.</param>
        /// <returns></returns>
        /// <exception cref="Exception">Throw something exception...</exception>
        public IResult<bool> IsAny<T>(Func<IEnumerable<T>> execute)
        {
            var result = _waitHandler.Until(() => execute().Any());
            if (result)
            {
                return new Result<bool>(_waitHandler) { Value = true };
            }

            throw new Exception("Throw something exception...");
        }

        /// <summary>
        /// Determines whether [is not null] [the specified execute].
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="execute">The execute.</param>
        /// <returns></returns>
        /// <exception cref="Exception">Throw something exception...</exception>
        public IResult<TResult> IsNotNull<TResult>(Func<TResult> execute)
        {
            if (execute() != null)
            {
                return new Result<TResult>(_waitHandler) { Value = execute() };
            }

            throw new Exception("Throw something exception...");
        }

        /// <summary>
        /// Determines whether the specified execute is true.
        /// </summary>
        /// <param name="execute">The execute.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public IResult<bool> IsTrue(Func<bool> execute)
        {
            throw new NotImplementedException();
        }
    }
}
