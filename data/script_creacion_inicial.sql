USE [GD2C2013]
GO

IF SCHEMA_ID('PROYECTO_W') IS NOT NULL
BEGIN
		IF OBJECT_ID('PROYECTO_W.SP_CARGAR_FECHA') IS NOT NULL
			DROP PROCEDURE PROYECTO_W.SP_CARGAR_FECHA;
			
		IF OBJECT_ID('PROYECTO_W.F_BONOS_FARMACIA_DISPONIBLES') IS NOT NULL
			DROP FUNCTION PROYECTO_W.F_BONOS_FARMACIA_DISPONIBLES;
			
		IF OBJECT_ID('PROYECTO_W.SP_TURNO_CONCRETADO') IS NOT NULL
			DROP PROCEDURE PROYECTO_W.SP_TURNO_CONCRETADO;
			
		IF OBJECT_ID('PROYECTO_W.SP_REGISTRAR_AGENDA') IS NOT NULL
			DROP PROCEDURE PROYECTO_W.SP_REGISTRAR_AGENDA;
			
		IF OBJECT_ID('PROYECTO_W.V_LISTADO_4') IS NOT NULL
			DROP VIEW PROYECTO_W.V_LISTADO_4;
			
		IF OBJECT_ID('[PROYECTO_W].[#Bono_Consulta_Aux]') IS NOT NULL
			DROP TABLE [PROYECTO_W].[#Bono_Consulta_Aux];
		
		IF OBJECT_ID('PROYECTO_W.F_COMPRABONO_DATOS') IS NOT NULL
			DROP FUNCTION PROYECTO_W.F_COMPRABONO_DATOS;
		
		IF OBJECT_ID('PROYECTO_W.SP_COMPRABONOADMIN') IS NOT NULL
				DROP PROCEDURE PROYECTO_W.SP_COMPRABONOADMIN;
				
		IF OBJECT_ID('PROYECTO_W.F_FECHA_CONFIG') IS NOT NULL
			DROP FUNCTION PROYECTO_W.F_FECHA_CONFIG;
				
		IF OBJECT_ID('PROYECTO_W.SP_CANCELAR') IS NOT NULL
				DROP PROCEDURE PROYECTO_W.SP_CANCELAR;
				
        IF OBJECT_ID('[PROYECTO_W].[TurnoCancelacion]') IS NOT NULL
                DROP TABLE [PROYECTO_W].[TurnoCancelacion] ;

        IF OBJECT_ID('[PROYECTO_W].[TipoCancelacion]') IS NOT NULL
                DROP TABLE [PROYECTO_W].[TipoCancelacion] ;

        IF OBJECT_ID('[PROYECTO_W].[BonoPorReceta]') IS NOT NULL
                DROP TABLE [PROYECTO_W].[BonoPorReceta] ;

        IF OBJECT_ID('[PROYECTO_W].[TurnoConcretado]') IS NOT NULL
                DROP TABLE [PROYECTO_W].[TurnoConcretado] ;

        IF OBJECT_ID('[PROYECTO_W].[Receta]') IS NOT NULL
                DROP TABLE [PROYECTO_W].[Receta] ;

        IF OBJECT_ID('[PROYECTO_W].[TurnoLlegada]') IS NOT NULL
                DROP TABLE [PROYECTO_W].[TurnoLlegada] ;

        IF OBJECT_ID('[PROYECTO_W].[Turno]') IS NOT NULL
                DROP TABLE [PROYECTO_W].[Turno] ;

        IF OBJECT_ID('[PROYECTO_W].[EspecialidadPorProfesional]') IS NOT NULL
                DROP TABLE [PROYECTO_W].[EspecialidadPorProfesional] ;

        IF OBJECT_ID('[PROYECTO_W].[Especialidad]') IS NOT NULL
                DROP TABLE [PROYECTO_W].[Especialidad] ;

        IF OBJECT_ID('[PROYECTO_W].[TipoEspecialidad]') IS NOT NULL
                DROP TABLE [PROYECTO_W].[TipoEspecialidad] ;
       
        IF OBJECT_ID('[PROYECTO_W].[RangoHorario]') IS NOT NULL
                DROP TABLE [PROYECTO_W].[RangoHorario] ;

        IF OBJECT_ID('[PROYECTO_W].[Fecha]') IS NOT NULL
                DROP TABLE [PROYECTO_W].[Fecha] ;
                
        IF OBJECT_ID('[PROYECTO_W].[DiaDisponible]') IS NOT NULL
                DROP TABLE [PROYECTO_W].[DiaDisponible] ;

        IF OBJECT_ID('[PROYECTO_W].[AgendaProfesional]') IS NOT NULL
                DROP TABLE [PROYECTO_W].[AgendaProfesional] ;

        IF OBJECT_ID('[PROYECTO_W].[Profesional]') IS NOT NULL
                DROP TABLE [PROYECTO_W].[Profesional] ;

        IF OBJECT_ID('[PROYECTO_W].[MedicamentoPorBonoFarmacia]') IS NOT NULL
                DROP TABLE [PROYECTO_W].[MedicamentoPorBonoFarmacia] ;
                
        IF OBJECT_ID('[PROYECTO_W].[Medicamento]') IS NOT NULL
				DROP TABLE [PROYECTO_W].[Medicamento] ;

        IF OBJECT_ID('[PROYECTO_W].[BonoFarmacia]') IS NOT NULL
                DROP TABLE [PROYECTO_W].[BonoFarmacia] ;

        IF OBJECT_ID('[PROYECTO_W].[BonoConsulta]') IS NOT NULL
                DROP TABLE [PROYECTO_W].[BonoConsulta] ;

        IF OBJECT_ID('[PROYECTO_W].[BonoAdquirido]') IS NOT NULL
                DROP TABLE [PROYECTO_W].[BonoAdquirido] ;

        IF OBJECT_ID('[PROYECTO_W].[HistorialPlan]') IS NOT NULL
                DROP TABLE [PROYECTO_W].[HistorialPlan] ;

        IF OBJECT_ID('[PROYECTO_W].[Afiliado]') IS NOT NULL
                DROP TABLE [PROYECTO_W].[Afiliado] ;

        IF OBJECT_ID('[PROYECTO_W].[Plan]') IS NOT NULL
                DROP TABLE [PROYECTO_W].[Plan] ;

        IF OBJECT_ID('[PROYECTO_W].[FuncionalidadPorRol]') IS NOT NULL
                DROP TABLE [PROYECTO_W].[FuncionalidadPorRol] ;

        IF OBJECT_ID('[PROYECTO_W].[RolPorUsuario]') IS NOT NULL
                DROP TABLE [PROYECTO_W].[RolPorUsuario] ;

        IF OBJECT_ID('[PROYECTO_W].[Funcionalidad]') IS NOT NULL                
                DROP TABLE [PROYECTO_W].[Funcionalidad] ;

        IF OBJECT_ID('[PROYECTO_W].[Rol]') IS NOT NULL
                DROP TABLE [PROYECTO_W].[Rol] ;

        IF OBJECT_ID('[PROYECTO_W].[Usuario]') IS NOT NULL
                DROP TABLE [PROYECTO_W].[Usuario] ;
                
        IF OBJECT_ID('[PROYECTO_W].[FechaConfig]') IS NOT NULL
                DROP TABLE [PROYECTO_W].[FechaConfig] ;
                
        DROP SCHEMA [PROYECTO_W] ;
END
GO

CREATE SCHEMA [PROYECTO_W] AUTHORIZATION [gd]
GO

CREATE TABLE [PROYECTO_W].[Usuario]
(
        [usu_username] [varchar](255) NOT NULL,
        [usu_password] [varchar](255) NOT NULL,
        [usu_cant_intentos] [tinyint] NOT NULL DEFAULT 0,
        [usu_estado] [char](1) NOT NULL DEFAULT 'H', --Habilitado
        PRIMARY KEY (usu_username)
)
GO

CREATE TABLE [PROYECTO_W].[Rol]
(
        [rol_cod] [tinyint] IDENTITY(1,1) NOT NULL,
        [rol_nombre] [varchar](255) NOT NULL,
        [rol_estado] [char](1) NOT NULL DEFAULT 'H',
        UNIQUE (rol_nombre), -- no repetir los nombres de roles
        PRIMARY KEY (rol_cod)
)
GO

CREATE TABLE [PROYECTO_W].[RolPorUsuario]
(
        [rolxusu_username] [varchar](255) NOT NULL,
        [rolxusu_rol_cod] [tinyint] NOT NULL,
        FOREIGN KEY([rolxusu_rol_cod]) REFERENCES [PROYECTO_W].[Rol] ([rol_cod]),
        FOREIGN KEY([rolxusu_username]) REFERENCES [PROYECTO_W].[Usuario] ([usu_username])
                ON UPDATE CASCADE,
        PRIMARY KEY(rolxusu_username, rolxusu_rol_cod)  -- unique podria haber sido, pero no
)
GO

CREATE TABLE [PROYECTO_W].[Funcionalidad]
(
        [func_cod] [tinyint] IDENTITY(1,1) NOT NULL,
        [func_nombre] [varchar](255) NOT NULL,
        UNIQUE (func_nombre),
        PRIMARY KEY (func_cod)
)
GO

CREATE TABLE [PROYECTO_W].[FuncionalidadPorRol]
(
        [funcxrol_rol_cod] [tinyint] NOT NULL,
        [funcxrol_func_cod] [tinyint] NOT NULL,
        [funcxrol_estado] [char](1) NOT NULL DEFAULT 'D',
        FOREIGN KEY([funcxrol_func_cod]) REFERENCES [PROYECTO_W].[Funcionalidad] ([func_cod]),
        FOREIGN KEY([funcxrol_rol_cod]) REFERENCES [PROYECTO_W].[Rol] ([rol_cod]),
        PRIMARY KEY(funcxrol_rol_cod, funcxrol_func_cod)
)
GO

CREATE TABLE [PROYECTO_W].[Plan]
(
        [plan_cod] [numeric](18, 0) /*IDENTITY(555555,1)*/ NOT NULL,
        [plan_descripcion] [varchar](255) NOT NULL DEFAULT 'SIN DESCRIPCION',
        [plan_precio_bono_consulta] [numeric](18, 0) NOT NULL DEFAULT 0,
        [plan_precio_bono_farmacia] [numeric](18, 0) NOT NULL DEFAULT 0,
        [plan_precio_cuota] [smallmoney] NULL,
        CHECK (plan_precio_bono_consulta>=0 AND plan_precio_bono_farmacia>=0 AND plan_precio_cuota>=0),
        PRIMARY KEY (plan_cod)
)
GO

CREATE TABLE [PROYECTO_W].[Afiliado]
(
        [afil_nombre] [varchar](255) NOT NULL,
        [afil_apellido] [varchar](255) NOT NULL,
        [afil_doc_tipo] [varchar](3) NOT NULL DEFAULT 'DNI',
        [afil_doc_nro] [numeric](18, 0) NOT NULL,
        [afil_direccion] [varchar](255) NOT NULL,
        [afil_telefono] [numeric](18, 0) NOT NULL,
        [afil_fecha_nac] [datetime] NOT NULL,
        [afil_sexo] [char](1) NULL,
        [afil_username] [varchar](255) NULL,
        [afil_nro] [bigint] /*IDENTITY(10000001,100)*/ NOT NULL,
        [afil_plan_cod] [numeric](18, 0) NOT NULL,
        [afil_estado] [char](1) NOT NULL DEFAULT 'H',
        [afil_cant_pers_a_cargo] [tinyint] NOT NULL DEFAULT 0,
        [afil_nro_consultas] [numeric](18, 0) NOT NULL DEFAULT 0,
        [afil_estado_civil] [varchar](2) NULL,
        [afil_fecha_baja] [datetime] NULL,
        [afil_mail] [varchar](255) NOT NULL,
        FOREIGN KEY([afil_plan_cod]) REFERENCES [PROYECTO_W].[Plan] ([plan_cod]),
        FOREIGN KEY([afil_username]) REFERENCES [PROYECTO_W].[Usuario] ([usu_username])
                ON UPDATE CASCADE,
--        UNIQUE (afil_doc_tipo, afil_doc_nro, afil_sexo), --no sabemos sexo, asique unique no
--        UNIQUE (afil_username), --SI VA A ESTAR TAMBIEN EN PROFESIONAL, VER QUE SEA LA MISMA PERSONA
        PRIMARY KEY (afil_nro)
)
GO

CREATE TABLE [PROYECTO_W].[HistorialPlan]
(
        [hist_afil_nro] [bigint] NOT NULL,
        [hist_fecha_cambio] [datetime] NOT NULL,
        [hist_nuevo_plan_cod] [numeric](18, 0) NOT NULL,
        [hist_motivo_cambio] [varchar](255) NULL,
        FOREIGN KEY([hist_afil_nro]) REFERENCES [PROYECTO_W].[Afiliado] ([afil_nro]),
        FOREIGN KEY([hist_nuevo_plan_cod]) REFERENCES [PROYECTO_W].[Plan] ([plan_cod]),
        PRIMARY KEY(hist_afil_nro, hist_fecha_cambio)
)
GO

CREATE TABLE [PROYECTO_W].[BonoAdquirido]
(
        [bonadq_tipo_bono] [varchar](255) NOT NULL,
        [bonadq_fecha_compra] [datetime] NOT NULL,
        [bonadq_fecha_impresion] [datetime] NOT NULL,
        [bonadq_cantidad_comprada] [tinyint] NOT NULL,
        [bonadq_afil_nro] [bigint] NOT NULL,
        [bonadq_plan_cod] [numeric](18, 0) NOT NULL,
        [bonadq_suma_pagada] [smallmoney] NULL,
        [bonadq_cod] [bigint] IDENTITY(1,1) NOT NULL,
        [bonadq_afil_doc_nro] [numeric](18, 0) NOT NULL, --############### ALTER 
        FOREIGN KEY([bonadq_afil_nro]) REFERENCES [PROYECTO_W].[Afiliado] ([afil_nro]),
        FOREIGN KEY([bonadq_plan_cod]) REFERENCES [PROYECTO_W].[Plan] ([plan_cod]),
        PRIMARY KEY(bonadq_cod)
)
GO

CREATE TABLE [PROYECTO_W].[BonoConsulta]
(
        [bonocons_bonadq_cod] [bigint] NULL,
        [bonocons_cod] [bigint] NOT NULL,
        [bonocons_estado] [char](1) NOT NULL DEFAULT 'S', --Sin usar
        FOREIGN KEY([bonocons_bonadq_cod]) REFERENCES [PROYECTO_W].[BonoAdquirido] ([bonadq_cod]),
        PRIMARY KEY (bonocons_cod)
)
GO

CREATE TABLE [PROYECTO_W].[BonoFarmacia]
(
        [bonofarm_bonadq_cod] [bigint] NOT NULL,
        [bonofarm_cod] [bigint] NOT NULL,
        [bonofarm_fecha_venc] [datetime] NOT NULL,
        [bonofarm_estado] [char](1) NOT NULL DEFAULT 'S',
        FOREIGN KEY([bonofarm_bonadq_cod]) REFERENCES [PROYECTO_W].[BonoAdquirido] ([bonadq_cod]),
        PRIMARY KEY (bonofarm_cod)
)
GO

CREATE TABLE [PROYECTO_W].[Medicamento]
(
        [medicamento_nombre_cod] [bigint] IDENTITY(1,1) NOT NULL,
        [medicamento_nombre] [varchar](255) NOT NULL,
        UNIQUE (medicamento_nombre),
        PRIMARY KEY (medicamento_nombre_cod)
)
GO

CREATE TABLE [PROYECTO_W].[MedicamentoPorBonoFarmacia]
(
        [medxbonofar_bonofarm_cod] [bigint] NOT NULL,
        [medxbonofar_medicamento_nombre_cod] [bigint] NOT NULL, -- UNA VE SOLA POR BONO FARM
        [medxbonofar_medicamento_cantidad] [tinyint] NOT NULL,
        FOREIGN KEY([medxbonofar_bonofarm_cod]) REFERENCES [PROYECTO_W].[BonoFarmacia] ([bonofarm_cod]),
        FOREIGN KEY([medxbonofar_medicamento_nombre_cod]) REFERENCES [PROYECTO_W].[Medicamento]([medicamento_nombre_cod]),
        PRIMARY KEY(medxbonofar_bonofarm_cod, medxbonofar_medicamento_nombre_cod)
)
GO

CREATE TABLE [PROYECTO_W].[Profesional]
(
        [prof_nombre] [varchar](255) NOT NULL,
        [prof_apellido] [varchar](255) NOT NULL,
        [prof_doc_tipo] [varchar](3) NULL DEFAULT 'DNI',
        [prof_doc_nro] [numeric](18, 0) NOT NULL,
        [prof_direccion] [varchar](255) NOT NULL,
        [prof_telefono] [numeric](18, 0) NOT NULL,
        [prof_mail] [varchar](255) NOT NULL,
        [prof_fecha_nac] [datetime] NOT NULL,
        [prof_sexo] [char](1) NULL,
        [prof_username] [varchar](255) NULL,
        [prof_matricula] [varchar](255) NULL,
        [prof_estado] [char](1) NOT NULL DEFAULT 'H', --Habilitado = activo
        [prof_cod] [bigint] IDENTITY(1,1) NOT NULL,
        FOREIGN KEY([prof_username]) REFERENCES [PROYECTO_W].[Usuario] ([usu_username])
                ON UPDATE CASCADE,
        UNIQUE (prof_doc_nro,prof_nombre),
        PRIMARY KEY (prof_cod)
)
GO

CREATE TABLE [PROYECTO_W].[AgendaProfesional]
(
        [agen_cod] [bigint] IDENTITY(1,1) NOT NULL,
        [agen_prof_cod] [bigint] NOT NULL,
        [agen_estado] [char](1) NOT NULL DEFAULT 'H',   -- Habilitado para no tener que tocar codigo, si el prof da de baja -> 'D'
        FOREIGN KEY([agen_prof_cod]) REFERENCES [PROYECTO_W].[Profesional] ([prof_cod]),
        PRIMARY KEY(agen_cod)
)
GO
-- TODO controlar fechas y horas, que sean validas, con un trigger o algo en lo insert, o algo hacer

CREATE TABLE [PROYECTO_W].[Fecha]
(
        [fecha_fecha] [date] NOT NULL,
        [fecha_agen_cod] [bigint] NOT NULL,
        [fecha_estado] [char](1) NOT NULL DEFAULT 'H', --Habilitado. En la migracion lo hardcodeo a 'D'.
        FOREIGN KEY([fecha_agen_cod]) REFERENCES [PROYECTO_W].[AgendaProfesional] ([agen_cod]),
        PRIMARY KEY(fecha_fecha, fecha_agen_cod)
)
GO

CREATE TABLE [PROYECTO_W].[RangoHorario]
(
        [hora_inicio] [time] NOT NULL,
        [hora_fin] [time] NOT NULL,
        [hora_fecha] [date] NOT NULL,
        [hora_agen_cod] [bigint] NOT NULL,
        FOREIGN KEY([hora_fecha], [hora_agen_cod]) REFERENCES [PROYECTO_W].[Fecha] ([fecha_fecha], [fecha_agen_cod]),
        PRIMARY KEY(hora_inicio, hora_fin, hora_fecha, hora_agen_cod)
)
GO

CREATE TABLE [PROYECTO_W].[TipoEspecialidad]
(
        [tipoesp_cod] [numeric](18, 0) NOT NULL,
        [tipoesp_descripcion] [varchar](255) NOT NULL,
        UNIQUE (tipoesp_descripcion),
        PRIMARY KEY (tipoesp_cod)
)
GO

CREATE TABLE [PROYECTO_W].[Especialidad]
(
        [esp_cod] [numeric](18, 0) NOT NULL,
        [esp_descripcion] [varchar](255) NOT NULL,
        [esp_tipoesp_cod] [numeric](18, 0) NOT NULL,
        FOREIGN KEY([esp_tipoesp_cod]) REFERENCES [PROYECTO_W].[TipoEspecialidad] ([tipoesp_cod]),
        UNIQUE (esp_descripcion),
        PRIMARY KEY (esp_cod)
)
GO

CREATE TABLE [PROYECTO_W].[EspecialidadPorProfesional]
(
        [espxprof_prof_cod] [bigint] NOT NULL,
        [espxprof_esp_cod] [numeric](18, 0) NOT NULL,
        FOREIGN KEY([espxprof_esp_cod]) REFERENCES [PROYECTO_W].[Especialidad] ([esp_cod]),
        FOREIGN KEY([espxprof_prof_cod]) REFERENCES [PROYECTO_W].[Profesional] ([prof_cod]),
        PRIMARY KEY(espxprof_prof_cod, espxprof_esp_cod)
)
GO

CREATE TABLE [PROYECTO_W].[Turno]
(
        [turno_nro] [numeric](18, 0) IDENTITY(56565,1) NOT NULL,
        [turno_afil_nro] [bigint] NOT NULL,
        [turno_estado] [char](1) NOT NULL DEFAULT 'P', --Pedido,Registrado,Contretado.. aca es Pedido, A AUSENTE
        [turno_fecha] [datetime] NOT NULL,
        [turno_prof_cod] [bigint] NOT NULL,
        [turno_esp_cod] [numeric](18, 0) NOT NULL,
        [turno_agen_cod] [bigint] NOT NULL,
        FOREIGN KEY([turno_afil_nro]) REFERENCES [PROYECTO_W].[Afiliado] ([afil_nro]),
        FOREIGN KEY([turno_prof_cod]) REFERENCES [PROYECTO_W].[Profesional] ([prof_cod]),
        FOREIGN KEY([turno_esp_cod]) REFERENCES [PROYECTO_W].[Especialidad] ([esp_cod]),
        FOREIGN KEY ([turno_agen_cod]) REFERENCES [PROYECTO_W].[AgendaProfesional],
        --UNIQUE (turno_fecha, turno_prof_cod)
        PRIMARY KEY (turno_nro)
)
GO

CREATE TABLE [PROYECTO_W].[TurnoLlegada]
(
        [turlle_turno_nro] [numeric](18, 0) NOT NULL,
        [turlle_afil_nro_consulta] [numeric](18, 0) NOT NULL,
        [turlle_bonocons_cod] [bigint] NOT NULL,
        [turlle_llegada_fecha] [datetime] NOT NULL,
        FOREIGN KEY([turlle_bonocons_cod]) REFERENCES [PROYECTO_W].[BonoConsulta] ([bonocons_cod]),
        FOREIGN KEY([turlle_turno_nro]) REFERENCES [PROYECTO_W].[Turno] ([turno_nro]),
        UNIQUE(turlle_turno_nro,turlle_bonocons_cod),
        PRIMARY KEY(turlle_turno_nro)
)
GO

CREATE TABLE [PROYECTO_W].[Receta]
(
        [receta_cod] [bigint] IDENTITY(1,1) NOT NULL,
        [receta_fecha_prescripcion] [datetime] NULL,  -- ???
        [receta_bonofarm_cod] [bigint] NOT NULL,
        --FOREIGN KEY([receta_bonofarm_cod]) REFERENCES [PROYECTO_W].[BonoFarmacia] ([bonofarm_cod]),
        PRIMARY KEY (receta_cod)
)
GO

CREATE TABLE [PROYECTO_W].[TurnoConcretado]
(
        [turconcr_sintomas] [varchar](255) NULL,
        [turconcr_diagnostico] [varchar](255) NULL,
        --[turconcr_fecha] [datetime] NOT NULL,
        [turconcr_turno_nro] [numeric](18, 0) NOT NULL,
        [turconcr_receta_cod] [bigint] NULL,
        FOREIGN KEY([turconcr_receta_cod]) REFERENCES [PROYECTO_W].[Receta] ([receta_cod]),
        FOREIGN KEY([turconcr_turno_nro]) REFERENCES [PROYECTO_W].[Turno] ([turno_nro]),
        PRIMARY KEY(turconcr_turno_nro)
)
GO

CREATE TABLE [PROYECTO_W].[BonoPorReceta]
(
        [bonoxreceta_receta_cod] [bigint] NOT NULL,
        [bonoxreceta_bonofarm_cod] [bigint] NOT NULL,
        FOREIGN KEY([bonoxreceta_bonofarm_cod]) REFERENCES [PROYECTO_W].[BonoFarmacia] ([bonofarm_cod]), 
        FOREIGN KEY([bonoxreceta_receta_cod]) REFERENCES [PROYECTO_W].[Receta] ([receta_cod]),
        PRIMARY KEY(bonoxreceta_receta_cod, bonoxreceta_bonofarm_cod)
)
GO

CREATE TABLE [PROYECTO_W].[TipoCancelacion]
(
        [tipocanc_cod] [tinyint] IDENTITY(1,1) NOT NULL,
        [tipocanc_descripcion] [varchar](255) NOT NULL,
        UNIQUE (tipocanc_descripcion),
        PRIMARY KEY (tipocanc_cod)
)
GO

CREATE TABLE [PROYECTO_W].[TurnoCancelacion]
(
        [turcan_fecha] [datetime] NOT NULL,
        [turcan_turno_nro] [numeric](18, 0) NOT NULL,
        [turcan_tipocanc_cod] [tinyint] NOT NULL,
        [turcan_motivo] [varchar](255) NULL,
        FOREIGN KEY([turcan_tipocanc_cod]) REFERENCES [PROYECTO_W].[TipoCancelacion] ([tipocanc_cod]),
        FOREIGN KEY([turcan_turno_nro]) REFERENCES [PROYECTO_W].[Turno] ([turno_nro]),
        PRIMARY KEY(turcan_turno_nro)
)
GO

CREATE TABLE [PROYECTO_W].[FechaConfig]
(
		[fechaconfig] [datetime] NOT NULL
)
GO

--###################################INSERT-FECHA-CONFIG(DESPUES SACAR)###########################
--INSERT INTO PROYECTO_W.FechaConfig (fechaconfig) VALUES ('2014-01-01 00:00:00.00')
--GO

--###################################CARGAR-FECHA-CONFIG##########################################
CREATE PROCEDURE PROYECTO_W.SP_CARGAR_FECHA
@FECHA_CARG DATETIME
AS
BEGIN
	IF ((SELECT COUNT(*) FROM PROYECTO_W.FechaConfig) > 0)
	BEGIN
		DELETE PROYECTO_W.FechaConfig
		INSERT INTO PROYECTO_W.FechaConfig (fechaconfig) VALUES (@FECHA_CARG)
	END
	ELSE
	BEGIN
		INSERT INTO PROYECTO_W.FechaConfig (fechaconfig) VALUES (@FECHA_CARG)
	END
END
GO
		

--###################################FUNCION-FECHA-CONFIG#########################################
CREATE FUNCTION [PROYECTO_W].[F_FECHA_CONFIG]()
RETURNS DATETIME
AS
BEGIN
	DECLARE @FECHA_CONFIG DATETIME
	SET @FECHA_CONFIG = (SELECT TOP 1 fechaconfig FROM [PROYECTO_W].[FechaConfig])
	RETURN @FECHA_CONFIG
END
GO


--###################################MIGRACION####################################################

USE GD2C2013
GO

-- MIGRACION PLAN MEDICO
INSERT INTO [PROYECTO_W].[Plan] (plan_cod, plan_descripcion, plan_precio_bono_consulta, plan_precio_bono_farmacia)
SELECT DISTINCT Plan_Med_Codigo, Plan_Med_Descripcion, Plan_Med_Precio_Bono_Consulta, Plan_Med_Precio_Bono_Farmacia
FROM gd_esquema.Maestra
GO

-- AUX afiliado aux Aux
CREATE TABLE #AuxAfiliado
(
        [afil_nombre] [varchar](255) NOT NULL,
        [afil_apellido] [varchar](255) NOT NULL,
        [afil_doc_tipo] [varchar](3) NOT NULL DEFAULT 'DNI',
        [afil_doc_nro] [numeric](18, 0) NOT NULL,
        [afil_direccion] [varchar](255) NOT NULL,
        [afil_telefono] [numeric](18, 0) NOT NULL,
        [afil_fecha_nac] [datetime] NOT NULL,
        [afil_sexo] [char](1) NULL,
        [afil_username] [varchar](255) NULL,
        [afil_nro] [bigint] IDENTITY(10000001,100) NOT NULL,
        [afil_plan_cod] [numeric](18, 0) NOT NULL,
        [afil_estado] [char](1) NOT NULL DEFAULT 'H',
        [afil_cant_pers_a_cargo] [tinyint] NOT NULL DEFAULT 0,
        [afil_nro_consultas] [numeric](18, 0) NOT NULL DEFAULT 0,
        [afil_estado_civil] [varchar](2) NULL,
        [afil_fecha_baja] [datetime] NULL,
        [afil_mail] [varchar](255) NOT NULL,
--        FOREIGN KEY([afil_plan_cod]) REFERENCES [PROYECTO_W].[Plan] ([plan_cod]),
--        FOREIGN KEY([afil_username]) REFERENCES [PROYECTO_W].[Usuario] ([usu_username]) ON UPDATE CASCADE,
        PRIMARY KEY (afil_nro)
)
GO

-- MIGRACION AFILIADO
INSERT INTO #AuxAfiliado(afil_nombre,afil_apellido,afil_doc_nro,afil_direccion,afil_telefono,afil_fecha_nac,afil_plan_cod,afil_nro_consultas,afil_mail)
SELECT Paciente_Nombre, Paciente_Apellido, Paciente_Dni, Paciente_Direccion, Paciente_Telefono, Paciente_Fecha_Nac, Plan_Med_Codigo, COUNT(*) AS Total_Consultas, Paciente_Mail
FROM gd_esquema.Maestra
WHERE Turno_Numero IS NOT NULL AND Bono_Consulta_Numero IS NOT NULL
GROUP BY Paciente_Nombre, Paciente_Apellido, Paciente_Dni, Paciente_Direccion, Paciente_Telefono, Paciente_Fecha_Nac, Plan_Med_Codigo, Paciente_Mail
GO

INSERT INTO [PROYECTO_W].[Afiliado] 
SELECT * FROM #AuxAfiliado
GO

DROP TABLE #AuxAfiliado
GO

-- MIGRACION PROFESIONALES
INSERT INTO PROYECTO_W.Profesional (prof_nombre,prof_apellido,prof_doc_nro, prof_direccion,prof_telefono,prof_mail,prof_fecha_nac)
SELECT DISTINCT Medico_Nombre, Medico_Apellido, Medico_Dni, Medico_Direccion, Medico_Telefono, Medico_Mail, Medico_Fecha_Nac
FROM gd_esquema.Maestra
WHERE Medico_Dni IS NOT NULL
GO


-- MIGRACION TIPO ESPECIALIDAD
INSERT INTO PROYECTO_W.TipoEspecialidad
SELECT DISTINCT Tipo_Especialidad_Codigo, Tipo_Especialidad_Descripcion
FROM gd_esquema.Maestra
WHERE Tipo_Especialidad_Codigo IS NOT NULL
GO

-- MIGRACION ESPECIALIDAD
INSERT INTO PROYECTO_W.Especialidad
SELECT DISTINCT Especialidad_Codigo, Especialidad_Descripcion, Tipo_Especialidad_Codigo
FROM gd_esquema.Maestra
WHERE Especialidad_Codigo IS NOT NULL
GO

-- MIGRACION AGENDA
INSERT INTO PROYECTO_W.AgendaProfesional
SELECT prof_cod
FROM PROYECTO_W.Profesional
GO

-- MIGRACION FECHA 
/*
INSERT INTO PROYECTO_W.Fecha (fecha_agen_cod, fecha_fecha)
SELECT DISTINCT agen_cod, CAST(Turno_Fecha AS DATE) AS Dia
FROM gd_esquema.Maestra, PROYECTO_W.Profesional, PROYECTO_W.AgendaProfesional
WHERE prof_doc_nro = Medico_Dni AND prof_cod = agen_prof_cod AND Bono_Consulta_Numero IS NULL AND Turno_Numero IS NOT NULL
GO
*/

--#########################No se migra porque se asume que la fecha config es despues del 01-01-2014#########
-- MIGRACION RANGOHORARIO
--DECLARE @FECHA_ACTUAL DATETIME = '2014-01-01 00:00:00.00'	-- fecha , esa que saldria de config
--INSERT INTO PROYECTO_W.RangoHorario (hora_agen_cod, hora_fecha, hora_inicio, hora_fin)
--SELECT agen_cod, CAST(Turno_Fecha AS DATE) AS Dia, MIN(Turno_Fecha) AS Primer_Consulta, MAX(Turno_Fecha) AS Ultima_Consulta
--FROM gd_esquema.Maestra, PROYECTO_W.AgendaProfesional, PROYECTO_W.Profesional
--WHERE Medico_Dni = prof_doc_nro AND agen_prof_cod = prof_cod AND Bono_Consulta_Numero IS NULL AND Turno_Numero IS NOT NULL AND Turno_Fecha > @FECHA_ACTUAL
--GROUP BY agen_cod, CAST(Turno_Fecha AS DATE)
--GO


-- Creacion de tabla auxiliar para los turnos
CREATE TABLE #AuxTurnos
(
		[auxturno_nro] [numeric](18, 0) NOT NULL,
        [auxturno_afil_nro] [bigint] NOT NULL,
        [auxturno_estado] [char](1) NOT NULL DEFAULT 'P', --Pedido,Registrado,Contretado.. aca es Pedido, A AUSENTE
        [auxturno_fecha] [datetime] NOT NULL,
        [auxturno_prof_cod] [bigint] NOT NULL,
        [auxturno_esp_cod] [numeric](18, 0) NOT NULL,
        [auxturno_agen_cod] [bigint] NOT NULL
)
GO

-- Migracion a la tabla auxiliar
INSERT INTO #AuxTurnos(auxturno_nro, auxturno_afil_nro, auxturno_fecha, auxturno_prof_cod, auxturno_esp_cod, auxturno_agen_cod) 
SELECT DISTINCT MAE.Turno_Numero, AFI.afil_nro, MAE.Turno_Fecha, PRO.prof_cod, MAE.Especialidad_Codigo, AGEN.agen_cod
FROM gd_esquema.Maestra AS MAE
JOIN PROYECTO_W.Afiliado AS AFI ON MAE.Paciente_Dni = AFI.afil_doc_nro
JOIN PROYECTO_W.Profesional AS PRO ON MAE.Medico_Dni = PRO.prof_doc_nro
JOIN PROYECTO_W.AgendaProfesional AS AGEN ON AGEN.agen_prof_cod = PRO.prof_cod
WHERE MAE.Turno_Numero IS NOT NULL
GO


-- MIGRACION TURNOS
INSERT INTO [PROYECTO_W].[Turno] (turno_afil_nro, turno_fecha, turno_prof_cod,turno_esp_cod, turno_agen_cod)
SELECT auxturno_afil_nro, auxturno_fecha, auxturno_prof_cod, auxturno_esp_cod, auxturno_agen_cod
FROM #AuxTurnos
ORDER BY auxturno_nro
GO

DROP TABLE #AuxTurnos
GO
--INSERT INTO [PROYECTO_W].[Turno] (turno_nro, turno_afil_nro, turno_fecha, turno_prof_cod,turno_esp_cod, turno_agen_cod) 
--SELECT DISTINCT MAE.Turno_Numero, AFI.afil_nro, MAE.Turno_Fecha, PRO.prof_cod, MAE.Especialidad_Codigo, AGEN.agen_cod
--FROM gd_esquema.Maestra AS MAE
--JOIN PROYECTO_W.Afiliado AS AFI ON MAE.Paciente_Dni = AFI.afil_doc_nro
--JOIN PROYECTO_W.Profesional AS PRO ON MAE.Medico_Dni = PRO.prof_doc_nro
--JOIN PROYECTO_W.AgendaProfesional AS AGEN ON AGEN.agen_prof_cod = PRO.prof_cod
--WHERE MAE.Turno_Numero IS NOT NULL
--GO -- PEDIDOS ES EL ESTADO POR DEFAULT

--DECLARE @FECHA_ACTUAL DATETIME = '2014-01-01 00:00:00.00'	-- fecha , esa que saldria de config
--UPDATE [PROYECTO_W].[Turno] SET turno_estado='N'			-- Turnos antes de la fecha que no fueron atendidos (No se presento)
--WHERE Turno_Fecha <= @FECHA_ACTUAL AND turno_nro NOT IN
--(
--SELECT Turno_Numero
--FROM gd_esquema.Maestra
--WHERE Turno_Numero IS NOT NULL AND Bono_Consulta_Numero IS NOT NULL
--)

UPDATE TUR SET turno_estado='N' -- Turno que no fueron atendidos (No atendidos)
FROM [PROYECTO_W].[Turno] AS TUR
WHERE NOT EXISTS
(
SELECT turno_nro
FROM gd_esquema.Maestra as MAE
WHERE MAE.Turno_Numero = TUR.turno_nro AND MAE.Bono_Consulta_Numero IS NOT NULL
)

UPDATE TUR SET turno_estado='A' -- Turno concretado (Atendido)
FROM [PROYECTO_W].[Turno] AS TUR
WHERE EXISTS
(
SELECT turno_nro
FROM gd_esquema.Maestra as MAE
WHERE MAE.Turno_Numero = TUR.turno_nro AND MAE.Bono_Consulta_Numero IS NOT NULL
)
GO

-- MIGRACION BONO ADQUIRIDO
-- No falta la suma pagada (consultar con los precios del plan)
INSERT INTO 
PROYECTO_W.BonoAdquirido 
        (bonadq_afil_nro, bonadq_tipo_bono, bonadq_fecha_compra, bonadq_fecha_impresion,bonadq_cantidad_comprada, bonadq_plan_cod, bonadq_afil_doc_nro)
SELECT  AFIL.afil_nro AS Afil_Cod, 'Consulta' AS Tipo_Bono, Compra_Bono_Fecha, Bono_Consulta_Fecha_Impresion AS Fecha_Impresion, 
        COUNT (*) AS Cant_Comprada, Plan_Med_Codigo, Paciente_Dni
FROM gd_esquema.Maestra A
JOIN PROYECTO_W.Afiliado AS AFIL ON A.Paciente_Dni = AFIL.afil_doc_nro
WHERE Compra_Bono_Fecha IS NOT NULL AND Bono_Consulta_Numero IS NOT NULL
GROUP BY AFIL.afil_nro, Compra_Bono_Fecha, Bono_Consulta_Fecha_Impresion, Plan_Med_Codigo, A.Paciente_Dni
UNION 
SELECT AFIL.afil_nro AS Afil_Cod, 'Farmacia' AS Tipo_Bono, Compra_Bono_Fecha, Bono_Farmacia_Fecha_Impresion AS Fecha_Impresion, 
        COUNT (*) AS Cant_Comprada, Plan_Med_Codigo, Paciente_Dni
FROM gd_esquema.Maestra A
JOIN PROYECTO_W.Afiliado AS AFIL ON A.Paciente_Dni = AFIL.afil_doc_nro
WHERE Compra_Bono_Fecha IS NOT NULL AND Bono_Farmacia_Numero IS NOT NULL
GROUP BY AFIL.afil_nro, Compra_Bono_Fecha, Bono_Farmacia_Fecha_Impresion, Plan_Med_Codigo, A.Paciente_Dni
GO

-- Suma pagada Bono Adquirido Consulta
UPDATE BA SET BA.bonadq_suma_pagada = BA.bonadq_cantidad_comprada * PL.plan_precio_bono_consulta
FROM PROYECTO_W.BonoAdquirido AS BA
JOIN [GD2C2013].[PROYECTO_W].[Plan] AS PL
ON BA.bonadq_plan_cod = PL.plan_cod
WHERE BA.bonadq_tipo_bono = 'Consulta'
GO
-- Suma pagada Bono Adquirido Farmacia
UPDATE BA SET BA.bonadq_suma_pagada = BA.bonadq_cantidad_comprada * PL.plan_precio_bono_farmacia
FROM PROYECTO_W.BonoAdquirido AS BA
JOIN [GD2C2013].[PROYECTO_W].[Plan] AS PL
ON BA.bonadq_plan_cod = PL.plan_cod
WHERE BA.bonadq_tipo_bono = 'Farmacia'
GO


-- ##################################################################################
-- TABLA AUXILIAR BONOCONSULTA
CREATE TABLE [PROYECTO_W].[#Bono_Consulta_Aux] (
bonoconsaux_cod bigint not null,
bonoconsaux_estado char(1) not null )
GO

-- MIGRACION BONO CONSULTA
-- Falta nro de bono adquirido buscarlo por fecha en esa tabla
-- Bonos usados y no usados EL 46498 NUNCA LO UTILIZARON
-- Tabla AUX
INSERT INTO #Bono_Consulta_Aux (bonoconsaux_cod, bonoconsaux_estado)
SELECT A.Bono_Consulta_Numero, 'Estado' = 
        CASE
                WHEN EXISTS (SELECT B.Bono_Consulta_Numero
                                FROM gd_esquema.Maestra B
                                WHERE B.Bono_Consulta_Numero IS NOT NULL AND B.Turno_Numero IS NOT NULL AND A.Bono_Consulta_Numero = B.Bono_Consulta_Numero) -- Bono utilizado
            THEN 'U'
                ELSE 'S'
        END
FROM gd_esquema.Maestra A
WHERE Bono_Consulta_Numero IS NOT NULL AND Turno_Numero IS NULL  -- Bono Comprados
GO

-- INSERT EN LA TABLA

INSERT INTO PROYECTO_W.BonoConsulta (bonocons_bonadq_cod, bonocons_cod, bonocons_estado)
SELECT C.bonadq_cod, A.bonoconsaux_cod, A.bonoconsaux_estado
FROM PROYECTO_W.#Bono_Consulta_Aux A, gd_esquema.Maestra B, PROYECTO_W.BonoAdquirido C
WHERE A.bonoconsaux_cod = B.Bono_Consulta_Numero AND B.Turno_Numero IS NULL AND B.Bono_Consulta_Numero IS NOT NULL AND B.Paciente_Dni = C.bonadq_afil_doc_nro AND B.Compra_Bono_Fecha = C.bonadq_fecha_compra AND C.bonadq_tipo_bono = 'Consulta'-- Bono Comprado
GO

-- BORRAR LA TABLA AUX
DROP TABLE [PROYECTO_W].[#Bono_Consulta_Aux]
GO

-- ##################################################################################
-- TABLA AUXILIAR BONO FARMACIA
CREATE TABLE [PROYECTO_W].[#Bono_Farmacia_Aux] (
bonofarsaux_cod bigint not null,
bonofarsaux_estado char(1) not null,
bonofaraux_fecha_venc datetime not null )
GO

-- MIGRACION BONO FARMACIA
INSERT INTO #Bono_Farmacia_Aux (bonofarsaux_cod, bonofaraux_fecha_venc, bonofarsaux_estado)
SELECT A.Bono_Farmacia_Numero, Bono_Farmacia_Fecha_Vencimiento, 'U' AS Estado 
FROM gd_esquema.Maestra A
WHERE Bono_Farmacia_Numero IS NOT NULL AND Turno_Numero IS NULL  -- Bono Comprados
GO

-- INSERT TABLA ORIGINAL BONO FARMACIA
INSERT INTO PROYECTO_W.BonoFarmacia (bonofarm_bonadq_cod, bonofarm_cod, bonofarm_estado, bonofarm_fecha_venc)
SELECT C.bonadq_cod, A.bonofarsaux_cod, A.bonofarsaux_estado, bonofaraux_fecha_venc
FROM PROYECTO_W.#Bono_Farmacia_Aux A, gd_esquema.Maestra B, PROYECTO_W.BonoAdquirido C
WHERE A.bonofarsaux_cod = B.Bono_Farmacia_Numero AND B.Turno_Numero IS NULL AND B.Bono_Farmacia_Numero IS NOT NULL AND B.Paciente_Dni = C.bonadq_afil_doc_nro AND B.Compra_Bono_Fecha = C.bonadq_fecha_compra AND C.bonadq_tipo_bono = 'Farmacia'-- Bono Comprado
GO

-- BORRAR LA TABLA AUX
DROP TABLE [PROYECTO_W].[#Bono_Farmacia_Aux]
GO

--#########################################################
-- BORRAR CAMPO DNI DE BONO ADQUIRIDO
ALTER TABLE [PROYECTO_W].[BonoAdquirido] DROP COLUMN [bonadq_afil_doc_nro]
GO

-- INGRESO DE MEDICAMENTOS EN TABLA DE MEDICAMENTOS
INSERT INTO PROYECTO_W.Medicamento (medicamento_nombre)
SELECT DISTINCT Bono_Farmacia_Medicamento 
FROM gd_esquema.Maestra
WHERE Bono_Farmacia_Medicamento IS NOT NULL
GO

-- MIGRACION MEDICAMENTOS POR BONO FARMACIA
INSERT INTO PROYECTO_W.MedicamentoPorBonoFarmacia (medxbonofar_bonofarm_cod, medxbonofar_medicamento_nombre_cod, medxbonofar_medicamento_cantidad)
SELECT Bono_Farmacia_Numero, MED.medicamento_nombre_cod, 1 AS Cant_Med
FROM gd_esquema.Maestra AS MAE
RIGHT JOIN PROYECTO_W.Medicamento AS MED
ON MAE.Bono_Farmacia_Medicamento = MED.medicamento_nombre
WHERE Bono_Farmacia_Medicamento IS NOT NULL
GO

-- MIGRACION TABLA TURNO_LLEGADA
INSERT INTO PROYECTO_W.TurnoLlegada (turlle_turno_nro, turlle_afil_nro_consulta, turlle_bonocons_cod, turlle_llegada_fecha)
SELECT A.turno_nro, ROW_NUMBER() OVER(PARTITION BY A.turno_afil_nro ORDER BY A.turno_fecha) AS Nro_Consulta, B.Bono_Consulta_Numero AS Bono_Nro, A.turno_fecha
FROM PROYECTO_W.Turno A, gd_esquema.Maestra B
WHERE A.turno_estado = 'A' AND A.turno_nro = B.Turno_Numero AND B.Bono_Consulta_Numero IS NOT NULL
GO

-- MIGRACION RECETA
INSERT INTO PROYECTO_W.Receta (receta_bonofarm_cod, receta_fecha_prescripcion)
SELECT Bono_Farmacia_Numero, Bono_Farmacia_Fecha_Vencimiento
FROM gd_esquema.Maestra
WHERE Bono_Farmacia_Medicamento IS NOT NULL
GO

-- MIGRACION TABLA BONO POR RECETA
INSERT INTO PROYECTO_W.BonoPorReceta (bonoxreceta_bonofarm_cod, bonoxreceta_receta_cod)
SELECT receta_bonofarm_cod, receta_cod
FROM PROYECTO_W.Receta
GO

-- MIGRACION TURNO CONCRETADO
INSERT INTO PROYECTO_W.TurnoConcretado (turconcr_sintomas, turconcr_diagnostico, turconcr_turno_nro, turconcr_receta_cod)
SELECT Consulta_Sintomas, Consulta_Enfermedades, Turno_Numero, B.receta_cod
FROM gd_esquema.Maestra A, PROYECTO_W.Receta B
WHERE A.Bono_Farmacia_Medicamento IS NOT NULL AND A.Bono_Farmacia_Numero = B.receta_bonofarm_cod
ORDER BY Turno_Numero
GO

-- BORRAR COLUMNA BONO_FARM DE RECETA
ALTER TABLE [PROYECTO_W].[Receta] DROP COLUMN [receta_bonofarm_cod]
GO

-- MIGRACION ESPECIALIDAD POR PROFESIONAL
INSERT INTO PROYECTO_W.EspecialidadPorProfesional (espxprof_prof_cod, espxprof_esp_cod)
SELECT DISTINCT B.prof_cod, Especialidad_Codigo
FROM gd_esquema.Maestra A, PROYECTO_W.Profesional B
WHERE A.Turno_Numero IS NOT NULL AND A.Bono_Consulta_Numero IS NULL AND A.Medico_Dni = B.prof_doc_nro
GO

-- LO QUE HACE DESPUES DE MIGRAR
ALTER TABLE [PROYECTO_W].[TurnoConcretado]
ADD CONSTRAINT FK_TurnoConcretado_turconcr_receta_cod
FOREIGN KEY([turconcr_receta_cod]) REFERENCES [PROYECTO_W].[Receta] ([receta_cod])
GO

ALTER TABLE [PROYECTO_W].[BonoPorReceta]
ADD CONSTRAINT FK_BonoPorReceta_bonoxreceta_receta_cod
FOREIGN KEY([bonoxreceta_receta_cod]) REFERENCES [PROYECTO_W].[Receta] ([receta_cod])
GO


/*
SET IDENTITY_INSERT [PROYECTO_W].[Receta] ON
GO
*/

--#-#-# INSERT DE COSAS Y ESO
        -- INSERT DE FUNCIONALIDAD
INSERT INTO PROYECTO_W.Funcionalidad (func_nombre) VALUES ('ABM_LOGIN'),
('ABM_REGISTRO_USUA'), ('ABM_AFILIADO'), ('ABM_PROFESIONAL'), ('ABM_ESP_MED'),
('ABM_PLAN'), ('ABM_AGEN_PROF'), ('ABM_BONOS'), ('ABM_TURNO'), 
('ABM_REGISTRO_LLEGADA'), ('ABM_REG_ATENCION'), ('ABM_CANCELACION'), ('ABM_RECETA'),
('ABM_ESTADISTICO'), ('ABM_ROL');
GO
        -- INSERT DE ROL
INSERT INTO PROYECTO_W.Rol (rol_nombre) VALUES ('ADMINISTRADOR'),
('AFILIADO'), ('PROFESIONAL');
GO
        -- INSERT DE FUNCIONALIDAD POR ROL
INSERT INTO PROYECTO_W.FuncionalidadPorRol (funcxrol_rol_cod,funcxrol_func_cod)
SELECT R.rol_cod, F.func_cod
FROM PROYECTO_W.Funcionalidad AS F
CROSS JOIN PROYECTO_W.Rol AS R
ORDER BY R.rol_cod
GO
        -- FUNCIONALIDADES DEL ROL ADMINISTRADOR HABILITADO TODO
UPDATE FPR SET funcxrol_estado='H'
FROM PROYECTO_W.FuncionalidadPorRol AS FPR
JOIN PROYECTO_W.Rol AS ROL ON ROL.rol_cod = FPR.funcxrol_rol_cod
WHERE ROL.rol_nombre = 'ADMINISTRADOR'
GO
--			FUNCIONALIDADES DEL ROL AFILIADO
UPDATE FUNCXROL SET funcxrol_estado = 'H'
FROM PROYECTO_W.FuncionalidadPorRol AS FUNCXROL JOIN PROYECTO_W.Funcionalidad ON funcxrol_func_cod = func_cod
	JOIN PROYECTO_W.Rol ON rol_cod = funcxrol_rol_cod
WHERE func_nombre IN ('ABM_CANCELACION', 'ABM_BONOS', 'ABM_TURNO') AND rol_nombre = 'AFILIADO'
GO
--			FUNCIONALIDADES DEL ROL PROFESIONAL
UPDATE FUNCXROL SET funcxrol_estado = 'H'
FROM PROYECTO_W.FuncionalidadPorRol AS FUNCXROL JOIN PROYECTO_W.Funcionalidad ON funcxrol_func_cod = func_cod
	JOIN PROYECTO_W.Rol ON rol_cod = funcxrol_rol_cod
WHERE func_nombre IN ('ABM_CANCELACION', 'ABM_AGEN_PROF', 'ABM_RECETA', 'ABM_REG_ATENCION') AND rol_nombre = 'PROFESIONAL'
GO
        -- INSERT DE USUARIOS
INSERT INTO PROYECTO_W.Usuario (usu_username,usu_password) -- cant intentos cero por defaul, estado 'H' por default
VALUES ('admin','E6B87050BFCB8143FCB8DB0170A4DC9ED00D904DDD3E2A4AD1B1E8DC0FDC9BE7'),
('afil1', 'A0834A020958991CBAA15C6D8DB2F7337DEDDD6BA595CFC056F7C6A35CB7847C'),
('afil2', 'DEF7869D73C43D43DB77F02E31C09BDF214BAE23053E11FB36DEEB7998982DCB'),
('afil3', '8490F02746D495AE38F55EA732727BA854BAAAAC56DB6938183CDAD1C4768530'),
('prof1', '9BEB8428008FBA903A067A9CE23828F5C4196E74CABAF7131233BFEE3AA3A991'),
('prof2', 'DC7A2DB63253C482D862CD4BDFC81B960FBF54AA58EEE1F1C31A3E7CE5E00D38'),
('prof3', 'EB8E0BDEBABDBC1DF42E983AD027375F81C1667B6BDE12D46FC018C1D9F90369')
GO
        -- INSERT DE ROL ADMINISTRADOR PARA USER ADMIN
INSERT INTO PROYECTO_W.RolPorUsuario (rolxusu_rol_cod,rolxusu_username)
VALUES (1, 'admin'), (2, 'afil1'), (2, 'afil2'), (2, 'afil3'), (3, 'prof1'), (3, 'prof2'), (3, 'prof3'), (2, 'admin')
--SELECT ROL.rol_cod,USUA.usu_username
--FROM PROYECTO_W.Rol AS ROL, PROYECTO_W.Usuario AS USUA
--WHERE ROL.rol_nombre = 'ADMINISTRADOR' AND USUA.usu_username = 'admin'
GO

--######### UPDATE DE LOS USUARIOS AFILIADOS
UPDATE PROYECTO_W.Afiliado
SET afil_username = 'afil1'
WHERE afil_nro = 10000001

UPDATE PROYECTO_W.Afiliado
SET afil_username = 'afil2'
WHERE afil_nro = 10000101

UPDATE PROYECTO_W.Afiliado
SET afil_username = 'afil3'
WHERE afil_nro = 10000201
GO
--####### UPDATE DE LOS USUARIOS PROFESIONALES
UPDATE PROYECTO_W.Profesional
SET prof_username = 'prof1'
WHERE prof_cod = 1

UPDATE PROYECTO_W.Profesional
SET prof_username = 'prof2'
WHERE prof_cod = 2

UPDATE PROYECTO_W.Profesional
SET prof_username = 'prof3'
WHERE prof_cod = 3
GO

--#-#-# TRIGGERS
		-- MATRICULA DEBE SER NULL O UNICA; SINO NO SE INSERTA Y DA ERROR
CREATE TRIGGER TR_PROFESIONAL_MATRICULA
ON PROYECTO_W.Profesional
INSTEAD OF INSERT
AS
IF EXISTS 
(
SELECT * FROM inserted AS INS 
JOIN PROYECTO_W.Profesional AS PRO ON PRO.prof_matricula = INS.prof_matricula
WHERE INS.prof_matricula IS NOT NULL
)
BEGIN
RAISERROR('NO SE REALIZA INSERT CON MATRICULAS EXISTENTES',16,1)
END
ELSE
BEGIN
INSERT INTO PROYECTO_W.Profesional 
(prof_apellido,prof_direccion,prof_doc_nro,prof_doc_tipo,prof_estado,prof_fecha_nac,prof_mail
,prof_matricula,prof_nombre,prof_sexo,prof_telefono,prof_username)
SELECT prof_apellido,prof_direccion,prof_doc_nro,prof_doc_tipo,prof_estado,prof_fecha_nac,prof_mail
,prof_matricula,prof_nombre,prof_sexo,prof_telefono,prof_username FROM INSERTED
END
GO

		-- GENERA CODIGO DE BONO CONSULTA
CREATE TRIGGER TR_BONOCONS_COD
ON PROYECTO_W.BonoConsulta
INSTEAD OF INSERT 
AS
BEGIN
	INSERT INTO PROYECTO_W.BonoConsulta
	(bonocons_bonadq_cod,bonocons_cod,bonocons_estado)
	SELECT bonocons_bonadq_cod,
	(SELECT TOP 1 bonocons_cod FROM PROYECTO_W.BonoConsulta ORDER BY bonocons_cod DESC) + 1,
	bonocons_estado
	FROM INSERTED
END
GO

	-- GENERA BONOFARM_COD
CREATE TRIGGER TR_BONOFARM_COD
ON PROYECTO_W.BonoFarmacia
INSTEAD OF INSERT 
AS
BEGIN
INSERT INTO PROYECTO_W.BonoFarmacia
(bonofarm_bonadq_cod,bonofarm_cod,bonofarm_estado,bonofarm_fecha_venc)
SELECT bonofarm_bonadq_cod,
(SELECT TOP 1 bonofarm_cod FROM PROYECTO_W.BonoFarmacia ORDER BY bonofarm_cod DESC) + 1,
bonofarm_estado, bonofarm_fecha_venc
FROM INSERTED
END
GO

--#-#-#		FUNCIONES
CREATE FUNCTION PROYECTO_W.F_COMPRABONO_DATOS
(@AFIL_NRO BIGINT, @TIPO_BONO VARCHAR(255), @CANTIDAD BIGINT)
RETURNS TABLE
AS
RETURN
(SELECT TOP 1 BA.bonadq_suma_pagada, BA.bonadq_plan_cod, BA.bonadq_fecha_compra,BA.bonadq_cod,BA.bonadq_tipo_bono
FROM PROYECTO_W.BonoAdquirido AS BA
WHERE BA.bonadq_afil_nro = @AFIL_NRO AND BA.bonadq_tipo_bono = @TIPO_BONO AND BA.bonadq_cantidad_comprada=@CANTIDAD
	AND BA.bonadq_fecha_compra = (SELECT PROYECTO_W.F_FECHA_CONFIG())
ORDER BY BA.bonadq_cod DESC)
GO

CREATE FUNCTION PROYECTO_W.F_BONOS_FARMACIA_DISPONIBLES
(@TURNO_NRO NUMERIC(18,0))
RETURNS TABLE
AS
RETURN (
SELECT bonofarm_cod,bonadq_afil_nro,bonofarm_fecha_venc
FROM PROYECTO_W.Turno
JOIN PROYECTO_W.Afiliado ON turno_afil_nro = afil_nro
JOIN PROYECTO_W.BonoAdquirido ON afil_plan_cod = bonadq_plan_cod 
JOIN PROYECTO_W.BonoFarmacia ON bonadq_cod = bonofarm_bonadq_cod
WHERE (CAST(bonadq_afil_nro AS BIGINT)/100) = (CAST(afil_nro AS BIGINT)/100)
	AND bonofarm_fecha_venc >= (SELECT PROYECTO_W.F_FECHA_CONFIG())
	AND bonofarm_estado = 'S'
	AND turno_nro = @TURNO_NRO
)
GO


--#-#-#		STOCK PROCEDURES
	-- COMPRA BONO ADMIN
CREATE PROCEDURE [PROYECTO_W].[SP_COMPRABONOADMIN]
@afil_nro bigint, @tipo_bono varchar(255), @cantidad bigint
AS
IF (EXISTS (SELECT afil_nro FROM PROYECTO_W.Afiliado WHERE afil_estado = 'H' AND @afil_nro = afil_nro)
	AND (@tipo_bono = 'Farmacia' OR @tipo_bono = 'Consulta') AND @cantidad > 0)
BEGIN
	DECLARE @fechasys DATETIME
	SET @fechasys = (SELECT PROYECTO_W.F_FECHA_CONFIG())
	DECLARE @PLANCOD NUMERIC(18,0) =
	(
	SELECT PL.plan_cod 
	FROM [GD2C2013].[PROYECTO_W].[Plan] AS PL 
	JOIN PROYECTO_W.Afiliado AS AFIL ON (AFIL.afil_nro = @afil_nro AND AFIL.afil_plan_cod = PL.plan_cod)
	)

	DECLARE @PRECIO SMALLMONEY

	IF (@tipo_bono='Consulta')
	BEGIN
		SET @PRECIO = 
		(
		SELECT PL.plan_precio_bono_consulta 
		FROM [GD2C2013].[PROYECTO_W].[Plan] AS PL 
		JOIN PROYECTO_W.Afiliado AS AFIL ON (AFIL.afil_nro = @afil_nro AND AFIL.afil_plan_cod = PL.plan_cod))

		INSERT INTO PROYECTO_W.BonoAdquirido
		(bonadq_tipo_bono, bonadq_fecha_compra, bonadq_fecha_impresion, bonadq_cantidad_comprada,
		bonadq_afil_nro, bonadq_plan_cod, bonadq_suma_pagada)
		VALUES (@tipo_bono, @fechaSys, @fechaSys, @cantidad, @afil_nro, @PLANCOD, @cantidad*@PRECIO)

		WHILE (@cantidad > 0)
		BEGIN
			INSERT INTO PROYECTO_W.BonoConsulta
			(bonocons_bonadq_cod,bonocons_estado)
			VALUES
			((SELECT TOP 1 bonadq_cod FROM PROYECTO_W.BonoAdquirido ORDER BY bonadq_cod DESC), 'S')
			SET @cantidad = @cantidad - 1
		END
	END
	ELSE -- es farmacia tonce
	BEGIN
		SET @PRECIO = 
		(SELECT PL.plan_precio_bono_farmacia 
		FROM [GD2C2013].[PROYECTO_W].[Plan] AS PL 
		JOIN PROYECTO_W.Afiliado AS AFIL ON (AFIL.afil_nro = @afil_nro AND AFIL.afil_plan_cod = PL.plan_cod) )

		INSERT INTO PROYECTO_W.BonoAdquirido
		(bonadq_tipo_bono, bonadq_fecha_compra, bonadq_fecha_impresion, bonadq_cantidad_comprada,
		bonadq_afil_nro, bonadq_plan_cod, bonadq_suma_pagada)
		VALUES (@tipo_bono, @fechaSys, @fechaSys, @cantidad, @afil_nro, @PLANCOD, @cantidad*@PRECIO)

		WHILE (@cantidad > 0)
		BEGIN
			INSERT INTO PROYECTO_W.BonoFarmacia
			(bonofarm_bonadq_cod,bonofarm_estado,bonofarm_fecha_venc)
			VALUES
			((SELECT TOP 1 bonadq_cod FROM PROYECTO_W.BonoAdquirido ORDER BY bonadq_cod DESC), 'S', @fechaSys + 60)
			SET @cantidad -= 1
		END
	END
	--COMPRO EL BONO
END
ELSE
BEGIN
RAISERROR('NO PUEDE COMPRAR, AFILIADO DESHABILITADO O DATOS INVALIDOS',16,1) -- o no existe
-- NO PUEDE COMPRAR 
END
GO

/* INSERT DE TIPOS DE CANCELACION , ESTO IBA MAS ARRIBA*/
INSERT INTO PROYECTO_W.TipoCancelacion
(tipocanc_descripcion)
VALUES ('MEDICO'),('PACIENTE')
GO

--	CANCELACION DE ATENCION
		/*HAY QUE BORRAR TURNO_LLEGADA EN CASO REGISTRADO??*/
CREATE PROCEDURE PROYECTO_W.SP_CANCELAR --TODO REVISAR QUE PODRIA IR AFIL_NRO O ASI TAMBIEN TAL VEZ MEJOR, O NO
@TURNO_NRO NUMERIC(18,0), @QUIEN_CANCELA VARCHAR(255), @MOTIVO VARCHAR(255)
AS
BEGIN -- UN DIA ANTES, EXISTE EL TURNO
	DECLARE @FECHA DATETIME 
	SET @FECHA = (SELECT PROYECTO_W.F_FECHA_CONFIG())
	IF EXISTS(SELECT turno_nro FROM PROYECTO_W.Turno WHERE turno_nro = @TURNO_NRO
		AND turno_estado != 'A' and turno_estado != 'C')
	BEGIN
		IF ((DATEADD(DAY,-1,(SELECT turno_fecha FROM PROYECTO_W.Turno WHERE turno_nro = @TURNO_NRO))) >= @FECHA)
		BEGIN
			UPDATE PROYECTO_W.Turno SET turno_estado = 'C' WHERE turno_nro = @TURNO_NRO
			INSERT INTO PROYECTO_W.TurnoCancelacion
			(turcan_fecha,turcan_turno_nro,turcan_tipocanc_cod,turcan_motivo)
			VALUES
			(@FECHA,@TURNO_NRO,(SELECT tipocanc_cod FROM PROYECTO_W.TipoCancelacion WHERE tipocanc_descripcion = @QUIEN_CANCELA),
				@MOTIVO)
			IF EXISTS(SELECT * FROM PROYECTO_W.TurnoLlegada WHERE turlle_turno_nro = @TURNO_NRO)
			BEGIN
				UPDATE BC SET BC.bonocons_estado = 'S' 
				FROM PROYECTO_W.BonoConsulta AS BC
				JOIN PROYECTO_W.TurnoLlegada AS TL ON TL.turlle_turno_nro = @TURNO_NRO
				WHERE BC.bonocons_cod = TL.turlle_bonocons_cod
				-- no se si borrar el registro del bono que usaba y se le devolvio
				-- se lo dejo borrado por ahora
				DELETE FROM PROYECTO_W.TurnoLlegada
				WHERE turlle_turno_nro = @TURNO_NRO
				
				UPDATE PROYECTO_W.Afiliado SET afil_nro_consultas = afil_nro_consultas - 1
				
			END
		END ELSE RAISERROR('LAS CANCELACIONES SON CON UN DIA DE ANTELACION',16,1)
	END ELSE RAISERROR('NO EXISTE EL NUMERO DE TURNO',16,1)
END
GO

	-- PROCEDURE REGISTRAR_AGENDA
CREATE PROCEDURE PROYECTO_W.SP_REGISTRAR_AGENDA
@PROF_DNI NUMERIC(18,0), @DIA_CHECK INT, @DESDE DATE, @HASTA DATE,
	@HORA_INI TIME, @HORA_FIN TIME
AS 
BEGIN
BEGIN TRANSACTION -- SI DA UN ERROR EN ALGUN LUGAR, NO SE HACE NADA (CREO)
BEGIN TRY
	IF NOT EXISTS (	SELECT prof_cod
					FROM PROYECTO_W.Profesional 
					WHERE prof_doc_nro = @PROF_DNI AND prof_estado = 'H' )
	BEGIN
		RAISERROR('NO EXISTE O ESTA DADO DE BAJA',16,1)
		--ROLLBACK TRANSACTION
	END
	ELSE
		BEGIN
			IF NOT EXISTS (	SELECT agen_prof_cod 
							FROM PROYECTO_W.Profesional
							JOIN PROYECTO_W.AgendaProfesional ON prof_cod = agen_prof_cod	
							WHERE prof_doc_nro = @PROF_DNI )
			BEGIN
				INSERT INTO PROYECTO_W.AgendaProfesional (agen_prof_cod)
				SELECT prof_cod
				FROM PROYECTO_W.Profesional
				WHERE prof_doc_nro = @PROF_DNI
			END
			
			DECLARE @FECHA DATE
			SET @FECHA = @DESDE
			WHILE (DATEPART(DW,@FECHA) != @DIA_CHECK)
			SET @FECHA = DATEADD(DAY,1,@FECHA)
			
			DECLARE @FECHA_AGEN_COD BIGINT
			SET @FECHA_AGEN_COD = (	SELECT agen_cod 
									FROM PROYECTO_W.Profesional
									JOIN PROYECTO_W.AgendaProfesional
										ON agen_prof_cod = prof_cod
									WHERE prof_doc_nro = @PROF_DNI	)
			
			WHILE (@FECHA <= @HASTA)
			BEGIN  
				IF NOT EXISTS (	SELECT * 
								FROM PROYECTO_W.Fecha
								WHERE fecha_agen_cod = @FECHA_AGEN_COD
									AND fecha_fecha = @FECHA	)
				BEGIN -- SI YA ESTA LA FECHA NO HAGO EL INSERT
					INSERT INTO PROYECTO_W.Fecha (fecha_agen_cod,fecha_fecha)
					VALUES (@FECHA_AGEN_COD,@FECHA)
				END
				-- AHORA PARA UNA FECHA, TENGO QUE VER QUE LOS HORARIOS QUE METE NO SE SUPERPONGAN
				-- QUE META SEPARADO SI AGREGA UN RANGO HORARIO PA UNA MISMA FECHA PA UN MISMO CHABON
				IF NOT EXISTS (	SELECT * 
								FROM PROYECTO_W.RangoHorario 
								WHERE 
									(
										(hora_agen_cod = @FECHA_AGEN_COD
										AND hora_fecha = @FECHA)
										AND
										(
										(@HORA_INI > hora_inicio AND @HORA_INI < hora_fin)
										OR
										(@HORA_FIN > hora_inicio AND @HORA_FIN < hora_fin)
										OR
										(@HORA_INI = hora_inicio)
										OR
										(@HORA_FIN = hora_fin)
										OR
										(hora_inicio > @HORA_INI AND hora_fin < @HORA_FIN)
										
										)
									)
								)
				BEGIN
					INSERT INTO PROYECTO_W.RangoHorario 
					(hora_agen_cod,hora_fecha,hora_inicio,hora_fin)
					VALUES (@FECHA_AGEN_COD,@FECHA,@HORA_INI,@HORA_FIN)
				END
				ELSE
				BEGIN
					RAISERROR('RANGOS SUPERPUESTOS',16,1)
					--ROLLBACK TRANSACTION
				END
			SET @FECHA = DATEADD(DAY,7,@FECHA)
			END
		END
COMMIT TRANSACTION
END TRY
BEGIN CATCH
	ROLLBACK TRANSACTION
	RAISERROR('DATOS INVALIDOS',16,1)
END CATCH
END
GO	-- AGREGAR MERGE AUTOMATICO CUANDO HORA FIN VIEJA = HORA INI NUEVA EN MISMO DIA
-- AGREGAR ROLLBACK TRANSACTION, PERO BIEN 

CREATE PROCEDURE PROYECTO_W.SP_TURNO_CONCRETADO
(@TURNO_NRO NUMERIC(18,0), @SINTOMAS VARCHAR(255), @DIAGNOSTICO VARCHAR(255), @CONCRETADO INT)
AS
BEGIN
IF ((EXISTS (	SELECT * FROM PROYECTO_W.Turno 
				WHERE turno_nro=@TURNO_NRO AND turno_estado = 'P'))
		AND
		(EXISTS (SELECT * FROM PROYECTO_W.TurnoLlegada WHERE turlle_turno_nro = @TURNO_NRO))
	)
	BEGIN
		IF (@CONCRETADO = 0)
		BEGIN
			UPDATE PROYECTO_W.Turno SET turno_estado = 'N' 
			WHERE turno_nro = @TURNO_NRO
		END
		ELSE
		BEGIN
			INSERT INTO PROYECTO_W.TurnoConcretado
			(turconcr_sintomas,turconcr_diagnostico,turconcr_turno_nro)
			VALUES (@SINTOMAS,@DIAGNOSTICO,@TURNO_NRO)
			
			UPDATE PROYECTO_W.Turno SET turno_estado = 'A' 
			WHERE turno_nro = @TURNO_NRO
		END
	END
	ELSE
	BEGIN
		RAISERROR('Turno no disponible para registrar',16,1);
	END
END
GO

-- Vista para listado estadistico 4
CREATE VIEW PROYECTO_W.V_LISTADO_4
AS
-- Devuelve Bono (consulta y farmacia) que fueron utilizados pero no comprados por un usuario
SELECT AFIL.afil_nro, AFIL.afil_nombre, AFIL.afil_apellido, TURN.turno_fecha
FROM PROYECTO_W.TurnoLlegada AS TURNLLEG JOIN PROYECTO_W.Turno AS TURN ON TURNLLEG.turlle_turno_nro = TURN.turno_nro JOIN PROYECTO_W.Afiliado AS AFIL ON TURN.turno_afil_nro = AFIL.afil_nro JOIN PROYECTO_W.BonoConsulta AS BONOCONS ON TURNLLEG.turlle_bonocons_cod = BONOCONS.bonocons_cod JOIN PROYECTO_W.BonoAdquirido AS BONOADQ ON BONOCONS.bonocons_bonadq_cod = BONOADQ.bonadq_cod
WHERE BONOADQ.bonadq_afil_nro != TURN.turno_afil_nro
UNION
SELECT AFIL.afil_nro, AFIL.afil_nombre, AFIL.afil_apellido, TURN.turno_fecha
FROM PROYECTO_W.TurnoConcretado AS TURNCON JOIN PROYECTO_W.Turno AS TURN ON TURNCON.turconcr_turno_nro = TURN.turno_nro JOIN PROYECTO_W.Afiliado AS AFIL ON TURN.turno_afil_nro = AFIL.afil_nro JOIN PROYECTO_W.BonoPorReceta AS BONOXREC ON TURNCON.turconcr_receta_cod = BONOXREC.bonoxreceta_receta_cod JOIN PROYECTO_W.BonoFarmacia AS BONOFARM ON BONOXREC.bonoxreceta_bonofarm_cod = BONOFARM.bonofarm_cod JOIN PROYECTO_W.BonoAdquirido AS BONOADQ ON BONOFARM.bonofarm_bonadq_cod = BONOADQ.bonadq_cod
WHERE BONOADQ.bonadq_afil_nro != TURN.turno_afil_nro

-- HABRIA QUE PONER RESTRICCIONES, QUE UN ADMIN NO SE PUEDA ASIGNAR A USUARIOS AFILIADOS Y PROFESIONALES
-- QUE UN USERNAME NO PUEDA SER DE USUARIO Y PROF DISTINTOS A LA VEZ,, ETC
