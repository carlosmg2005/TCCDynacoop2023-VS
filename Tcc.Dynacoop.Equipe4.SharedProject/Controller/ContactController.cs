﻿using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Tooling.Connector;
using Tcc.Dynacoop.Equipe4.SharedProject.Model;

namespace Tcc.Dynacoop.Equipe4.SharedProject.Controller
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

        public ContactController(CrmServiceClient crmnServiceClient)
        {
            this.ServiceClient = crmnServiceClient;
            this.Contact = new Contact(ServiceClient);
        }

        public Entity GetContactByCPF(string cpf)
        {
            return Contact.GetContactByCPF(cpf);
        }
    }
}