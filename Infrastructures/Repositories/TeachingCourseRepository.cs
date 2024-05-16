using Applications.Commons;
using Applications.Interfaces;
using Applications.Repositories;
using Applications.ViewModels;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Infrastructures.Repositories
{
    public class TeachingCourseRepository : GenericRepository<TeachingCourse>, ITeachingCourseRepository
    {
        public TeachingCourseRepository(AppDbContext context, ICurrentTimeService currentTime, IClaimsServices claimsServices) : base(context, currentTime, claimsServices)
        {

        }

        public async Task<Pagination<TeachingCourse>> Filter(FilterTeachingCourseRequest request, int pageIndex = 0, int pageSize = 10)
        {
            var query = _dbSet.AsQueryable();
            if (request.CourseName is not null)
            {
                query = query.Where(x => x.CourseName.Contains(request.CourseName));
            }
            int checkDuration = 0; ;
            foreach(var item in request.DurationType)
            {
                if (item == 1)
                {
                    checkDuration = checkDuration + 1;
                }
                if (item == 2)
                {
                    checkDuration = checkDuration + 9;
                }
                if (item == 3)
                {
                    checkDuration = checkDuration + 20;
                }
            }

            if(checkDuration == 1)
            {
                query = query.Where(x => x.Duration <= 60);
            } else if(checkDuration == 9)
            {
                query = query.Where(x => x.Duration >= 60 && x.Duration <=120);
            }
            else if (checkDuration == 20)
            {
                query = query.Where(x => x.Duration > 120);
            }
            else if (checkDuration == 10)
            {
                query = query.Where(x =>x.Duration <= 120);
            }
            else if (checkDuration == 21)
            {
                query = query.Where(x => x.Duration <= 60 || x.Duration > 120);
            }
            else if (checkDuration == 9)
            {
                query = query.Where(x => x.Duration >= 60 && x.Duration <= 120);
            }
            else if (checkDuration == 29)
            {
                query = query.Where(x => x.Duration >= 60);
            }

            int checkStDate= 0;
            foreach (var item in request.StartDateType)
            {
                if (item == 1)
                {
                    checkStDate = checkStDate + 1;
                }
                if (item == 2)
                {
                    checkStDate = checkStDate + 9;
                }
                if (item == 3)
                {
                    checkStDate = checkStDate + 20;
                }
            }

            if (checkStDate == 1)
            {
                query = query.Where(x => x.StartDate.Date <= DateTime.Today.Date.AddDays(3));
            }
            else if (checkStDate == 9)
            {
                query = query.Where(x => x.StartDate.Date <= DateTime.Today.Date.AddDays(7));
            }
            else if (checkStDate == 20)
            {
                query = query.Where(x => x.StartDate.Date <= DateTime.Today.Date.AddDays(21));
            }           

            if (request.TeachingType is not null)
            {
                query = query.Where(x => x.TeachingType == request.TeachingType);
            }

            if (request.StartPrice != null && request.EndPrice != null)
            {
                query = query.Where(x => x.CoursePrice <= request.EndPrice && x.CoursePrice >= request.StartPrice);
            }
            if (request.CourseMajorId.Count() > 0)
            {
                    query = query.Where(x => request.CourseMajorId.Any(item => item == x.CourseMajorId));
            }

            if (request.AvgRating.Count() > 0)
            {
                    query = query.Where(x => request.AvgRating.Any(item => item == x.RatingStar));
            }

            var items = query.Where(x => x.IsDeleted == false).Include(x => x.Units).Include(x => x.University).Include(x => x.CourseMajor).ToList();
            var itemCount = items.Count();

            var result = new Pagination<TeachingCourse>()
            {
                PageIndex = pageIndex,
                PageSize = pageSize,
                TotalItemsCount = itemCount,
                Items = items,
            };
            return result;
        }

        public async Task<List<TeachingCourse?>> GetListTeachingCourse(int id)
        {
            var teachingCourse = await _dbSet.Where(x => x.Id == id && x.IsDeleted == false).ToListAsync();
            return teachingCourse;
        }

        public async Task<List<TeachingCourse?>> GetListTeachingCourse()
        {
            var teachingCourse = await _dbSet.Where(x => x.IsDeleted == false).ToListAsync();
            return teachingCourse;
        }

        public async Task<TeachingCourse> GetTCCByIdAsync(int id)
        {
            return await _dbSet.Include(x => x.Units).Include(x => x.University).Include(x => x.CourseMajor).FirstOrDefaultAsync(x => x.Id == id && x.IsDeleted == false);
        }
        public async Task<Pagination<TeachingCourse>> ToPaginationTCC(int pageIndex = 0, int pageSize = 10)
        {
            var itemCount = await _dbSet.Where(x => x.IsDeleted == false).CountAsync();
            var items = await _dbSet.Where(x => x.IsDeleted == false).Include(x => x.Units).Include(x => x.University).Include(x => x.CourseMajor).Skip(pageIndex * pageSize)
                                    .Take(pageSize)
                                    .AsNoTracking()
                                    .ToListAsync();

            var result = new Pagination<TeachingCourse>()
            {
                PageIndex = pageIndex,
                PageSize = pageSize,
                TotalItemsCount = itemCount,
                Items = items,
            };
            return result;
        }
    }
}
