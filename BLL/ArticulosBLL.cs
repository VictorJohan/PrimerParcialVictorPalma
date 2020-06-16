using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using PrimerParcial.DAL;
using PrimerParcial.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrimerParcial.BLL
{
    public class ArticulosBLL
    {
        public static bool Guardar(Articulos articulo)
        {
            if (!Existe(articulo.ArticuloId))
            {
                return Insertar(articulo);
            }
            else
            {
                return Modificar(articulo);
            }
        }

        public static bool Existe(int id)
        {
            bool ok = false;
            Contexto contexto = new Contexto();

            try
            {
                ok = contexto.Articulos.Any(e => e.ArticuloId == id);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return ok;
        }

        private static bool Insertar(Articulos articulo)
        {
            bool ok = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Articulos.Add(articulo);
                ok = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return ok;
        }

        private static bool Modificar(Articulos articulo)
        {
            bool ok = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Entry(articulo).State = EntityState.Modified;
                ok = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return ok;
        }

        public static Articulos Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Articulos articulo;

            try
            {
                articulo = contexto.Articulos.Find(id);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return articulo;
        }

        public static bool Eliminar(int id)
        {
            bool ok = false;
            Contexto contexto = new Contexto();
            Articulos articulo;

            try
            {
                articulo = contexto.Articulos.Find(id);
                if(articulo != null)
                {
                    contexto.Articulos.Remove(articulo);
                    ok = contexto.SaveChanges() > 0;
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

            return ok;
        }
    }
}
