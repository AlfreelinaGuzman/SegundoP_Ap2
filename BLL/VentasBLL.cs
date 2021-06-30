using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using SegundoP_Ap2.DAL;
using SegundoP_Ap2.Models;
using System.Threading.Tasks;

namespace SegundoP_Ap2.BLL
{
    public class VentasBLL
    {
        //+++++++++++++++++++++++++++++++++++++++++++++++ GUARDAR  +++++++++++++++++++++++++++++++++++++++++++++++
        public async static Task<bool> Guardar(Ventas ventas)
        {
            if (!await Existe(ventas.VentaId))
                return await Insertar(ventas);
            else
                return await Modificar(ventas);
        }
        //+++++++++++++++++++++++++++++++++++++++++++++++ INSERTAR  +++++++++++++++++++++++++++++++++++++++++++++++
        public async static Task<bool> Insertar(Ventas venta)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Ventas.Add(venta);
                paso = await contexto.SaveChangesAsync() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                await contexto.DisposeAsync();
            }

            return paso;
        }
        //+++++++++++++++++++++++++++++++++++++++++++++++ MODIFICAR  +++++++++++++++++++++++++++++++++++++++++++++++
        public async static Task<bool> Modificar(Ventas venta)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Entry(venta).State = EntityState.Modified;

                paso = await contexto.SaveChangesAsync() > 0;

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                await contexto.DisposeAsync();
            }
            return paso;
        }
        //+++++++++++++++++++++++++++++++++++++++++++++++ ELIMINAR  +++++++++++++++++++++++++++++++++++++++++++++++
        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                var ventas = contexto.Ventas.Find(id);
                if (ventas != null)
                {
                   
                    contexto.Ventas.Update(ventas);//Visibilidad en el Sistema.
                    paso = contexto.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }

        //+++++++++++++++++++++++++++++++++++++++++++++++ BUSCAR  +++++++++++++++++++++++++++++++++++++++++++++++
        public async static Task<Ventas> Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Ventas venta;

            try
            {
                venta = await contexto.Ventas.Where(v => v.VentaId == id).FirstOrDefaultAsync();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                await contexto.DisposeAsync();
            }

            return venta;
        }

        //+++++++++++++++++++++++++++++++++++++++++++++++ GETLIST  +++++++++++++++++++++++++++++++++++++++++++++++
        public static List<Ventas> GetList(Expression<Func<Ventas, bool>> criterio)
        {
            List<Ventas> lista = new List<Ventas>();
            Contexto contexto = new Contexto();

            try
            {
                lista = contexto.Ventas.Where(criterio).ToList();//Visibilidad en el Sistema. (Consulta)
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return lista;
        }
        //+++++++++++++++++++++++++++++++++++++++++++++++ EXISTE  +++++++++++++++++++++++++++++++++++++++++++++++
        public async static Task<bool> Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = await contexto.Ventas.AnyAsync(v => v.VentaId == id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                await contexto.DisposeAsync();
            }

            return encontrado;
        }
        //+++++++++++++++++++++++++++++++++++++++++++++++ GET  +++++++++++++++++++++++++++++++++++++++++++++++
        public async static Task<List<Ventas>> GetVentas(int clienteId = 0)
        {
            Contexto contexto = new Contexto();

            List<Ventas> ventas = new List<Ventas>();
            await Task.Delay(01);

            try
            {
                if (clienteId > 0)
                {
                    ventas = (await contexto.Ventas.ToListAsync()).Where(v => v.ClienteId == clienteId && v.Balance > 0).ToList();
                }
                else
                {
                    ventas = await contexto.Ventas.ToListAsync();
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                await contexto.DisposeAsync();
            }

            return ventas;
        }
    }
}