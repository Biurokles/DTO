using DTO.Dto;

namespace DTO.Interfaces
{
    public interface IHistoryService
    {
        HistoryDto GetHistory(int pageIndex);

        bool DeleteEntry(int entryId, int userId);
    }
}
