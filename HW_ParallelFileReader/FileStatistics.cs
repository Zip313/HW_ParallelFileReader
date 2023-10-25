using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_ParallelFileReader
{
    public class FileStatistics
    {
        public string FilePath { get; set; }
        public int CountSpaces { get; set; }
        public int Length { get; set; }
        public ulong TimeToReadInMilliseconds { get; set; }
        public int ThreadId { get; set; }
        public TimeOnly TimeStart { get; set; } = TimeOnly.FromDateTime(DateTime.Now);

        public override string ToString()
        {
            return $"StartedAt: {TimeStart.ToTimeSpan()}, FilePath: {Path.GetFileName(FilePath)}, Length: {Length}, TimeToRead: {TimeToReadInMilliseconds}ms, CountSpaces: {CountSpaces}, ThreadId: {ThreadId}";
        }
    }
}
