using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentWait.Tests.UnitTesting.ViewModels
{
    public class TestClassViewModel
    {
        public ObservableCollection<bool> TestCollection = new ObservableCollection<bool>();

        public List<int> something = new List<int>();


        public int Count { get; set; } = 1;
    }
}
