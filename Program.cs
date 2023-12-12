using MyLib;
using System.Xml.Serialization;
using System.IO;
using System.Text;
using System.IO.Compression;
using System.Diagnostics;

//internal class Task1
//{
//    private static void Main()
//    {
//        Lion lion0 = new Lion("Egypt", "No reason to hide. I'm a king", "King", "Lion");
//        Lion lion1 = new Lion("Russia", "Too lazy to hide", "Lev", "Lion");
//        Lion[] animals = { lion0, lion1 };
//        XmlSerializer serializer = new XmlSerializer(typeof(Lion[]));
//        using (FileStream xdoc = new FileStream("serialized.xml", FileMode.OpenOrCreate))
//            serializer.Serialize(xdoc, animals);
//        using (FileStream xdoc = new FileStream("serialized.xml", FileMode.OpenOrCreate))
//        {
//            Lion[] lions = serializer.Deserialize(xdoc) as Lion[];
//            foreach (Lion lion in lions) Console.WriteLine($"{lion.Name} {lion.Country} {lion.HideFromOtherAnimals} {lion.WhatAnimal}");
//        }
//    }
//}

internal class Task2
{
    public async static void search(DirectoryInfo mydir, FileInfo goal)
    {
        DirectoryInfo[] subdir = mydir.GetDirectories();
        FileInfo[] files = mydir.GetFiles();
        foreach (FileInfo file in files)
        {
            if (file.Name == goal.Name)
            {
                Console.WriteLine($"found in {file.FullName}");
                using (FileStream fs = new FileStream(file.FullName, FileMode.OpenOrCreate))
                {
                    byte[] buffer = new byte[file.Length];
                    fs.Read(buffer, 0, Convert.ToInt32(file.Length));
                    Console.WriteLine(Encoding.Default.GetString(buffer));
                }
                using (FileStream originalFileStream = File.OpenRead(file.FullName))
                {
                    using (FileStream compressedFileStream = File.Create(file.DirectoryName + "\\compressed.zip"))
                    {
                        using (ZipArchive myarchive = new ZipArchive(compressedFileStream, ZipArchiveMode.Create))
                        {
                            ZipArchiveEntry entry = myarchive.CreateEntry(file.Name);
                            using (Stream entryStream = entry.Open()) originalFileStream.CopyTo(entryStream);
                        }
                    }
                }

                return;
            }

        }
        foreach (DirectoryInfo sub in subdir) { search(sub, goal); }

    }
    private static void Main()
    {
        Console.WriteLine("Input directory's name:");
        DirectoryInfo mydir = new DirectoryInfo(Console.ReadLine());
        Console.WriteLine("Input file's name:");
        FileInfo goal = new FileInfo(Console.ReadLine());
        if (mydir.Exists) search(mydir, goal);
    }
}
