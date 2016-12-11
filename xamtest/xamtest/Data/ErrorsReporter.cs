using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace xamtest.Data
{
    public class ErrorsReporter
    {
        
        public static string CreateErrorReport(Exception ex,
        [System.Runtime.CompilerServices.CallerMemberName] string method = "",
        [System.Runtime.CompilerServices.CallerFilePath] string filePath = "",
        [System.Runtime.CompilerServices.CallerLineNumber] int lineNumber = 0)
        {
            //int lineNumber incorrect!

            string lineNum = ex.StackTrace.Substring(ex.StackTrace.LastIndexOf(':') + 1);

            string error = $"Type: {ex.GetType().Name}\nMessage: {ex.Message}\n\nPlace in code:\n - File: {filePath.Substring(filePath.LastIndexOf('\\'))}\n - Method name: {method}\n - Line number: {lineNum}";

            
            return error;
        }
    }
}
