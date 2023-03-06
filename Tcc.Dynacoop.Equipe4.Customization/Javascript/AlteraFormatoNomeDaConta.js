if (typeof (Dynacoop) == "undefined") { Dynacoop = {} }
if (typeof (Dynacoop.Account) == "undefined") { Dynacoop.Account = {} }

Dynacoop.Account = {
    OnLoad: function (executionContext) {
        var formContext = executionContext.getFormContext();
        debugger;
        var responseName = formContext.getAttribute("name").getValue();

        debugger;
        var palavras = responseName.split(" ");
        var nomeFinal = "";

        for (let i = 0; i < palavras.length; i++) {
            debugger;
            palavras[i] = palavras[i][0].toUpperCase() + palavras[i].substr(1);

            nomeFinal = nomeFinal + palavras[i] + " ";
        }

        formContext.getAttribute("name").setValue(nomeFinal.trim());
    }
}