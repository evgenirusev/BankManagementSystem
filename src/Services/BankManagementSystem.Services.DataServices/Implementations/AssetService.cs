using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BankManagementSystem.Common;
using BankManagementSystem.Common.BindingModels.Asset;
using BankManagementSystem.Common.ViewModels.Asset;
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
            asset.VendorId = client.Id;
            asset.CreatedAt = DateTime.Now;

            await this.Repository.AddAsync(asset);
            await this.Repository.SaveChangesAsync();

            return asset.Id;
        }

        public async Task<IEnumerable<AssetViewModel>> GetAllAssetsAsync()
        {
            return this.Mapper.Map<IEnumerable<AssetViewModel>>(this.Repository.All()
                .Where(a => a.Owner == null));
        }

        public async Task<AssetViewModel> FindById(int id)
        {
            Asset assetEntity = this.Repository.FindById(id);
            return this.Mapper.Map<AssetViewModel>(assetEntity);
        }

        public async Task PurchaseAssetAsync(PurchaseAssetBindingModel model, string username)
        {
            Validator.ThrowIfNull(model);

            var client = await this.GetUserByNamedAsync(username);
            client.Balance -= model.AssetPrice;
            Asset assetEntity = this.Repository.FindById(model.AssetId);
            assetEntity.Owner = client;
            client.PurchasedAssets.Add(assetEntity);
            
            await this.Repository.SaveChangesAsync();
        }
    }
}
