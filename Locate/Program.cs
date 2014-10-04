/*
 * Copyright (c) 2014 Joachim F. Rohde

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locate
{
    public class Program
    {
        // the file where all information is saved. it resides in the same directory as the exe
        private static string dbFile = "locate.db";
        private static TextWriter tw = null;

        public static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                if (args[0].Equals("-update"))
                {
                    tw = new StreamWriter(dbFile);
                    update();
                    tw.Close();
                }
                else
                {
                    search(args[0]);
                }
            }
            else
            {
                Console.WriteLine("Usage:");
                Console.WriteLine("locate -update       Updates the database");
                Console.WriteLine("locate searchTerm    Searches a file");
            }
        }

        private static void update()
        {
            DriveInfo[] allDrives = DriveInfo.GetDrives();

            foreach (DriveInfo d in allDrives)
            {
                if (d.DriveType == DriveType.Fixed && d.IsReady)
                {
                    DirSearch(d.Name);
                }
            }
        }

        static void DirSearch(string sDir)
        {

            try
            {
                foreach (string d in Directory.GetDirectories(sDir))
                {
                    try
                    {
                        foreach (string f in Directory.GetFiles(d))
                        {
                            tw.WriteLine(f);
                        }

                        DirSearch(d);
                    }
                    catch (System.Exception excpt)
                    {
                        Console.WriteLine(excpt.Message);
                    }
                }
            }
            catch (System.Exception excpt)
            {
                Console.WriteLine(excpt.Message);
            }
        }

        private static void search(string searchTerm)
        {
            TextReader tr = new StreamReader(AppDomain.CurrentDomain.BaseDirectory+dbFile);

            string line;
            while ((line = tr.ReadLine()) != null)
            {
                if (line.ToLower().Contains(searchTerm.ToLower()))
                {
                    Console.WriteLine(line);
                }
            }

            tr.Close();
        }

    }
}
