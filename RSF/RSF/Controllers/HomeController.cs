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


        public ActionResult CrearEquipo(Todos unEquipo)
        {
            Equipo unEquipo2 = new Equipo();
            unEquipo2.nombre = unEquipo.nombre;
            unEquipo2.cantjug = unEquipo.cantjug;
            bool equipoagregado = Equipos.AgregarUnEquipo(unEquipo2);
            Equipo traer = Equipos.TraerUnEquipo(unEquipo2);
            EquipoJugador A = new EquipoJugador();
            A.idEquipo = traer.id;
            A.idJugador = unEquipo.id;
            bool jugadoragregado = EquiposJugadores.Agregar(A);
            ViewBag.A = Equipos.TraerUnEquipo(traer);
            return View("PerfilEquipo");
        }
        public ActionResult BuscarJugador(Jugador unJugador)
        {
            if (unJugador.id > 0)
            {
                Jugador Jugadordevuelto = Jugadores.TraerUnJugador(unJugador);
                if (Jugadordevuelto.id > 0)
                {
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
        public ActionResult CrearPartido(Todos unPartido)
        {
          Partido unPartido2 = new Partido();
          unPartido2.CantJug = unPartido.cantjug;
          unPartido2.Fecha = unPartido.fecha;
          Cancha unaCancha = new Cancha();
          unaCancha.nombre = unPartido.canchas[0];
          unPartido2.IdCancha = Canchas.TraerUnaCancha(unaCancha).id;
          bool partidoagregado = Partidos.AgregarUnPartido(unPartido2);
          Partido traer = Partidos.TraerUnPartido(unPartido2);
          PartidoJugador A = new PartidoJugador();
          A.idPartido = traer.id;
          A.idJugador = unPartido.id;
          bool jugadoragregado = PartidosJugadores.AgregarB(A);
          ViewBag.A = Partidos.TraerUnPartido(traer);
          return View("PerfilPartido");
        }
        public ActionResult BuscarTodo(Todos J)
        {
            Jugador M = new Jugador();
            M.id = J.id;
            ViewBag.B = Jugadores.TraerUnJugador(M);
            string A = J.nombre;
            if (A.Substring(0, 1) == "#")
            {
                switch (A.Substring(1, 1))
                {
                    case "C":
                        Cancha canchaa = new Cancha();
                        canchaa.id = Convert.ToInt32(A.Substring(2, A.Length - 2));
                        canchaa = Canchas.TraerUnaCancha(canchaa);
                        ViewBag.A = canchaa;
                        Partido CCC = new Partido();
                        CCC.IdCancha = canchaa.id;
                        List<Partido> DDD = Partidos.TraerPartidos();
                        for (int i = 0; i < DDD.Count; i++)
                        {
                            if (canchaa.id != DDD[i].IdCancha)
                            {
                                DDD.Remove(DDD[i]);
                            }
                        }
                        ViewBag.G = DDD;
                        return View("PerfilCancha");
                    case "E":
                        Equipo equipoo = new Equipo();
                        equipoo.id = Convert.ToInt32(A.Substring(2, A.Length - 2));
                        equipoo = Equipos.TraerUnEquipo(equipoo);
                        ViewBag.A = equipoo;
                        EquipoJugador C = new EquipoJugador();
                        C.idEquipo = equipoo.id;
                        List<int> D = EquiposJugadores.TraerJugadores(C);
                        List<Jugador> E = new List<Jugador>();
                        for (int i = 0; i < D.Count; i++)
                        {
                            Jugador F = new Jugador();
                            F.id = D[i];
                            F = Jugadores.TraerUnJugador(F);
                            E.Add(F);
                        }
                        ViewBag.G = E;
                        return View("PerfilEquipo");
                    case "J":
                        Jugador jugadorr = new Jugador();
                        jugadorr.id = Convert.ToInt32(A.Substring(2, A.Length - 2));
                        jugadorr = Jugadores.TraerUnJugador(jugadorr);
                        ViewBag.A = jugadorr;
                        EquipoJugador CC = new EquipoJugador();
                        CC.idJugador = jugadorr.id;
                        List<int> DD = EquiposJugadores.TraerEquipos(CC);
                        List<Equipo> EE = new List<Equipo>();
                        for (int i = 0; i < DD.Count; i++)
                        {
                            Equipo FF = new Equipo();
                            FF.id = DD[i];
                            FF = Equipos.TraerUnEquipo(FF);
                            EE.Add(FF);
                        }
                        ViewBag.G = EE;
                        return View("PerfilJugador");
                    case "P":
                        Partido partidoo = new Partido();
                        partidoo.id = Convert.ToInt32(A.Substring(2, A.Length - 2));
                        partidoo = Partidos.TraerUnPartido(partidoo);
                        ViewBag.A = partidoo;
                        PartidoJugador CCCC = new PartidoJugador();
                        CCCC.idPartido = partidoo.id;
                        List<int> DDDD = PartidosJugadores.TraerJugadores(CCCC);
                        List<Jugador> EEEE = new List<Jugador>();
                        for (int i = 0; i < DDDD.Count; i++)
                        {
                            Jugador FFFF = new Jugador();
                            FFFF.id = DDDD[i];
                            FFFF = Jugadores.TraerUnJugador(FFFF);
                            EEEE.Add(FFFF);
                        }
                        ViewBag.G = EEEE;
                        Cancha L = new Cancha();
                        L.id = partidoo.IdCancha;
                        ViewBag.W = Canchas.TraerUnaCancha(L).nombre;
                        return View("PerfilPartido");
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
        public ActionResult LoguearJugador(Jugador unJugador)
        {
            Jugador Jugadordevuelto = Jugadores.TraerUnJugador(unJugador);
            ViewBag.B = Jugadordevuelto;
            Cancha nuevacancha = new Cancha();
            List<Cancha> ListadeCanchas = Canchas.TraerCanchas(nuevacancha);
            List<string> ListadeNombresDeCanchas = new List<string>();
            for (int i = 0; i < ListadeCanchas.Count; i++)
            {
                ListadeNombresDeCanchas.Add(ListadeCanchas[i].nombre);
            }
            ViewBag.C = ListadeNombresDeCanchas;
            ViewBag.D = Partidos.TraerPartidos();
            PartidoJugador nuevo = new PartidoJugador();
            nuevo.idJugador = Jugadordevuelto.id;
            List<int> E = PartidosJugadores.TraerPartidos(nuevo);
            List<Partido> Enviar = new List<Partido>();
            for (int i = 0; i < E.Count; i++)
            {
                Partido JJ = new Partido();
                JJ.id = E[i];
                Enviar.Add(Partidos.TraerUnPartido(JJ));
            }
            ViewBag.F = Enviar;
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
    }
}