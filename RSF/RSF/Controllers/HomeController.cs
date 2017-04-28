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

        public ActionResult LoguearJugador(Jugador unJugador)
        {
            Jugador Jugadordevuelto = Jugadores.TraerUnJugador(unJugador);
            if (Jugadordevuelto.id > 0)
            {
                return View("Logueado");
            }
            else
            {
                ViewBag.A = "Error en el Log In";
                return View("Index");
            }
        }
        public ActionResult Registrar(Jugador unJugador)
        {
            if (unJugador.contraseña == unJugador.Confcontraseña)
            {
                bool jugadorGuardado = Jugadores.AgregarUnJugador(unJugador);
                if (jugadorGuardado)
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
        public ActionResult BuscarJugador(Jugador unJugador)
        {
            List<Jugador> ListadeJugadores = Jugadores.TraerJugadores(unJugador);
            if (ListadeJugadores.Count > 0)
            {
                ViewBag.A = ListadeJugadores;
                return View("Jugadores");
            }
            else
            {
                return View("Logueado");
            }
        }
        public ActionResult AgregarCancha(Cancha unaCancha)
        {
            bool canchaagregada = Canchas.AgregarUnaCancha(unaCancha);
            if (canchaagregada)
            {
                return View("Logueado");
            }
            else
            {
                ViewBag.Funciono = "Error en la registracion";
                return View("Cancha");
            }
        }
        public ActionResult BuscarCanchas(Cancha unaCancha)
        {
            List<Cancha> ListadeCanchas = Canchas.TraerCanchas(unaCancha);
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
        
    }
}