using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;

namespace FluentWait.Contracts
{
    public interface IResult<T>
    {
        T Value { get; set; }

        void ThrowOnFailed(Func<T, string> condition);
        void ThrowOnFailed(string error);

        IResult<bool> IsAny(Func<T, bool> execute);
        IResult<TResult> IsAny<TResult>(Func<T, TResult> execute) where TResult : ICollection;
        IResult<TResult> IsAny<TResult, TResult1>(Func<T, TResult1> execute, Func<T, TResult> returnValue) where TResult1 : ICollection;
        IResult<bool> IsEqual(Func<T, bool> execute);
        IResult<TResult> IsEqual<TResult, TResult1>(Func<T, TResult1> execute, Func<T, TResult> returnValue);
        IResult<TResult> IsNotNull<TResult>(Func<T, TResult> execute);
        IResult<TResult> IsNotNull<TResult, TResult1>(Func<T, TResult1> execute, Func<T, TResult> returnValue);
    }
}
