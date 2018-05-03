using System;
using System.Collections.Generic;
using System.Data.Entity;
using Indra.Data.Context;
using Indra.Model.Models;

namespace Indra.Data
{
    public class SeedData : DropCreateDatabaseIfModelChanges<IndraContext>
    {
        protected override void Seed(IndraContext context)
        {
            var db = new ApplicationDbContext();
            GetCriterioEvaluaciones().ForEach(o => context.CriterioEvaluaciones.Add(o));
            GetCategoriaComponentes().ForEach(o => context.CategoriaComponentes.Add(o));
            GetTipoDocumentoIdentidades().ForEach(o => context.TipoDocumentoIdentidades.Add(o));
            GetTipoProyectos().ForEach(o => context.TipoProyectos.Add(o));
            GetPrioridades().ForEach(o => context.Prioridades.Add(o));
            GetEstados().ForEach(o => context.Estados.Add(o));
            GetEstadoAprobaciones().ForEach(o => context.EstadoAprobaciones.Add(o));
            GetRecursos().ForEach(o => context.Recursos.Add(o));
            context.SaveChanges();
            GetTrabajadores().ForEach(o => context.Trabajadores.Add(o));
            GetClientes().ForEach(o => context.Clientes.Add(o));
            GetPatrocinadores().ForEach(o => context.Patrocinadores.Add(o));
            context.SaveChanges();
            GetProyectos().ForEach(o => context.Proyectos.Add(o));
            context.SaveChanges();
            GetProgramas().ForEach(o => context.Programas.Add(o));
            context.SaveChanges();
            GetPortafolios().ForEach(o => context.Portafolios.Add(o));
            context.SaveChanges();
            GetSolicitudRecursos().ForEach(o => context.SolicitudRecursos.Add(o));
            context.SaveChanges();
        }

        private static List<CriterioEvaluacion> GetCriterioEvaluaciones() => new List<CriterioEvaluacion>
        {
            new CriterioEvaluacion{ Name = "Alineamiento Estratégico", Description = "La estrategia es la definición de fines y medios que orientan a la organización al logro de sus objetivos. Este criterio consiste en alinear todas las actividades de la empresa a su estrategia y políticas." },
            new CriterioEvaluacion{ Name = "Beneficios Intangibles", Description = "Los beneficios intangibles se obtienen a través de un sistema de información, son difíciles de cuantificar, son extremadamente importantes y pueden tener implicaciones de relevancia para el negocio, en su relación con personas tanto ajenas como propias de la organización." },
            new CriterioEvaluacion{ Name = "Beneficios Tangibles", Description = "Los beneficios tangibles son las ventajas económicas cuantificables que obtiene la organización. Aunque la medición no siempre es fácil los beneficios tangibles pueden estimarse en términos de pesos, recursos o tiempo ahorrados." },
            new CriterioEvaluacion{ Name = "Conformidad Regulatoria/legal", Description = "Las soluciones de INDRA para la conformidad regulatoria se basan en procesos integrados, diseñados para abarcar los aspectos clave de la planificación de la seguridad, la gestión y la información." },
            new CriterioEvaluacion{ Name = "Dificultad Técnica", Description = "La dificultad técnica se traduce en cualquier situación adversa que perjudique o dificulte algún proceso de la empresa. Para prevenir esto, la empresa tiene controles continuos de equipos y procesos, y además genera planes de contingencia que permitirán la solución ante algún problema." }
        };

