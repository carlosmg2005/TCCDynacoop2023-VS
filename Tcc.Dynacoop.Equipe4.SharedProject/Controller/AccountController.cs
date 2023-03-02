using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Tooling.Connector;
using Tcc.Dynacoop.Equipe4.SharedProject.Model;

namespace Tcc.Dynacoop.Equipe4.SharedProject.Controller
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

        public AccountController(CrmServiceClient crmnServiceClient)
        {
            this.ServiceClient = crmnServiceClient;
            this.Account = new Account(ServiceClient);
        }

        public Entity GetAccountByCnpj(string cep)
        {
            return Account.GetAccountByCNPJ(cep);
        }
    }
}
