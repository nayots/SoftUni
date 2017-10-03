using System;
using System.IO;
using System.Threading.Tasks;

namespace Problem2_SliceFileAsync
{
    class Startup
    {
        private static void Main(string[] args)
        {
            Console.Write("File path: ");
            string filePath = Console.ReadLine();
            Console.Write("Destination folder: ");
            string destinationPath = Console.ReadLine();
            Console.Write("Pieces count: ");
            int pieces = int.Parse(Console.ReadLine());

            Task.Run(() =>
            {
                Slice(filePath, destinationPath, pieces);
            });

            while (true)
            {
                if (Console.ReadLine() == "exit")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Enter exit to quit.");
                }
            }
        }

        private static void Slice(string sourceFile, string destinationPath, int parts)
        {
            if (!Directory.Exists(destinationPath))
            {
                Directory.CreateDirectory(destinationPath);
            }

            using (var source = new FileStream(sourceFile, FileMode.Open))
            {
                FileInfo fileInfo = new FileInfo(sourceFile);

                if (parts == 0)
                {
                    parts = 1;
                }

                long partLength = (source.Length / parts) + 1;
                long currentByte = 0;
                long bufferLength = (source.Length / parts) + 1;

                Console.WriteLine("Slicing started...");

                for (int currentPart = 1; currentPart <= parts; currentPart++)
                {
                    string filePath = $"{destinationPath}/Part-{currentPart}{fileInfo.Extension}";

                    using (var destination = new FileStream(filePath, FileMode.Create))
                    {
                        byte[] buffer = new byte[bufferLength];
                        while (currentByte < partLength * currentPart)
                        {
                            int readBytesCount = source.Read(buffer, 0, buffer.Length);

                            if (readBytesCount == 0)
                            {
                                break;
                            }

                            destination.Write(buffer, 0, readBytesCount);
                            currentByte += readBytesCount;
                        }
                    }

                    Console.WriteLine($"Part {currentPart}/{parts} ready.");
                }

                Console.WriteLine("Slice complete.");
            }
        }
    }
}