        private static List<CategoriaComponente> GetCategoriaComponentes() => new List<CategoriaComponente>
        {
            new CategoriaComponente{ Name = "Incrementar Rentabilidad", Description = "La rentabilidad es el resultado del proceso productivo, si es positivo la empresa gana utilidades y ha cumplido su objetivo y si es negativo el producto está dando pérdidas.", Remark = "La empresa INDRA tiene por objetivo incrementar la calidad de sus productos en primer lugar y por añadidura se incrementan los ingresos, posicionándose así dentro del mercado competitivo." },
            new CategoriaComponente{ Name = "Incrementar Participacion en el Mercado", Description = "Significa el posicionamiento en el mercado orientado principalmente a las ventas.", Remark = "INDRA ocupa el tercer puesto de las empresas peruanas exportadoras de harina de pescado para el periodo de enero- febrero del 2008, además fue la primera empresa peruana en realizar una colocación privada de acciones por cien millones de dólares americanos en el mercado de Oslo (Noruega); empezando así a negociarse las acciones de INCAMAR en la Bolsa de Valores de Oslo, incrementándose así su participación en el mercado." },
            new CategoriaComponente{ Name = "Incrementar Oferta de Productos", Description = "Fomentar la variabilidad de los productos producidos, con la finalidad de abarcar más el mercado.", Remark = "La empresa INDRA está diversificando sus productos ofrecidos invirtiendo en la acuicultura. Tratará de ingresar al mercado de Francia y EE.UU ofreciendo concha de abanico congelada, ampliando así su cartera de productos." },
            new CategoriaComponente{ Name = "Fortalecimiento Organizacional", Description = "El fortalecimiento organizacional se enfoca en inducir las condiciones suficientes y necesarias para que la organización tenga éxito en el logro de sus objetivos y metas.", Remark = "Para este propósito INDRA integra una estrategia la cual contempla la elaboración de un diagnóstico situacional de la organización, así como un plan de transformación o adecuación de la misma, incluso con alcance de reingeniería, si es necesario." },
        };

        private static List<TipoDocumentoIdentidad> GetTipoDocumentoIdentidades() => new List<TipoDocumentoIdentidad>
        {
            new TipoDocumentoIdentidad{ Name = "DNI", Description = "DNI" },
            new TipoDocumentoIdentidad{ Name = "RUC", Description = "RUC" }
        };

        private static List<TipoProyecto> GetTipoProyectos() => new List<TipoProyecto>
        {
            new TipoProyecto{ Name = "Consultoria o asesoramiento" },
            new TipoProyecto{ Name = "Gestión del cambio" },
            new TipoProyecto{ Name = "Nuevo producto o proceso" },
            new TipoProyecto{ Name = "Investigación, estudio, viabilidad" }
        };

        private static List<Prioridad> GetPrioridades() => new List<Prioridad>
        {
            new Prioridad{ Name = "Normal" },
            new Prioridad{ Name = "Media" },
            new Prioridad{ Name = "Alta" }
        };

        private static List<Estado> GetEstados() => new List<Estado>
        {
            new Estado{ Name = "En Ejecución" },
            new Estado{ Name = "Terminado" },
            new Estado{ Name = "Pendiente" }
        };

        private static List<EstadoAprobacion> GetEstadoAprobaciones() => new List<EstadoAprobacion>
        {
            new EstadoAprobacion{ Name = "Pendiente" },
            new EstadoAprobacion{ Name = "Aprobado" },
            new EstadoAprobacion{ Name = "Rechazado" }
        };

        private static List<Recurso> GetRecursos() => new List<Recurso>
        {
            new Recurso{ Name = "Laptop i7 4GB 500GB HP" },
            new Recurso{ Name = "Escaner HP" },
            new Recurso{ Name = "Impresora HP" },
            new Recurso{ Name = "Silla plastico" },
            new Recurso{ Name = "Auto 4 asientos Toyota" },
            new Recurso{ Name = "Camioneta 6 asientos Toyota" },
            new Recurso{ Name = "Calculadora HP" },
            new Recurso{ Name = "Folder 100/und" },
            new Recurso{ Name = "Celular S.O Andriod" },
            new Recurso{ Name = "Tablet S.O. Android" },
            new Recurso{ Name = "PC i7 4GB 500GB HP" }
        };

