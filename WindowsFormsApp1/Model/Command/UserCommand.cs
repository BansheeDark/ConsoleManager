using System;

namespace ConsoleManager.Model.Command
{
    public class UserCommand : DefaultCommand
    {
        private long id;

        private string programName;

        private string programPath;

        public long Id
        {
            get => id;
            set => id = value > 0 ? id = value : 0;
        }

        public string ProgramName
        {
            get => programName;
            set => programName = value != null ? programName = value.Trim() : String.Empty;
        }

        public string ProgramPath
        {
            get => programPath;
            set => programPath = value != null ? programPath = value.Trim() : String.Empty;
        }

        public override string ToString()
        {
            if (!IsNullOrEmpty(Key))
                Key = " (" + Key + ") ";
            return "Command: " + Id + " - " + Name + " {" + Key + CommandText + " } (" + Description + ")" + "\r\n"
                   + "Program: " + ProgramName + " { " + ProgramPath + " }";
        }
    }
}