using System;
using System.Collections;

namespace FluentWait.Contracts
{
    public interface IResult<T>
    {
        T Value { get; set; }

        void ThrowExceptionOnFailed(Func<T, string> condition);
        void ThrowExceptionOnFailed(string error);
     
        IResult<TResult> IsAny<TResult>(Func<T, TResult> execute) where TResult : ICollection;
        IResult<TResult> IsAny<TResult, TResult1>(Func<T, TResult1> execute, Func<T, TResult> returnValue) where TResult1 : ICollection;
        IResult<bool> IsEqual(Func<T, bool> execute);
        IResult<TResult> IsEqual<TResult, TResult1>(Func<T, bool> execute, Func<T, TResult> returnValue);
        IResult<TResult> IsNotNull<TResult>(Func<T, TResult> execute) where TResult : class;
        IResult<TResult> IsNotNull<TResult, TResult1>(Func<T, TResult1> execute, Func<T, TResult> returnValue) where TResult : class;
    }
}
