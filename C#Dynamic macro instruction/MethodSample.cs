using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSEngineTest
{
    internal class MethodSample
    {
        public MethodSample(string methodName, string sampleCode, int index)
        {
            this.MethodName = methodName;
            this.SampleCode = sampleCode;
            this.Index = index;
        }
        public string MethodName { get; set; }
        public string SampleCode { get; set; }
        public int Index { get; set; }
    }
}
