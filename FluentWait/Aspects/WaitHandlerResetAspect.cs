using FluentWait.Contracts;
using MethodBoundaryAspect.Fody.Attributes;
using System;

namespace FluentWait.Aspects
{
    public class WaitHandlerResetAspect : OnMethodBoundaryAspect
    {
        #region Fields

        private int _timeoutInSeconds;
        private int _pollingDurationInSeconds;
      
        #endregion

        #region Constructor

        public WaitHandlerResetAspect(int timeoutInSeconds, int pollingDurationInSeconds)
        {
            _timeoutInSeconds = timeoutInSeconds;
            _pollingDurationInSeconds = pollingDurationInSeconds;       
        }

        #endregion

        /// <summary>
        /// Called when [entry].
        /// </summary>
        /// <param name="args">The arguments.</param>
        public override void OnEntry(MethodExecutionArgs args)
        {
            if (args.Instance is IScriptHandler instance)
            {
                instance.waitHandler.SetPollingInterval(TimeSpan.FromSeconds(_pollingDurationInSeconds));
                instance.waitHandler.SetTimeout(TimeSpan.FromSeconds(_timeoutInSeconds));
            }
        }

        /// <summary>
        /// Called when [exit].
        /// </summary>
        /// <param name="args">The arguments.</param>
        public override void OnExit(MethodExecutionArgs args)
        {
            if (args.Instance is IScriptHandler instance)
            {
                instance.waitHandler.SetPollingInterval(TimeSpan.FromSeconds(1));
                instance.waitHandler.SetTimeout(TimeSpan.FromSeconds(60));
            }    
        }

        /// <summary>
        /// Called when [exception].
        /// </summary>
        /// <param name="args">The arguments.</param>
        public override void OnException(MethodExecutionArgs args)
        {
            System.Diagnostics.Trace.WriteLine("exceptions");
        }
    }
}
