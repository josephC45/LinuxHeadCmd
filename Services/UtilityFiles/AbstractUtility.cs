namespace Services.UtilityFiles
{
    public abstract class AbstractUtility
    {
        public abstract string? DetermineCmdOption(string? option);
        public abstract short? DetermineNumOfLinesOrBytesToRead(string? numberOfLinesToRead);
        public abstract void AddFilePathsToList(List<string>? fileList, string? filePath);
        public abstract (List<string>, string?, short?) ParseCmdLineArgs();
        public (List<string>, string?, short?) operationalCheck()
        {
            return ParseCmdLineArgs();
        }
    }
}
