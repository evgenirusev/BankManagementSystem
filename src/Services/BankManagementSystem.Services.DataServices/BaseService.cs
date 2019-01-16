using AutoMapper;
using BankManagementSystem.Data.Common.Repositories;
using BankManagementSystem.Web.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankManagementSystem.Services.DataServices
{
    public abstract class BaseService<T> where T : class
    {
        protected BaseService(IRepository<T> repository, IMapper mapper)
        {
            this.Mapper = mapper;
            this.Repository = repository;
        }

        protected IMapper Mapper { get; private set; }

        protected IRepository<T> Repository { get; private set; }
    }
}
