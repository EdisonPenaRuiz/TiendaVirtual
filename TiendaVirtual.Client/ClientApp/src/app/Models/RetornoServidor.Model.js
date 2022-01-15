"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.Respuesta = exports.RetornoServidor = void 0;
var RetornoServidor = /** @class */ (function () {
    function RetornoServidor(operacionExitosa, resultadoEspecifico, listadoResultados, error) {
        this.OperacionExitosa = operacionExitosa;
        this.ListadoResultados = listadoResultados;
        this.ResultadoEspecifico = resultadoEspecifico;
        this.Error = error;
    }
    return RetornoServidor;
}());
exports.RetornoServidor = RetornoServidor;
var Respuesta = /** @class */ (function () {
    function Respuesta(respuesta) {
        this.RespuesServidor = respuesta;
    }
    return Respuesta;
}());
exports.Respuesta = Respuesta;
//# sourceMappingURL=RetornoServidor.Model.js.map