# CONTPAQi.Despacho.Evaluacion

El repositorio está compuesto por 2 carpetas:

- ## Database
Contiene un archivo con el script para generar la base de datos con su respectivo registros utilizados para las pruebas.

- ## Evaluacion.Despacho.API
Contiene la solución con sus respectivos proyectos.

La solución está compuesta por 5 proyectos, de las cuales 4 son del Backend (API) y uno del Frontend. Esto es así, ya que al construir una API los separo al menos en 4 capas (common, datos, lógica y presentación) para la mejor arquitectura del mismo.

## BACKEND
- Evaluacion.Despacho.COMMON
- Evaluacion.Despacho.DATA
- Evaluacion.Despacho.BUSINESS
- Evaluacion.Despacho.API *> Backend*

## FRONTEND
- Evaluacion.Despacho.FRONT

# Configuración
Dentro del proyecto **Evaluacion.Despacho.FRONT** se encuentra el archivo de configuración ***appsettings.json***, en la cual viene la url base (URL_API) que apunta a la API, actualmente esta tiene la ruta y puerto: http://localhost:51337.
En caso de que esta cambie, en el atributo **URL_API** se puede cambiar.

# Herramientas/Tecnologías
- Desarrollado con Visual Studio 2019
- Base de datos SQL Server 2019
- Framework: Net Core 5
- Lenguaje C#

## Nota: 
Es importante iniciar ambos proyectos (API y FRONT) a la vez, para esto tenemos que dar click derecho en la Solución del proyecto, seleccionar **Properties**, se abrirá una ventana donde se seleccionará del menú de la inzquierda **Commmon Properties**, luego la opción **Startup Poroject**, postoriormente la opción **Multiple Startup Projects** y seleccionamos la opción **Start** para los proyectos API y FRONT. 

Posteriormente corremos la aplicación desde Visual Studio.
