using Services;
using System.Text;
namespace TestProject.Mock
{
    internal class MockFunctionality : IMockFunctionality
    {
        public string? DetermineCmdOption(string? option)
        {
            //Determine which option
            if (option.Equals(Constants.line) || option.Equals(Constants.bytte)) return option;
            else return null;
        }

        public async Task<string?> ReturnSpecificNumOfLines(string? filePath, short numOfLinesToReturn = 10)
        {
            StringBuilder returningStringBuilder = new StringBuilder();
            using (StreamReader sr = new StreamReader(filePath))
            {
                int minNumOfLinesToReturn = 0;
                while (!sr.EndOfStream && minNumOfLinesToReturn < numOfLinesToReturn)
                {
                    returningStringBuilder.AppendLine(await sr.ReadLineAsync());
                    minNumOfLinesToReturn++;
                }
            }
            string linesToReturn = returningStringBuilder.ToString();
            return linesToReturn;
        }

        public async Task<string?> ReturnSpecificNumOfBytes(string? filePath, short numberOfBytes)
        {
            char[] resultingCharactersToReturn;
            using (StreamReader stream = new StreamReader(filePath, Encoding.ASCII))
            {
                resultingCharactersToReturn = new char[numberOfBytes];
                await stream.ReadAsync(resultingCharactersToReturn, 0, numberOfBytes);
            }
            string stringToReturn = new string(resultingCharactersToReturn);
            return stringToReturn;
        }
    }
}
