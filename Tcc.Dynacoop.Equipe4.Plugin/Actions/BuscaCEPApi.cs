using Microsoft.Xrm.Sdk.Workflow;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tcc.Dynacoop.Equipe4.Plugin.DynacoopISV;
using Tcc.Dynacoop.Equipe4.SharedProject.VO;

namespace Tcc.Dynacoop.Equipe4.Plugin.Actions
{
    public class BuscaCEPApi : ActionCore
    {
        [Input("Cep")]
        public InArgument<string> Cep { get; set; }

        [Output("Logradouro")]
        public OutArgument<string> Logradouro { get; set; }

        [Output("Localidade")]
        public OutArgument<string> Localidade { get; set; }

        [Output("Bairro")]
        public OutArgument<string> Bairro { get; set; }

        [Output("DDD")]
        public OutArgument<string> DDD { get; set; }

        [Output("CodigoIBGE")]
        public OutArgument<string> CodigoIBGE { get; set; }

        [Output("Complemento")]
        public OutArgument<string> Complemento { get; set; }

        [Output("Uf")]
        public OutArgument<string> Uf { get; set; }

        public override void ExecuteAction(CodeActivityContext context)
        {
            var client = new RestClient($"https://viacep.com.br/ws/{Cep.Get(context)}/json/");
            RestRequest request = new RestRequest("", Method.Get);
            var response = client.Execute(request);

            var enderecoVO = JsonConvert.DeserializeObject<EnderecoVO>(response.Content);
            if (enderecoVO == null)
            {
                throw new Exception("Endereco nao encontrado");
            }

            Localidade.Set(context, enderecoVO.localidade);
            Bairro.Set(context, enderecoVO.bairro);
            DDD.Set(context, enderecoVO.ddd);
            Uf.Set(context, enderecoVO.uf);
            Logradouro.Set(context, enderecoVO.logradouro);
            Complemento.Set(context, enderecoVO.complemento);
            CodigoIBGE.Set(context, enderecoVO.ibge);
        }
    }
}
