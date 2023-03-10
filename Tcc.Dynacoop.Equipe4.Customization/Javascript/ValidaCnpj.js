if (typeof (Dynacoop) == "undefined") { Dynacoop = {} }
if (typeof (Dynacoop.Validacao) == "undefined") { Dynacoop.Validacao = {} }

Dynacoop.Validacao = {
    CNPJOnChange: function (executionContext) {
        var formContext = executionContext.getFormContext();
        var cnpj = formContext.getAttribute("dnc_cnpj").getValue();
        
        if (cnpj != null) {
            if (cnpj.length == 14) {
                var formattedCNPJ = cnpj.replace(/^(\d{2})(\d{3})(\d{3})(\d{4})(\d{2})/, "$1.$2.$3/$4-$5");
                var queryAccountId = "";

                Xrm.WebApi.online.retrieveMultipleRecords("account", "?$select=name&$filter=dnc_cnpj eq '" + formattedCNPJ + "'" + queryAccountId).then(
                    function success(results) {
                        if (results.entities.length == 0) {
                            formContext.getAttribute("dnc_cnpj").setValue(formattedCNPJ);
                        } else {
                            formContext.getAttribute("dnc_cnpj").setValue("");
                            AlfaPeople.Account.DynamicsAlert("O CNPJ já existe no sistema", "CNPJ duplicado!")
                        }
                    },
                    function (error) {
                        Dynacoop.Validacao.DynamicsAlert("Por favor contato o administrador", "Erro do sistema")
                    }
                );
            }
            else {
                Dynacoop.Validacao.DynamicsAlert("O CNPJ digitado não é valido", "CNPJ inválido!")
            }
        } else {
            Dynacoop.Validacao.DynamicsAlert("Informe um valor para o CNPJ", "CNPJ incorreto!")
        }
    },
    DynamicsAlert: function (alertText, alertTitle) {
        var alertStrings = {
            confirmButtonLabel: "OK",
            text: alertText,
            title: alertTitle
        };

        var alertOptions = {
            height: 120,
            width: 200
        };

        Xrm.Navigation.openAlertDialog(alertStrings, alertOptions);
    },
}
