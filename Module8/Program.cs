//using System.IO;
//using System.Linq;

using System.IO.Enumeration;

namespace Module8
{
    internal class Program
    {
        const string FileName = @"C:\Users\slavi\Desktop\BinaryFile.bin";
        static void Main(string[] args)
        {
            // -----------информация о дисках-----------
            //DriveInfo[] drivers = DriveInfo.GetDrives();

            //foreach (DriveInfo driver in drivers.Where(d => d.DriveType == DriveType.Fixed)) // можно выбрать тип дисков, о которых хотим посмотреть информацию (почему-то работает только с fixed)
            //{
            //    Console.WriteLine();
            //    Console.WriteLine("Name: " + driver.Name);
            //    Console.WriteLine("Type: " + driver.DriveType);

            //    if (driver.IsReady)
            //    {
            //        Console.WriteLine("Format: " + driver.DriveFormat);
            //        Console.WriteLine("Total size: " + driver.TotalSize);
            //        Console.WriteLine("Total free space: " + driver.TotalFreeSpace);
            //        Console.WriteLine("Avalible free space: " + driver.AvailableFreeSpace);
            //        Console.WriteLine("Label: " + driver.VolumeLabel);
            //    }
            //    Console.WriteLine();
            //}
            // -----------информация о дисках-----------

            // -----------создание и считывание файла-----------
            //string path = @"C:\Users\slavi\source\repos\Module8\Module8\Program.cs";
            //if (File.Exists(path))
            //{
            //    using (StreamWriter sw = File.AppendText(path))
            //    {
            //        sw.WriteLine($"// {DateTime.Now}"); // доабвление даты работы с файлом
            //    }
            //}

            //using (StreamReader sr = File.OpenText(path))
            //{
            //    string line = "";
            //    while ((line = sr.ReadLine()) != null)
            //    {
            //        Console.WriteLine(line);
            //    }
            //}
            // -----------создание и считывание файла-----------

            //-----------информация о каталогах диска-----------
            //Catalogs();
            // -----------информация о каталогах диска-----------

            // -----------работа с бинарными файлами-----------
            //WriteValues();
            //ReadValues();
            // -----------работа с бинарными файлами-----------

            Cleaner.CleanUp(@"C:\Users\Slavi\Desktop\test");
        }
        /// <summary>
        /// Метод для получения информации о каталогах диска
        /// </summary>
        //static void Catalogs()
        //{
        //    string dir = @"C:\";
        //    if (Directory.Exists(dir))
        //    {
        //        Console.WriteLine("Folders: ");
        //        string[] folds = Directory.GetDirectories(dir);
        //        string[] files = Directory.GetFiles(dir);

        //        foreach (string fold in folds)
        //        {
        //            Console.WriteLine(fold);
        //        }

        //        Console.WriteLine();
        //        Console.WriteLine("Files: ");

        //        foreach (string file in files)
        //        {
        //            Console.WriteLine(file);
        //        }

        //        Console.WriteLine(folds.Length + files.Length);
        //    }
        //}


        /// <summary>
        /// Запись бинарного файла
        /// </summary>
        //static void WriteValues()
        //{
        //    using (BinaryWriter writer = new BinaryWriter(File.Open(FileName, FileMode.Create)))
        //    {
        //        writer.Write($"File created {DateTime.Now} on {Environment.OSVersion}");
        //        //writer.Write("Text");
        //        //writer.Write(35);
        //        //writer.Write(false);
        //        //writer.Write(true);
        //    }
        //}
        /// <summary>
        /// Чтение бинарного файла
        /// </summary>
        //static void ReadValues()
        //{
        //    //float FloatVal;
        //    string StringVal;
        //    //int IntVal;
        //    //bool BoolVal;
            
        //    if (File.Exists(FileName))
        //    {
        //        using (BinaryReader reader = new BinaryReader(File.Open(FileName, FileMode.Open)))
        //        {
        //            //FloatVal = reader.ReadSingle();
        //            StringVal = reader.ReadString();
        //            //IntVal = reader.ReadInt32();
        //            //BoolVal = reader.ReadBoolean();
        //        }

        //        Console.WriteLine(string.Concat(StringVal));
        //    }
        //}

    }
}
// 02.10.2024 13:01:40
