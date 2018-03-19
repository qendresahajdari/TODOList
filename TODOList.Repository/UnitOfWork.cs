using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TODOList.Domain;

namespace TODOList.Repository
{
    public class UnitOfWork : IDisposable
    {
        private TodoListContext context = new TodoListContext();

        private AssignRepository _assignRepository;
        public AssignRepository assignRepository
        {
            get
            {
                return this._assignRepository ?? new AssignRepository(context);
            }
        }

        private BugRepository _bugRepository;
        public BugRepository bugRepository
        {
            get
            {
                return this._bugRepository ?? new BugRepository(context);
            }
        }

        private EmailNotificationRepository _emailNotificationRepository;
        public EmailNotificationRepository emailNotificationRepository
        {
            get
            {
                return this._emailNotificationRepository ?? new EmailNotificationRepository(context);
            }
        }

        private ProjectRepository _projectRepository;
        public ProjectRepository projectRepository
        {
            get
            {
                return this._projectRepository ?? new ProjectRepository(context);
            }
        }
        private RoleRepository _roleRepository;
        public RoleRepository roleRepository
        {
            get
            {
                return this._roleRepository ?? new RoleRepository(context);
            }
        }
        private SmsNotificationRepository _smsNotificationRepository;
        public SmsNotificationRepository smsNotificationRepository
        {
            get
            {
                return this._smsNotificationRepository ?? new SmsNotificationRepository(context);
            }
        }

        private SoftwareTaskRepository _softwareTaskRepository;
        public SoftwareTaskRepository softwareTaskRepository
        {
            get
            {
                return this._softwareTaskRepository ?? new SoftwareTaskRepository(context);
            }
        }

        private UserRepository _userRepository;
        public UserRepository userRepository
        {
            get
            {
                return this._userRepository ?? new UserRepository(context);
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
