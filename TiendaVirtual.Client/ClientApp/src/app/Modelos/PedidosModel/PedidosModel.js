"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.PedidosModel = void 0;
var PedidosModel = /** @class */ (function () {
    function PedidosModel(pedidoId, paisDestino, provinciaDestino, sectorDestino, articuloID, formaPagoID, usuarioID) {
        this.PedidoId = pedidoId;
        this.ArticuloId = articuloID;
        this.PaisDestino = paisDestino;
        this.ProvinciaDestino = provinciaDestino;
        this.SectorDestino = sectorDestino;
        this.FormaPagoId = formaPagoID;
        this.UsuarioId = usuarioID;
    }
    return PedidosModel;
}());
exports.PedidosModel = PedidosModel;
//# sourceMappingURL=PedidosModel.js.map