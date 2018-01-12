
using ConsoleManager.Properties;
using ConsoleManager.ViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ConsoleManager
{
    public partial class Form1 : Form
    {
        List<CommandCMD> commlist = new List<CommandCMD>();
  
        
        [DllImport("user32.dll")]
        static extern bool HideCaret(IntPtr hWnd);
        public Form1()
        {
            this.Text = Settings.Default.ManagerName + " v."+ Application.ProductVersion;
            InitializeComponent();
            statusabel.Text = "Wait Command";
            progressBar1.Maximum = 100;
            ProcessConsole pc = new ProcessConsole();
            Thread t = new Thread(pc.Run);
            t.Start();
            ProcessConsole.CommandComplete += CommandCompleted;
            ProcessConsole.ProgressValue += ProgressValueChange;
            ProcessConsole.OutputData += GetOutputData;
            commlist.Add(new CommandCMD() { CommandName="Start Server", CommandText= @"c:\Server\bin\Apache24\bin\httpd.exe -k start" });
            commlist.Add(new CommandCMD() { CommandName = "Start Localhost", CommandText = @"start http://localhost" });
            commlist.Add(new CommandCMD() { CommandName = "Start MySql", CommandText = @"net start MySQL" });
            commlist.Add(new CommandCMD() { CommandName = "Restart Server", CommandText = @"c:\Server\bin\Apache24\bin\httpd.exe -k restart" });
            commlist.Add(new CommandCMD() { CommandName = "Restart MySql", CommandText = @"c:\Server\bin\mysql-5.7\bin\mysqld --restart" });
            commlist.Add(new CommandCMD() { CommandName = "Stop Server", CommandText = @"c:\Server\bin\Apache24\bin\httpd.exe -k stop" });
            commlist.Add(new CommandCMD() { CommandName = "Stop MySql", CommandText = @"net stop MySQL" });           
        }

        public void GetOutputData(string obj)
        {
            try
            {
                Action action = () =>
                {
                    textBox1.Text = obj;
                };
                if (action != null)
                {
                    Invoke(action);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);              
            }
        
        }

        public void ProgressValueChange(int i)
        {
            try
            {
                Action action = () =>
                {
                    progressBar1.Value = i;
                };
                Invoke(action);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }

        }

        public void CommandCompleted(bool complete)
        {
            try
            {
                Action action = () =>
                {
                    string status = complete ? "Done" : "Eror";
                    if (status == "Done")
                        statusabel.ForeColor = Color.DarkGreen;
                    else
                        statusabel.ForeColor = Color.DarkRed;
                    statusabel.Text = status;

                };
                Invoke(action);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }

        }

        public class CommandCMD
        {
            public string CommandName { get; set; }
            public string CommandText { get; set; }
            public override string ToString()
            {
                return CommandText;
            }
        }
        
        private void Btn_start_Click(object sender, EventArgs e)
        {
            foreach (CommandCMD c in commlist)
            {
                switch (c.CommandName)
                {
                    case "Start Server":
                        ProcessConsole.CommandRun(c.CommandText);                    
                        break;
                    case "Start MySql":
                        ProcessConsole.CommandRun(c.CommandText);                     
                        break;
                    case "Start Localhost":
                        ProcessConsole.CommandRun(c.CommandText);
                        break;
                }
            }          
        }

        private void Btn_restart_Click(object sender, EventArgs e)
        {
            foreach (CommandCMD c in commlist)
            {
                switch (c.CommandName)
                {
                    case "Restart Server":
                        ProcessConsole.CommandRun(c.CommandText);
                        break;
                    case "Restart MySql":
                        ProcessConsole.CommandRun(c.CommandText);                   
                        break;
                }
            }            
        }

        private void Btn_stop_Click(object sender, EventArgs e)
        {
            foreach (CommandCMD c in commlist)
            {
                switch (c.CommandName)
                {
                    case "Stop Server":
                        ProcessConsole.CommandRun(c.CommandText);
                        break;
                    case "Stop MySql":
                        ProcessConsole.CommandRun(c.CommandText);
                        break;
                }
            }        
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            ProcessConsole.Stop();
            Application.Exit();
        }

        private void Button3_Click(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            FormListManager formListManager = new FormListManager();
            formListManager.Show();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            HideCaret(textBox1.Handle);
        }
    }
}
