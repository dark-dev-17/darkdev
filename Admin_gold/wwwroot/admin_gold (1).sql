-- phpMyAdmin SQL Dump
-- version 4.9.2
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 01-04-2020 a las 02:06:01
-- Versión del servidor: 10.4.11-MariaDB
-- Versión de PHP: 7.4.1

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `admin_gold`
--

DELIMITER $$
--
-- Procedimientos
--
CREATE DEFINER=`root`@`localhost` PROCEDURE `SP_Cliente` (IN `Id` INT, IN `Nombre` VARCHAR(150), IN `Telefono` VARCHAR(10), IN `ModeProcedure` INT, OUT `CodeResponse` INT, OUT `MessageResponse` TEXT)  BEGIN
	/*
		1 add
        2 upd 
        3 delete 
    */
    DECLARE ResultTransaction int;
    set ResultTransaction = 0;

    -- start transaction
    START TRANSACTION;
    SET autocommit=0;
    -- start process
    if(ModeProcedure = 1) then
		INSERT INTO `t02_cliente`(`t02_pk01`,`t02_f001`,`t03_f002`)VALUES(null,Nombre,Telefono);
		set ResultTransaction = ROW_COUNT();
		set CodeResponse = 0;
        set MessageResponse = concat('Información guardada' );
	elseif(ModeProcedure = 2) then
		if(Select count(*) from t02_cliente where t02_pk01 = Id) > 0 then
			update t02_cliente set t02_f001 = Nombre, t03_f002 = Telefono where t02_pk01 = Id;
			set ResultTransaction = ROW_COUNT();
			set CodeResponse = 0;
			set MessageResponse = concat('Información actualzada' );       
        else
			set CodeResponse = 200;
			set MessageResponse = concat('Información no actualzada' );
        end if;
    else 
		if(Select count(*) from t02_cliente where t02_pk01 = Id) > 0 then
			delete from t02_cliente  where t02_pk01 = Id;
			set ResultTransaction = ROW_COUNT();
			set CodeResponse = 0;
			set MessageResponse = concat('Registro  eliminado' );       
        else
			set CodeResponse = 200;
			set MessageResponse = concat('Registro no eliminado' );
        end if;
    end if;
    -- valid success of the process
    if(CodeResponse = 0 ) then
		if(ResultTransaction != 1) then
			rollback;
			set CodeResponse = 900;
			set MessageResponse = concat('Error al procesar, por favor contacta al departamento de TI: ' ,Idd,'*',ResultTransaction,'*',ModeProcedure);
		else	
			commit;
        end if;
    end if;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `SP_Pedido` (IN `Id` INT, IN `Total` DOUBLE, IN `FechaCompra` DATETIME, IN `Estatus` INT, IN `Proveedor` INT, IN `ModeProcedure` INT, OUT `CodeResponse` INT, OUT `MessageResponse` TEXT)  BEGIN
	/*
		1 add
        2 upd 
        3 delete 
    */
    DECLARE ResultTransaction int;
    set ResultTransaction = 0;

    -- start transaction
    START TRANSACTION;
    SET autocommit=0;
    -- start process
    if(ModeProcedure = 1) then
		INSERT INTO `t04_pedido`(`t04_pk01`,`t04_f001`,`t04_f002`,t04_f003,t03_pk01)VALUES(null,Total,FechaCompra,Estatus,Proveedor);
		set ResultTransaction = ROW_COUNT();
		set CodeResponse = 0;
        set MessageResponse = concat('Información guardada' );
	elseif(ModeProcedure = 2) then
		if(Select count(*) from t04_pedido where t04_pk01 = Id) > 0 then
			update t04_pedido set t04_f001 = Total, t04_f002 = FechaCompra, t04_f003 = Estatus, t03_pk01 = Proveedor  where t04_pk01 = Id;
			set ResultTransaction = ROW_COUNT();
			set CodeResponse = 0;
			set MessageResponse = concat('Información actualzada' );       
        else
			set CodeResponse = 200;
			set MessageResponse = concat('Información no actualzada' );
        end if;
    else 
		if(Select count(*) from t04_pedido where t04_pk01 = Id) > 0 then
			delete from t04_pedido  where t04_pk01 = Id;
			set ResultTransaction = ROW_COUNT();
			set CodeResponse = 0;
			set MessageResponse = concat('Registro  eliminado' );       
        else
			set CodeResponse = 200;
			set MessageResponse = concat('Registro no eliminado' );
        end if;
    end if;
    -- valid success of the process
    if(CodeResponse = 0 ) then
		if(ResultTransaction != 1) then
			rollback;
			set CodeResponse = 900;
			set MessageResponse = concat('Error al procesar, por favor contacta al departamento de TI: ' ,Idd,'*',ResultTransaction,'*',ModeProcedure);
		else	
			commit;
        end if;
    end if;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `SP_PedidoNota` (IN `Id` INT, IN `Folio` VARCHAR(15), IN `Pedido` INT, IN `ModeProcedure` INT, OUT `CodeResponse` INT, OUT `MessageResponse` TEXT)  BEGIN
	/*
		1 add
        2 upd 
        3 delete 
    */
    DECLARE ResultTransaction int;
    set ResultTransaction = 0;

    -- start transaction
    START TRANSACTION;
    SET autocommit=0;
    -- start process
    if(ModeProcedure = 1) then
		INSERT INTO `t05_pedidonota`(`t05_pk01`,`t05_f001`,`t04_pk01`)VALUES(null,Folio,Pedido);
		set ResultTransaction = ROW_COUNT();
		set CodeResponse = 0;
        set MessageResponse = concat('Información guardada' );
	elseif(ModeProcedure = 2) then
		if(Select count(*) from t05_pedidonota where t05_pk01 = Id) > 0 then
			update t05_pedidonota set t05_f001 = Folio, t04_pk01 = Pedido where t05_pk01 = Id;
			set ResultTransaction = ROW_COUNT();
			set CodeResponse = 0;
			set MessageResponse = concat('Información actualzada' );       
        else
			set CodeResponse = 200;
			set MessageResponse = concat('Información no actualzada' );
        end if;
    else 
		if(Select count(*) from t05_pedidonota where t05_pk01 = Id) > 0 then
			delete from t05_pedidonota  where t05_pk01 = Id;
			set ResultTransaction = ROW_COUNT();
			set CodeResponse = 0;
			set MessageResponse = concat('Registro  eliminado' );       
        else
			set CodeResponse = 200;
			set MessageResponse = concat('Registro no eliminado' );
        end if;
    end if;
    -- valid success of the process
    if(CodeResponse = 0 ) then
		if(ResultTransaction != 1) then
			rollback;
			set CodeResponse = 900;
			set MessageResponse = concat('Error al procesar, por favor contacta al departamento de TI: ' ,Idd,'*',ResultTransaction,'*',ModeProcedure);
		else	
			commit;
        end if;
    end if;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `SP_Proveedor` (IN `Id` INT, IN `Nombre` VARCHAR(150), IN `Telefono` VARCHAR(10), IN `Direccion` VARCHAR(300), IN `ModeProcedure` INT, OUT `CodeResponse` INT, OUT `MessageResponse` TEXT)  BEGIN
	/*
		1 add
        2 upd 
        3 delete 
    */
    DECLARE ResultTransaction int;
    set ResultTransaction = 0;

    -- start transaction
    START TRANSACTION;
    SET autocommit=0;
    -- start process
    if(ModeProcedure = 1) then
		INSERT INTO `t03_proveedor`(`t03_pk01`,`t03_f001`,`t03_f002`,t03_f003)VALUES(null,Nombre,Telefono,Direccion);
		set ResultTransaction = ROW_COUNT();
		set CodeResponse = 0;
        set MessageResponse = concat('Información guardada' );
	elseif(ModeProcedure = 2) then
		if(Select count(*) from t03_proveedor where t03_pk01 = Id) > 0 then
			update t03_proveedor set t03_f001 = Nombre, t03_f002 = Telefono, t03_f003 = Direccion where t03_pk01 = Id;
			set ResultTransaction = ROW_COUNT();
			set CodeResponse = 0;
			set MessageResponse = concat('Información actualzada' );       
        else
			set CodeResponse = 200;
			set MessageResponse = concat('Información no actualzada' );
        end if;
    else 
		if(Select count(*) from t03_proveedor where t03_pk01 = Id) > 0 then
			delete from t03_proveedor  where t03_pk01 = Id;
			set ResultTransaction = ROW_COUNT();
			set CodeResponse = 0;
			set MessageResponse = concat('Registro  eliminado' );       
        else
			set CodeResponse = 200;
			set MessageResponse = concat('Registro no eliminado' );
        end if;
    end if;
    -- valid success of the process
    if(CodeResponse = 0 ) then
		if(ResultTransaction != 1) then
			rollback;
			set CodeResponse = 900;
			set MessageResponse = concat('Error al procesar, por favor contacta al departamento de TI: ' ,Idd,'*',ResultTransaction,'*',ModeProcedure);
		else	
			commit;
        end if;
    end if;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `SP_tipoProducto` (IN `Id` INT, IN `Descripcion` VARCHAR(150), IN `ModeProcedure` INT, OUT `CodeResponse` INT, OUT `MessageResponse` TEXT)  BEGIN
	/*
		1 add
        2 upd 
    */
    DECLARE ResultTransaction int;
    set ResultTransaction = 0;

    -- start transaction
    START TRANSACTION;
    SET autocommit=0;
    -- start process
    if(ModeProcedure = 1) then
		INSERT INTO `t01_tipoproducto`(`t01_pk01`,`t01_f001`)VALUES	(null,	Descripcion);
		set ResultTransaction = ROW_COUNT();
		set CodeResponse = 0;
        set MessageResponse = concat('Información guardada' );
	elseif(ModeProcedure = 2) then
		if(Select count(*) from t01_tipoproducto where t01_pk01 = Id) > 0 then
			update t01_tipoproducto set t01_f001 = Descripcion where t01_pk01 = Id;
			set ResultTransaction = ROW_COUNT();
			set CodeResponse = 0;
			set MessageResponse = concat('Información actualzada' );       
        else
			set CodeResponse = 200;
			set MessageResponse = concat('Información no encontrada' );
        end if;
    else 
		if(Select count(*) from t01_tipoproducto where t01_pk01 = Id) > 0 then
			delete from t01_tipoproducto  where t01_pk01 = Id;
			set ResultTransaction = ROW_COUNT();
			set CodeResponse = 0;
			set MessageResponse = concat('Registro  eliminado' );       
        else
			set CodeResponse = 200;
			set MessageResponse = concat('Registro no encontrado' );
        end if;
    end if;
    -- valid success of the process
    if(CodeResponse = 0 ) then
		if(ResultTransaction != 1) then
			rollback;
			set CodeResponse = 900;
			set MessageResponse = concat('Error al procesar, por favor contacta al departamento de TI: ' ,Idd,'*',ResultTransaction,'*',ModeProcedure);
		else	
			commit;
        end if;
    end if;
