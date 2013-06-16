// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StructuremapMvc.cs" company="Web Advanced">
// Copyright 2012 Web Advanced (www.webadvanced.com)
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0

// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Data.Entity;
using System.Web.Http;
using System.Web.Mvc;
using QBank.Api.App_Start;
using QBank.Api.DependencyResolution;
using QBank.DataAccess;
using QBank.Model;
using QBank.Service;
using QBank.Service.Handler;
using QBank.Service.Mapper;
using QBank.Service.Model;
using StructureMap;
using WebActivator;

[assembly: PreApplicationStartMethod(typeof (StructuremapMvc), "Start")]

namespace QBank.Api.App_Start
{
    public static class StructuremapMvc
    {
        public static void Start()
        {
            IContainer container = IoC.Initialize();
            DependencyResolver.SetResolver(new StructureMapDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new StructureMapDependencyResolver(container);

            container.Configure(x =>
            {
                // Handlers -- TODO: Scan and register based on convention
                x.For<IRequestHandler<CheckBalanceRequest, CheckBalanceResponse>>()
                    .Use
                    <CheckBalanceRequestHandler>();

                x.For<IRequestHandler<WithdrawRequest, WithdrawResponse>>()
                    .Use
                    <WithdrawResquestHandler>();
                x.For<IAccountRepository>().Use<AccountRepository>();
                x.For<IEntityMapper<AccountDto, Account>>().Use<AccountMapper>();
                x.For<AccountService>().Use<AccountService>();
                x.For<DbContext>().HttpContextScoped().Use(ctx => new DbContext("QBankContext"));
            });
        }
    }
}