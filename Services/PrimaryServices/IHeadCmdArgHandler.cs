namespace Services.PrimaryServices
{
    public interface IHeadCmdArgHandler
    {
        public Task ReturnSpecificNumOfLines(string? filePath, short numOfLines);
        public Task ReturnSpecificNumOfBytes(string? filePath, short numOfBytes);

    }
}
