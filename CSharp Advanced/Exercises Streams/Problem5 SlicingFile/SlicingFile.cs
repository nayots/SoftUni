using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem5_SlicingFile
{
    class SlicingFile
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Use sample.jpg in the problem folder for testing or enter the values yourself ?");
            Console.Write("Y/N: ");
            var choice = Console.ReadLine().ToUpper();

            if (choice == "Y")
            {
                UseTest();
            }
            else
            {
                Console.Write("Slice or Merge: ");
                var featureChoice = Console.ReadLine().ToLower();

                if (featureChoice == "slice")
                {
                    Console.WriteLine("Slicin chosen.");
                    Console.Write("Enter file path: ");
                    var filePath = Console.ReadLine();
                    Console.Write("Enter destination folder: ");
                    var folder = Console.ReadLine();
                    Console.WriteLine("Split the file in how many ");
                    var slices = int.Parse(Console.ReadLine());
                    try
                    {
                        Slice(filePath, folder, slices);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Something went wrong when slicing: {ex.Message}");
                    }
                }
                else
                {
                    Console.WriteLine("Merging chosen.");

                    var files = new List<string>();
                    int counter = 1;
                    Console.WriteLine("Enter files paths or END to stop adding files to the list.");
                    Console.Write($"Path for file{counter}: ");
                    var path = Console.ReadLine();
                    while (path.ToUpper() != "END")
                    {
                        counter++;
                        files.Add(path);
                        Console.Write($"Path for file{counter}: ");
                        path = Console.ReadLine();
                    }

                    Console.Write("Enter destination folder: ");
                    var folder = Console.ReadLine();

                    Console.Write("Enter name for merged file: ");
                    var fileName = Console.ReadLine();

                    try
                    {
                        Assemble(files, folder, fileName);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Something went wrong when merging: {ex.Message}");
                    }
                }
            }
        }

        private static void UseTest()
        {
            //If you are too lazy to enter the properties yourself just use the next couple of lines
            //and the program wil use the sample.jpg in the problem folder(if you have not deleted it for some reason) for the rest run.
            //<test code start>
            Slice(@"..\..\sample.jpg", @"..\..\PhotoSlices", 4);
            Assemble(new List<string>() { @"..\..\PhotoSlices\SamplePart1.jpg", @"..\..\PhotoSlices\SamplePart2.jpg", @"..\..\PhotoSlices\SamplePart3.jpg", @"..\..\PhotoSlices\SamplePart4.jpg" }, @"..\..\MergeResults", "MergedJPGFile");
            //</test code end>
        }

        private static void Slice(string sourceFile, string destinationDirectory, int parts)
        {
            if (!Directory.Exists(destinationDirectory))
            {
                Directory.CreateDirectory(destinationDirectory);
            }
            Console.WriteLine("Slicing...");
            FileStream fsIN = new FileStream(sourceFile, FileMode.Open, FileAccess.Read);
            using (fsIN)
            {
                int sizeOfEachFile = (int)Math.Ceiling((double)fsIN.Length / parts);
                string fileName = Path.GetFileNameWithoutExtension(sourceFile);
                string extension = Path.GetExtension(sourceFile);

                for (int i = 1; i <= parts; i++)
                {
                    var outFilepath = destinationDirectory + "\\" + fileName + $"Part{i}" + extension;
                    FileStream fsOUT = new FileStream(outFilepath, FileMode.Create, FileAccess.Write);

                    using (fsOUT)
                    {
                        int bytesRead = 0;
                        byte[] buffer = new byte[sizeOfEachFile];

                        if ((bytesRead = fsIN.Read(buffer, 0, sizeOfEachFile)) > 0)
                        {
                            fsOUT.Write(buffer, 0, bytesRead);
                        }
                    }
                }
            }
            Console.WriteLine("Slicing done.");
        }

        private static void Assemble(List<string> files, string destinationDirectory, string filename)
        {
            if (files.Count <= 0)
            {
                Console.WriteLine("No input files specified!");
                return;
            }
            if (!Directory.Exists(destinationDirectory))
            {
                Directory.CreateDirectory(destinationDirectory);
            }

            Console.WriteLine("Merging");

            var fn = filename;
            var fileExtension = Path.GetExtension(files.First());

            var path = destinationDirectory + "\\" + fn + fileExtension;

            FileStream fsOUT = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);

            using (fsOUT)
            {
                foreach (var filePath in files)
                {
                    byte[] buffer = new byte[1024];
                    int bytesRead = 0;

                    FileStream inpFile = new FileStream(filePath, FileMode.Open, FileAccess.Read);

                    using (inpFile)
                    {
                        while ((bytesRead = inpFile.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            fsOUT.Write(buffer, 0, bytesRead);
                        }
                    }
                }
            }

            Console.WriteLine("Files Merged");
        }
    }
}