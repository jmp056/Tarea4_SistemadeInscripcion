﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Tarea4_SistemadeInscripcion.Data;
using Tarea4_SistemadeInscripcion.Models;

namespace Tarea4_SistemadeInscripcion.Controllers
{
    public class InscripcionesController
    {
        public bool Insertar(Pagos Inscripcion)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                if (Inscripcion.InscripcionId == 0)
                {

                    paso = Guardar(Inscripcion);
                }
                else
                {

                    paso = Modificar(Inscripcion);
                }
            }
            catch (Exception)
            {

                throw;
            }


            return paso;
        }

        public static bool Guardar(Pagos Inscripcion)
        {

            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {

                contexto.Inscripciones.Add(Inscripcion);
                paso = contexto.SaveChanges() > 0;
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

        public static bool Modificar(Pagos Inscripcion)
        {

            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {

                contexto.Entry(Inscripcion).State = EntityState.Modified;
                paso = contexto.SaveChanges() > 0;
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

        public bool Eliminar(int Id)
        {

            bool paso = false;
            Contexto contexto = new Contexto();
            Pagos Inscripcion = contexto.Inscripciones.Find(Id);

            try
            {

                contexto.Entry(Inscripcion).State = EntityState.Deleted;
                paso = contexto.SaveChanges() > 0;
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

        public Pagos Buscar(int Id)
        {

            Contexto contexto = new Contexto();
            Pagos Inscripcion = new Pagos();

            try
            {

                Inscripcion = contexto.Inscripciones.Find(Id);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {

                contexto.Dispose();
            }

            return Inscripcion;
        }

        public List<Pagos> GetList(Expression<Func<Pagos, bool>> expression)
        {

            Contexto contexto = new Contexto();
            List<Pagos> ListadoInscripciones = new List<Pagos>();

            try
            {

                ListadoInscripciones = contexto.Inscripciones.Where(expression).ToList();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {

                contexto.Dispose();
            }

            return ListadoInscripciones;
        }
    }
}
