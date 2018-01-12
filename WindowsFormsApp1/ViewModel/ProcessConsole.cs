using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ConsoleManager.ViewModel
{
     class ProcessConsole
    {
        private static StringBuilder cmdOutput;
        private static int numOutputLines;
        private static bool _complete;
        private static Process cmdProcess;
        private static StreamWriter cmdStreamWriter;
        public static event Action<bool> CommandComplete;
        public static event Action<int> ProgressValue;
        public static event Action<string> OutputData;

        public void Run()
        {
            try
            {
                cmdOutput = new StringBuilder();
                cmdProcess = new Process();
                cmdProcess.StartInfo.FileName = "cmd.exe";
                cmdProcess.StartInfo.UseShellExecute = false;
                cmdProcess.StartInfo.RedirectStandardError = true;
                cmdProcess.StartInfo.RedirectStandardOutput = true;
                cmdProcess.StartInfo.RedirectStandardInput = true;
                cmdProcess.StartInfo.StandardOutputEncoding = Encoding.GetEncoding(866);
                cmdProcess.StartInfo.CreateNoWindow = true;
                cmdProcess.OutputDataReceived += SortOutputHandler;
                cmdProcess.Start();
                cmdProcess.ErrorDataReceived += SortOutputHandler;
                cmdStreamWriter = cmdProcess.StandardInput;
                cmdProcess.BeginOutputReadLine();
                cmdProcess.BeginErrorReadLine();                            
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
            }
        }

        public static void CommandRun(string command)
        {
            try
            {
                ProgressValue(25);
                _complete = true;
                ProgressValue(50);
                cmdStreamWriter.WriteLine(command);
                ProgressValue(75);
                CommandComplete(_complete);
                ProgressValue(100);

            }
            catch (Exception ex)
            {
                try
                {
                    _complete = false;
                    CommandComplete(_complete);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
            }
            finally
            {
                Console.WriteLine(command);
            }
        }

        public static void Stop()
        {
            if (cmdStreamWriter != null)
            {
                cmdStreamWriter.Close();
            }
            if (cmdProcess != null)
            {
               cmdProcess.Close();
            }
            
        }

        private static void SortOutputHandler(object sendingProcess, DataReceivedEventArgs outLine)
        {
            if (!string.IsNullOrEmpty(outLine.Data))
            {
                numOutputLines++;
                cmdOutput.Append( DateTime.Now.ToString("HH:mm:ss") + " " + "[" + numOutputLines + "] - " + outLine.Data + Environment.NewLine);
                OutputData(cmdOutput.ToString());
                Console.WriteLine(outLine.Data);               
            }
        }
    }
}