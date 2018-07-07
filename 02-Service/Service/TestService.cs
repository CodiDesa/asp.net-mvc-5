using Model.Domain;
using Persistence.DbContextScope;
using Persistence.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface ItestService
    {
        IEnumerable<Course> GetAll();
    }

    public class TestService : ItestService
    {
        private readonly IDbContextScopeFactory _dbContextScopeFactory;
        private readonly IRepository<Course> _courseRepo;

        public TestService(
            IDbContextScopeFactory dbContextScopeFactory,
            IRepository<Course> courseRepo
            )
        {
            _dbContextScopeFactory = dbContextScopeFactory;
            _courseRepo = courseRepo;
        }
       
        public IEnumerable<Course> GetAll()
        {
            var courses = new List<Course>();
            using (var ctx = _dbContextScopeFactory.CreateReadOnly())
            {
                courses = _courseRepo.GetAll(x => x.StudentPerCourses.Select(y=>y.Student)).ToList();

            }
                return courses;
        }
    }
}
