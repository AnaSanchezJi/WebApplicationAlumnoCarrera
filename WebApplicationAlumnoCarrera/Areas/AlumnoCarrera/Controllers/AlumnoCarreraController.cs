using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplicationAlumnoCarrera.Areas.AlumnoCarrera.Services;
using WebApplicationAlumnoCarrera.Models;

namespace WebApplicationAlumnoCarrera.Areas.AlumnoCarrera.Controllers
{
    [Area("AlumnoCarrera")]
    public class AlumnoCarreraController : Controller
    {
        SrvAlumnoCarreraList FicService;
        List<eva_alumnos_carreras> FicLista;
        eva_alumnos_carreras edi;


        public AlumnoCarreraController()
        {
            FicService = new SrvAlumnoCarreraList();
        }
       
        //Lista Edificio-------------------------------------------
        public IActionResult FicViAlumnoCarreraList()
        {
            try
            {
                FicService = new SrvAlumnoCarreraList();
                FicLista = FicService.FicGetListAlumnoCarrera().Result;
                ViewBag.Title = "Catalogo de alumnos";                
                return View(FicLista);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        #region //Detalle Edificio------------------------------------------
        public IActionResult FicViAlumnoCarreraDetalle(int id)
        {
            try
            {
                FicService = new SrvAlumnoCarreraList();
                eva_alumnos_carreras FicLista = FicService.FicGetDetailAlumnoCarrera(id).Result;                
                ViewBag.Title = "Detalle de alumnos";
                return View(FicLista);
            }
            catch (Exception e)
            {
                throw;
            }
        }
        #endregion
        #region Editar edificio-------------------------------------
        public IActionResult FicViAlumnoCarreraUpdate(short id)
        {
            try
            {
                FicService = new SrvAlumnoCarreraList();
                edi = FicService.FicGetDetailAlumnoCarrera(id).Result;
                ViewBag.Title = "Editar alumno";
                return View(edi);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        [HttpPost]
        public ActionResult FicViAlumnoCarreraUpdate(eva_alumnos_carreras edificio)
        {
            FicService.FicAlumnoCarreraUpdate(edificio).Wait();
            return RedirectToAction("FicViAlumnoCarreraList");
        }
        #endregion
        #region Nuevo Edificio 
        public ActionResult FicViAlumnoCarreraAdd()
        {
            ViewBag.IdAlumno = new SelectList(new List<SelectListItem>(), "Text");
            ViewBag.IdGenIngreso = new SelectList(new List<SelectListItem>(), "Text");
            ViewBag.IdGenNivelEscolar = new SelectList(new List<SelectListItem>(), "Text");
            ViewBag.IdGenOpcionTitulacion = new SelectList(new List<SelectListItem>(), "Text");
            ViewBag.IdGenPlanEstudio = new SelectList(new List<SelectListItem>(), "Text");
            ViewBag.IdPeriodoTitulacion = new SelectList(new List<SelectListItem>(), "Text");
            ViewBag.IdPeriodoUltimo = new SelectList(new List<SelectListItem>(), "Text");
            ViewBag.IdPeriodoIngreso = new SelectList(new List<SelectListItem>(), "Text");
            ViewBag.IdEspecialidad = new SelectList(new List<SelectListItem>(), "Text");
            ViewBag.IdReticula = new SelectList(new List<SelectListItem>(), "Text");
            ViewBag.IdCarrera = new SelectList(new List<SelectListItem>(), "Text");
            return View();
        }



        [HttpPost]
        public ActionResult FicViAlumnoCarreraAdd(eva_alumnos_carreras ed)
        {
            FicService.FicAlumnoCarreraCreate(ed).Wait();
            return RedirectToAction("FicViAlumnoCarreraList");
        }
        #endregion
        #region Eliminar Edificio----------------------------------------- 
        public ActionResult FicViAlumnoCarreraDelete(short id)
        {
            if (id != null)
            {
                FicService.FicAlumnoCarreraDelete(id).Wait();
                return RedirectToAction("FicViAlumnoCarreraList");
            }
            return null;
        }
        #endregion

    }
}