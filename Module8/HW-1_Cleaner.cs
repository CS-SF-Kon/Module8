using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module8
{
    static class Cleaner
    {
        public static void CleanUp(string URL)
        {
            string[] folds = Directory.GetDirectories(URL);
            string[] files = Directory.GetFiles(URL);

            string[] FnF = new string[folds.Length + files.Length];
            for (int i = 0; i < (folds.Length + files.Length); i++)
            {
                if (i < folds.Length)
                {
                    FnF[i] = folds[i];
                }
                else
                {
                    FnF[i] = files[i-folds.Length];
                }
            }

            foreach (string fn in FnF)
            {
                Console.WriteLine($"{fn} - {File.GetLastAccessTime(fn)}");
                DateTime dt = File.GetLastAccessTime(fn);
                Console.WriteLine(TimeSpan.FromMinutes(30) >= (DateTime.Now - dt));
            }

            //foreach (string file in files)
            //{
            //}
            //foreach (string fold in folds)
            //{
            //    Console.WriteLine($"{fold} - {File.GetLastAccessTime(fold)}");
            //}

        }
    } 
}
