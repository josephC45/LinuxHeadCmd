namespace Services.PrimaryServices
{
    public class HandleStdin : IHeadCmdArgHandler
    {
        public async Task ReturnSpecificNumOfLines(string? filePath, short currentNumOfLinesRead = 10)
        {
            int numOfLinesToRead = 0;
            while (numOfLinesToRead < currentNumOfLinesRead)
            {
                string? currentLineWritten = Console.ReadLine();
                Console.WriteLine(currentLineWritten);
                numOfLinesToRead++;
            }

            return;
        }

        /* This goes against ISP since I am depending on a method I am not utilizing.
         * I will revisit in the future and make necessary changes but for now
         * I am just experimenting with dependency injection.
         */
        public async Task ReturnSpecificNumOfBytes(string? filePath, short numOfBytes)
        {
        }
    }
}
