using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kroulis.Text
{
    class TextControl
    {
		public static string GetStringLeftByLength(string X,int length)
        {
            if (X.Length < length)
                return X;
            return X.Substring(0, length);
        }

        public static string GetStringRightByLength(string X, int length)
        {
            if (X.Length < length)
                return X;
            return X.Substring(X.Length-length , length);
        }
    }
}