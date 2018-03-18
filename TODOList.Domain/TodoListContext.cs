using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TODOList.Domain
{
    public class TodoListContext: DbContext
    {
        public TodoListContext() : base("TodoListContext") { }

        public DbSet<Person> Persons { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<BaseTask> BaseTasks { get; set; }
        public DbSet<SoftwareTask> SoftwareTasks { get; set; }
        public DbSet<Bug> Bugs { get; set; }
        public DbSet<Assign> Assignes { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<EmailNotification> EmailNotifications { get; set; }
        public DbSet<SmsNotification> SmsNotifications { get; set; }

    }
}
