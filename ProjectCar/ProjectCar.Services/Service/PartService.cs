using AutoMapper;
using ProjectCar.Data.Interface;
using ProjectCar.Data.Models;
using ProjectCar.Services.DTO;
using ProjectCar.Services.Interface;

namespace ProjectCar.Services.Service
{
    internal class PartService : IPartService
    {
        private readonly IPartRepository _partRepository;
        private readonly IMapper _mapper;

        public PartService(IPartRepository partRepository, IMapper mapper)
        {
            _partRepository = partRepository;
            _mapper = mapper;
        }

        public PartDTO Create(PartDTO part)
        {
            var newPart = _mapper.Map<Part>(part);
            _partRepository.Create(newPart);
            return _mapper.Map<PartDTO>(newPart);
        }

        public void Delete(int id)
        {
            _partRepository.Delete(id);
        }

        public PartDTO Get(int id)
        {
            var part = _partRepository.Get(id);
            return _mapper.Map<PartDTO>(part);
        }

        public List<PartDTO> GetAll()
        {
            var parts = _partRepository.GetAll();
            return _mapper.Map<List<PartDTO>>(parts);
        }

        public void Update(PartDTO part)
        {
            var updatePart = _mapper.Map<Part>(part);
            _partRepository.Update(updatePart);
        }
    }
}