END$$

DELIMITER ;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `t01_tipoproducto`
--

CREATE TABLE `t01_tipoproducto` (
  `t01_pk01` int(11) NOT NULL,
  `t01_f001` varchar(150) COLLATE utf8_spanish_ci DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

--
-- Volcado de datos para la tabla `t01_tipoproducto`
--

INSERT INTO `t01_tipoproducto` (`t01_pk01`, `t01_f001`) VALUES
(2, 'Oro'),
(3, 'Plata');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `t02_cliente`
--

CREATE TABLE `t02_cliente` (
  `t02_pk01` int(11) NOT NULL,
  `t02_f001` varchar(150) COLLATE utf8_spanish_ci DEFAULT NULL,
  `t03_f002` varchar(10) COLLATE utf8_spanish_ci DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

--
-- Volcado de datos para la tabla `t02_cliente`
--

INSERT INTO `t02_cliente` (`t02_pk01`, `t02_f001`, `t03_f002`) VALUES
(2, 'Jesus Martinez', '4481695819'),
(3, 'jesus', 'martinez');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `t03_proveedor`
--

CREATE TABLE `t03_proveedor` (
  `t03_pk01` int(11) NOT NULL,
  `t03_f001` varchar(150) COLLATE utf8_spanish_ci DEFAULT NULL,
  `t03_f002` varchar(10) COLLATE utf8_spanish_ci DEFAULT NULL,
  `t03_f003` varchar(300) COLLATE utf8_spanish_ci DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

--
-- Volcado de datos para la tabla `t03_proveedor`
--

INSERT INTO `t03_proveedor` (`t03_pk01`, `t03_f001`, `t03_f002`, `t03_f003`) VALUES
(1, 'Luis Angel Martinez', '1122334455', 'Libertad sn'),
(2, 'Luis', '1122334455', 'Libertad sn');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `t04_pedido`
--

CREATE TABLE `t04_pedido` (
  `t04_pk01` int(11) NOT NULL,
  `t04_f001` double DEFAULT NULL,
  `t04_f002` datetime DEFAULT NULL,
  `t04_f003` int(11) DEFAULT NULL,
  `t03_pk01` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

--
-- Volcado de datos para la tabla `t04_pedido`
--

INSERT INTO `t04_pedido` (`t04_pk01`, `t04_f001`, `t04_f002`, `t04_f003`, `t03_pk01`) VALUES
(2, 1212, '2020-03-04 00:00:00', 0, 1),
(3, 500, '2020-03-04 00:00:00', 0, 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `t05_pedidonota`
--

CREATE TABLE `t05_pedidonota` (
  `t05_pk01` int(11) NOT NULL,
  `t05_f001` varchar(15) COLLATE utf8_spanish_ci DEFAULT NULL,
  `t04_pk01` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `t01_tipoproducto`
--
ALTER TABLE `t01_tipoproducto`
  ADD PRIMARY KEY (`t01_pk01`);

--
-- Indices de la tabla `t02_cliente`
--
ALTER TABLE `t02_cliente`
  ADD PRIMARY KEY (`t02_pk01`);

--
-- Indices de la tabla `t03_proveedor`
--
ALTER TABLE `t03_proveedor`
  ADD PRIMARY KEY (`t03_pk01`);

--
-- Indices de la tabla `t04_pedido`
--
ALTER TABLE `t04_pedido`
  ADD PRIMARY KEY (`t04_pk01`);

--
-- Indices de la tabla `t05_pedidonota`
--
ALTER TABLE `t05_pedidonota`
  ADD PRIMARY KEY (`t05_pk01`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `t01_tipoproducto`
--
ALTER TABLE `t01_tipoproducto`
  MODIFY `t01_pk01` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT de la tabla `t02_cliente`
--
ALTER TABLE `t02_cliente`
  MODIFY `t02_pk01` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT de la tabla `t03_proveedor`
--
ALTER TABLE `t03_proveedor`
  MODIFY `t03_pk01` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT de la tabla `t04_pedido`
--
ALTER TABLE `t04_pedido`
  MODIFY `t04_pk01` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT de la tabla `t05_pedidonota`
--
ALTER TABLE `t05_pedidonota`
  MODIFY `t05_pk01` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
