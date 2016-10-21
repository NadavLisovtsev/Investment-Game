using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;

namespace InvestmentGame.ForDebug
{
    public static class DebugFileWriter
    {
        private static string _debugFilesPath = @"C:\Users\Ola\Desktop\Nadav\Investment Game\ForDebug\";

        public static void writeToFile(string filename, string data)
        {
            if (!inDebugMode()) return;

            using(StreamWriter outFile = new StreamWriter(_debugFilesPath + filename, true))
            {
                outFile.WriteLine(data);
            }

        }

        private static bool inDebugMode()
        {
            return Debugger.IsAttached;
        }
    }
}