using System;
using Bedrock.Template.Api.Domain.Entity;

using Bedrock.Shared.Data.Repository.Interface;
using Bedrock.Shared.Session.Implementation;
using Bedrock.Shared.Session.Interface;

namespace Bedrock.Template.Api.Domain
{
    public interface ITemplateContext : ISessionAware
    {
        #region Properties
        IRepositoryOrmId<Log, long> Logs { get; }

        IRepositoryOrmId<User, int> Users { get; }
        #endregion
    }

    public partial class TemplateContext : SessionAwareBase, ITemplateContext
    {
        #region Constructors
        public TemplateContext
        (
            Lazy<IRepositoryOrmId<Log, long>> logs,
            Lazy<IRepositoryOrmId<User, int>> users
        )
        {
            LazyLogs = logs;
            LazyUsers = users;
        }
        #endregion

        #region Properties
        Lazy<IRepositoryOrmId<Log, long>> LazyLogs { get; set; }

        Lazy<IRepositoryOrmId<User, int>> LazyUsers { get; set; }
        #endregion

        #region ITransactionalContext Properties
        public IRepositoryOrmId<Log, long> Logs
        {
            get
            {
                LazyLogs.Value.Enlist(Session);
                return LazyLogs.Value;
            }
        }

        public IRepositoryOrmId<User, int> Users
        {
            get
            {
                LazyUsers.Value.Enlist(Session);
                return LazyUsers.Value;
            }
        }
        #endregion

        #region Public Methods
        public static Type[] GetTypes()
        {
            return new Type[]
            {
                typeof(Log),
                typeof(User)
            };
        }
        #endregion
    }
}
