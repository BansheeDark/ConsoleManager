using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;
using ConsoleManager.Model.Command;
using ConsoleManager.Properties;

namespace ConsoleManager.ViewModel
{
    public class Data
    {
        #region Fields

        private readonly string path = @"C:\Users\nicki\desktop\i.txt";
        private readonly string error = "Error";
        private FileStream _file;
        private readonly string filenotexist = "_file not exist! Create now?";
        private XmlSerializer ser;
        private BindingList<UserCommand> template = null;//  field assigned to create the model data file.

        #endregion


        #region ReadFile and GetData

        public BindingList<UserCommand> GetData()
        {
            try
            {
                if(Settings.Default.FirstCreateFile)
                FileExist(path,true);
                else FileExist(path, false);
                _file = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.None);
                ser = new XmlSerializer(typeof(BindingList<UserCommand>));
                var res = (BindingList<UserCommand>) ser.Deserialize(_file);
                _file.Close();
                return res;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, error, MessageBoxButtons.OK);
                return null;
            }
        }

        #endregion

        #region CreateFile and SaveInFile

        public void CreateFile()
        {
            try
            {
                if (Settings.Default.FirstCreateFile) Settings.Default.FirstCreateFile = true;
                _file = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None);
                ser = new XmlSerializer(typeof(BindingList<UserCommand>));
                ser.Serialize(_file, template);
                _file.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, error, MessageBoxButtons.OK);
            }
        }

        public void SetData(BindingList<UserCommand> list)
        {
            try
            {

                FileExist(path,false);
                _file = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None);
                ser = new XmlSerializer(typeof(BindingList<UserCommand>));
                ser.Serialize(_file, list);
                _file.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, error, MessageBoxButtons.OK);
            }
        }

        #endregion

        #region _file check

        private bool FileExist(string pathToFile, bool firstStart)
        {
            if (!File.Exists(pathToFile) && !firstStart)
            {
                var message = MessageBox.Show(filenotexist, error, MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Error);
                if (message == DialogResult.OK)
                    try
                    {
                        CreateFile();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, error, MessageBoxButtons.OK);
                    }
                else if(message == DialogResult.Cancel)
                {
                    MessageBox.Show("", error, MessageBoxButtons.OK);
                }
            }
            else if(!File.Exists(pathToFile) && firstStart)
            {
                try
                {
                    CreateFile();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, error, MessageBoxButtons.OK);
                }
            }
            return true;
        }

        #endregion
    }
}