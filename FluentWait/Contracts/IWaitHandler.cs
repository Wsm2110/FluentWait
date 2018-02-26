using System;
using System.Collections.Generic;
using System.Text;

namespace FluentWait.Contracts
{
    public interface IWaitHandler
    {
        void Until<TResult>(Func<ExpectedConditions, TResult> execute);

        IWaitHandler SetDefaultTimeout(TimeSpan duration);

        IWaitHandler SetDefaultPollingInterval(TimeSpan duration);

    }
}
