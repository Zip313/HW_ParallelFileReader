namespace HW_ParallelFileReader
{
    public interface IFileReader
    {
        Task<IEnumerable<FileStatistics>> GetStatistic();
    }
}