        private static  List<Trabajador> GetTrabajadores() => new List<Trabajador>
        {
            new Trabajador { Nombres = "Luis", ApellidoPaterno = "Carranza", ApellidoMaterno = "Perez", NroDocumento = "42894678", TipoDocumentoIdentidadId = 1, Telefono = "987676554", Email = "lcarranza@indra.com" },
            new Trabajador { Nombres = "Luisa", ApellidoPaterno = "Palomino", ApellidoMaterno = "Córdova", NroDocumento = "43564523", TipoDocumentoIdentidadId = 1, Telefono = "786655442", Email = "lpalomino@indra.com" },
            new Trabajador { Nombres = "Marcelo", ApellidoPaterno = "Mendoza", ApellidoMaterno = "Paucar", NroDocumento = "67897898", TipoDocumentoIdentidadId = 1, Telefono = "121232112", Email = "mmendoza@indra.com" },
            new Trabajador { Nombres = "Ana", ApellidoPaterno = "Balarezo", ApellidoMaterno = "Zárate", NroDocumento = "43562341", TipoDocumentoIdentidadId = 1, Telefono = "987676551", Email = "abalarezo@indra.com" },
            new Trabajador { Nombres = "Raúl", ApellidoPaterno = "García", ApellidoMaterno = "Marquez", NroDocumento = "11223344", TipoDocumentoIdentidadId = 1, Telefono = "897867562", Email = "rgarcia@indra.com" },
            new Trabajador { Nombres = "Jorge", ApellidoPaterno = "Espejo", ApellidoMaterno = "Blanco", NroDocumento = "34234532", TipoDocumentoIdentidadId = 1, Telefono = "909090221", Email = "jespejo@indra.com" }
        };

        private static List<Cliente> GetClientes() => new List<Cliente>
        {
            new Cliente { RazonSocial = "Toyota del Perú S.A.", NroDocumento = "20100132592", TipoDocumentoIdentidadId = 2, Telefono = "017676554", Email = "contacto@toyota.com", WebSite = "www.toyota.com", ContactName = "José Alcántara Peña", Direccion = "AV. SANTO TORIBIO NRO. 173 INT. PI14 (VIA CENTRAL 125, TORRE REAL 8 OF.1401-02) LIMA - LIMA - SAN ISIDRO" },
            new Cliente { RazonSocial = "Ferreyros Sociedad Anonima", NroDocumento = "20100028698", TipoDocumentoIdentidadId = 2, Telefono = "016655442", Email = "contacto@ferreyros.com", WebSite = "www.ferreyros.com", ContactName = "Elsa Ruiz Tejada", Direccion = "JR. CRISTOBAL DE PERALTA NORT NRO. 820 URB. SAN IDELFONSO LIMA - LIMA - SANTIAGO DE SURCO" },
            new Cliente { RazonSocial = "Alicorp S.A.", NroDocumento = "20100055237", TipoDocumentoIdentidadId = 2, Telefono = "011232112", Email = "contacto@alicorp.com", WebSite = "www.alicorp.com", ContactName = "Rosa Nuñez Zuloaga", Direccion = "AV. ARGENTINA NRO. 4793 URB. PARQUE INDUSTRIAL PROV. CONST. DEL CALLAO - PROV. CONST. DEL CALLAO - CARMEN DE LA LEGUA REYNOSO" },
            new Cliente { RazonSocial = "Corporación Aceros Arequipa S.A.", NroDocumento = "20370146994", TipoDocumentoIdentidadId = 2, Telefono = "019090221", Email = "contacto@acerosarequipa.com", WebSite = "www.acerosarequipa.com", ContactName = "Toribio Deza Salcedo", Direccion = "CAR.PANAMERICANA SUR NRO. 241 PANAMERICANA SUR ICA - PISCO - PARACAS" }
        };

        private static List<Patrocinador> GetPatrocinadores() => new List<Patrocinador>
        {
            new Patrocinador { Nombres = "Pablo", ApellidoPaterno = "Heredia", ApellidoMaterno = "Castro", NroDocumento = "42894078", TipoDocumentoIdentidadId = 1, Telefono = "887676554", Email = "pheredia@indra.com" },
            new Patrocinador { Nombres = "Joaquin", ApellidoPaterno = "Casaverde", ApellidoMaterno = "Pardo", NroDocumento = "40564523", TipoDocumentoIdentidadId = 1, Telefono = "886655442", Email = "jcasaverde@indra.com" },
            new Patrocinador { Nombres = "Carol", ApellidoPaterno = "Aliaga", ApellidoMaterno = "Condezo", NroDocumento = "67897808", TipoDocumentoIdentidadId = 1, Telefono = "881232112", Email = "caliaga@indra.com" },
            new Patrocinador { Nombres = "Luis", ApellidoPaterno = "Zela", ApellidoMaterno = "Panduro", NroDocumento = "43062341", TipoDocumentoIdentidadId = 1, Telefono = "887676551", Email = "lzela@indra.com" },
            new Patrocinador { Nombres = "Kevin", ApellidoPaterno = "Salas", ApellidoMaterno = "Bautista", NroDocumento = "11220344", TipoDocumentoIdentidadId = 1, Telefono = "887867562", Email = "ksalas@indra.com" },
            new Patrocinador { Nombres = "Rocio", ApellidoPaterno = "Torres", ApellidoMaterno = "Montoya", NroDocumento = "30234532", TipoDocumentoIdentidadId = 1, Telefono = "889090221", Email = "rtorres@indra.com" }
        };

