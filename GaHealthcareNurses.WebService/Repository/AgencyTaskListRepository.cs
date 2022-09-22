//using Contracts;
//using GaHealthcareNurses.Entity;
//using System.Collections.Generic;
//using System.Threading.Tasks;
//using System.Linq;
//using GaHealthcareNurses.Entity.Models;
//using Microsoft.EntityFrameworkCore;

//namespace Repository
//{
//    public class AgencyTaskListRepository : IAgencyTaskListRepository
//    {
//        private GaHealthcareNursesContext _gaHealthcareNursesContext;

//        #region Contructor For AgencyTaskListRepository
//        public AgencyTaskListRepository(GaHealthcareNursesContext context)
//        {
//            _gaHealthcareNursesContext = context;
//        }
//        #endregion

//        #region Implementing Interface
//        public async Task<AgencyTaskList> Add(AgencyTaskList agencyTaskList)
//        {
//            await _gaHealthcareNursesContext.AgencyTaskList.AddAsync(taskListTemplate);
//            await _gaHealthcareNursesContext.SaveChangesAsync();
//            return taskListTemplate;
//        }

//        public async Task Delete(AgencyTaskList taskListTemplate)
//        {
//            _gaHealthcareNursesContext.AgencyTaskList.Remove(taskListTemplate);
//            await _gaHealthcareNursesContext.SaveChangesAsync();
//        }

//        public async Task<IEnumerable<AgencyTaskList>> Get()
//        {
//            return await _gaHealthcareNursesContext.AgencyTaskList.Include(x=>x.TaskListTemplate).ToListAsync();
//        }

//        public async Task<AgencyTaskList> GetById(int id)
//        {
//            return await _gaHealthcareNursesContext.AgencyTaskList.Where(x => x.Id == id).FirstOrDefaultAsync();
//        }

//        public async Task<TaskListTemplate> Update(TaskListTemplate taskListTemplate)
//        {
//            _gaHealthcareNursesContext.TaskListTemplate.Update(taskListTemplate);
//            await _gaHealthcareNursesContext.SaveChangesAsync();
//            return taskListTemplate;
//        }
//        #endregion
//    }
//}
