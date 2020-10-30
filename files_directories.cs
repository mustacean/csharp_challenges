using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

static class Extensions
{
    public static void RemoveBlankLines (string path) //done!
    {
        if (!File.Exists (path)) throw new FileNotFoundException ("file not found", path);
        string new_path = path + "_2";
        using (var tw = File.CreateText (new_path))
        {
            foreach (var item in File.ReadAllLines (path))
            {
                if (item == null || item == string.Empty) continue;
                tw.WriteLine (item);
            }
            File.Delete (path);
            File.Move (new_path, path);
        }
    }

    public static string HumanReadableSize (this long sz)
    {
        byte counter = 0;
        decimal size = sz;
        while (true)
        {
            if (size < 1024) break;
            counter++;
            size = size / 1024;
        }

        string addit_str = "byte";
        switch (counter)
        {
            case 1:
                addit_str = "kilobyte";
                break;
            case 2:
                addit_str = "megabyte";
                break;
            case 3:
                addit_str = "gigabyte";
                break;
            case 0:
            default:
                addit_str = "byte";
                break;
        }
        return Math.Round ((decimal) size, 2) + " " + addit_str;
    }

    private static IEnumerable<FileInfo> DirectoryFiles (string dir_path, bool include_sub_directories = false)
    {
        if (!Directory.Exists (dir_path)) throw new DirectoryNotFoundException ();

        var _dir = new DirectoryInfo (dir_path);
        if (include_sub_directories)
        {
            foreach (var item in _dir.GetDirectories ())
                foreach (var sub_item in DirectoryFiles (item.FullName, include_sub_directories))
                    yield return sub_item;
        }
        foreach (var file in _dir.GetFiles ()) yield return file;
    }

    public static long DirectorySize (string dir_path, bool include_sub_directories = false) //done!
    {
        long total_len = 0;
        foreach (var item in DirectoryFiles (dir_path, include_sub_directories))
            total_len += item.Length;
        return total_len;
    }

    public static IEnumerable<string> SearchFiles (string dir_path,
        string file_pattern,
        bool include_sub_directories = false) //done!
    {
        bool st_wit = file_pattern.StartsWith ("*");
        bool en_with = file_pattern.EndsWith ("*");
        if (st_wit) file_pattern = file_pattern.Substring (1);
        if (en_with) file_pattern = file_pattern.Substring (0, file_pattern.Length - 1);

        foreach (var item in DirectoryFiles (dir_path, include_sub_directories))
        {
            if (st_wit && en_with && item.Name.Contains (file_pattern, StringComparison.CurrentCultureIgnoreCase))
                yield return item.FullName;

            else if (st_wit && !en_with && item.Name.EndsWith (file_pattern, StringComparison.CurrentCultureIgnoreCase))
                yield return item.FullName;

            else if (!st_wit && en_with && item.Name.StartsWith (file_pattern, StringComparison.CurrentCultureIgnoreCase))
                yield return item.FullName;

            else if (file_pattern == item.Name) yield return item.FullName;
        }
    }

    public static IEnumerable<string> DuplicateFiles (string dir_path,
        bool include_sub_directories = false) //dale done dale!
    {
        IEnumerable<string> Helavelavelvela ()
        {
            FileInfo last_file = null;
            foreach (var item in DirectoryFiles (dir_path, include_sub_directories).
                OrderBy (i => i.Length))
            {
                if (last_file != null && item.Length == last_file.Length)
                {
                    using (var fs1 = File.OpenRead (last_file.FullName))
                    using (var fs2 = File.OpenRead (item.FullName))
                    {
                        bool yoyeyayo = true;
                        for (int i = 0; i < item.Length; i++)
                        {
                            if (fs1.ReadByte () != fs2.ReadByte ())
                            {
                                yoyeyayo = false;
                                break;
                            }
                        }
                        if (yoyeyayo)
                        {
                            yield return last_file.FullName;
                            yield return item.FullName;
                        }
                    }
                }
                last_file = item;
            }
        }

        return Helavelavelvela ().Distinct ();
    }
}
