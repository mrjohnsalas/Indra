--PORTAFOLIO
INSERT INTO Portafolios (NumDocument, Presupuesto, StarDate, FinalDate, CategoriaComponenteId, PrioridadId, EstadoId, ResponsableId, UserId, CreateDate, EditDate, TipoDuracionId, Duracion, Name, Description) VALUES ('PO-2018-08-00001',	0,	'2018-08-01', '2018-09-14', 3, 3, 1, 2, 'admin@indra.com', '2018-08-01', '2018-08-01', 1, 44, 'Portafolio de desarrollo de software #01', 'Un portafolio es un conjunto de programas y proyectos relacionados de una manera coordinada para obtener beneficios y control, no disponible cuando se gestiona de manera individual. La gestión de portafolios permite agrupar programas y proyectos alrededor de objetivos comunes y realizar una planiﬁcación y un seguimiento.')
GO
--PROGRAMA
INSERT INTO Programas (NumDocument, Presupuesto, StarDate, FinalDate, PrioridadId, EstadoId, ResponsableId, UserId, CreateDate, EditDate, TipoDuracionId, Duracion, PortafolioId, Name, Description) VALUES ('PR-2018-09-00001', 23600, '2018-08-01', '2018-09-11', 3, 1, 4, 'admin@indra.com', '2018-08-01', '2018-08-01', 1, 27, 1, 'Programa de desarrollo de software #01', 'Un programa es un conjunto de proyectos relacionados de una manera coordinada para obtener beneficios y control, no disponible cuando se gestiona de manera individual. La gestión de programas permite agrupar proyectos alrededor de objetivos comunes y realizar una planiﬁcación y un seguimiento.')
GO
--PROYECTO
--PENDIENTE - 1
INSERT INTO Proyectos (NumDocument, Presupuesto, StarDate, FinalDate, EstadoAprobacionId, PrioridadId, EstadoId, ClienteId, TipoProyectoId, ResponsableId, PatrocinadorId, UserId, CreateDate, EditDate, TipoDuracionId, Duracion, PortafolioId, ProgramaId, [Name], [Description]) VALUES ('PY-2018-08-00001', 8500, '2018-08-27', '2018-09-11', 2, 1, 1, 1, 1, 1, 1, 'admin@indra.com', '2018-08-27', '2018-08-27', 1, 15, NULL, 1, 'Software para el diseño de redes de ordenadores', 'El diseño asistido por ordenador, más conocido como CAD (computer-aided design), es el uso de un amplio rango de herramientas computacionales que asisten a ingenieros, arquitectos y a otros profesionales del diseño en sus respectivas actividades. En este proyecto se creara una pequeña herramienta CAD que permita diseñar redes de ordenadores basicas de diferentes clases (e.g., Ethernet, FDDI). El software permitira crear redes virtuales utilizando iconos descriptivos que representen diferentes ordenadores, tarjetas de red, cables y routers, entre otros. Esta herramienta asistira a estudiantes de otras titulaciones a la hora de comprender los conceptos basicos del diseño de redes de una forma amigable.')
--TERMINADO - 2
INSERT INTO Proyectos (NumDocument, Presupuesto, StarDate, FinalDate, EstadoAprobacionId, PrioridadId, EstadoId, ClienteId, TipoProyectoId, ResponsableId, PatrocinadorId, UserId, CreateDate, EditDate, TipoDuracionId, Duracion, PortafolioId, ProgramaId, [Name], [Description]) VALUES ('PY-2018-08-00002', 5675, '2018-08-01', '2018-08-16', 2, 2, 2, 2, 2, 2, 2, 'admin@indra.com',	'2018-08-01', '2018-08-01',	1, 15, NULL, 1, 'Herramienta interactiva de visualización de datos para la Web', 'Se propone el desarrollo de una herramienta interactiva de visualización de datos que haga uso de las facilidades ofrecidas por HTML5, sin recurrir al uso de plug-ins externos (Flash, Java). NOTA: En http://www.chromeexperiments.com se pueden ver algunos ejemplos de lo que se puede conseguir utilizando exclusivamente HTML, CSS y JavaScript.')
--TERMINADO - 3
INSERT INTO Proyectos (NumDocument, Presupuesto, StarDate, FinalDate, EstadoAprobacionId, PrioridadId, EstadoId, ClienteId, TipoProyectoId, ResponsableId, PatrocinadorId, UserId, CreateDate, EditDate, TipoDuracionId, Duracion, PortafolioId, ProgramaId, [Name], [Description]) VALUES ('PY-2018-08-00003', 9425, '2018-08-05', '2018-08-30', 2, 2, 2, 3, 3, 3, 3, 'admin@indra.com',	'2018-08-05', '2018-08-05',	1, 25, NULL, 1, 'Herramienta de diseño 3D', 'Se propone el desarrollo de una herramienta diseño 3D que haga uso de las facilidades ofrecidas por HTML5, sin recurrir al uso de plug-ins externos (Flash, Java). NOTA: En http://www.chromeexperiments.com se pueden ver algunos ejemplos de lo que se puede conseguir utilizando exclusivamente HTML, CSS y JavaScript.')
--PENDIENTE - 4
INSERT INTO Proyectos (NumDocument, Presupuesto, StarDate, FinalDate, EstadoAprobacionId, PrioridadId, EstadoId, ClienteId, TipoProyectoId, ResponsableId, PatrocinadorId, UserId, CreateDate, EditDate, TipoDuracionId, Duracion, PortafolioId, ProgramaId, [Name], [Description]) VALUES ('PY-2018-08-00004', 7000, '2018-08-15', '2018-09-02', 2, 3, 1, 1, 2, 1, 1, 'admin@indra.com', '2018-08-15', '2018-08-15',	1, 18, NULL, NULL, 'Software de ges. Almacen', 'Se propone el desarrollo de una herramienta interactiva de visualización de datos que haga uso de las facilidades ofrecidas por HTML5, sin recurrir al uso de plug-ins externos (Flash, Java). NOTA: En http://www.chromeexperiments.com se pueden ver algunos ejemplos de lo que se puede conseguir utilizando exclusivamente HTML, CSS y JavaScript.')
--PENDIENTE - 5
INSERT INTO Proyectos (NumDocument, Presupuesto, StarDate, FinalDate, EstadoAprobacionId, PrioridadId, EstadoId, ClienteId, TipoProyectoId, ResponsableId, PatrocinadorId, UserId, CreateDate, EditDate, TipoDuracionId, Duracion, PortafolioId, ProgramaId, [Name], [Description]) VALUES ('PY-2018-08-00005', 30000, '2018-08-04', '2018-09-14', 2, 3, 1, 4, 4, 22, 4, 'admin@indra.com', '2018-08-04', '2018-08-04', 1, 41, 1, NULL, 'Diseño y desarrollo de un servidor web de juegos de táctica', 'Se pretende desarrollar un servidor web que gestione partidas de un determinado juego de táctica. El servidor podrá ser utilizado tanto por jugadores humanos como por jugadores automáticos programados en Python. Debe de gestionar tanto las partidas, como los jugadores, como los terrenos de juego, de forma que sea capaz de devolver estadísticas tales como clasificación, porcentaje de victorias, etc. En el desarrollo se emplearán los lenguajes de programación Java y Python y se almacenará y recuperará información en una base de datos MySQL.')
--TERMINADO - 6
INSERT INTO Proyectos (NumDocument, Presupuesto, StarDate, FinalDate, EstadoAprobacionId, PrioridadId, EstadoId, ClienteId, TipoProyectoId, ResponsableId, PatrocinadorId, UserId, CreateDate, EditDate, TipoDuracionId, Duracion, PortafolioId, ProgramaId, [Name], [Description]) VALUES ('PY-2018-08-00006', 5650, '2018-08-06', '2018-08-21', 2, 1, 2, 2, 3, 20, 20, 'admin@indra.com', '2018-08-06', '2018-08-06', 1, 15, 1, NULL, 'Diseño y desarrollo de un Tutor Inteligente', 'Se pretende desarrollar un sistema de e-learning que incorpore un tutor inteligente que adapte el material docente a las necesidades individuales del alumno.')
GO
--TAREAS
--PROYECTO - 1
INSERT INTO Tareas (Name, [Index], TipoDuracionId, Duracion, StarDate, FinalDate, EstadoId, ResponsableId, ProyectoId) VALUES ('Investigación', 1, 1, 1, '2018-08-27', '2018-08-28', 2, 2, 1)
INSERT INTO Tareas (Name, [Index], TipoDuracionId, Duracion, StarDate, FinalDate, EstadoId, ResponsableId, ProyectoId) VALUES ('Análisis'     , 2, 1, 2, '2018-08-28', '2018-08-30', 2, 3, 1)
INSERT INTO Tareas (Name, [Index], TipoDuracionId, Duracion, StarDate, FinalDate, EstadoId, ResponsableId, ProyectoId) VALUES ('Desarrollo'   , 3, 1, 3, '2018-08-30', '2018-09-02', 3, 4, 1)
INSERT INTO Tareas (Name, [Index], TipoDuracionId, Duracion, StarDate, FinalDate, EstadoId, ResponsableId, ProyectoId) VALUES ('Pruebas'      , 4, 1, 4, '2018-09-02', '2018-09-06', 3, 5, 1)
INSERT INTO Tareas (Name, [Index], TipoDuracionId, Duracion, StarDate, FinalDate, EstadoId, ResponsableId, ProyectoId) VALUES ('Demo'         , 5, 1, 5, '2018-09-06', '2018-09-11', 3, 5, 1)
--PROYECTO - 2
INSERT INTO Tareas (Name, [Index], TipoDuracionId, Duracion, StarDate, FinalDate, EstadoId, ResponsableId, ProyectoId) VALUES ('Investigación',	1, 1, 5, '2018-08-01', '2018-08-06', 2, 1, 2)
INSERT INTO Tareas (Name, [Index], TipoDuracionId, Duracion, StarDate, FinalDate, EstadoId, ResponsableId, ProyectoId) VALUES ('Análisis'     ,	2, 1, 4, '2018-08-06', '2018-08-10', 2, 3, 2)
INSERT INTO Tareas (Name, [Index], TipoDuracionId, Duracion, StarDate, FinalDate, EstadoId, ResponsableId, ProyectoId) VALUES ('Desarrollo'   ,	3, 1, 3, '2018-08-10', '2018-08-13', 2, 4, 2)
INSERT INTO Tareas (Name, [Index], TipoDuracionId, Duracion, StarDate, FinalDate, EstadoId, ResponsableId, ProyectoId) VALUES ('Pruebas'      ,	4, 1, 2, '2018-08-13', '2018-08-15', 2, 5, 2)
INSERT INTO Tareas (Name, [Index], TipoDuracionId, Duracion, StarDate, FinalDate, EstadoId, ResponsableId, ProyectoId) VALUES ('Demo'         ,	5, 1, 1, '2018-08-15', '2018-08-16', 2, 6, 2)
--PROYECTO - 3
INSERT INTO Tareas (Name, [Index], TipoDuracionId, Duracion, StarDate, FinalDate, EstadoId, ResponsableId, ProyectoId) VALUES ('Investigación',	1, 1, 3, '2018-08-05', '2018-08-08', 2, 1, 3)
INSERT INTO Tareas (Name, [Index], TipoDuracionId, Duracion, StarDate, FinalDate, EstadoId, ResponsableId, ProyectoId) VALUES ('Análisis'     ,	2, 1, 4, '2018-08-08', '2018-08-12', 2, 2, 3)
INSERT INTO Tareas (Name, [Index], TipoDuracionId, Duracion, StarDate, FinalDate, EstadoId, ResponsableId, ProyectoId) VALUES ('Desarrollo'   ,	3, 1, 5, '2018-08-12', '2018-08-17', 2, 4, 3)
INSERT INTO Tareas (Name, [Index], TipoDuracionId, Duracion, StarDate, FinalDate, EstadoId, ResponsableId, ProyectoId) VALUES ('Pruebas'      ,	4, 1, 6, '2018-08-17', '2018-08-23', 2, 5, 3)
INSERT INTO Tareas (Name, [Index], TipoDuracionId, Duracion, StarDate, FinalDate, EstadoId, ResponsableId, ProyectoId) VALUES ('Demo'         ,	5, 1, 7, '2018-08-23', '2018-08-30', 2, 6, 3)
--PROYECTO - 4
INSERT INTO Tareas (Name, [Index], TipoDuracionId, Duracion, StarDate, FinalDate, EstadoId, ResponsableId, ProyectoId) VALUES ('Investigación', 1, 1, 1, '2018-08-15', '2018-08-16', 2, 2, 4)
INSERT INTO Tareas (Name, [Index], TipoDuracionId, Duracion, StarDate, FinalDate, EstadoId, ResponsableId, ProyectoId) VALUES ('Análisis'     , 2, 1, 3, '2018-08-16', '2018-08-19', 2, 3, 4)
INSERT INTO Tareas (Name, [Index], TipoDuracionId, Duracion, StarDate, FinalDate, EstadoId, ResponsableId, ProyectoId) VALUES ('Desarrollo'   , 3, 1, 4, '2018-08-19', '2018-08-23', 3, 4, 4)
INSERT INTO Tareas (Name, [Index], TipoDuracionId, Duracion, StarDate, FinalDate, EstadoId, ResponsableId, ProyectoId) VALUES ('Pruebas'      , 4, 1, 8, '2018-08-23', '2018-08-31', 3, 5, 4)
INSERT INTO Tareas (Name, [Index], TipoDuracionId, Duracion, StarDate, FinalDate, EstadoId, ResponsableId, ProyectoId) VALUES ('Demo'         , 5, 1, 2, '2018-08-31', '2018-09-02', 3, 6, 4)
--PROYECTO - 5
INSERT INTO Tareas (Name, [Index], TipoDuracionId, Duracion, StarDate, FinalDate, EstadoId, ResponsableId, ProyectoId) VALUES ('Investigación',	1, 1,  6, '2018-08-04', '2018-08-10', 2, 12, 5)
INSERT INTO Tareas (Name, [Index], TipoDuracionId, Duracion, StarDate, FinalDate, EstadoId, ResponsableId, ProyectoId) VALUES ('Análisis'     ,	2, 1,  4, '2018-08-10', '2018-08-14', 2, 13, 5)
INSERT INTO Tareas (Name, [Index], TipoDuracionId, Duracion, StarDate, FinalDate, EstadoId, ResponsableId, ProyectoId) VALUES ('Desarrollo'   , 3, 1, 15, '2018-08-14', '2018-08-29', 3, 14, 5)
INSERT INTO Tareas (Name, [Index], TipoDuracionId, Duracion, StarDate, FinalDate, EstadoId, ResponsableId, ProyectoId) VALUES ('Pruebas'      , 4, 1,  9, '2018-08-29', '2018-09-07', 3, 15, 5)
INSERT INTO Tareas (Name, [Index], TipoDuracionId, Duracion, StarDate, FinalDate, EstadoId, ResponsableId, ProyectoId) VALUES ('Demo'         , 5, 1,  7, '2018-09-07', '2018-09-14', 3, 16, 5)
--PROYECTO - 6
INSERT INTO Tareas (Name, [Index], TipoDuracionId, Duracion, StarDate, FinalDate, EstadoId, ResponsableId, ProyectoId) VALUES ('Investigación', 1, 1, 1, '2018-08-06', '2018-08-07', 2,  2, 6)
INSERT INTO Tareas (Name, [Index], TipoDuracionId, Duracion, StarDate, FinalDate, EstadoId, ResponsableId, ProyectoId) VALUES ('Análisis'	  , 2, 1, 2, '2018-08-07', '2018-08-09', 2,  6, 6)
INSERT INTO Tareas (Name, [Index], TipoDuracionId, Duracion, StarDate, FinalDate, EstadoId, ResponsableId, ProyectoId) VALUES ('Desarrollo'   ,	3, 1, 5, '2018-08-09', '2018-08-14', 2,  9, 6)
INSERT INTO Tareas (Name, [Index], TipoDuracionId, Duracion, StarDate, FinalDate, EstadoId, ResponsableId, ProyectoId) VALUES ('Pruebas'      ,	4, 1, 4, '2018-08-14', '2018-08-18', 2,  5, 6)
INSERT INTO Tareas (Name, [Index], TipoDuracionId, Duracion, StarDate, FinalDate, EstadoId, ResponsableId, ProyectoId) VALUES ('Demo'         ,	5, 1, 3, '2018-08-18', '2018-08-21', 2, 10, 6)

