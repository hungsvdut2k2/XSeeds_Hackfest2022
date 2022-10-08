using API.Core.IRepository;
using API.Models.ModelDBs;
using API.Services.IServices;

namespace API.Services
{
    public class UnitService : IUnitService
    {
        private readonly IUnitRepository _unitRepository;

        public UnitService(IUnitRepository unitRepository)
        {
            this._unitRepository = unitRepository;
        }
        public async Task<Unit> AddAsync(Unit unit)
        {
            await _unitRepository.AddAsync(unit);
            _unitRepository.Save();
            return unit;
        }

        public void Delete(Unit unit)
        {
            _unitRepository.Delete(unit);
            _unitRepository.Save();
                
        }

        public async Task<IEnumerable<Unit>> GetAllAsync()
        {
           return await _unitRepository.GetAllAsync();
            
        }

       

        public async Task<IEnumerable<Unit>> getUnitByCourse(int Course_Id)
        {
           return await _unitRepository.GetUnitByIdCourse(Course_Id);
        }

        public async Task<Unit> GetUnitById(int course_Id)
        {
            return await _unitRepository.GetUnitById(course_Id);
        }

        public void Update(Unit teacher)
        {
             _unitRepository.Update(teacher);
            _unitRepository.Save();

        }
    }
}
