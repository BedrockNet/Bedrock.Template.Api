using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Bedrock.Template.Api.Core.Constant;
using Bedrock.Template.Api.Core.Enumeration.StringHelper;
using Bedrock.Template.Api.Core.Utility;

using Bedrock.Template.Api.Domain.Entity;
using Bedrock.Template.Api.Domain.Entity.Search;

using Bedrock.Template.Api.Domain.Validation.Configurator;
using Bedrock.Template.Api.Domain.Service.Interface;

using Bedrock.Shared.Configuration;
using Bedrock.Shared.Data.Repository;
using Bedrock.Shared.Data.Repository.Extension;
using Bedrock.Shared.Domain.Interface;
using Bedrock.Shared.Mapper.Extension;
using Bedrock.Shared.Pagination;
using Bedrock.Shared.Service.Interface;

using ProcedureEntity = Bedrock.Template.Api.Domain.Entity.Procedure;

namespace Bedrock.Template.Api.Domain.Service
{
    public class RockService : ServiceBaseDomain, IRockService
    {
        #region Constructors
        public RockService
        (
            ITemplateContext context,
            IDomainEventDispatcher eventDispatcher,
            RockValidationConfigurator validationConfigurator,
            BedrockConfiguration bedrockConfiguration
        )
        : base(bedrockConfiguration, eventDispatcher, context)
        {
            ValidationConfigurator = validationConfigurator;
        }
        #endregion

        #region Properties
        protected RockValidationConfigurator ValidationConfigurator { get; set; }
        #endregion

        #region IRockService Methods
        public async Task<IEnumerable<Rock>> GetRocksAsync()
        {
            return await Context
                            .Rocks
                            .AsNoTracking()
                            .Include(r => r.RockType)
                            .ToArrayAsync();
        }

        public async Task<IEnumerable<T>> GetRocksAsync<T>()
        {
            return await Context
                            .Rocks
                            .AsNoTracking()
                            .ProjectTo<Rock, T>()
                            .ToArrayAsync();
        }

        public async Task<Rock> GetRockByIdAsync(int id)
        {
            return await Context
                            .Rocks
                            .AsNoTracking()
                            .Include(r => r.RockType)
                            .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<T> GetRockByIdAsync<T>(int id)
        {
            return await Context
                            .Rocks
                            .AsNoTracking()
                            .Where(c => c.Id == id)
                            .ProjectTo<Rock, T>()
                            .SingleOrDefaultAsync();
        }

        public IServiceResponse<Rock, Rock> AddRock(Rock rockToAdd)
        {
            if (rockToAdd == null)
                throw new ArgumentNullException(nameof(rockToAdd));

            rockToAdd.DoSomethingToRaiseEvent();
            EventDispatcher.Dispatch(rockToAdd, false);

            Context.Rocks.Add(rockToAdd);

            return ResponseValidation(rockToAdd, ValidationConfigurator.GetConfigurationAddRock(rockToAdd));
        }

        public async Task<IServiceResponse<Rock, Rock>> UpdateRockAsync(Rock rockToUpdate)
        {
            if (rockToUpdate == null)
                throw new ArgumentNullException(nameof(rockToUpdate));

            var existingRock = await Context
                                            .Rocks
                                            .SingleOrDefaultAsync(c => c.Id == rockToUpdate.Id);

            if (existingRock == null)
                throw new ArgumentException(StringHelperTemplate.Current.Lookup(StringErrorTemplate.RockDoesNotExist), nameof(existingRock));

            Mapper.Map<Rock, Rock>(existingRock, rockToUpdate);
            Context.Rocks.Update(existingRock);

            return ResponseValidation(rockToUpdate, ValidationConfigurator.GetConfigurationUpdateRock(existingRock));
        }

        public async Task<PaginationResult<Rock>> SearchRocksAsync(RockSearch rockSearch)
        {
            var returnValue = Context
                                .Rocks
                                .AsNoTracking()
                                .Include(c => c.RockType)
                                .AsNoTracking();

            return await returnValue.PaginateAsync(rockSearch, rockSearch.PagingInstruction);
        }

        public IEnumerable<ProcedureEntity.Rock> GetRocksWithProcedure(int id)
        {
            return Context
                    .Rocks
                    .ExecuteQuery<ProcedureEntity.Rock>(StoredProcedure.SearchRocks, new SqlParameter[] { SqlParameter.CreateInstance(nameof(id), id) })
                    .ToList();
        }
        #endregion
    }
}
