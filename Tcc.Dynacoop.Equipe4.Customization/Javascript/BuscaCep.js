if (typeof (Dynacoop) == "undefined") { Dynacoop = {} }
if (typeof (Dynacoop.Endereco) == "undefined") { Dynacoop.Endereco = {} }

Dynacoop.Endereco = {
    OnCepChange: function (executionContext) {
        var formContext = executionContext.getFormContext();

        var id = Xrm.Page.data.entity.getId();
        var cep = formContext.getAttribute("dnc_cep").getValue();
        var execute_dnc_BuscaCEPApi_Request = {
            // Parameters			
            entity: { entityType: "account", id: id }, // entity

            Cep: cep,

            getMetadata: function () {
                return {
                    boundParameter: "entity",
                    parameterTypes: {
                        entity: { typeName: "mscrm.account", structuralProperty: 5 },
                        Cep: { typeName: "Edm.String", structuralProperty: 1 }
                    },
                    operationType: 0, operationName: "dnc_BuscaCEPApi"
                };
            }
        };

        Xrm.WebApi.execute(execute_dnc_BuscaCEPApi_Request).then(
            function success(response) {
                if (response.ok) { return response.json(); }
            }
        ).then(function (responseBody) {
            var result = responseBody;
            console.log(result);
            // Return Type: mscrm.dnc_BuscaCEPApiResponse
            // Output Parameters
            var logradouro = result["Logradouro"]; // Edm.String
            var bairro = result["Bairro"]; // Edm.String
            var uf = result["Uf"]; // Edm.String
            var ddd = result["DDD"]; // Edm.String
            var localidade = result["Localidade"]; // Edm.String
            var codigoibge = result["CodigoIBGE"]; // Edm.String
            var complemento = result["Complemento"]; // Edm.String

            formContext.getAttribute("dnc_localidade").setValue(localidade);
            formContext.getAttribute("dnc_bairro").setValue(bairro);
            formContext.getAttribute("dnc_ddd").setValue(ddd);
            formContext.getAttribute("dnc_uf").setValue(uf);
            formContext.getAttribute("dnc_logradouro").setValue(logradouro);

            formContext.getAttribute("dnc_complemento").setValue(complemento);
            formContext.getAttribute("dnc_codigoibge").setValue(codigoibge);
        }).catch(function (error) {
            console.log(error.message);
        });
    }
}