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
using BankManagementSystem.Models.Enum;
using Microsoft.AspNetCore.Identity;

namespace BankManagementSystem.Services.DataServices.Implementations
{
    public class AssetService : BaseService<Asset>, IAssetService
    {
        private ITransactionService transactionService;

        public AssetService(IRepository<Asset> repository,
            IMapper mapper,
            UserManager<Client> userManager,
            ITransactionService transactionService)
            : base(repository, mapper, userManager)
        {
            this.transactionService = transactionService;
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

            await this.transactionService.CreateTransactionAsync(client.Id,
                model.AssetPrice,
                TransactionType.Purchase);

            await this.Repository.SaveChangesAsync();
        }

    }
}
