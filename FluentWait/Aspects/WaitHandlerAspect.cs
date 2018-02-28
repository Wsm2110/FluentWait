using FluentWait.Contracts;
using MethodBoundaryAspect.Fody.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace FluentWait.Aspects
{
    public class WaitHandlerAspect : OnMethodBoundaryAspect
    {
        public int TimeoutInSeconds { get; }
        public int PollingDurationInSeconds { get; }

        public WaitHandlerAspect(int timeoutInSeconds, int pollingDurationInSeconds)
        {
            TimeoutInSeconds = timeoutInSeconds;
            PollingDurationInSeconds = pollingDurationInSeconds;
        }

        /// <summary>
        /// Called when [entry].
        /// </summary>
        /// <param name="args">The arguments.</param>
        public override void OnEntry(MethodExecutionArgs args)
        {
            dynamic instance = args.Instance;

            if (instance.waitHandler != null)
            {
                instance.waitHandler.SetPollingInterval(TimeSpan.FromSeconds(PollingDurationInSeconds));
                instance.waitHandler.SetTimeout(TimeSpan.FromSeconds(TimeoutInSeconds));
            }      

        }

        /// <summary>
        /// Called when [exit].
        /// </summary>
        /// <param name="args">The arguments.</param>
        public override void OnExit(MethodExecutionArgs args)
        {
            dynamic instance = args.Instance;
            if (instance.waitHandler != null)
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
