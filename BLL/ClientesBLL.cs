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
    public class ClientesBLL
    {
        //+++++++++++++++++++++++++++++++++++++++++++++++ GETLIST +++++++++++++++++++++++++++++++++++++++++++++++
        public static List<Clientes> GetList(Expression<Func<Clientes, bool>> criterio)
        {
            List<Clientes> lista = new List<Clientes>();
            Contexto contexto = new Contexto();

            try
            {
                lista = contexto.Clientes.Where(criterio).ToList();//Visibilidad en el Sistema. (Consulta)
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
        //+++++++++++++++++++++++++++++++++++++++++++++++ GET +++++++++++++++++++++++++++++++++++++++++++++++
        public async static Task<List<Clientes>> GetClientes()
        {
            Contexto contexto = new Contexto();

            List<Clientes> clientes = new List<Clientes>();
            await Task.Delay(01);

            try
            {

                clientes = await contexto.Clientes.ToListAsync();

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                await contexto.DisposeAsync();
            }

            return clientes;

        }
    }
}