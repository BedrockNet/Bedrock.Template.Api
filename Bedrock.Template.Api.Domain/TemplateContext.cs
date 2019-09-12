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

		IRepositoryOrmId<Rock, int> Rocks { get; }

		IRepositoryOrmId<RockType, int> RockTypes { get; }

		IRepositoryOrmId<User, int> Users { get; }
		#endregion
	}

	public partial class TemplateContext : SessionAwareBase, ITemplateContext
	{
		#region Constructors
		public TemplateContext
		(
			Lazy<IRepositoryOrmId<Log, long>> logs,
			Lazy<IRepositoryOrmId<Rock, int>> rocks,
			Lazy<IRepositoryOrmId<RockType, int>> rockTypes,
			Lazy<IRepositoryOrmId<User, int>> users
		)
		{
			LazyLogs = logs;
			LazyRocks = rocks;
			LazyRockTypes = rockTypes;
			LazyUsers = users;
		}
		#endregion

		#region Properties
		Lazy<IRepositoryOrmId<Log, long>> LazyLogs { get; set; }

		Lazy<IRepositoryOrmId<Rock, int>> LazyRocks { get; set; }

		Lazy<IRepositoryOrmId<RockType, int>> LazyRockTypes { get; set; }

		Lazy<IRepositoryOrmId<User, int>> LazyUsers { get; set; }
		#endregion

		#region Template Properties
		public IRepositoryOrmId<Log, long> Logs
		{
			get
			{
				LazyLogs.Value.Enlist(Session);
				return LazyLogs.Value;
			}
		}

		public IRepositoryOrmId<Rock, int> Rocks
		{
			get
			{
				LazyRocks.Value.Enlist(Session);
				return LazyRocks.Value;
			}
		}

		public IRepositoryOrmId<RockType, int> RockTypes
		{
			get
			{
				LazyRockTypes.Value.Enlist(Session);
				return LazyRockTypes.Value;
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
				typeof(Rock),
				typeof(RockType),
				typeof(User)
			};
		}
		#endregion
	}
}
