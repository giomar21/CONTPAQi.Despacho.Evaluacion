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
