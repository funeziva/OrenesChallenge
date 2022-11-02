Proyecto creado con .Net6

Para ejecutar el proyecto abre la solución, esta se encuentra dentro del proyecto de API (ejecute el proyecto de api). Este le llevará a un front de desarrollo de swagger que mostrará todos los controladores con algunas de las salidas documentadas y también las entradas de cada controlador. Importante no haga caso al botón de authorize porque todos los controladores están decorados con [AllowAnonymous], ya que si lo decoraba con una autorización con rol la api devolvía el 403.

La base de datos se trata de un fichero de sqlite ya montado que se encuentra en el proyecto de api llamado database.

La estructura de carpetas sigue arquitectura hexagonal:
Con el proyecto api con los controladores, la clase startup con todas las configuraciones del proyecto y una carpeta con servicies dependencies para no tener una clase startup llena de dependencias.
Application es la capa de servicios de la aplicación.
Domain básicamente contiene algunas reglas como excepciones, interfaces para llamar a infrastructure, y las clases de dominio. También contiene algunos predicados para centralizar un poco luego la llamada a base de datos.
Infrastructure tenemos las llamadas mediante a ef a la base de datos, las migraciones a base de datos ya que la base de datos se ha generado con code first utilizando la consola de administrador de paquetes y el dbContext.

Por último la base de datos tiene dos triggers cuando se inserta un vehículo nuevo o cuando se edita la ubicación de vehículos, este inserta un nuevo registro en la tabla de UbicationHistories para dejar un histórico de ubicaciones de cada vehículo.

Me hubiera gustado dedicarle más tiempo y haber terminado la autorización con el jwt. Ha estado bastante entretenido hacerlo.