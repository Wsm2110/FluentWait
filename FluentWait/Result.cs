using FluentWait.Contracts;
using System;
using System.Collections;
using System.Collections.Specialized;

namespace FluentWait
{
    public class Result<T> : IResult<T>
    {
        public T Value { get; set; }

        #region IsAny

        public IResult<bool> IsAny(Func<T, bool> execute)
        {
            return new Result<bool> { Value = execute(Value) };
        }

        public IResult<TResult> IsAny<TResult>(Func<T, TResult> execute) where TResult : ICollection
        {
            return new Result<TResult> { Value = execute(Value) };
        }

        public IResult<TResult> IsAny<TResult, TResult1>(Func<T, TResult1> execute, Func<T, TResult> returnValue)
        {
            var result = execute(Value);
            var cast = result as ICollection;

            if (cast == null)
            {
                throw new InvalidCastException($"Unable to cast result to {nameof(ICollection)}");
            }

            var xom = cast.Count > 0;

            if (!xom)
            {
                throw new InvalidCastException($"Collection is empty");
            }

            return new Result<TResult> { Value = returnValue(Value) };
        }

        #endregion

        #region IsEqual

        public IResult<bool> IsEqual(Func<T, bool> execute)
        {
            var result = execute(Value);

            if (result == false)
            {
                throw new ImLazyException($"Is not equal");
            }

            return new Result<bool> { Value = result };
        }

        public IResult<TResult> IsEqual<TResult, TResult1>(Func<T, TResult1> execute, Func<T, TResult> returnValue)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IsNull

        public IResult<bool> IsNotNull<TResult>(Func<T, TResult> execute)
        {
            throw new NotImplementedException();
        }

        public IResult<TResult> IsNotNull<TResult, TResult1>(Func<T, TResult1> execute, Func<T, TResult> returnValue)
        {
            throw new NotImplementedException();
        }

        #endregion
      
    }
}
