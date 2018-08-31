--PROYECTO
INSERT INTO Proyectos (NumDocument, Presupuesto, StarDate, FinalDate, EstadoAprobacionId, PrioridadId, EstadoId, ClienteId, TipoProyectoId, ResponsableId, PatrocinadorId, UserId, CreateDate, EditDate, TipoDuracionId, Duracion, [Name], [Description]) VALUES ('PY-2018-08-00001', 8500, '2018-08-27', '2018-09-11', 2, 1, 1, 1, 1, 1, 1, 'admin@indra.com', '2018-08-27', '2018-08-27', 1, 15, 'Software para el diseño de redes de ordenadores', 'El diseño asistido por ordenador, más conocido como CAD (computer-aided design), es el uso de un amplio rango de herramientas computacionales que asisten a ingenieros, arquitectos y a otros profesionales del diseño en sus respectivas actividades. En este proyecto se creara una pequeña herramienta CAD que permita diseñar redes de ordenadores basicas de diferentes clases (e.g., Ethernet, FDDI). El software permitira crear redes virtuales utilizando iconos descriptivos que representen diferentes ordenadores, tarjetas de red, cables y routers, entre otros. Esta herramienta asistira a estudiantes de otras titulaciones a la hora de comprender los conceptos basicos del diseño de redes de una forma amigable.')
GO
--TAREAS
INSERT INTO Tareas (Name, [Index], TipoDuracionId, Duracion, StarDate, FinalDate, EstadoId, ResponsableId, ProyectoId) VALUES ('Investigación', 1, 1, 1, '2018-08-27', '2018-08-28', 2, 2, 1)
INSERT INTO Tareas (Name, [Index], TipoDuracionId, Duracion, StarDate, FinalDate, EstadoId, ResponsableId, ProyectoId) VALUES ('Análisis', 2, 1, 2,      '2018-08-28', '2018-08-30', 2, 3, 1)
INSERT INTO Tareas (Name, [Index], TipoDuracionId, Duracion, StarDate, FinalDate, EstadoId, ResponsableId, ProyectoId) VALUES ('Desarrollo', 3, 1, 3,    '2018-08-30', '2018-09-02', 3, 4, 1)
INSERT INTO Tareas (Name, [Index], TipoDuracionId, Duracion, StarDate, FinalDate, EstadoId, ResponsableId, ProyectoId) VALUES ('Pruebas', 4, 1, 4,       '2018-09-02', '2018-09-06', 3, 5, 1)
INSERT INTO Tareas (Name, [Index], TipoDuracionId, Duracion, StarDate, FinalDate, EstadoId, ResponsableId, ProyectoId) VALUES ('Demo', 5, 1, 5,          '2018-09-06', '2018-09-11', 3, 6, 1)
GO
--SOLICITUDES
INSERT INTO SolicitudesRecurso (ProyectoId, CreateDate, PrioridadId, EstadoId, ResponsableId) VALUES (1, '2018-08-27', 3, 4, 1)
GO
--DETALLE DE SOLICITUDES DE RECURSO
INSERT INTO SolicitudesRecursoDetalle (SolicitudRecursoId, RecursoId, Quantity, QuantityAttended, TipoSolicitudRecursoId, DiasAlquiler, CostoTotal) VALUES (1, 1, 6, 6, 2, 15, 4500)
INSERT INTO SolicitudesRecursoDetalle (SolicitudRecursoId, RecursoId, Quantity, QuantityAttended, TipoSolicitudRecursoId, DiasAlquiler, CostoTotal) VALUES (1, 3, 3, 3, 2, 15, 2250)
INSERT INTO SolicitudesRecursoDetalle (SolicitudRecursoId, RecursoId, Quantity, QuantityAttended, TipoSolicitudRecursoId, DiasAlquiler, CostoTotal) VALUES (1, 9, 6, 6, 2, 15, 1350)
INSERT INTO SolicitudesRecursoDetalle (SolicitudRecursoId, RecursoId, Quantity, QuantityAttended, TipoSolicitudRecursoId, DiasAlquiler, CostoTotal) VALUES (1, 8, 1, 1, 1,  0, 25)
GO