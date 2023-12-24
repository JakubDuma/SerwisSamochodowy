using AutoMapper;
using ProjectCar.Data.Interface;
using ProjectCar.Data.Models;
using ProjectCar.Services.DTO;
using ProjectCar.Services.Interface;

namespace ProjectCar.Services.Service
{
    internal class TimetableService : ITimetableService
    {
        private readonly ITimetableRepository _timetableRepository;
        private readonly IMapper _mapper;

        public TimetableService(ITimetableRepository timetableRepository, IMapper mapper)
        {
            _timetableRepository = timetableRepository;
            _mapper = mapper;
        }

        public TimetableDTO Create(TimetableDTO timetable)
        {
            var newTimetable = _mapper.Map<Timetable>(timetable);
            _timetableRepository.Create(newTimetable);
            return _mapper.Map<TimetableDTO>(newTimetable);
        }

        public void Delete(int id)
        {
            _timetableRepository.Delete(id);
        }

        public TimetableDTO Get(int id)
        {
            var part = _timetableRepository.Get(id);
            return _mapper.Map<TimetableDTO>(part);
        }

        public List<TimetableDTO> GetAll()
        {
            var timetables = _timetableRepository.GetAll();
            return _mapper.Map<List<TimetableDTO>>(timetables);
        }

        public void Update(TimetableDTO timetable)
        {
            var updateTimetable = _mapper.Map<Timetable>(timetable);
            _timetableRepository.Update(updateTimetable);
        }
    }
}