using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesTest
{
    public static class DelegateInvoker
    {
        public static void InvokeDelgate(Program.VoidDelegateFirst InvokeFirstDelegate)
        {
            InvokeFirstDelegate.Invoke();  //or InvokeFirstDelegate();

        }
        public static int InvokeDelegateWithParametes(Program.IntDelegateSecond DelegateIntReturn)
        {
            return DelegateIntReturn(50,100);
        }
    }
}
