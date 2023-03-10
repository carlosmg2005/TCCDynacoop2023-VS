using Dynacoop.Logistics.SharedProject.Model;
using Microsoft.Xrm.Sdk;

namespace Dynacoop.Logistics.SharedProject.Controller
{
    public class ContactController
    {
        public IOrganizationService ServiceClient { get; set; }

        public Contact Contact { get; set; }

        public ContactController(IOrganizationService crmnServiceClient)
        {
            this.ServiceClient = crmnServiceClient;
            this.Contact = new Contact(ServiceClient);
        }

        public Entity GetContactByCPF(string cpf)
        {
            return Contact.GetContactByCPF(cpf);
        }

        public void AddContact(Entity opportunity)
        {
            Contact.AddContact(opportunity);
        }
    }
}
