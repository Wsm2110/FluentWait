using FluentWait.Contracts;
using System;
using System.Collections;
namespace FluentWait
{
    public class Result<T> : IResult<T>
    {
        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public T Value { get; set; }

        private IWaitHandler _wait { get; }

        public Result(IWaitHandler wait)
        {
            _wait = wait;
        }

        /// <summary>
        /// Determines whether the specified execute is any.
        /// </summary>
        /// <param name="execute">The execute.</param>
        /// <returns></returns>
        public IResult<bool> IsAny(Func<T, bool> execute)
        {
            return new Result<bool>(_wait) { Value = execute(Value) };
        }

        /// <summary>
        /// Determines whether the specified execute is any.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="execute">The execute.</param>
        /// <returns></returns>
        public IResult<TResult> IsAny<TResult>(Func<T, TResult> execute) where TResult : ICollection
        {
            var result = _wait.Until(() =>
             {
                 var condition = execute(Value);
                 var cast = condition as ICollection;
                 if (cast == null)
                 {
                     throw new InvalidCastException($"Unable to cast result to {nameof(ICollection)}");
                 }
                 return cast.Count > 0;
             });

            if (!result)
                throw new TestFailedException("Collection is Empty, expected otherwise");

            return new Result<TResult>(_wait) { Value = execute(Value) };
        }

        /// <summary>
        /// Determines whether the specified execute is any and returns a returns a new type
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <typeparam name="TResult1">The type of the result1.</typeparam>
        /// <param name="execute">The execute.</param>
        /// <param name="returnValue">The return value.</param>
        /// <returns></returns>
        public IResult<TResult> IsAny<TResult, TResult1>(Func<T, TResult1> execute, Func<T, TResult> returnValue) where TResult1 : ICollection
        {
            _wait.Until(() =>
             {
                 var condition = execute(Value);
                 var cast = condition as ICollection;
                 if (cast == null)
                 {
                     throw new InvalidCastException($"Unable to cast result to {nameof(ICollection)}");
                 }
                 return cast.Count > 0;
             }).ThrowOnFailed("Collection is Empty, expected otherwise");

            return new Result<TResult>(_wait) { Value = returnValue(Value) };
        }

        /// <summary>
        /// Determines whether the specified execute is equal.
        /// </summary>
        /// <param name="execute">The execute.</param>
        /// <returns></returns>
        /// <exception cref="ImLazyException"></exception>
        public IResult<bool> IsEqual(Func<T, bool> execute)
        {
            var result = execute(Value);

            if (result == false)
            {
                throw new TestFailedException($"Is not equal");
            }

            return new Result<bool>(_wait) { Value = result };
        }

        /// <summary>
        /// Determines whether the specified execute is equal.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <typeparam name="TResult1">The type of the result1.</typeparam>
        /// <param name="execute">The execute.</param>
        /// <param name="returnValue">The return value.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public IResult<TResult> IsEqual<TResult, TResult1>(Func<T, TResult1> execute, Func<T, TResult> returnValue)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Determines whether [is not null] [the specified execute].
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="execute">The execute.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public IResult<TResult> IsNotNull<TResult>(Func<T, TResult> execute)
        {
            var result = _wait.Until(() => execute(Value));

            if (result == null)
            {
                throw new TestFailedException("Execution the given condition returned  a null");
            }

            return new Result<TResult>(_wait) { Value = result };
        }

        /// <summary>
        /// Determines whether [is not null] [the specified execute].
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <typeparam name="TResult1">The type of the result1.</typeparam>
        /// <param name="execute">The execute.</param>
        /// <param name="returnValue">The return value.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public IResult<TResult> IsNotNull<TResult, TResult1>(Func<T, TResult1> execute, Func<T, TResult> returnValue)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Throws the on failed.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="condition">The condition.</param>
        /// <exception cref="NotImplementedException"></exception>
        public void ThrowOnFailed(Func<T, string> condition)
        {
          
        }

        /// <summary>
        /// Throws the on failed.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="condition">The condition.</param>
        /// <exception cref="NotImplementedException"></exception>
        public void ThrowOnFailed(string condition)
        {
            
        }

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