        private static List<Proyecto> GetProyectos() => new List<Proyecto>
        {
            new Proyecto
            {
                NumProyecto = "PY-2018-01-00001",
                Name = "Implementación del Sistema de Control Interno.",
                Description = "El proyecto consiste en la Implementación del Sistema de Control Interno el cual es un conjunto de acciones estructuradas y coordinadas que lleva a cabo la Gerencia General de la empresa, diseñado para proporcionar un grado de seguridad razonable para que la empresa logre sus objetivos.",
                Presupuesto = 3000000,
                StarDate = DateTime.Parse("2018-01-15"),
                FinalDate = DateTime.Parse("2019-01-31"),
                EstadoAprobacionId = 2,
                PrioridadId = 1,
                EstadoId = 1,
                ClienteId = 1,
                TipoProyectoId = 4,
                ResponsableId = 1,
                PatrocinadorId = 1
            },
            new Proyecto
            {
                NumProyecto = "PY-2018-01-00002",
                Name = "Implementación de Inteligencia de Negocios Orientado al Valor Agregado",
                Description = "El proyecto INOVA consiste en proveer de información confiable y oportuna, que brinde un apoyo óptimo al proceso de toma de decisiones de negocio, a través de la implementación de una herramienta tecnológica conocida como Business Intelligence (BI).",
                Presupuesto = 3500000,
                StarDate = DateTime.Parse("2017-02-1"),
                FinalDate = DateTime.Parse("2019-02-21"),
                EstadoAprobacionId = 2,
                PrioridadId = 2,
                EstadoId = 1,
                ClienteId = 2,
                TipoProyectoId = 3,
                ResponsableId = 2,
                PatrocinadorId = 2
            },
            new Proyecto
            {
                NumProyecto = "PY-2018-01-00003",
                Name = "Sistematización y control general en planta",
                Description = "Se requiere un sistema de información de trazabilidad que permita Trazar el flujo de materiales (suministros, alimentos, ingredientes y envases), seguimiento para cada etapa de la producción, asegure la coordinación adecuada entre los distintos actores involucrados, requiriendo que cada parte.",
                Presupuesto = 4000000,
                StarDate = DateTime.Parse("2018-02-1"),
                FinalDate = DateTime.Parse("2018-12-21"),
                EstadoAprobacionId = 2,
                PrioridadId = 3,
                EstadoId = 1,
                ClienteId = 2,
                TipoProyectoId = 2,
                ResponsableId = 3,
                PatrocinadorId = 3
            },
            new Proyecto
            {
                NumProyecto = "PY-2018-01-00004",
                Name = "Definir y mejorar un proceso para aumentar la productividad y reducir los costos.",
                Description = "Permitir al personal de TI y de negocio diseñar y poner en práctica el proceso de autoservicio de RH de manera colaborativa.",
                Presupuesto = 2500000,
                StarDate = DateTime.Parse("2018-05-1"),
                FinalDate = DateTime.Parse("2018-12-31"),
                EstadoAprobacionId = 2,
                PrioridadId = 3,
                EstadoId = 1,
                ClienteId = 2,
                TipoProyectoId = 2,
                ResponsableId = 1,
                PatrocinadorId = 2
            },
            new Proyecto
            {
                NumProyecto = "PY-2018-01-00005",
                Name = "Implementación del Sistema de Control Interno.",
                Description = "El proyecto consiste en la Implementación del Sistema de Control Interno el cual es un conjunto de acciones estructuradas y coordinadas que lleva a cabo la Gerencia General.",
                Presupuesto = 1000000,
                StarDate = DateTime.Parse("2017-12-1"),
                FinalDate = DateTime.Parse("2018-05-25"),
                EstadoAprobacionId = 2,
                PrioridadId = 1,
                EstadoId = 1,
                ClienteId = 3,
                TipoProyectoId = 2,
                ResponsableId = 3,
                PatrocinadorId = 2
            },
            new Proyecto
            {
                NumProyecto = "PY-2018-01-00006",
                Name = "Implementación de Inteligencia de Negocios Orientado al Valor Agregado.",
                Description = "El proyecto consiste en proveer de información confiable y oportuna, que brinde un apoyo óptimo al proceso de toma de decisiones de negocio, a través de la implementación de una herramienta tecnológica conocida como Business Intelligence (BI)",
                Presupuesto = 8100000,
                StarDate = DateTime.Parse("2017-06-1"),
                FinalDate = DateTime.Parse("2018-06-1"),
                EstadoAprobacionId = 2,
                PrioridadId = 3,
                EstadoId = 1,
                ClienteId = 2,
                TipoProyectoId = 1,
                ResponsableId = 2,
                PatrocinadorId = 1
            },
            new Proyecto
            {
                NumProyecto = "PY-2018-01-00007",
                Name = "Sistematización y control general en planta.",
                Description = "Se requiere un sistema de información de trazabilidad que permita Trazar el flujo de materiales (suministros, alimentos, ingredientes y envases), seguimiento para cada etapa de la producción, asegure la coordinación.",
                Presupuesto = 8100000,
                StarDate = DateTime.Parse("2017-06-1"),
                FinalDate = DateTime.Parse("2018-06-1"),
                EstadoAprobacionId = 2,
                PrioridadId = 3,
                EstadoId = 1,
                ClienteId = 1,
                TipoProyectoId = 2,
                ResponsableId = 1,
                PatrocinadorId = 2
            },
            new Proyecto
            {
                NumProyecto = "PY-2018-01-00008",
                Name = "Definir y mejorar un proceso para aumentar la productividad y reducir los costos.",
                Description = "Permitir al personal de TI y de negocio diseñar y poner en práctica el proceso de autoservicio de RH de manera colaborativa. El marco de implementación iterativo permitió al equipo refinar continuamente los requisitos y en última instancia ofrecer una solución que puede conducir a mejores.",
                Presupuesto = 8100000,
                StarDate = DateTime.Parse("2017-01-1"),
                FinalDate = DateTime.Parse("2018-09-1"),
                EstadoAprobacionId = 2,
                PrioridadId = 2,
                EstadoId = 1,
                ClienteId = 3,
                TipoProyectoId = 1,
                ResponsableId = 2,
                PatrocinadorId = 1
            }
        };

