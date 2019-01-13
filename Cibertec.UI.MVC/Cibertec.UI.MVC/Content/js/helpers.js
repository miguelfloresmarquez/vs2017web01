(function (cibertec) {
    cibertec.helpers = {
        replaceAll: function (string, find, replace) {
            var result = string.replace(
                new RegExp(find, 'g'), replace
            );
            return result;
        },
        getAniosArray: function (anioInicio) {
            var hoy = new Date();
            var anios = [];
            for (i = anioInicio; i <= hoy.getFullYear(); i++) {
                anios.push(i);
            }
            return anios;
        },
        BloquearControls: function () {
            $("input, select, textarea").attr("disabled", "disabled");
            $("#idEnviar").attr("disabled", "disabled");
        },
        DesbloquearControls: function () {
            $("input, select, button, textarea").removeAttr("disabled");
        },
        SetObjetLocalStorage: function (jsObject, keyStorage) {
            var json = JSON.stringify(jsObject);
            localStorage.setItem(keyStorage, json);
        },
        GetObjetLocalStorage: function (keyStorage) {
            var json = localStorage.getItem(keyStorage);
            return JSON.parse(json);
        }
    }
}
)(window.cibertec = window.cibertec || {});