using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Counter.Models
{
    public class Counter
    {
        public Counter() {
            this.CounterName = "";
            this.CounterValue = 0;
            this.CounterColor = "";
            this.CounterDefaultValue = null;
        }
        public string CounterName { get; set; }
        public int CounterValue { get; set; }
        public string CounterColor { get; set; }
        public int? CounterDefaultValue { get; set; }
    }
}
