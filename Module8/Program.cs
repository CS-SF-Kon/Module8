
namespace Module8
{
    internal class Program
    {
        const string FileName = @"C:\Users\User\Desktop\students.dat"; // данные для 4 задания
        const string Destination = @"C:\Users\User\Desktop\Students"; // данные для 4 задания
        static void Main(string[] args)
        {
            Cleaner.CleanUp(@"C:\test1" /* вставить путь к директории */); // метод для первого задания

            Console.WriteLine(Cleaner.VolumeCounter(@"C:\test2" /* вставить путь к директории */)); // метод для второго задания

            Cleaner.Combined(@"C:\test3" /* вставить путь к директории */); // метод для третьего задания


            List<Student> studs = Reader(FileName);


            if (!Directory.Exists(Destination))
            {
                Directory.CreateDirectory(Destination);
            }

            foreach (Student student in studs)
            {
                string filename = $"{Destination}\\{student.Group}.txt";
                
                FileInfo f = new FileInfo(filename);

                if (!f.Exists)
                {
                    using (StreamWriter sw = f.CreateText())
                    {
                        sw.WriteLine(string.Concat(student.Name, ", ", student.DateOfBirth, ", ", student.AverageScore));
                    }
                }
                else
                {
                    using (StreamWriter sw = f.AppendText()) // если запусить код ещё раз, а файлы уже будут созданы и будут содержать данные об учениках, информация просто продублируется - не придумал, как это побороть
                    {
                        sw.WriteLine(string.Concat(student.Name, ", ", student.DateOfBirth, ", ", student.AverageScore));
                    }
                }
            }
        }

        static List<Student> Reader(string f)
        {
            List<Student> result = new();
            using FileStream fs = new FileStream(f, FileMode.Open);
            using StreamReader sr = new StreamReader(fs);

            //Console.WriteLine(sr.ReadToEnd()); - зочемъ?

            fs.Position = 0;

            BinaryReader br = new BinaryReader(fs);

            while (fs.Position < fs.Length)
            {
                Student student = new Student();
                student.Name = br.ReadString();
                student.Group = br.ReadString();
                long dt = br.ReadInt64();
                student.DateOfBirth = DateTime.FromBinary(dt);
                student.AverageScore = br.ReadDecimal();

                result.Add(student);
            }

            fs.Close();

            return result;
        }
    }
}
