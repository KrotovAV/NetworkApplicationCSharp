using System.Diagnostics;

namespace ConsoleApp03HW06
{
    internal class Program
    {
        public static void SrartProcc(string procName)
        {
            try
            {
                using (Process myProcess = new Process())
                {
                    myProcess.StartInfo.UseShellExecute = true;
                    myProcess.StartInfo.FileName = procName;
                    myProcess.StartInfo.CreateNoWindow = true;
                    myProcess.Start();

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        static void Main(string[] args)
        {
            string pathToServer = "D:\\GeekBrains\\My Git\\NetworkApplicationCSharp\\03_Lesson_HW\\ConsoleApp03HW\\bin\\Debug\\net7.0\\MyUDPServer.exe";
            SrartProcc(pathToServer);

            Thread.Sleep(1000);

            string pathToClient1 = "D:\\GeekBrains\\My Git\\NetworkApplicationCSharp\\03_Lesson_HW\\ConsoleApp03HW02\\bin\\Debug\\net7.0\\MyUDPClient1.exe";
            //string pathToClient2 = "D:\\GeekBrains\\My Git\\NetworkApplicationCSharp\\03_Lesson_HW\\ConsoleApp03HW03\\bin\\Debug\\net7.0\\MyUDPClient2.exe";

            SrartProcc(pathToClient1);
            //SrartProcc(pathToClient2);

            string pathToAutoClient1 = "D:\\GeekBrains\\My Git\\NetworkApplicationCSharp\\03_Lesson_HW\\ConsoleApp03HW04\\bin\\Debug\\net7.0\\MyUDPClient1Auto.exe";
            //string pathToAutoClient2 = "D:\\GeekBrains\\My Git\\NetworkApplicationCSharp\\03_Lesson_HW\\ConsoleApp03HW03\\bin\\Debug\\net7.0\\MyUDPClient2Auto.exe";

            SrartProcc(pathToAutoClient1);
            //SrartProcc(pathToAutoClient2);
        }
    }
}