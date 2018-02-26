using System;
using System.Collections.Generic;
using System.Text;

namespace FluentWait.Contracts
{
    
   public interface IWaitBuilder
    {
        IResult<bool> IsTrue(Func<bool> execute);

        IResult<TResult> IsNotNull<TResult>(Func<TResult> execute);
               
        IResult<bool> IsAny<T>(Func<IEnumerable<T>> execute);
    }
}
