using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiendaVirtual.Core.Entities;
using TiendaVirtual.Core.Interfaces;
using TiendaVirtual.Core.Wrappers;
using TiendaVirtual.Infrastruture.Data;

namespace TiendaVirtual.Infrastruture.Repositories
{
    internal class PedidosRepository:IPedidosRepository
    {
        public readonly TiendaVirtualContext _context;
        public PedidosRepository(TiendaVirtualContext context)
        {
            _context = context;
        }


        public async Task<RepuestasServidorGenericas<ListadoPedido>> ObtenerPedidosPorUsuarioID(int UsuarioID)
        {
            var Respuesta = new RepuestasServidorGenericas<ListadoPedido>(new ListadoPedido() { },new List<ListadoPedido>() { }, true, null);

            try
            {
                if (UsuarioID != null && UsuarioID != 0)
                {
                    if (_context.Usuarios.Where(usuario => usuario.UsuarioId == UsuarioID).Count() > 0)
                    {
                        var PedidosUsuario = await _context.Pedidos
                            .Join(_context.Articulos, pedido => pedido.ArticuloId,
                            articulo => articulo.ArticuloId, (pedidos, articulos) => new
                            {
                                PedidoID = pedidos.PedidoId,
                                Nombre = articulos.Nombre,
                                PaisDestino = pedidos.PaisDestino,
                                ProvinciaDestino = pedidos.ProvinciaDestino,
                                SectorDestino = pedidos.SectorDestino,
                                Precio = articulos.Precio,
                                FormaPagoID = pedidos.FormaPagoId,
                                UsuarioID = pedidos.UsuarioId
                            }).Join(_context.FormaPagos, pedidos => pedidos.FormaPagoID,
                            formaPago => formaPago.FormaPagoId, (pedidos, formaPagos) => new
                            {
                                PedidoID = pedidos.PedidoID,
                                Nombre = pedidos.Nombre,
                                PaisDestino = pedidos.PaisDestino,
                                ProvinciaDestino = pedidos.ProvinciaDestino,
                                SectorDestino = pedidos.SectorDestino,
                                Precio = pedidos.Precio,
                                FormaDePago = formaPagos.Nombre,
                                UsuarioID = pedidos.UsuarioID
                            })
                            .Where(pedido => pedido.UsuarioID == UsuarioID)
                            .Select(pedido => new ListadoPedido { PedidoID = pedido.PedidoID, Nombre = pedido.Nombre, PaisDestino = pedido.PaisDestino, ProvinciaDestino = pedido.ProvinciaDestino, SectorDestino = pedido.SectorDestino, Precio = pedido.Precio, FormaDePago = pedido.FormaDePago })
                            .ToListAsync();

                        Respuesta = PedidosUsuario.Count() > 0 ?
                         new RepuestasServidorGenericas<ListadoPedido>(new ListadoPedido() { }, PedidosUsuario, true, null) :
                         new RepuestasServidorGenericas<ListadoPedido>(new ListadoPedido() { }, new List<ListadoPedido>(), true, "No existen pedidos para este usuario");
                    }else
                    {
                        Respuesta = new RepuestasServidorGenericas<ListadoPedido>(new ListadoPedido() { }, new List<ListadoPedido>() { }, false,"No existe el usuario con que desea obtener los pedidos");
                         
                    }
                }
                else
                {
                    Respuesta = new RepuestasServidorGenericas<ListadoPedido>(new ListadoPedido() { },new List<ListadoPedido>() { } ,false, "No existe el usuario con id 0 o null");
                }
            }
            catch (Exception ex)
            {
                Respuesta = new RepuestasServidorGenericas<ListadoPedido>(new ListadoPedido() { },new List<ListadoPedido>() { }, false, ex.Message);
            }
            return Respuesta;
        }

        public async Task<RepuestasServidorGenericas<Pedido>> AgregarPedidos(List<Pedido> pedidos)
        {
            var Respuesta = new RepuestasServidorGenericas<Pedido>(new Pedido() { }, new List<Pedido>() { }, true, null);

            try
            {
                if (pedidos != null)
                {
                    //obtengo el ultimo PedidoID Introducido y le sumo 1
                    var UltimoPedidoIDGuardado = _context.Pedidos.Select(x => x.PedidoId).Max()+1;

                    //Pedidos Transformados
                    List<Pedido> PedidosTransformados = new List<Pedido>();
                    //Transformo la data para que todos los pedidos que lleguen se agrupen en un solo pedido id
                    pedidos.ForEach(pedido =>
                    {
                        PedidosTransformados.Add(new Pedido()
                        {
                            PedidoId = UltimoPedidoIDGuardado,//Con esto se busca que con un solo pedido el usuario pueda agregar diferentes articulos
                            ArticuloId = pedido.ArticuloId,
                            UsuarioId = pedido.UsuarioId,
                            FormaPagoId = pedido.FormaPagoId,
                            PaisDestino = pedido.PaisDestino,
                            ProvinciaDestino = pedido.ProvinciaDestino,
                            SectorDestino = pedido.SectorDestino
                        });
                    });
                    _context.AddRange(PedidosTransformados);
                    await _context.SaveChangesAsync();
                    
                    Respuesta = new RepuestasServidorGenericas<Pedido>(new Pedido() { }, new List<Pedido>() { }, true);
                }
                else
                {
                    Respuesta = new RepuestasServidorGenericas<Pedido>(new Pedido() { }, new List<Pedido>() { }, false, "No existe el usuario con id 0 o null");
                }
            }
            catch (Exception ex)
            {
                Respuesta = new RepuestasServidorGenericas<Pedido>(new Pedido() { }, new List<Pedido>() { }, false, ex.Message);
            }
            return Respuesta;
        }

