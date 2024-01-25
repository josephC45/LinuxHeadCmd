namespace TestProject.Mock
{
    internal class MockFunctionalityHandler
    {
        private readonly IMockFunctionality _mockFunctionalityInterface;

        public MockFunctionalityHandler(IMockFunctionality mockFunctionalityInterface)
        {
            _mockFunctionalityInterface = mockFunctionalityInterface;
        }

        public string? GetCmdOption(string? option)
        {
            return _mockFunctionalityInterface.DetermineCmdOption(option);
        }

        public async Task<string?> GetLines(string? filePath, short numOfLines = 10)
        {
            return await _mockFunctionalityInterface.ReturnSpecificNumOfLines(filePath, numOfLines);
        }

        public async Task<string?> GetBytes(string? filePath, short numOfBytes)
        {
            return await _mockFunctionalityInterface.ReturnSpecificNumOfBytes(filePath, numOfBytes);
        }
    }
}
