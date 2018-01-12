using System;

namespace ConsoleManager.Model.Command
{
    public class DefaultCommand : CommandModel
    {
        private string commandText;

        private string description;

        private string key;

        private string name;

        public override string Name
        {
            get => name;
            set => name = value != null ? name = value.Trim() : String.Empty;
        }

        public override string Key
        {
            get => key;
            set => key = value != null ? key = value.Trim() : String.Empty;
        }

        public override string CommandText
        {
            get => commandText; 
            set => commandText = value!=null ? commandText = value.Trim() : String.Empty;
        }

        public override string Description
        {
            get => description;
            set => description = value != null ? description = value.Trim() : String.Empty;
        }

        public override bool IsNullOrEmpty(string value)
        {
            if (value != " " && value != null)
                return false;
            return true;
        }

        public override string ToString()
        {
            return "Command: " + Name + " { " + CommandText + " } (" + Description + ")";
        }
    }
}