﻿using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Tooling.Connector;
using Dynacoop.Logistics.SharedProject.Model;

namespace Dynacoop.Logistics.SharedProject.Controller
{
    public class AccountController
    {
        public IOrganizationService ServiceClient { get; set; }

        public Account Account { get; set; }

        public AccountController(IOrganizationService crmnServiceClient)
        {
            this.ServiceClient = crmnServiceClient;
            this.Account = new Account(ServiceClient);
        }

        public Entity GetAccountByCnpj(string cep)
        {
            return Account.GetAccountByCNPJ(cep);
        }
         
        public void AddAccount(Entity opportunity)
        {
            Account.AddAccount(opportunity);
        }

    }
}
