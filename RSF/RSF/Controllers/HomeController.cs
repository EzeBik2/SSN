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
        public ActionResult Logueado()
        {
            return View();
        }
        public ActionResult CrearEquipo3()
        {
            return View("CrearEquipo");
        }
        public ActionResult Endesarrollo()
        {
            return View("Endesarrollo");
        }
        public ActionResult EliminarEquipo3()
        {
            return View("EliminarEquipo");
        }
    
        public ActionResult BuscarTodo(Todos J)
        {
            string A = J.nombre;
            if (A.Substring(0, 1) == "#")
            {
                switch (A.Substring(1, 1))
                {
                    case "C":
                        Cancha canchaa = new Cancha();
                        canchaa.id = Convert.ToInt32(A.Substring(2, A.Length - 3));
                        canchaa = Canchas.TraerUnaCancha(canchaa);
                        ViewBag.A = canchaa;
                        return View("PerfilCancha");
                    case "E": 
                        Equipo equipoo = new Equipo();
                        equipoo.id = Convert.ToInt32(A.Substring(2, A.Length - 3));
                        equipoo = Equipos.TraerUnEquipo(equipoo);
                        ViewBag.A = equipoo;
                        return View("PerfilEquipo");
                    case "J":
                        Jugador jugadorr = new Jugador();
                        jugadorr.id = Convert.ToInt32(A.Substring(2, A.Length - 2));
                        jugadorr = Jugadores.TraerUnJugador(jugadorr);
                        ViewBag.A = jugadorr;
                        return View("PerfilJugador");
                    default:
                        return View("Logueado");
                }
            }
            else
            {
                Equipo B = new Equipo();
                B.nombre = A;
                List<Equipo> C = Equipos.TraerEquipos(B);
                Cancha D = new Cancha();
                D.nombre = A;
                List<Cancha> E = Canchas.TraerCanchas(D);
                Jugador F = new Jugador();
                F.nombre = A;
                List<Jugador> G = Jugadores.TraerJugadores(F);
                List<Todos> W = new List<Todos>();
                for (int i = 0; i < C.Count; i++)
                {
                    Todos P = new Todos();
                    P.id = C[i].id;
                    P.nombre = C[i].nombre;
                    P.tipo = "Equipo";
                    W.Add(P);
                }
                for (int i = 0; i < E.Count; i++)
                {
                    Todos P = new Todos();
                    P.id = E[i].id;
                    P.nombre = E[i].nombre;
                    P.tipo = "Cancha";
                    W.Add(P);
                }
                for (int i = 0; i < G.Count; i++)
                {
                    Todos P = new Todos();
                    P.id = G[i].id;
                    P.nombre = G[i].nombre;
                    P.tipo = "Jugador";
                    W.Add(P);
                }
                ViewBag.A = W;
                return View("Todos");
            }
        }
        
        public ActionResult LoguearJugador(Jugador unJugador)
        {
            Jugador Jugadordevuelto = Jugadores.TraerUnJugador(unJugador);
            ViewBag.B = Jugadordevuelto;
            //ViewBag.C = Partidos.TraerPartidosLogueado();
            if (Jugadordevuelto.id > 0)
            {
                return View("Logueado");
            }
            else
            {
                ViewBag.A = "No se encontro al Jugador";
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
            if (unJugador.id > 0)
            {
                Jugador Jugadordevuelto = Jugadores.TraerUnJugador(unJugador);
                if (Jugadordevuelto.id > 0)
                {
                    ViewBag.A = Jugadordevuelto;
                    return View("PerfilJugador");
                }
                else
                {
                    ViewBag.Error = "No funciono";
                    return View("Logueado");
                }
            }
            else
            {
                List<Jugador> ListadeJugadores = Jugadores.TraerJugadores(unJugador);
                if (ListadeJugadores.Count > 0)
                {
                    ViewBag.A = ListadeJugadores;
                    return View("Jugadores");
                }
                else
                {
                    ViewBag.Error = "No funciono";
                    return View("Logueado");
                }
            }   
        }
        public ActionResult ModificarJugador(Jugador unJugador)
        {
            bool funciono = Jugadores.ModificarUnJugador(unJugador);
            if (funciono)
            {
                return View("Logueado");
            }
            else
            {
                return View("PerfilJugador");
            }
        }
        public ActionResult EliminarJugador(int A)
        {
            bool Funciono = Jugadores.EliminarUnJugador(A);
            if (Funciono)
            {
                return View("Index");
            }
            else
            {
                return View("Logueado");
            }
        }
        public ActionResult EquiposJugador(Jugador unJugador)
        {
            EquipoJugador A = new EquipoJugador();
            A.idJugador = unJugador.id;
            List<int> B = EquiposJugadores.TraerEquipos(A);
            List<Equipo> C = new List<Equipo>();
            for (int i = 0; i < B.Count; i++)
            {
                Equipo D = new Equipo();
                D.id = B[i];
                D = Equipos.TraerUnEquipo(D);
                C.Add(D);
            }
            ViewBag.E = C;
            return View("EquiposJugador");
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
            if (unaCancha.id > 0)
            {
                Cancha unaCancha2 = Canchas.TraerUnaCancha(unaCancha);
                if (unaCancha2.id > 0)
                {
                    ViewBag.A = unaCancha2;
                    return View("PerfilCancha");
                }
                else
                {
                    ViewBag.Error = "No se pudo";
                    return View("Cancha");
                }
            }
            else
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
        public ActionResult ModificarCancha(Cancha unaCancha)
        {
            bool funciono = Canchas.ModificarUnaCancha(unaCancha);
            return View("Logueado");
        }
        public ActionResult EliminarCancha(int A)
        {
            bool Funciono = Canchas.EliminarUnaCancha(A);
            if (Funciono)
            {
                return View("Logueado");
            }
            else
            {
                return View("Logueado");
            }
        }

        public ActionResult CrearEquipo(Todos unEquipo)
        {
            Equipo unEquipo2 = new Equipo();
            unEquipo2.nombre = unEquipo.nombre;
            unEquipo2.cantjug = unEquipo.cantjug;
            bool equipoagregado = Equipos.AgregarUnEquipo(unEquipo2);
            Equipo traer = Equipos.TraerUnEquipo(unEquipo2);
            EquipoJugador A = new EquipoJugador();
            A.idEquipo = traer.id;
            A.idJugador = unEquipo2.id;
            bool jugadoragregado = EquiposJugadores.Agregar(A);
            ViewBag.A = Equipos.TraerUnEquipo(traer);
            return View("PerfilEquipo");
        }
        public ActionResult BuscarEquipos(Equipo unequipo)
        {
            if (unequipo.id > 0)
            {
                Equipo unequipo2 = Equipos.TraerUnEquipo(unequipo);
                if (unequipo2.id > 0)
                {
                    ViewBag.A = unequipo2;
                    return View("PerfilEquipo");
                }
                else
                {
                    ViewBag.Error = "No se pudo";
                    return View("Equipo");
                }
            }
            else
            {
                List<Equipo> ListadeEquipos = Equipos.TraerEquipos(unequipo);
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
        }
        public ActionResult ModificarEquipo(Equipo unEquipo)
        {
            bool funciono = Equipos.ModificarUnEquipo(unEquipo);
            return View("Logueado");

        }
        public ActionResult EliminarEquipo(int A)
        {
            bool Funciono = Equipos.EliminarUnEquipo(A);
            bool Funcionob = EquiposJugadores.EliminarEquipo(A);
            if (Funciono)
            {
                return View("Logueado");
            }
            else
            {
                return View("Logueado");
            }
        }
        public ActionResult VerPlantel(int A)
        {
            EquipoJugador B = new EquipoJugador();
            B.idEquipo = A;
            List<int> Lista = EquiposJugadores.TraerJugadores(B);
            List<Jugador> W = new List<Jugador>();
            foreach (int J in Lista)
            {
                Jugador m = new Jugador();
                m.id = J;
                m = Jugadores.TraerUnJugador(m);
                W.Add(m);
            }
            ViewBag.A = W;
            return View("Plantel");
        }
        public ActionResult EliminarEquipo2(EquipoJugador jugador)
        {
            jugador = EquiposJugadores.Traer(jugador);
            bool funciono = EquiposJugadores.Eliminar(jugador.id);
            return View("Logueado");
        }
    }
}