        private static List<Programa> GetProgramas() => new List<Programa>
        {
            new Programa
            {
                NumProyecto = "PR-2018-01-00001",
                Name = "Proyectos de crecimiento.",
                Description = "Un programa es un conjunto de proyectos relacionados de una manera coordinada para obtener beneficios y control, no disponible cuando se gestiona de manera individual. La gestión de programas permite agrupar proyectos alrededor de objetivos comunes y realizar una planiﬁcación y un seguimiento.",
                Presupuesto = 3000000,
                StarDate = DateTime.Parse("2018-01-15"),
                FinalDate = DateTime.Parse("2019-01-31"),
                PrioridadId = 1,
                EstadoId = 1,
                ResponsableId = 1,
                ProgramaDetalles = new List<ProgramaDetalle>{ new ProgramaDetalle{ ProyectoId = 1 }, new ProgramaDetalle { ProyectoId = 2 } }
            },
            new Programa
            {
                NumProyecto = "PR-2018-02-00002",
                Name = "Iniciativas de mejoras internas",
                Description = "Un programa es un conjunto de proyectos relacionados de una manera coordinada para obtener beneficios y control, no disponible cuando se gestiona de manera individual.",
                Presupuesto = 3500000,
                StarDate = DateTime.Parse("2017-02-1"),
                FinalDate = DateTime.Parse("2019-02-21"),
                PrioridadId = 2,
                EstadoId = 1,
                ResponsableId = 2,
                ProgramaDetalles = new List<ProgramaDetalle>{ new ProgramaDetalle{ ProyectoId = 3 }, new ProgramaDetalle { ProyectoId = 4 } }
            },
            new Programa
            {
                NumProyecto = "PR-2018-02-00003",
                Name = "Implementación del Sistema de Producción más limpia.",
                Description = "Se requiere un sistema de información de trazabilidad que permita Trazar el flujo de materiales (suministros, alimentos, ingredientes y envases), seguimiento para cada etapa de la producción, asegure la coordinación adecuada entre los distintos actores involucrados, requiriendo que cada parte.",
                Presupuesto = 4000000,
                StarDate = DateTime.Parse("2018-02-1"),
                FinalDate = DateTime.Parse("2018-12-21"),
                PrioridadId = 3,
                EstadoId = 1,
                ResponsableId = 3,
                ProgramaDetalles = new List<ProgramaDetalle>{ new ProgramaDetalle{ ProyectoId = 5 } }
            }
        };