GO
--SOLICITUDES
--PROYECTO - 1
INSERT INTO SolicitudesRecurso (ProyectoId, CreateDate, PrioridadId, EstadoId, ResponsableId) VALUES (1, '2018-08-27', 3, 4, 1)
--PROYECTO - 2
INSERT INTO SolicitudesRecurso (ProyectoId, CreateDate, PrioridadId, EstadoId, ResponsableId) VALUES (2, '2018-08-01', 2, 4, 2)
--PROYECTO - 3
INSERT INTO SolicitudesRecurso (ProyectoId, CreateDate, PrioridadId, EstadoId, ResponsableId) VALUES (3, '2018-08-05', 2, 4, 3)
--PROYECTO - 4
INSERT INTO SolicitudesRecurso (ProyectoId, CreateDate, PrioridadId, EstadoId, ResponsableId) VALUES (4, '2018-08-15', 3, 4, 1)
--PROYECTO - 5
INSERT INTO SolicitudesRecurso (ProyectoId, CreateDate, PrioridadId, EstadoId, ResponsableId) VALUES (5, '2018-08-04', 3, 4, 22)
--PROYECTO - 6
INSERT INTO SolicitudesRecurso (ProyectoId, CreateDate, PrioridadId, EstadoId, ResponsableId) VALUES (6, '2018-08-06', 1, 4, 20)
GO

