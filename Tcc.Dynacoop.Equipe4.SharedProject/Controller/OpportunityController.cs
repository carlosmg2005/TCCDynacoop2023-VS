using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Tooling.Connector;
using Tcc.Dynacoop.Equipe4.SharedProject.Model;

namespace Tcc.Dynacoop.Equipe4.SharedProject.Controller
{
    public class OpportunityController
    {
        public IOrganizationService ServiceClient { get; set; }

        public Opportunity Opportunity { get; set; }

        public OpportunityController(IOrganizationService crmnServiceClient)
        {
            this.ServiceClient = crmnServiceClient;
            this.Opportunity = new Opportunity(ServiceClient);
        }

        public OpportunityController(CrmServiceClient crmnServiceClient)
        {
            this.ServiceClient = crmnServiceClient;
            this.Opportunity = new Opportunity(ServiceClient);
        }

        public EntityCollection GetAllOpportunitys()
        {
            return Opportunity.GetAllOpportunitys();
        }

        public Entity VerificaDuplicidade(string idAlfa)
        {
            return Opportunity.VerificaDuplicidade(idAlfa);
        }
    }
}
