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
        /// <summary>
        /// Метод для первого задания - чистит указанную директорию от файлов и папок, которые не использовались более 30 минут
        /// </summary>
        /// <param name="URL"></param>
        public static void CleanUp(string URL)
        {
            const int mins = 30;
            int foldsCount = 0;
            int filesCount = 0;
            try
            {
                if (Directory.Exists(URL))
                {
                    var dir = new DirectoryInfo(URL);
                    foreach (FileInfo file in dir.GetFiles())
                    {
                        DateTime dt = file.LastAccessTime; // в задании речь шла про "использование", думаю, LastAccessTime подойдёт
                        if (TimeSpan.FromMinutes(mins) <= (DateTime.Now - dt))
                        {
                            file.Delete();
                            filesCount++;
                        }
                    }

                    foreach (DirectoryInfo fold in dir.GetDirectories())
                    {
                        DateTime dt = fold.LastAccessTime;
                        if (TimeSpan.FromMinutes(mins) <= (DateTime.Now - dt))
                        {
                            fold.Delete(true);
                            foldsCount++;
                        }
                    }
                    Console.WriteLine($"Unused for {mins} minutes directories and files has been deleted");
                    Console.WriteLine($"Totally removed {foldsCount + filesCount} objects: {foldsCount} folders and {filesCount} files");
                }
                else Console.WriteLine("Directory does not exists");
            }
            catch (Exception err)
            {
                Console.WriteLine($"Error: {err}");
            }
        }

        /// <summary>
        /// Метод для второго задания - считает в байтах объём файлов в директории, а также файлов во вложенных в директорию папках
        /// </summary>
        /// <param name="URL"></param>
        public static float VolumeCounter(string URL)
        {
            float Vol = 0;
            try
            {
                if (Directory.Exists(URL))
                {
                    var dir = new DirectoryInfo(URL);
                    foreach (FileInfo file in dir.GetFiles())
                    {
                        Vol += file.Length;
                    }

                    foreach (DirectoryInfo fold in dir.GetDirectories())
                    {
                        Vol += VolumeCounter(fold.FullName);
                    }
                }
                else Console.WriteLine("Directory does not exists");

            }
            catch (Exception err)
            {
                Console.WriteLine($"Error: {err}");
            }
            return Vol;
        }

        /// <summary>
        /// Корректный на мой взгляд метод по очистке - удаляет только устаревшие файлы (в т.ч. и вложенные), 
        /// а папки удаляет только в случае, если они становятся пустыми после чистки
        /// </summary>
        /// <param name="URL"></param>
        public static (int f, int d) CleanUpCorrect(string URL)
        {
            const int mins = 30;
            int foldsCount = 0;
            int filesCount = 0;
            try
            {
                if (Directory.Exists(URL))
                {
                    var dir = new DirectoryInfo(URL);
                    foreach (FileInfo file in dir.GetFiles())
                    {
                        DateTime dt = file.LastAccessTime; // в задании речь шла про "использование", думаю, LastAccessTime подойдёт
                        if (TimeSpan.FromMinutes(mins) <= (DateTime.Now - dt))
                        {
                            file.Delete();
                            filesCount++;
                        }
                    }

                    foreach (DirectoryInfo fold in dir.GetDirectories())
                    {
                        (int f, int d) = CleanUpCorrect(fold.FullName); // нужно, чтобы рекурсия учитывала вложенные удалённые файлы
                        foldsCount += d;
                        filesCount += f;
                        DateTime dt = fold.LastAccessTime;
                        if (TimeSpan.FromMinutes(mins) <= (DateTime.Now - dt))
                        {
                            try
                            {
                                fold.Delete();
                                foldsCount++;
                            }
                            catch (Exception ex)
                            {

                            }
                        }
                    }
                    //Console.WriteLine($"Unused for {mins} minutes directories and files has been deleted");
                    //Console.WriteLine($"Totally removed {foldsCount + filesCount} objects: {foldsCount} folders and {filesCount} files");
                }
                else Console.WriteLine("Directory does not exists");
            }
            catch (Exception err)
            {
                Console.WriteLine($"Error: {err}");
            }
            return (filesCount, foldsCount);
        }

        /// <summary>
        /// Метод для третьего задания - объединяет в себе два предыдущих метода, один их которых переработан для корректного выполнения
        /// </summary>
        /// <param name="URL"></param>
        public static void Combined(string URL)
        {
            /* Console.WriteLine($"Directory's volume before cleanup: {VolumeCounter(URL)}");
            CleanUp(URL);
            Console.WriteLine($"Directory's volume after cleanup: {VolumeCounter(URL)}");
            
            Хотел, было, сказать, зачем плодить методы, если можно использовать комбинацию уже готовых решений,
            но столкнулся с тем, что если в папке изменить файл, то время обращения к папке всё равно не изменится и она будет удалена в соответствии с алгоритмом первого метода
            Поэтому переделал первый метод так, чтобы он удалял только "несвежие" файлы (в т.ч. и вложенные), а папки удалял только если они оказались пустые в результате чистки*/

            Console.WriteLine($"Directory's volume before cleanup: {VolumeCounter(URL)}");

            (int f, int d) = CleanUpCorrect(URL);
            Console.WriteLine($"Totally removed {d + f} objects: {d} folders and {f} files");

            Console.WriteLine($"Directory's volume after cleanup: {VolumeCounter(URL)}");

        }
    } 
}
