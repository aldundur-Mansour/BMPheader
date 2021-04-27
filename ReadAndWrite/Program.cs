using System;
using System.IO; 

namespace BmpHeaderDecoder
{
    class Program
    {

        const string fileName = @"C:\Users\lenovo1\Desktop\input2.bmp";
        static void Main()
        {
            DisplayValues();
        }

        public static void DisplayValues()
        {
           
            byte[] arrOfBytes = null;
            int length = (int) new FileInfo(fileName).Length ;

            if (File.Exists(fileName))
            {
                using (BinaryReader reader = new BinaryReader(File.Open(fileName, FileMode.Open)))
                {
                    try
                    {
                        arrOfBytes = reader.ReadBytes(length);
                       
                    } catch (Exception e)
                    {
                        Console.WriteLine(e); 
                    }
                                 
                }

                // GENERAL header Information  14 bytes 
                byte[] magicCode; // first to bytes 2 bytes 
                byte[] fileSize; // 4 bytes  
                // reserved; // 4 bytes  
                // DataOffset; // 4 bytes 

                // Decide Ranges 0 - 14 Header
                magicCode = arrOfBytes[0..2];
                Console.WriteLine("Magic Number: " + BitConverter.ToString(magicCode));
                fileSize = arrOfBytes[2..6];
                Console.WriteLine("File size in Bytes: " + BitConverter.ToInt32(fileSize));

                // Info Header 40 bytes 
                byte[] sizeOfInfoHeader = arrOfBytes[14..18];
                Console.WriteLine("Size Of the Info Header in Bytes: " + BitConverter.ToInt32(sizeOfInfoHeader));
                byte[] width = arrOfBytes[18..22];
                Console.WriteLine("Width of The image: " + BitConverter.ToInt32(width));
                byte[] height = arrOfBytes[22..26];
                Console.WriteLine("Height of The image: " + BitConverter.ToInt32(height));
                byte[] numberOfPlanes = arrOfBytes[26..28];
                Console.WriteLine("Number Of Planes: " + BitConverter.ToInt16(numberOfPlanes));
                byte[] bitsPerPixel = arrOfBytes[28..30];
                Console.WriteLine("Bits Per Pixel: " + BitConverter.ToInt16(bitsPerPixel));
                byte[] comperssion = arrOfBytes[30..34];
                Console.WriteLine("Compression: " + BitConverter.ToInt32(comperssion));
                byte[] imageSize = arrOfBytes[34..38];
                Console.WriteLine("Compressed Image Size: " +(BitConverter.ToInt32(comperssion)==0?0:BitConverter.ToInt32(imageSize)));
                byte[] XpixelsPerM = arrOfBytes[38..42];
                Console.WriteLine("XpixelsPerM: " + BitConverter.ToInt32(XpixelsPerM));
                byte[] YpixelsPerM = arrOfBytes[42..46];
                Console.WriteLine("YpixelsPerM: " + BitConverter.ToInt32(YpixelsPerM));
                byte[] colorsUsed = arrOfBytes[46..50];
                Console.WriteLine("Colors Used: " + BitConverter.ToInt32(colorsUsed));
                byte[] importantColors = arrOfBytes[50..54];
                Console.WriteLine("importantColors: " + BitConverter.ToInt32(importantColors));






            }

            

        }

    }

    }