using FluentWait.Contracts;
using System;
using System.Collections;
using System.Collections.Specialized;

namespace FluentWait
{
    public class Result<T> : IResult<T>
    {
        public T Value { get; set; }
        public IWaitHandler Wait { get; }

        public Result(IWaitHandler wait)
        {
            Wait = wait;
        }

        #region IsAny

        public IResult<bool> IsAny(Func<T, bool> execute)
        {
            return new Result<bool>(Wait) { Value = execute(Value) };
        }

        public IResult<TResult> IsAny<TResult>(Func<T, TResult> execute) where TResult : ICollection
        {
            return new Result<TResult>(Wait) { Value = execute(Value) };
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

            return new Result<TResult>(Wait) { Value = returnValue(Value) };
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

            return new Result<bool>(Wait) { Value = result };
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

        /// <summary>
        /// Performs an implicit conversion from <see cref="Result{T}"/> to <see cref="T"/>.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        public static implicit operator T(Result<T> result)
        {
            return result.Value;
        }

    }
}
