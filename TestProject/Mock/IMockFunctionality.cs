namespace TestProject.Mock
{
    internal interface IMockFunctionality
    {
        public string? DetermineCmdOption(string? option);
        public Task<string?> ReturnSpecificNumOfLines(string? filePath, short numOfLines = 10);
        public Task<string?> ReturnSpecificNumOfBytes(string? filePath, short numOfBytes);
    }
}
