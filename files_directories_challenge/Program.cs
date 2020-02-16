using System;

namespace files_directories
{
    class Program
    {
        static void Main (string[] args)
        {
            /*System.Console.WriteLine ("duplicate files :");
            foreach (var item in Extensions.DuplicateFiles (args[0], true))
                System.Console.WriteLine (item);*/

            /*System.Console.WriteLine ("search result :");
            foreach (var item in Extensions.SearchFiles (args[0], args[1], true))
            {
                System.Console.WriteLine (item);
            } */

            var l = Extensions.DirectorySize (args[0], true);
            //System.Console.WriteLine (l);
            System.Console.WriteLine (l.HumanReadableSize ());

            //Extensions.RemoveBlankLines (args[0]);

        }
    }
}