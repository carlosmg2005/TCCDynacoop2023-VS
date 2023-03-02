using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Tooling.Connector;

namespace Tcc.Dynacoop.Equipe4.SharedProject.Model
{
    public class Product
    {
        public IOrganizationService ServiceClient { get; set; }

        public string LogicalName { get; set; }

        public Product(IOrganizationService crmServiceClient)
        {
            this.ServiceClient = crmServiceClient;
            this.LogicalName = "account";
        }

        public Product(CrmServiceClient crmServiceClient)
        {
            this.ServiceClient = crmServiceClient;
            this.LogicalName = "account";
        }
    }
}
