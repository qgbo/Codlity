using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace System
{
    public static class Common
    {
        public static string Join(this int[] t)
        {
           return  string.Join(',',t);
        }
    }
}
