namespace ConsoleManager.Model.Command
{
    public abstract class CommandModel
    {
        public abstract string Name { get; set; }
        public abstract string Key { get; set; }
        public abstract string CommandText { get; set; }
        public abstract string Description { get; set; }
        public abstract bool IsNullOrEmpty(string value);
    }
}