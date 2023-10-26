namespace HW_ParallelFileReader
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            List<string> files = new List<string>() 
            {
                @"c:\temp\1.txt",
                @"c:\temp\2.txt",
                @"c:\temp\3.txt",
            };
            IFileReader fileReader = new FileReader(files);
            var statistics = await fileReader.GetStatistic();

            foreach ( var item in statistics )
            {
                Console.WriteLine(item); 
            }
        }
    }
}