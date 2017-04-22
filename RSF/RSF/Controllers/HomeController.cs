using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RSF.Models;
using RSF.Models.DataAccess;

namespace RSF.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Registracion()
        {
            return View();
        }
        public ActionResult Equipo()
        {
            return View();
        }
        public ActionResult Cancha()
        {
            return View();
        }

        public ActionResult LoguearUsuario(Usuario unUsuario)
        {
            bool existeUsuario = Usuarios.existeUsuario(unUsuario);
            if (existeUsuario)
            {
                return View("Logueado");
            }
            else
            {
                ViewBag.A = "Error en el Log In";
                return View("Index");
            }
        }
        public ActionResult Registrar(Usuario unUsuario)
        {
            if (unUsuario.contraseña == unUsuario.Confcontraseña)
            {
                bool usuarioGuardado = Usuarios.GuardarUsuario(unUsuario);
                if (usuarioGuardado)
                {
                    return View("Index");
                }
                else
                {
                    ViewBag.Error = "Error en la registracion";
                    return View("Registracion");
                }
            }
            else
            {
                ViewBag.Error = "Error en la contraseña";
                return View("Registracion");
            }           
        }

        public ActionResult busJugadores(Usuario unJugador)
        {
            List<Usuario> ListadeJugadores = new List<Usuario>();
            ListadeJugadores = Usuarios.buscarJugadores(unJugador);
            if (ListadeJugadores.Count > 0)
            {
                ViewBag.A = ListadeJugadores;
                return View("Jugadores");
            }
            else
            {
                ViewBag.Error = "No se Encontraron Jugadores con esos datos";
                return View("Logueado");
            }
        }

        public ActionResult busCancha(Cancha unaCancha)
        {
            List<Cancha> ListadeCanchas = new List<Cancha>();
            ListadeCanchas = Canchas.existeCancha(unaCancha);
            if (ListadeCanchas.Count > 0)
            {
                ViewBag.A = ListadeCanchas;
                return View("Canchas");
            }
            else
            {
                return View("Cancha");
            }
        }
        public ActionResult newCancha(Cancha unaCancha)
        {
            bool Funciono = Canchas.GuardarCancha(unaCancha);
            if (Funciono)
            {
                ViewBag.Funciono = "Lo Has Logrado Chico";
            }
            else
            {
                ViewBag.Funciono = "Tenes un par de problemas";
            }
            return View("Cancha");
        }
        public ActionResult busEquipo (Equipo unEquipo)
        {            
            List<Equipo> ListadeEquipos = new List<Equipo>();
            ListadeEquipos = Equipos.existeEquipo(unEquipo);
            if (ListadeEquipos.Count > 0)
            {
                ViewBag.A = ListadeEquipos;
                return View("Equipos");
            }
            else
            {
                return View("Equipo");
            }
        }
        public ActionResult newEquipo(Equipo unEquipo)
        {
            bool Funciono = Equipos.GuardarEquipo(unEquipo);
            if (Funciono)
            {
                ViewBag.Funciono = "Lo Has Logrado Chico";
            }
            else
            {
                ViewBag.Funciono = "Tenes un par de problemas";
            }
            return View("Equipo");
        }
    }
}