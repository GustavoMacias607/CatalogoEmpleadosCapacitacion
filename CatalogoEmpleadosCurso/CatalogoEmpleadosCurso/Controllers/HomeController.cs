using CatalogoEmpleadosCurso.Database;
using CatalogoEmpleadosCurso.Models;
using CatalogoEmpleadosCurso.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CatalogoEmpleadosCurso.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            var model = new EmpleadosViewModel()
        {

            datos = EmpleadosService.getEmployees(),
            lista = EmpleadosService.getPositions()

        };
                return View(model);



    }



    [HttpPost]
    public ActionResult Guardar(EmpleadosViewModel model)
    {
        var empleado = new EmployeesGustavo()
        {
            CreationDate = DateTime.Now,
            Name = model.Nombre,
            LastName = model.Apellido,
            Birthday = model.Cumpleaños,
            RFC = model.RFC,
            Email = model.Email,
            PhoneNumber = model.Telefono,
            PositionId = model.SeleccionId,
            IsDeleted = false

        };
        EmpleadosService.Agregar(empleado);
        return RedirectToAction("Index");
    }

    public ActionResult Detalles(int id)
    {


        var empleado = EmpleadosService.FindEmpleado(id);
        var puesto = EmpleadosService.FindPuesto(empleado.PositionId);

        var model = new EmpleadosViewModel()
        {
            Id = id,
            FechaCreate = empleado.CreationDate.ToString("dd/MM/yyyy"),
            Nombre = empleado.Name,
            Apellido = empleado.LastName,
            Cumple = empleado.Birthday.ToString("dd/MM/yyyy"),
            RFC = empleado.RFC,
            Email = empleado.Email,
            Telefono = empleado.PhoneNumber,
            Puesto = puesto.Name,



        };
        return View(model);
    }
    public ActionResult Editar(int id)
    {
        var empleado = EmpleadosService.FindEmpleado(id);
        var model = new EmpleadosViewModel()
        {
            Id = id,

            Nombre = empleado.Name,
            Apellido = empleado.LastName,
            Cumpleaños = empleado.Birthday,
            RFC = empleado.RFC,
            Email = empleado.Email,
            Telefono = empleado.PhoneNumber,
            SeleccionId = empleado.PositionId,
            lista = EmpleadosService.getPositions()


        };
        return View(model);

    }
    [HttpPost]
    public ActionResult Actualizar(EmpleadosViewModel modelo)
    {
        var crea = EmpleadosService.FindEmpleado(modelo.Id);
        var empleado = new EmployeesGustavo()
        {
            Id = modelo.Id,
            Name = modelo.Nombre,
            LastName = modelo.Apellido,
            CreationDate = crea.CreationDate,
            Birthday = Convert.ToDateTime(modelo.Cumpleaños),
            Email = modelo.Email,
            RFC = modelo.RFC,
            PhoneNumber = modelo.Telefono,
            IsDeleted = crea.IsDeleted,
            PositionId = modelo.SeleccionId
        };
        EmpleadosService.Actualizar(empleado);
        return RedirectToAction("Index");
    }
    [HttpPost]
    public ActionResult IsDeleted(EmpleadosViewModel model)
    {
        bool cambio;
        var empleado = EmpleadosService.FindEmpleado(model.Id);
        if (empleado.IsDeleted == true)
        {
            cambio = false;
        }
        else
        {
            cambio = true;
        }



        var modelo = new EmployeesGustavo()
        {
            Id = empleado.Id,
            Name = empleado.Name,
            LastName = empleado.LastName,
            CreationDate = empleado.CreationDate,
            Birthday = empleado.Birthday,
            Email = empleado.Email,
            RFC = empleado.RFC,
            PhoneNumber = empleado.PhoneNumber,

            IsDeleted = cambio,
            PositionId = empleado.PositionId

        };
        EmpleadosService.Actualizar(modelo);
        return RedirectToAction("Index");
    }
}
}