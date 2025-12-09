using System;
using System.Collections.Generic;

namespace FileExtensionInfoSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            // Dictionary to store extension → description
            Dictionary<string, string> fileExtensions = new Dictionary<string, string>()
            {
                { ".mp4", "Video file (MPEG-4)" },
                { ".mp3", "Audio file (MP3 audio)" },
                { ".mov", "Apple QuickTime video" },
                { ".avi", "Audio Video Interleave video" },
                { ".mkv", "Matroska video file" },
                { ".webm", "Open media video format" },
                { ".wav", "Waveform audio file" },
                { ".flac", "Free Lossless Audio Codec audio file" },
                { ".jpg", "JPEG image file" },
                { ".png", "Portable Network Graphics image" },
                { ".gif", "Graphics Interchange Format image" },
                { ".bmp", "Bitmap image file" },
                { ".txt", "Plain text file" },
                { ".pdf", "Portable Document Format file" },
                { ".docx", "Microsoft Word document" },
                { ".xlsx", "Microsoft Excel workbook" },
                { ".pptx", "Microsoft PowerPoint presentation" },
                { ".zip", "Compressed archive file" },
                { ".rar", "WinRAR compressed file" },
                { ".exe", "Windows executable program" },
                { ".html", "Web page file (HyperText Markup Language)" },
                { ".css", "Cascading Style Sheets file" },
                { ".js", "JavaScript file" }
            };

            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("      FILE EXTENSION INFORMATION SYSTEM");
            Console.WriteLine("--------------------------------------------------");

            while (true)
            {
                Console.WriteLine("\nEnter a file extension (e.g. .mp4, .pdf, .jpg)");
                Console.Write("Type 'exit' to quit → ");

                string? input = Console.ReadLine()?.ToLower().Trim();

                if (input == "exit")
                {
                    Console.WriteLine("Exiting program... Goodbye!");
                    break;
                }

                // Ensure input starts with a dot
                if (!input.StartsWith("."))
                {
                    Console.WriteLine("Invalid format! Extensions should start with a dot (e.g. .mp4).");
                    continue;
                }

                // Check if extension exists
                if (fileExtensions.ContainsKey(input))
                {
                    Console.WriteLine($"Extension: {input}");
                    Console.WriteLine($"Description: {fileExtensions[input]}");
                }
                else
                {
                    Console.WriteLine($"Sorry, no information found for '{input}'.");
                }
            }
        }
    }
}
