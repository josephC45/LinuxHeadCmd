namespace Services.PrimaryServices
{
    public class HeadCmdArgHandler
    {
        private readonly IHeadCmdArgHandler _headCmdArgHandler;
        public HeadCmdArgHandler(IHeadCmdArgHandler argHandler)
        {
            _headCmdArgHandler = argHandler;
        }

        public async Task GetSpecificNumOfLines(string? filePath, short numOfLines = 10)
        {
            await _headCmdArgHandler.ReturnSpecificNumOfLines(filePath, numOfLines);
        }

        public async Task GetSpecificNumOfBytes(string? filePath, short numOfBytes)
        {
            await _headCmdArgHandler.ReturnSpecificNumOfBytes(filePath, numOfBytes);
        }
    }
}
