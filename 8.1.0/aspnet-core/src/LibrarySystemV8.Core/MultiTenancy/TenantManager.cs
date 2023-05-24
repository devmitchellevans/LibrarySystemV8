using Abp.Application.Features;
using Abp.Domain.Repositories;
using Abp.MultiTenancy;
using LibrarySystemV8.Authorization.Users;
using LibrarySystemV8.Editions;

namespace LibrarySystemV8.MultiTenancy
{
    public class TenantManager : AbpTenantManager<Tenant, User>
    {
        public TenantManager(
            IRepository<Tenant> tenantRepository, 
            IRepository<TenantFeatureSetting, long> tenantFeatureRepository, 
            EditionManager editionManager,
            IAbpZeroFeatureValueStore featureValueStore) 
            : base(
                tenantRepository, 
                tenantFeatureRepository, 
                editionManager,
                featureValueStore)
        {
        }
    }
}
