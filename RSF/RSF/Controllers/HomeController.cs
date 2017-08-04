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

        public static List<string> TraerNombresDeCanchas(List<Cancha> ListadeCanchas)
        {
            List<string> ListadeNombresDeCanchas = new List<string>();
            for (int Contador = 0; Contador < ListadeCanchas.Count; Contador++)
            {
                ListadeNombresDeCanchas.Add(ListadeCanchas[Contador].nombre); //Trae la lista de todos los nombres de las canchas de la lista anterior
            }
            return ListadeNombresDeCanchas;
        }
        public static List<List<Jugador>> TraerListadeListadeJugadores(List<Partido> TodosLosPartidos)
        {
            List<List<Jugador>> ListadeListadeJugadores = new List<List<Jugador>>();
            List<Jugador> JugadoresPorPartido = new List<Jugador>();
            for (int Contador = 0; Contador < TodosLosPartidos.Count; Contador++)
            {
                PartidoJugador partidodelosjugadoresatrer = new PartidoJugador();
                partidodelosjugadoresatrer.idPartido = TodosLosPartidos[Contador].id; //Agarro el id de un partido
                List<int> ListadeIdsdeJugadoresdelPartido = PartidosJugadores.TraerJugadores(partidodelosjugadoresatrer); //Traigo una lista de ids de los jugadores del partido
                for (int Contador2 = 0; Contador2 < ListadeIdsdeJugadoresdelPartido.Count; Contador2++)
                {
                    Jugador unjugador = new Jugador();
                    unjugador.id = ListadeIdsdeJugadoresdelPartido[Contador2]; //Agarro el id de un jugador del partido
                    JugadoresPorPartido.Add(Jugadores.TraerUnJugador(unjugador)); //Agrego el jugador al que le pertenecia el id a la lista de jugadores de ese partido
                }
                ListadeListadeJugadores.Add(JugadoresPorPartido); //Cuando termina de agregar a todos los jugadores del partido al partido, agrego el partido a la lista de partidos
                JugadoresPorPartido = new List<Jugador>(); //Inicializo nuevamente la lista de jugadores de un partido
            }
            return ListadeListadeJugadores;
        }
        public static List<Partido> Traerlistademispartidos(int iddemijugador)
        {
            PartidoJugador mijugador = new PartidoJugador();
            mijugador.idJugador = iddemijugador;
            List<int> listadeidsdelospartidosdemijugador = PartidosJugadores.TraerPartidos(mijugador); //Traigo lista de IDs de los partidos de mi jugador
            List<Partido> Listademispartidos = new List<Partido>();
            for (int i = 0; i < listadeidsdelospartidosdemijugador.Count; i++)
            {
                Partido unodemispartidos = new Partido();
                unodemispartidos.id = listadeidsdelospartidosdemijugador[i]; //Agarro el id de uno de mis partidos
                Listademispartidos.Add(Partidos.TraerUnPartido(unodemispartidos)); //Agrego el partido a la lista de mis partidos
            }
            return Listademispartidos;
        }
        public static List<string> TraerListadebarrios(List<Cancha> ListadeCanchas)
        {
            List<string> ListaDeBarrios = new List<string>();
            for (int i = 0; i < ListadeCanchas.Count; i++)
            {
                if (ListaDeBarrios.Contains(ListadeCanchas[i].barrio) == false)
                {
                    ListaDeBarrios.Add(ListadeCanchas[i].barrio);
                }
            }
            return ListaDeBarrios;
        }

        public ActionResult Registrar(Jugador jugadoraregistrar)
        {
            bool jugadorGuardado = Jugadores.AgregarUnJugador(jugadoraregistrar); //Si el jugador se agrego con exito devuelve true
            if (jugadorGuardado)
            {
                ViewBag.ErrorEnElRegistro = "Su Usuario esta siendo moderado, espere.";
            }
            else
            {
                ViewBag.ErrorEnElRegistro = "Error en la registracion por parte del programa.";
            }
            return View("Index");
        }
        public ActionResult LoguearJugador(Jugador jugadorqueselogueo)
        {
            jugadorqueselogueo = Jugadores.TraerUnJugador(jugadorqueselogueo); //Verifica que exista el jugador, devuelve un jugador
            if (jugadorqueselogueo.id > 0)
            {
                return Logueado(jugadorqueselogueo); //Si el jugador devuelto tiene un id valido, existe y ejecuta el metodo Logueado
            }
            else
            {
                ViewBag.NoSeEncontro = "No se encontro al Jugador";
                return View("Index"); //Si el jugador devuelto no tiene un id valido, no existe y vuelve a index enviando mensaje de error
            }
        }
        public ActionResult Logueado(Jugador jugadorlogueado)
        {
            Cancha nuevacancha = new Cancha();
            List<Cancha> ListadeCanchas = Canchas.TraerCanchas(nuevacancha); //Trae la lista de todas las canchas que existen
            List<string> ListadeNombresDeCanchas = TraerNombresDeCanchas(ListadeCanchas); //Trae la lista de todos los nombres de las canchas que existen
            List<Partido> TodosLosPartidos = Partidos.TraerPartidos(); //Trae la lista de todos los partidos que existen
            List<List<Jugador>> ListadeListadeJugadores = TraerListadeListadeJugadores(TodosLosPartidos); //Esta lista es una lista en la que en cada posicion tiene una lista que en cada posicion tiene jugadores
            List<Partido> Listademispartidos = Traerlistademispartidos(jugadorlogueado.id); //Trae la lista de mis patidos ---wrong---
            List<string> ListaBarrios = TraerListadebarrios(ListadeCanchas);
            if (Listademispartidos.Count == 0 || ListadeCanchas.Count == 0 || ListadeNombresDeCanchas.Count == 0 || TodosLosPartidos.Count == 0 || ListadeListadeJugadores.Count == 0 || jugadorlogueado.id == 0 || ListaBarrios.Count == 0)
            {

                ViewBag.NoSeEncontro = "Tuvimos un problema, vuelva a loguearse por favor.";
                return Index(); //Si fallo el programa que vuelva a inicio.
            }
            else
            {
                ViewBag.ListaDeBarrios = ListaBarrios;
                ViewBag.JugadorLogueado = jugadorlogueado; //Envia Jugador que se logueo
                ViewBag.ListadeListasdeJugadores = ListadeListadeJugadores; //Envio la lista de listas de jugadores
                ViewBag.MisPartidos = Listademispartidos; //Envio la lista de mis partidos
                ViewBag.Combobox = ListadeNombresDeCanchas; //Envia la lista con los nombres a Logueado para el combobox en la creacion de un partido
                ViewBag.ListaDeCanchas = ListadeCanchas;
                ViewBag.TodosLosPartidos = TodosLosPartidos; //Trae la lista de todos los partidos que existen y la envia a logueado para mostrarlas
                return View("Logueado"); //Voy a la pantalla de logueado
            }
        }

        public ActionResult BuscarTodo(Todos todo)
        {
            Jugador mijugador = new Jugador();
            mijugador.id = todo.id;
            ViewBag.B = Jugadores.TraerUnJugador(mijugador); //Envia Jugador logueado

            string Id = todo.nombre;
            if (Id.Substring(0, 1) == "#")
            {
                switch (Id.Substring(1, 1))
                {
                    case "C":
                        IrAPerfilCancha(Id);
                        return View("PerfilCancha");
                    case "E":
                        IrAPerfilEquipo(Id);
                        return View("PerfilEquipo");
                    case "J":
                        IrAPerfilJugador(Id);
                        return View("PerfilJugador");
                    case "P":
                        IrAPerfilPartido(Id);
                        return View("PerfilPartido");
                    default:
                        return View("Logueado");
                }
            }
            else
            {
                Equipo B = new Equipo();
                B.nombre = Id;
                List<Equipo> C = Equipos.TraerEquipos(B);
                Cancha D = new Cancha();
                D.nombre = Id;
                List<Cancha> E = Canchas.TraerCanchas(D);
                Jugador F = new Jugador();
                F.nombre = Id;
                List<Jugador> G = Jugadores.TraerJugadores(F);
                List<Todos> W = new List<Todos>();
                for (int i = 0; i < C.Count; i++)
                {
                    Todos P = new Todos();
                    P.id = C[i].id;
                    P.nombre = C[i].nombre;
                    P.tipo = "Equipo";
                    if (P.id != 0)
                    {
                        W.Add(P);
                    }
                }
                for (int i = 0; i < E.Count; i++)
                {
                    Todos P = new Todos();
                    P.id = E[i].id;
                    P.nombre = E[i].nombre;
                    P.tipo = "Cancha";
                    if (P.id != 0)
                    {
                        W.Add(P);
                    }
                }
                for (int i = 0; i < G.Count; i++)
                {
                    Todos P = new Todos();
                    P.id = G[i].id;
                    P.nombre = G[i].nombre;
                    P.tipo = "Jugador";
                    if (P.id != 0)
                    {
                        W.Add(P);
                    }
                }
                ViewBag.A = W;
                return View("Todos");
            }
        }

        public ActionResult BuscarCanchasPor(Todos todo)
        {
            Jugador jugadorqueselogueo = new Jugador();
            jugadorqueselogueo.id = todo.id;
            ViewBag.B = Jugadores.TraerUnJugador(jugadorqueselogueo); //Verifica que exista el jugador, devuelve un jugador


            if (todo.fecha != null)
            {
                Cancha nuevaCancha = new Cancha();
                List<Cancha> ListaDeCanchas = Canchas.TraerCanchas(nuevaCancha);
                List<Partido>  Listadepartidos = Partidos.TraerPartidos();
                for (int i = 0; i < Listadepartidos.Count; i++)
                {
                    if (Listadepartidos[i].Fecha.Equals(todo.fecha))
                    {
                        for (int o = 0; o < ListaDeCanchas.Count; o++)
                        {
                            if (Listadepartidos[i].IdCancha == ListaDeCanchas[o].id)
                            {
                                ListaDeCanchas.Remove(ListaDeCanchas[o]);
                            }
                        }
                    }
                }
                ViewBag.ListadeCanchasDelBarrio = ListaDeCanchas;
                return View("Canchas");
            }
            else
            {
                Cancha nuevaCancha = new Cancha();
                nuevaCancha.barrio = todo.barrios[0];
                ViewBag.ListadeCanchasDelBarrio = Canchas.TraerCanchas(nuevaCancha);
                return View("Canchas");
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

        public ActionResult IrAPerfilCancha(string IddeCancha)
        {
            Cancha Canchaabuscar = new Cancha();
            Canchaabuscar.id = Convert.ToInt32(IddeCancha.Substring(2, IddeCancha.Length - 2)); //Id de Base de Datos de la Cancha
            Canchaabuscar = Canchas.TraerUnaCancha(Canchaabuscar); //Trae de la base de datos la Cancha
            ViewBag.CanchaElejida = Canchaabuscar; //Envia la cancha buscada

            Partido nuevopartido = new Partido();
            nuevopartido.IdCancha = Canchaabuscar.id;
            List<Partido> TodoslosPartidos = Partidos.TraerPartidos(); // Trae todos los Partidos
            for (int Contador = 0; Contador < TodoslosPartidos.Count; Contador++)
            {
                if (Canchaabuscar.id == 0)
                {
                    TodoslosPartidos.Remove(TodoslosPartidos[Contador]); //Quita todos los partidos invalidos
                }
                else
                {
                    if (Canchaabuscar.id != TodoslosPartidos[Contador].IdCancha)
                    {
                        TodoslosPartidos.Remove(TodoslosPartidos[Contador]); //Quita todos los partidos que no sean de la cancha elejida
                    }
                }
            }
            ViewBag.PartidosCancha = TodoslosPartidos; //Envia Lista de partidos en esa cancha
            return View("PerfilCancha");
        }
        public ActionResult IrAPerfilEquipo(string A)
        {
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
                if (F.id > 0)
                {
                    E.Add(F);
                }
            }
            ViewBag.G = E;
            return View("PerfilEquipo");
        }
        public ActionResult ModificarEquipo(Equipo unEquipo)
        {
            Todos A = new Todos();
            A.id = unEquipo.id2;
            bool funciono = Equipos.ModificarUnEquipo(unEquipo);
            A.nombre = "#E" + Equipos.TraerUnEquipo(unEquipo).id;
            return BuscarTodo(A);
        }
        public ActionResult IrAPerfilJugador(string A)
        {

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
                if (FF.id > 0)
                {
                    EE.Add(FF);
                }
            }
            ViewBag.G = EE;
            return View("PerfilJugador");
        }
        public ActionResult ModificarJugador(Jugador unJugador)
        {
            bool funciono = Jugadores.ModificarUnJugador(unJugador);
            if (funciono)
            {
                Todos Nuevo = new Todos();
                Nuevo.id = unJugador.id;
                Nuevo.nombre = "#J" + unJugador.id;
                return BuscarTodo(Nuevo);
            }
            else
            {
                Todos Nuevo = new Todos();
                Nuevo.id = unJugador.id;
                Nuevo.nombre = "#J" + unJugador.id;
                return BuscarTodo(Nuevo);
            }
        }
        public ActionResult IrAPerfilPartido(string A)
        {
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
                if (FFFF.id > 0)
                {
                    EEEE.Add(FFFF);
                }
            }
            ViewBag.G = EEEE;
            Cancha L = new Cancha();
            L.id = partidoo.IdCancha;
            ViewBag.W = Canchas.TraerUnaCancha(L).nombre;
            return View("PerfilPartido");
        }
        public ActionResult EquiposJugador(Jugador unJugador)
        {
            ViewBag.B = unJugador;
            EquipoJugador A = new EquipoJugador();
            A.idJugador = unJugador.id;
            List<int> B = EquiposJugadores.TraerEquipos(A);
            List<Equipo> C = new List<Equipo>();
            for (int i = 0; i < B.Count; i++)
            {
                Equipo D = new Equipo();
                D.id = B[i];
                D = Equipos.TraerUnEquipo(D);
                if (D.id > 0)
                {
                    C.Add(D);
                }
            }
            ViewBag.E = C;
            return View("EquiposJugador");
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
            Todos M = new Todos();
            M.nombre = "#E" + traer.id;
            M.id = unEquipo.id;
            return BuscarTodo(M);
        }
        public ActionResult CrearPartido(Todos unPartido)
        {
            Partido unPartido2 = new Partido();
            unPartido2.CantJug = unPartido.cantjug;
            unPartido2.Fecha = unPartido.fecha;
            Cancha unaCancha = new Cancha();
            unaCancha.nombre = unPartido.canchas[0];
            unPartido2.IdCancha = Canchas.TraerUnaCancha(unaCancha).id;
            Partido unPartido3 = Partidos.TraerUnPartido2(unPartido2);
            if (unPartido3.id > 0)
            {
                ViewBag.YaExiste = "El horario seleccionado en esta cancha esta ocupado.";
                Jugador K = new Jugador();
                K.id = unPartido.id;
                return Logueado(K);
            }
            PartidoJugador A = new PartidoJugador();
            A.idJugador = unPartido.id;
            List<int> WW = PartidosJugadores.TraerPartidos(A);
            int oo = 0;
            for (int T = 0; T < WW.Count; T++)
            {
                Partido O = new Partido();
                O.id = WW[T];
                O = Partidos.TraerUnPartido(O);
                if (O.Fecha == unPartido2.Fecha)
                {
                    oo++;
                }
            }
            if (oo > 0)
            {
                ViewBag.YaExiste = "Usted ya tiene un partido en este horario.";
                Jugador K = new Jugador();
                K.id = unPartido.id;
                return Logueado(K);
            }
            else
            {
                bool partidoagregado = Partidos.AgregarUnPartido(unPartido2);
                Partido traer = Partidos.TraerUnPartido(unPartido2);
                A.idPartido = traer.id;
                bool jugadoragregado = PartidosJugadores.Agregar(A);
                traer = Partidos.TraerUnPartido(traer);
                Todos tooddooss = new Todos();
                tooddooss.id = unPartido.id;
                tooddooss.nombre = "#P" + traer.id;
                return BuscarTodo(tooddooss);
            }
            
        }
        public ActionResult AgregarCancha(Todos unaCancha)
        {
            Cancha A = new Models.Cancha();
            A.nombre = unaCancha.nombre;
            A.telefono = unaCancha.telefono;
            A.calle = unaCancha.calle;
            A.barrio = unaCancha.barrio;
            Jugador B = new Jugador();
            B.id = unaCancha.id;
            B = Jugadores.TraerUnJugador(B);
            bool canchaagregada = Canchas.AgregarUnaCancha(A);
            if (canchaagregada)
            {
                return Logueado(B);
            }
            else
            {
                ViewBag.Funciono = "Error en la registracion";
                return Logueado(B);
            }
        }
        public ActionResult EntrarAEquipo(EquipoJugador unequipojugador)
        {
            bool A = EquiposJugadores.Agregar(unequipojugador);
            unequipojugador = EquiposJugadores.Traer(unequipojugador);
            Todos B = new Todos();
            B.nombre = "#E" + unequipojugador.idEquipo;
            B.id = unequipojugador.idJugador;
            return BuscarTodo(B);
        }
        public ActionResult SalirDelEquipo(EquipoJugador unequipojugador)
        {
            unequipojugador = EquiposJugadores.Traer(unequipojugador);
            bool A = EquiposJugadores.Eliminar(unequipojugador.id);
            Todos B = new Todos();
            B.nombre = "#E" + unequipojugador.idEquipo;
            B.id = unequipojugador.idJugador;
            return BuscarTodo(B);
        }
        public ActionResult EntrarAPartido(PartidoJugador unpartidojugador)
        {
            bool A = PartidosJugadores.Agregar(unpartidojugador);
            unpartidojugador = PartidosJugadores.Traer(unpartidojugador);
            Todos B = new Todos();
            B.nombre = "#P" + unpartidojugador.idPartido;
            B.id = unpartidojugador.idJugador;
            return BuscarTodo(B);
        }
        public ActionResult SalirDelPartido(PartidoJugador unpartidojugador)
        {
            unpartidojugador = PartidosJugadores.Traer(unpartidojugador);
            bool A = PartidosJugadores.Eliminar(unpartidojugador.id);
            Todos B = new Todos();
            B.nombre = "#P" + unpartidojugador.idPartido;
            B.id = unpartidojugador.idJugador;
            return BuscarTodo(B);
        }
        public ActionResult QuienesSomos()
        {
            return View();
        }

        public ActionResult Contacto()
        {
            return View();
        }
        public ActionResult Afiliar()
        {
            return View();
        }
    }
}