        private static List<Portafolio> GetPortafolios() => new List<Portafolio>
        {
            new Portafolio
            {
                NumPortafolio = "PO-2018-01-00001",
                Name = "Mejoras operativas y nuevos productos.",
                Description = "Un programa es un conjunto de proyectos relacionados de una manera coordinada para obtener beneficios y control, no disponible cuando se gestiona de manera individual. La gestión de programas permite agrupar proyectos alrededor de objetivos comunes y realizar una planiﬁcación y un seguimiento.",
                CreateDate = DateTime.Parse("2018-01-15"),
                EditDate = DateTime.Parse("2019-01-31"),
                CategoriaComponenteId = 1,
                PrioridadId = 1,
                EstadoId = 1,
                ResponsableId = 1,
                Remark = "Un programa es un conjunto de proyectos relacionados de una manera coordinada para obtener beneficios y control, no disponible cuando se gestiona de manera individual. La gestión de programas permite agrupar proyectos alrededor de objetivos comunes y realizar una planiﬁcación y un seguimiento.",
                PortafolioDetalleProgramas = new List<PortafolioDetallePrograma>{ new PortafolioDetallePrograma { ProgramaId = 1 }, new PortafolioDetallePrograma { ProgramaId = 2 } },
                PortafolioDetalleProyectos = new List<PortafolioDetalleProyecto>{ new PortafolioDetalleProyecto { ProyectoId = 6 } }
            },
            new Portafolio
            {
                NumPortafolio = "PO-2018-02-00002",
                Name = "Programas y proyectos corporativos",
                Description = "Un programa es un conjunto de proyectos relacionados de una manera coordinada para obtener beneficios y control, no disponible cuando se gestiona de manera individual.",
                CreateDate = DateTime.Parse("2017-02-1"),
                EditDate = DateTime.Parse("2019-02-21"),
                CategoriaComponenteId = 2,
                PrioridadId = 2,
                EstadoId = 1,
                ResponsableId = 2,
                Remark = "Un programa es un conjunto de proyectos relacionados de una manera coordinada para obtener beneficios y control, no disponible cuando se gestiona de manera individual.",
                PortafolioDetalleProgramas = new List<PortafolioDetallePrograma>{ new PortafolioDetallePrograma { ProgramaId = 3 } },
                PortafolioDetalleProyectos = new List<PortafolioDetalleProyecto>{ new PortafolioDetalleProyecto { ProyectoId = 7 }, new PortafolioDetalleProyecto { ProyectoId = 8 } }
            }
        };

