using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentWait.Contracts;
using System;
using FluentWait.Tests.UnitTesting.ViewModels;

namespace FluentWait.Tests.UnitTesting
{
    [TestClass]
    public class FluentWaitHandlerAssertionTests
    {
        public IWaitHandler waitHandler = new WaitHandler().SetPollingInterval(TimeSpan.FromSeconds(1)).SetTimeout(TimeSpan.FromSeconds(60));

        [TestMethod]
        [Aspects.WaitHandlerResetAspect(360, 10)]
        public void AssertCollectionIsNotNullAndIsAnyIsTrue()
        {
            IWaitBuilder builder = new WaitBuilder(waitHandler);

            var testClass = new TestClassViewModel();
            testClass.TestCollection.Add(true);

            var result = builder.IsNotNull(() => testClass)
                                .IsAny(vm => vm.TestCollection);

            Assert.IsNotNull(result.Value);
        }

        [TestMethod]
        [Aspects.WaitHandlerResetAspect(2, 1)]
        [ExpectedException(typeof(TestFailedException))]
        public void AssertCollectionIsNotNullAndIsAnyIsFalse()
        {
            IWaitBuilder builder = new WaitBuilder(waitHandler);

            var testClass = new TestClassViewModel();

            var result = builder.IsNotNull(() => testClass)
                                .IsAny(vm => vm.TestCollection);
        }

        [TestMethod]
        [Aspects.WaitHandlerResetAspect(2, 1)]
        [ExpectedException(typeof(TestFailedException))]
        public void AssertCollectionIsNotNullAndIsNotEqual()
        {
            IWaitBuilder builder = new WaitBuilder(waitHandler);

            var testClass = new TestClassViewModel();

            var result = builder.IsNotNull(() => testClass)
                                .IsEqual(vm => vm.TestCollection.Count == 1);
        }

        [TestMethod]
        [Aspects.WaitHandlerResetAspect(2, 1)]
        public void AssertCollectionIsNotNullAndIsEqual()
        {
            IWaitBuilder builder = new WaitBuilder(waitHandler);

            var testClass = new TestClassViewModel();

            testClass.TestCollection.Add(true);

            var result = builder.IsNotNull(() => testClass)
                                .IsEqual(vm => vm.TestCollection.Count == 1);

            Assert.IsTrue(result.Value);
        }


    }
}
