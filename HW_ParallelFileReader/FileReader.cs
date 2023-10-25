using System.Diagnostics;

namespace HW_ParallelFileReader
{
    public class FileReader : IFileReader
    {
        private List<string> filesPath;

        public FileReader(List<string> filesPath)
        {
            this.filesPath = filesPath;
        }


        private FileStatistics CalculateSpacesInFile(string filePath)
        {
            FileStatistics fileStatistics = new FileStatistics();

            Stopwatch sw = new Stopwatch();
            sw.Start();
            string text = File.ReadAllText(filePath);
            int countSpacesInFile = 0;
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == ' ') {  countSpacesInFile++; }
            }
            sw.Stop();
            fileStatistics.TimeToReadInMilliseconds = (ulong) sw.ElapsedMilliseconds;
            fileStatistics.CountSpaces = countSpacesInFile;
            fileStatistics.Length = text.Length;
            fileStatistics.FilePath = filePath;
            fileStatistics.ThreadId = Thread.CurrentThread.ManagedThreadId;
            return fileStatistics;
        }

        public List<FileStatistics> GetStatistic()
        {
            List<Task<FileStatistics>> fileStatisticsTasks = new List<Task<FileStatistics>>();
            foreach (string filePath in filesPath)
            {
                var task = Task.Run(() => { return CalculateSpacesInFile(filePath); });
                fileStatisticsTasks.Add(task);
            }
            Task.WaitAll(fileStatisticsTasks.ToArray());
            var res = fileStatisticsTasks.Select(task => task.Result).ToList();

            return res;
        }
    }
}