        private static List<SolicitudRecurso> GetSolicitudRecursos() => new List<SolicitudRecurso>
        {
            new SolicitudRecurso
            {
                ProyectoId = 1,
                CreateDate = DateTime.Parse("2018-01-15"),
                PrioridadId = 1,
                EstadoId = 3,
                ResponsableId = 1,
                Remark = "Urgente",
                SolicitudRecursoDetalles = new List<SolicitudRecursoDetalle>
                {
                    new SolicitudRecursoDetalle { RecursoId = 1, Quantity = 2 },
                    new SolicitudRecursoDetalle { RecursoId = 2, Quantity = 3 },
                    new SolicitudRecursoDetalle { RecursoId = 3, Quantity = 4 }
                }
            },
            new SolicitudRecurso
            {
                ProyectoId = 2,
                CreateDate = DateTime.Parse("2017-02-1"),
                PrioridadId = 1,
                EstadoId = 3,
                ResponsableId = 2,
                Remark = "Urgente",
                SolicitudRecursoDetalles = new List<SolicitudRecursoDetalle>
                {
                    new SolicitudRecursoDetalle { RecursoId = 4, Quantity = 8 },
                    new SolicitudRecursoDetalle { RecursoId = 5, Quantity = 5 },
                    new SolicitudRecursoDetalle { RecursoId = 6, Quantity = 8 }
                }
            },
            new SolicitudRecurso
            {
                ProyectoId = 3,
                CreateDate = DateTime.Parse("2018-02-1"),
                PrioridadId = 1,
                EstadoId = 3,
                ResponsableId = 3,
                Remark = "Urgente",
                SolicitudRecursoDetalles = new List<SolicitudRecursoDetalle>
                {
                    new SolicitudRecursoDetalle { RecursoId = 1, Quantity = 6 },
                    new SolicitudRecursoDetalle { RecursoId = 4, Quantity = 5 },
                    new SolicitudRecursoDetalle { RecursoId = 9, Quantity = 4 }
                }
            },
            new SolicitudRecurso
            {
                ProyectoId = 4,
                CreateDate = DateTime.Parse("2018-05-1"),
                PrioridadId = 1,
                EstadoId = 3,
                ResponsableId = 1,
                Remark = "Urgente",
                SolicitudRecursoDetalles = new List<SolicitudRecursoDetalle>
                {
                    new SolicitudRecursoDetalle { RecursoId = 11, Quantity = 5 },
                    new SolicitudRecursoDetalle { RecursoId = 10, Quantity = 7 },
                    new SolicitudRecursoDetalle { RecursoId = 8, Quantity = 2 }
                }
            },
            new SolicitudRecurso
            {
                ProyectoId = 5,
                CreateDate = DateTime.Parse("2017-12-1"),
                PrioridadId = 1,
                EstadoId = 3,
                ResponsableId = 3,
                Remark = "Urgente",
                SolicitudRecursoDetalles = new List<SolicitudRecursoDetalle>
                {
                    new SolicitudRecursoDetalle { RecursoId = 11, Quantity = 3 },
                    new SolicitudRecursoDetalle { RecursoId = 6, Quantity = 2 },
                    new SolicitudRecursoDetalle { RecursoId = 3, Quantity = 1 }
                }
            },
            new SolicitudRecurso
            {
                ProyectoId = 6,
                CreateDate = DateTime.Parse("2017-06-1"),
                PrioridadId = 1,
                EstadoId = 3,
                ResponsableId = 2,
                Remark = "Urgente",
                SolicitudRecursoDetalles = new List<SolicitudRecursoDetalle>
                {
                    new SolicitudRecursoDetalle { RecursoId = 2, Quantity = 5 },
                    new SolicitudRecursoDetalle { RecursoId = 3, Quantity = 8 },
                    new SolicitudRecursoDetalle { RecursoId = 4, Quantity = 1 }
                }
            },
            new SolicitudRecurso
            {
                ProyectoId = 7,
                CreateDate = DateTime.Parse("2017-06-1"),
                PrioridadId = 1,
                EstadoId = 3,
                ResponsableId = 1,
                Remark = "Urgente",
                SolicitudRecursoDetalles = new List<SolicitudRecursoDetalle>
                {
                    new SolicitudRecursoDetalle { RecursoId = 5, Quantity = 7 },
                    new SolicitudRecursoDetalle { RecursoId = 3, Quantity = 3 },
                    new SolicitudRecursoDetalle { RecursoId = 7, Quantity = 4 }
                }
            },
            new SolicitudRecurso
            {
            ProyectoId = 8,
            CreateDate = DateTime.Parse("2017-01-1"),
            PrioridadId = 1,
            EstadoId = 3,
            ResponsableId = 2,
            Remark = "Urgente",
            SolicitudRecursoDetalles = new List<SolicitudRecursoDetalle>
            {
                new SolicitudRecursoDetalle { RecursoId = 3, Quantity = 3 },
                new SolicitudRecursoDetalle { RecursoId = 5, Quantity = 3 },
                new SolicitudRecursoDetalle { RecursoId = 1, Quantity = 3 }
            }
        }
        };
    }
}