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
            var result = _waitHandler.Until(() => execute().Any());
            if (result)
            {
                return new Result<bool>(_waitHandler) { Value = true };
            }

            throw new Exception("Throw something exception...");
        }

        public IResult<TResult> IsNotNull<TResult>(Func<TResult> execute)
        {
            if (execute() != null)
            {
                return new Result<TResult>(_waitHandler) { Value = execute() };
            }

            throw new Exception("Throw something exception...");
        }

        public IResult<bool> IsTrue(Func<bool> execute)
        {
            throw new NotImplementedException();
        }
    }
}
