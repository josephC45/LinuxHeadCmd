using Services;
using Services.PrimaryServices;
using Services.UtilityFiles;
namespace LinuxHeadCmd_Main
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            Console.WriteLine("Head cmd is running...");
            AbstractUtility utility = new Utility(args);
            (List<string> fileList, string? cmdOption, short? cmdOptionNumber) = utility.operationalCheck();
            int numOfFiles = fileList.Count();

            //File paths exist
            if(numOfFiles > 0)
            {
                HeadCmdArgHandler argHandler = new(new HandleFilePath());
                if(numOfFiles == 1)
                {
                    if (cmdOption is null && cmdOptionNumber is null) await argHandler.GetSpecificNumOfLines(fileList[0]);
                    else if (cmdOption!.Equals(Constants.line) && cmdOptionNumber is not null) await argHandler.GetSpecificNumOfLines(fileList[0], (short)(cmdOptionNumber));
                    else if (cmdOption!.Equals(Constants.bytte) && cmdOptionNumber is not null) await argHandler.GetSpecificNumOfBytes(fileList[0], (short)(cmdOptionNumber));
                }
                else if(numOfFiles > 1)
                {
                    
                    foreach(string filePath in fileList)
                    {
                        Console.WriteLine($"==> {filePath} <==");
                        if (cmdOption is null || cmdOptionNumber is null) await argHandler.GetSpecificNumOfLines(filePath);
                        else if (cmdOption!.Equals(Constants.line) && cmdOptionNumber is not null) await argHandler.GetSpecificNumOfLines(filePath, (short)cmdOptionNumber);
                        else if (cmdOption!.Equals(Constants.bytte) && cmdOptionNumber is not null) await argHandler.GetSpecificNumOfBytes(filePath, (short)(cmdOptionNumber));
                    }

                }
            //We are reading from stdin
            }else
            {
                HeadCmdArgHandler argHandler = new(new HandleStdin());
                if (cmdOptionNumber is null) await argHandler.GetSpecificNumOfLines(null);
                else if(cmdOptionNumber is not null) await argHandler.GetSpecificNumOfLines(null, (short)cmdOptionNumber);
            }
            Console.ReadKey();
        }
    }
}
