using System.Text;
namespace Services.PrimaryServices
{
    public class HandleFilePath : IHeadCmdArgHandler
    {
        public async Task ReturnSpecificNumOfLines(string? filePath, short numOfLinesToReturn = 10)
        {
            StringBuilder stringOfLinesToReturn = new StringBuilder();
            using (StreamReader streamReader = new StreamReader(filePath!))
            {
                int minNumOfLinesToReturn = 0;
                while (!streamReader.EndOfStream && minNumOfLinesToReturn < numOfLinesToReturn)
                {
                    stringOfLinesToReturn.AppendLine(await streamReader.ReadLineAsync());
                    minNumOfLinesToReturn++;
                }
            }
            Console.WriteLine(stringOfLinesToReturn.ToString());
        }

        public async Task ReturnSpecificNumOfBytes(string? filePath, short numberOfBytes)
        {
            char[] resultingCharArray;
            using (StreamReader streamReader = new StreamReader(filePath!, Encoding.ASCII))
            {
                resultingCharArray = new char[numberOfBytes];
                await streamReader.ReadAsync(resultingCharArray, 0, numberOfBytes);
            }
            Console.WriteLine(new string(resultingCharArray));
        }
    }
}
