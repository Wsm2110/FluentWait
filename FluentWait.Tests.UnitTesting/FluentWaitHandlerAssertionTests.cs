﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentWait.Contracts;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using FluentWait.Tests.UnitTesting.ViewModels;

namespace FluentWait.Tests.UnitTesting
{
    [TestClass]
    public class FluentWaitHandlerAssertionTests
    {
        ObservableCollection<Result<bool>> _testCollection = new ObservableCollection<Result<bool>>();
             
        [TestMethod]
        public void TestMethod2()
        {
            IWaitHandler waitHandler = new WaitHandler().SetDefaultPollingInterval(TimeSpan.FromSeconds(1)).SetDefaultTimeout(TimeSpan.FromSeconds(60));
            IWaitBuilder builder = new WaitBuilder(waitHandler);

            var result = builder.IsAny(() => _testCollection)
                                .IsAny(exp => false)
                                .IsAny(exp => exp == false, exp => 1)
                                .IsAny(exp => exp == 1);

            Assert.IsTrue(result.Value);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void AssertCollectionIsNotNullAndIsAnyIsFalse()
        {
            IWaitHandler waitHandler = new WaitHandler().SetDefaultPollingInterval(TimeSpan.FromSeconds(1)).SetDefaultTimeout(TimeSpan.FromSeconds(60));
            IWaitBuilder builder = new WaitBuilder(waitHandler);
            
            var testClass = new TestClassViewModel();

            testClass._testCollection.Add(true);

            var result = builder.IsNotNull(() => testClass)
                                .IsAny(vm => vm._testCollection, vm => vm.Count)
                                .IsEqual(res => res == 1); 

            Assert.IsNotNull(result.Value);
        }
    }
}
