using System;
using System.Collections.Generic;
using System.Text;

namespace FluentWait.Contracts
{
    public interface IScriptHandler
    {

        IWaitHandler waitHandler { get; set; }

    }
}
