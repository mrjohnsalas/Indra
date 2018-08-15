# Indra
Taller de Proyectos 3 - Indra


Proyecto Gestión de Portafolio

El sistema que permitirá la gestión eficaz del portafolio de proyectos, de esta manera, mediante un monitoreo de alto nivel, facilite y apoye la toma de decisiones estratégicas, y conduzca a mejorar la asignación de recursos basado en prioridades que obedezcan a objetivos de la empresa.


Arquitectura

La arquitectura lógica se ha considerado en tres capas: El sistema implementa los patrones de diseño Modelo Vista Controlador (MVC).


Base de Datos

El motor de base de datos es el SQL Server


Diagrama de Paquetes

1. Registro y Planificación de Portafolios
2. Balanceo de Portafolios
3. Monitoreo de Portafolios
4. Seguridad


Casos de Uso de Sistemas

El proyecto contempla los siguientes casos de usos del sistema:

1. Registro y Planificación de Portafolios

•	GPP_CUS001: Actualizar Programa

•	GPP_CUS002: Actualizar Portafolio

•	GPP_CUS003: Administrar Criterio Evaluación

•	GPP_CUS014: Administrar Categoría de Componentes

•	GPP_CUS004: Asignar Prioridades

•	GPP_CUS005: Generar Reporte Ranking de Priorización

•	GPP_CUS006: Seleccionar Proyecto

•	GPP_CUS007: Seleccionar Programa


2. Balanceo de Portafolios

•	GPP_CUS010: Realizar Propuesta de Balanceo

•	GPP_CUS011: Actualizar documentos del portafolio

•	GPP_CUS012: Generar Reporte de Balance

•	GPP_CUS013: Registrar histórico

3. Monitoreo de Portafolios

•	GPP_CUS008: Controlar Portafolio

•	GPP_CUS009: Generar Informe de Desempeño de Portafolio

•	GPP_CUS015: Crear Solicitud


Casos de Uso a Desarrollar

GPP_CUS001: Actualizar Programa

•	Realiza la creación o actualización del programa.

El caso de uso comienza cuando el Analista de Portafolio accede a la opción Mantenimiento de Programa. El Analista selecciona los proyectos que guardan cierta relación entre sí. El caso de uso termina con la creación o actualización del programa en el sistema.

GPP_CUS002: Actualizar Portafolio

•	Realiza la creación o actualización del portafolio.

El caso de uso comienza cuando el Analista de Portafolio accede a la opción Mantenimiento de Portafolio. El Analista selecciona los programas y proyectos y los agrupa en aquellas que tienen estrategias similares. Registra los datos del portafolio. El caso de uso termina con la creación o actualización del portafolio en el sistema.

GPP_CUS008: Controlar Portafolio

•	Controlar del avance de los portafolios.

El caso de uso inicia cuando el Gestor de Monitoreo, selecciona la opción control de portafolio. En ese momento se compara el reporte de avance de los proyectos contra el avance estimado de los proyectos de portafolios. El caso de uso termina con la generación del reporte de avance de portafolio

GPP_CUS009: Generar Informe de Desempeño de Portafolio

•	Generación del informe de desempeño de portafolio.

El caso de uso inicia cuando el Gestor de Monitoreo, mediante la opción, generar informe de desempeño, compara los indicadores y plan de manejo de portafolios con el reporte de indicadores de desempeño de programas y/o proyectos. El caso de uso termina cuando se genera el Informe de desempeño de portafolio.

GPP_CUS011: Actualizar documentos del portafolio

•	Actualizar la documentación del portafolio

El caso de uso comienza cuando el Analista de Balanceo recibe el mapa de portafolio balanceo aprobado y empieza a actualizar la documentación del portafolio. El caso de uso termina cuando la actualización de la documentación del portafolio se registra en el sistema.

GPP_CUS012: Generar Reporte de Balance

•	Generar reporte de balanceado ya aprobado

El caso de uso comienza cuando el Analista de Balanceo recibe el mapa de portafolio actualizado. Luego, el Analista genera un reporte de lo balanceado. El caso de uso termina con la generación del reporte por el sistema.

