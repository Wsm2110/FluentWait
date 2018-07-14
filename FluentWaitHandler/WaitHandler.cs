using FluentWait.Contracts;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace FluentWait
{

    public class WaitHandler : IWaitHandler
    {

        #region Fields

        private static float _performanceFactor;
        private readonly IClock _clock;
        private TimeSpan _timeout;
        private TimeSpan _pollingInterval;

        #endregion

        /// <summary>, 
        /// Initializes a new instance of the <see cref="WaitHandler"/> class.
        /// </summary>
        public WaitHandler()
        {
            _clock = new SystemClock();
        }

        /// <summary>
        /// Waits the specified milliseconds.
        /// </summary>
        public void From(TimeSpan seconds)
        {
            var frame = new DispatcherFrame();
            Task.Factory.StartNew(() =>
            {
                Thread.Sleep(seconds);
                frame.Continue = false;
            });
            Dispatcher.PushFrame(frame);
        }

        /// <summary>
        /// waits until a curtain condition is met
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="action">The action.</param>
        /// <param name="errorMessage">The error message.</param>
        /// <returns>
        /// Instance of a type or a boolean
        /// </returns>   
        public Result<TResult> Until<TResult>(Func<TResult> action)
        {
            var waitResult = new Result<TResult>(this);
            var resultType = typeof(TResult);
            var endTime = _clock.LaterBy(_timeout);
            var start = _clock.Now;

            do
            {
                try
                {
                    //return instance
                    TResult result;
                    if (resultType != typeof(bool))
                    {
                        result = action();
                        if (result != null)
                        {
                            waitResult.Value = result;
                            break;
                        }
                    }
                    else
                    {
                        //return bool
                        result = action();
                        var boolResult = result as bool?;
                        if (boolResult.HasValue && boolResult.Value)
                        {
                            waitResult.Value = result;
                            break;
                        }
                    }
                }
                catch (Exception e)
                {
                    //log something
                }
                From(_pollingInterval);
            }
            while (_clock.IsNowBefore(endTime));

            return waitResult;
        }

        /// <summary>, 
        /// Sets the polling duration
        /// </summary>
        public IWaitHandler SetPollingInterval(TimeSpan duration)
        {
            _pollingInterval = duration;
            return this;
        }

        /// <summary>, 
        /// Sets the timeout duration
        /// </summary>
        public IWaitHandler SetTimeout(TimeSpan duration)
        {
            _timeout = duration;
            return this;
        }
    }
}
