using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleVideo
{
    internal class Program
    {
        public static void CutVideo(string inputFilePath, string outputFilePath, string startTime, string duration)
        {
            // Set up FFmpeg process start info
            var startInfo = new ProcessStartInfo();
            startInfo.FileName = "ffmpeg";
            startInfo.Arguments = $"-ss {startTime} -i \"{inputFilePath}\" -t {duration} -c copy \"{outputFilePath}\"";
            startInfo.RedirectStandardOutput = true;
            startInfo.RedirectStandardError = true;
            startInfo.UseShellExecute = false;

            // Start FFmpeg process
            var process = new Process();
            process.StartInfo = startInfo;
            process.Start();

            // Wait for process to finish
            process.WaitForExit();
        }

        static void Main(string[] args)
        {
            var inputFilePath = "C:\\fiap\\video_exemplo\\video2.mp4";
            Console.WriteLine("Qual será o tempo Inicio do vídeo?");
            var startTime = "00:00:30"; //Console.ReadLine();

            Console.WriteLine("Qual seria a duração do corte?");
            var duration = "00:00:10"; // Console.ReadLine(); //

            Console.WriteLine("Qual sera o nome do video?");
            var nome = Console.ReadLine(); //
            var outputFilePath = $"C:\\fiap\\video_exemplo\\{nome}.mp4";


            CutVideo(inputFilePath, outputFilePath, startTime, duration);
        }
    }
}
