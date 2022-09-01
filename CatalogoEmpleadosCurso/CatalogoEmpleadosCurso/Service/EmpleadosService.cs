using CatalogoEmpleadosCurso.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CatalogoEmpleadosCurso.Service
{
    public class EmpleadosService
    {
        /// <summary>
        /// Metodo para obtener todos los empleados
        /// </summary>
        /// <returns></returns>
        public static List<EmployeesGustavo> getEmployees()
        {
            try
            {
                List<EmployeesGustavo> lista = new List<EmployeesGustavo>();
                using (var db = new DB_ITSEntities())
                {
                    lista = db.EmployeesGustavo.ToList();
                }
                return lista;
            }
            catch (Exception ex)
            {

                throw;
            }


        }
        /// <summary>
        /// Metodo para obtener todos las posiciones
        /// </summary>
        /// <returns></returns>
        public static List<PositionsGustavo> getPositions()
        {
            try
            {
                List<PositionsGustavo> lista = new List<PositionsGustavo>();
                using (var db = new DB_ITSEntities())
                {
                    lista = db.PositionsGustavo.ToList();
                }
                return lista;
            }
            catch (Exception ex)
            {

                throw;
            }


        }

        /// <summary>
        /// Metodo para guardar un nuevo Empleado
        /// </summary>
        /// <param name="empleado"></param>
        public static void Agregar(EmployeesGustavo empleado)
        {
            try
            {
                using (var db = new DB_ITSEntities())
                {
                    db.EmployeesGustavo.Add(empleado);
                    db.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static EmployeesGustavo FindEmpleado(int id)
        {
            var empleado = new EmployeesGustavo();

            try
            {
                using (var db = new DB_ITSEntities())
                {
                    empleado = db.EmployeesGustavo.Find(id);
                }
            }
            catch (Exception)
            {

                throw;
            }
            return empleado;
        }
        public static PositionsGustavo FindPuesto(int id)
        {
            var puesto = new PositionsGustavo();

            try
            {
                using (var db = new DB_ITSEntities())
                {
                    puesto = db.PositionsGustavo.Find(id);
                }
            }
            catch (Exception)
            {

                throw;
            }
            return puesto;
        }

        public static void Actualizar(EmployeesGustavo employee)
        {
            try
            {
                using (var db = new DB_ITSEntities())
                {
                    db.Entry(employee).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}