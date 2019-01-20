using System;
using System.Threading.Tasks;
using AutoMapper;
using BankManagementSystem.Common;
using BankManagementSystem.Common.BindingModels.Asset;
using BankManagementSystem.Data.Common.Repositories;
using BankManagementSystem.Models;
using Microsoft.AspNetCore.Identity;

namespace BankManagementSystem.Services.DataServices.Implementations
{
    public class AssetService : BaseService<Asset>, IAssetService
    {
        public AssetService(IRepository<Asset> repository,
            IMapper mapper,
            UserManager<Client> userManager)
            : base(repository, mapper, userManager)
        {
        }

        public async Task<int> Create(CreateAssetBindingModel model, string username)
        {
            Validator.ThrowIfNull(model);

            var client = await this.GetUserByNamedAsync(username);

            var asset = this.Mapper.Map<Asset>(model);
            asset.ClientId = client.Id;
            asset.CreatedAt = DateTime.Now;

            await this.Repository.AddAsync(asset);
            await this.Repository.SaveChangesAsync();

            return asset.Id;
        }
    }
}
