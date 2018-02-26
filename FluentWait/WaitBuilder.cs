using FluentWait.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FluentWait
{
    public class WaitBuilder : IWaitBuilder
    {

        #region Fields

        private IWaitHandler _waitHandler;

        #endregion

        public WaitBuilder(IWaitHandler waitHandler)
        {
            _waitHandler = waitHandler;
        }

        public IResult<bool> IsAny<T>(Func<IEnumerable<T>> execute)
        {
            if (execute().Any())
            {
                return new Result<bool> { Value = true };
            }

            throw new Exception("Throw something exception...");
        }

        public IResult<TResult> IsNotNull<TResult>(Func<TResult> execute)
        {
            if (execute() != null)
            {
                return new Result<TResult> { Value = execute() };
            }

            throw new Exception("Throw something exception...");
        }

        public IResult<bool> IsTrue(Func<bool> execute)
        {
            throw new NotImplementedException();
        }
    }
}
