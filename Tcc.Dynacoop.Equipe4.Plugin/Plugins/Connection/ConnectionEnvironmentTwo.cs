using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Tooling.Connector;

namespace Tcc.Dynacoop.Equipe4.Plugin.Plugins.Connection
{
    public class ConnectionEnvironmentTwo
    {
        public IOrganizationService GetService()
        {
            string url = "org246c61e6";
            string clientId = "4d61825c-c15b-4b65-b4bf-1a90e43b8d1e";
            string clientSecret = "8xh8Q~o6uvKuOLL3bJ025XWbX7mv-lHQC__Yxbdd";

            IOrganizationService serviceClient = new CrmServiceClient($"AuthType=ClientSecret;Url=https://{url}.crm2.dynamics.com/;AppId={clientId};ClientSecret={clientSecret};");
            return serviceClient;
        }
    }
}
