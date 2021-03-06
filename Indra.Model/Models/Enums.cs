﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indra.Model.Models
{
    public class Enums
    {
        public enum EstadoAprobacionType
        {
            Pendiente = 1,
            Aprobado = 2,
            Rechazado = 3
        }

        public enum EstadoType
        {
            EnEjecucion = 1,
            Terminado = 2,
            Pendiente = 3,
            Atendido = 4,
            Anulado = 5
        }

        public enum PrioridadType
        {
            Normal = 1,
            Media = 2,
            Alta = 3
        }

        public enum TipoDocumentoIdentidadType
        {
            Dni = 1,
            Ruc = 2
        }

        public enum TipoProyectoType
        {
            ConsultoriaAsesoramiento = 1,
            GestiónCambio = 2,
            NuevoProductoProceso = 3,
            InvestigaciónEstudioViabilidad = 4
        }

        public enum TipoDuracionType
        {
            Dia = 1,
            Mes = 2,
            Ano = 3
        }

        public enum TipoSolicitudRecursoType
        {
            Compra = 1,
            Alquiler = 2
        }
    }
}