        public async Task<RepuestasServidorGenericas<Pedido>> ActualizarPedido(List<Pedido> pedidos,int pedidoID)
        {
            var Respuesta = new RepuestasServidorGenericas<Pedido>(new Pedido() { }, new List<Pedido>() { }, true, null);

            try
            {
                if (pedidos != null )
                {
                    //Comprobando existencia de pedidos
                    if (_context.Pedidos.Where(pedidos => pedidos.PedidoId == pedidoID).Count() > 0)
                    {

                        //Obteniendo los pedidos a actualizar para eliminarlos 
                        var PedidosEliminar = _context.Pedidos.Where(pedido => pedido.PedidoId == pedido.PedidoId).ToList();

                        //Eliminando pedidos para crear nuevos pedidos con el mismo pedido ID
                        _context.RemoveRange(PedidosEliminar);
                        await _context.SaveChangesAsync();

                        //Actualizar pedidos
                        List<Pedido> PedidosActualizarTransformados = new List<Pedido>();
                        //Transformo la data para que todos los pedidos que lleguen se agrupen en un solo pedido id
                        pedidos.ForEach(pedido =>
                        {
                            _context.Entry(pedido).State = EntityState.Modified;


                            PedidosActualizarTransformados.Add(new Pedido()
                            {
                                PedidoId = pedidoID,//Con esto se busca que con un solo pedido el usuario pueda agregar diferentes articulos
                                ArticuloId = pedido.ArticuloId,
                                UsuarioId = pedido.UsuarioId,
                                FormaPagoId = pedido.FormaPagoId,
                                PaisDestino = pedido.PaisDestino,
                                ProvinciaDestino = pedido.ProvinciaDestino,
                                SectorDestino = pedido.SectorDestino
                            });
                        });
                        _context.AddRange(PedidosActualizarTransformados);
                        await _context.SaveChangesAsync();



                        Respuesta = new RepuestasServidorGenericas<Pedido>(new Pedido(), new List<Pedido>() { }, true);
                    }
                    else if (_context.Pedidos.Where(pedidos => pedidos.PedidoId == pedidoID).Count() == 0) ;
                    {
                        Respuesta = new RepuestasServidorGenericas<Pedido>(new Pedido(), new List<Pedido>() { }, true,"No existe el pedido que desea actualizar");
                    }
                }
                else
                {
                    Respuesta = new RepuestasServidorGenericas<Pedido>(new Pedido() { }, new List<Pedido>() { }, false, "No se puede actualizar un pedido vacio");
                }
            }
            catch (Exception ex)
            {
                Respuesta = new RepuestasServidorGenericas<Pedido>(new Pedido() { }, new List<Pedido>() { }, false, ex.Message);
            }
            return Respuesta;
        }

        public async Task<RepuestasServidorGenericas<Pedido>> EliminarPedido(int pedidoID)
        {
            var Respuesta = new RepuestasServidorGenericas<Pedido>(new Pedido() { }, new List<Pedido>() { }, true, null);

            try
            {
                if (pedidoID != null && pedidoID != 0)
                {
                    var pedidoEliminar = await _context.Pedidos.FindAsync(pedidoID);
                        
                    if (pedidoEliminar != null)
                    {
                        _context.Pedidos.Remove(pedidoEliminar);
                        await _context.SaveChangesAsync();
                        Respuesta = new RepuestasServidorGenericas<Pedido>(new Pedido(), new List<Pedido>() { }, true);
                    }
                    else if (pedidoEliminar == null)
                    {
                        Respuesta = new RepuestasServidorGenericas<Pedido>(new Pedido(), new List<Pedido>() { }, true, "No existe el pedido que desea eliminar");
                    }
                }
                else
                {
                    Respuesta = new RepuestasServidorGenericas<Pedido>(new Pedido() { }, new List<Pedido>() { }, false, "No se puede eliminar un pedido inexistente");
                }
            }
            catch (Exception ex)
            {
                Respuesta = new RepuestasServidorGenericas<Pedido>(new Pedido() { }, new List<Pedido>() { }, false, ex.Message);
            }
            return Respuesta;
        }
    }

    
}

    

