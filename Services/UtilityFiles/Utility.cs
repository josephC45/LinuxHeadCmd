namespace Services.UtilityFiles
{
    public class Utility : AbstractUtility
    {
        private readonly string[] _args;
        public Utility(string[] args)
        {
            _args = args;
        }
        public override string? DetermineCmdOption(string? option)
        {
            //Determine which option
            if (option.Equals(Constants.line) || option.Equals(Constants.bytte)) return option;
            else return null;
        }

        public override short? DetermineNumOfLinesOrBytesToRead(string? numberOfLinesOrBytesToRead)
        {
            short numToRead = 0;
            if (short.TryParse(numberOfLinesOrBytesToRead, out numToRead) != false) return numToRead;
            else return null;

        }

        public override void AddFilePathsToList(List<string> fileList, string? filePath)
        {
            if (filePath?.Length >= 5)
            {
                string fileExtensison = filePath.Substring(filePath.Length - 4);
                if (fileExtensison.Equals(".txt"))
                {
                    fileList?.Add(filePath);
                }
            }
            return;
        }
        public override (List<string>, string?, short?) ParseCmdLineArgs()
        {
            List<string> fileList = new();
            string? cmdOption = null;
            short? cmdOptionNumber = null;

            cmdOption = DetermineCmdOption(this._args[0]);

            //Determine number of lines/bytes to print
            if (this._args.Length > 1)
            {
                cmdOptionNumber = DetermineNumOfLinesOrBytesToRead(this._args[1]);
            }
            foreach (string argument in this._args)
            {
                AddFilePathsToList(fileList, argument);
            }
            return (fileList, cmdOption, cmdOptionNumber);
        }
    }
}
