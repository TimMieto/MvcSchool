using Microsoft.EntityFrameworkCore;

namespace MvcSchool.Models
{
    public class MvcSchoolContext : DbContext
    {
        public MvcSchoolContext (DbContextOptions<MvcSchoolContext> options)
            : base(options)
        {
        }

        //这些代码为每个实体集创建DbSet<TEntity>属性。实体集通常对应一个数据库表，实体表对应表中的行。
        public DbSet<Student> Student { get; set; }

        public DbSet<Course> Course { get; set; }

        public DbSet<Teacher> Teacher { get; set; }

        public DbSet<Major> Major { get; set; }

        public DbSet<Enrollment> Enrollment { get; set; }
    }
}
