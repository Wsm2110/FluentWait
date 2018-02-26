using FluentWait.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FluentWait
{

    public class WaitHandler : IWaitHandler
    {

        public IWaitHandler SetDefaultPollingInterval(TimeSpan duration)
        {      
            return this;
        }

        public IWaitHandler SetDefaultTimeout(TimeSpan duration)
        {
            return this;
        }

        public void Until<TResult>(Func<ExpectedConditions, TResult> execute)
        {
           
        }
    }
}
