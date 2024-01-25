using ProjectCar.Services.DTO;

namespace ProjectCar.Services.Interface
{
    public interface IPartService
    {
        PartDTO Create(PartDTO part);

        void Delete(int id);

        PartDTO Get(int id);

        List<PartDTO> GetAll();

        void Update(PartDTO part);

        void CreateWW(PartDTO part, int quantity);

        void CreateWZ(TimetableDTO timetable);
    }
}