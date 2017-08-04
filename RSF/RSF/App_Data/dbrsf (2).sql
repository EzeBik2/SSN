-- phpMyAdmin SQL Dump
-- version 3.5.1
-- http://www.phpmyadmin.net
--
-- Servidor: localhost
-- Tiempo de generación: 04-08-2017 a las 06:50:45
-- Versión del servidor: 5.5.24-log
-- Versión de PHP: 5.4.3

SET SQL_MODE="NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Base de datos: `dbrsf`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `canchas`
--

CREATE TABLE IF NOT EXISTS `canchas` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nombre` varchar(50) NOT NULL,
  `barrio` varchar(50) NOT NULL,
  `calle` varchar(50) NOT NULL,
  `telefono` int(11) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=16 ;

--
-- Volcado de datos para la tabla `canchas`
--

INSERT INTO `canchas` (`id`, `nombre`, `barrio`, `calle`, `telefono`) VALUES
(14, 'CanchaRandom', 'BarrioRandom', 'CalleRandom', 12312512),
(15, 'Liber', 'Almagro', 'almagro', 1252151);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `equipos`
--

CREATE TABLE IF NOT EXISTS `equipos` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nombre` varchar(50) NOT NULL,
  `cantjug` int(11) NOT NULL,
  `calificacion` int(11) NOT NULL,
  `cantvotos` int(11) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=44 ;

--
-- Volcado de datos para la tabla `equipos`
--

INSERT INTO `equipos` (`id`, `nombre`, `cantjug`, `calificacion`, `cantvotos`) VALUES
(43, 'Independiente', 10, 0, 0);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `equiposjugadores`
--

CREATE TABLE IF NOT EXISTS `equiposjugadores` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `estado` varchar(50) NOT NULL,
  `idequipo` int(11) NOT NULL,
  `idjugador` int(11) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=74 ;

--
-- Volcado de datos para la tabla `equiposjugadores`
--

INSERT INTO `equiposjugadores` (`id`, `estado`, `idequipo`, `idjugador`) VALUES
(73, 'En Formacion', 43, 16);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `jugadores`
--

CREATE TABLE IF NOT EXISTS `jugadores` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nombre` varchar(50) NOT NULL,
  `apellido` varchar(50) NOT NULL,
  `foto` varchar(50) NOT NULL,
  `edad` int(11) NOT NULL,
  `telefono` int(11) NOT NULL,
  `calificacion` int(11) NOT NULL,
  `cantidaddevotos` int(11) NOT NULL,
  `email` varchar(50) NOT NULL,
  `clave` varchar(50) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=3 ;

--
-- Volcado de datos para la tabla `jugadores`
--

INSERT INTO `jugadores` (`id`, `nombre`, `apellido`, `foto`, `edad`, `telefono`, `calificacion`, `cantidaddevotos`, `email`, `clave`) VALUES
(2, 'Martin', 'Alvarez', '', 17, 0, 0, 0, 'martxdx@gmail.com', 'poker1'),
(16, 'Pepe', 'Juarez', '', 11, 12412412, 0, 0, 'PepitoJuarez@gmail.com', 'poker1');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `partidos`
--

CREATE TABLE IF NOT EXISTS `partidos` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `fecha` datetime NOT NULL,
  `cantjug` int(11) NOT NULL,
  `idcancha` int(11) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=25 ;

--
-- Volcado de datos para la tabla `partidos`
--

INSERT INTO `partidos` (`id`, `fecha`, `cantjug`, `idcancha`) VALUES
(20, '2017-01-01 01:01:01', 10, 14),
(21, '2017-01-01 01:01:01', 10, 14),
(22, '2017-01-01 01:01:01', 10, 15),
(24, '2017-01-01 01:01:01', 10, 15);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `partidosjugadores`
--

CREATE TABLE IF NOT EXISTS `partidosjugadores` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `estado` varchar(50) NOT NULL,
  `idpartido` int(11) NOT NULL,
  `idjugador` int(11) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=18 ;

--
-- Volcado de datos para la tabla `partidosjugadores`
--

INSERT INTO `partidosjugadores` (`id`, `estado`, `idpartido`, `idjugador`) VALUES
(2, 'En formacion', 20, 16),
(17, 'En formacion', 21, 2);

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