--DETALLE DE SOLICITUDES DE RECURSO
--PROYECTO - 1
INSERT INTO SolicitudesRecursoDetalle (SolicitudRecursoId, RecursoId, Quantity, QuantityAttended, TipoSolicitudRecursoId, DiasAlquiler, CostoTotal) VALUES (1, 1, 6, 6, 2, 15, 4500)
INSERT INTO SolicitudesRecursoDetalle (SolicitudRecursoId, RecursoId, Quantity, QuantityAttended, TipoSolicitudRecursoId, DiasAlquiler, CostoTotal) VALUES (1, 3, 3, 3, 2, 15, 2250)
INSERT INTO SolicitudesRecursoDetalle (SolicitudRecursoId, RecursoId, Quantity, QuantityAttended, TipoSolicitudRecursoId, DiasAlquiler, CostoTotal) VALUES (1, 9, 6, 6, 2, 15, 1350)
INSERT INTO SolicitudesRecursoDetalle (SolicitudRecursoId, RecursoId, Quantity, QuantityAttended, TipoSolicitudRecursoId, DiasAlquiler, CostoTotal) VALUES (1, 8, 1, 1, 1,  0,   25)
--PROYECTO - 2
INSERT INTO SolicitudesRecursoDetalle (SolicitudRecursoId, RecursoId, Quantity, QuantityAttended, TipoSolicitudRecursoId, DiasAlquiler, CostoTotal) VALUES (2, 1, 2, 6, 2, 15, 1500)
INSERT INTO SolicitudesRecursoDetalle (SolicitudRecursoId, RecursoId, Quantity, QuantityAttended, TipoSolicitudRecursoId, DiasAlquiler, CostoTotal) VALUES (2, 3, 4, 3, 2, 15, 3000)
INSERT INTO SolicitudesRecursoDetalle (SolicitudRecursoId, RecursoId, Quantity, QuantityAttended, TipoSolicitudRecursoId, DiasAlquiler, CostoTotal) VALUES (2, 9, 5, 6, 2, 15, 1125)
INSERT INTO SolicitudesRecursoDetalle (SolicitudRecursoId, RecursoId, Quantity, QuantityAttended, TipoSolicitudRecursoId, DiasAlquiler, CostoTotal) VALUES (2, 8, 2, 1, 1,  0,   50)
--PROYECTO - 3
INSERT INTO SolicitudesRecursoDetalle (SolicitudRecursoId, RecursoId, Quantity, QuantityAttended, TipoSolicitudRecursoId, DiasAlquiler, CostoTotal) VALUES (3, 1, 2, 6, 2, 25, 2500)
INSERT INTO SolicitudesRecursoDetalle (SolicitudRecursoId, RecursoId, Quantity, QuantityAttended, TipoSolicitudRecursoId, DiasAlquiler, CostoTotal) VALUES (3, 3, 4, 3, 2, 25, 5000)
INSERT INTO SolicitudesRecursoDetalle (SolicitudRecursoId, RecursoId, Quantity, QuantityAttended, TipoSolicitudRecursoId, DiasAlquiler, CostoTotal) VALUES (3, 9, 5, 6, 2, 25, 1875)
INSERT INTO SolicitudesRecursoDetalle (SolicitudRecursoId, RecursoId, Quantity, QuantityAttended, TipoSolicitudRecursoId, DiasAlquiler, CostoTotal) VALUES (3, 8, 2, 2, 1,  0,   50)
--PROYECTO - 4
INSERT INTO SolicitudesRecursoDetalle (SolicitudRecursoId, RecursoId, Quantity, QuantityAttended, TipoSolicitudRecursoId, DiasAlquiler, CostoTotal) VALUES (4, 1, 2, 6, 2, 18, 1800)
INSERT INTO SolicitudesRecursoDetalle (SolicitudRecursoId, RecursoId, Quantity, QuantityAttended, TipoSolicitudRecursoId, DiasAlquiler, CostoTotal) VALUES (4, 3, 4, 3, 2, 18, 3600)
INSERT INTO SolicitudesRecursoDetalle (SolicitudRecursoId, RecursoId, Quantity, QuantityAttended, TipoSolicitudRecursoId, DiasAlquiler, CostoTotal) VALUES (4, 9, 5, 6, 2, 18, 1350)
INSERT INTO SolicitudesRecursoDetalle (SolicitudRecursoId, RecursoId, Quantity, QuantityAttended, TipoSolicitudRecursoId, DiasAlquiler, CostoTotal) VALUES (4, 8, 2, 2, 1,  0,   50)
--PROYECTO - 5
INSERT INTO SolicitudesRecursoDetalle (SolicitudRecursoId, RecursoId, Quantity, QuantityAttended, TipoSolicitudRecursoId, DiasAlquiler, CostoTotal) VALUES (5, 1, 6, 6, 2, 41, 12300)
INSERT INTO SolicitudesRecursoDetalle (SolicitudRecursoId, RecursoId, Quantity, QuantityAttended, TipoSolicitudRecursoId, DiasAlquiler, CostoTotal) VALUES (5, 3, 2, 3, 2, 41,  4100)
INSERT INTO SolicitudesRecursoDetalle (SolicitudRecursoId, RecursoId, Quantity, QuantityAttended, TipoSolicitudRecursoId, DiasAlquiler, CostoTotal) VALUES (5, 9, 6, 6, 2, 41,  3690)
INSERT INTO SolicitudesRecursoDetalle (SolicitudRecursoId, RecursoId, Quantity, QuantityAttended, TipoSolicitudRecursoId, DiasAlquiler, CostoTotal) VALUES (5, 8, 1, 1, 1,  0,    25)
--PROYECTO - 6
INSERT INTO SolicitudesRecursoDetalle (SolicitudRecursoId, RecursoId, Quantity, QuantityAttended, TipoSolicitudRecursoId, DiasAlquiler, CostoTotal) VALUES (6, 1, 4, 6, 2, 15, 3000)
INSERT INTO SolicitudesRecursoDetalle (SolicitudRecursoId, RecursoId, Quantity, QuantityAttended, TipoSolicitudRecursoId, DiasAlquiler, CostoTotal) VALUES (6, 3, 2, 3, 2, 15, 1500)
INSERT INTO SolicitudesRecursoDetalle (SolicitudRecursoId, RecursoId, Quantity, QuantityAttended, TipoSolicitudRecursoId, DiasAlquiler, CostoTotal) VALUES (6, 9, 5, 6, 2, 15, 1125)
INSERT INTO SolicitudesRecursoDetalle (SolicitudRecursoId, RecursoId, Quantity, QuantityAttended, TipoSolicitudRecursoId, DiasAlquiler, CostoTotal) VALUES (6, 8, 1, 1, 1,  0,   25)
GO