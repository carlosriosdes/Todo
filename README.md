# Todo

# Documentación del Proyecto

## Enfoque de la solución

La aplicación es un sistema de gestión de Todos que permite la autenticación y autorización a través de un mecanismo de login. Los usuarios pueden iniciar sesión proporcionando su nombre de usuario y contraseña, y el sistema valida sus credenciales contra la base de datos.

El proyecto está desarrollado utilizando **ASP.NET Core**, una arquitectura **Clean Architecture** para estructurar la lógica del negocio, y **Entity Framework Core** para la interacción con la base de datos. La base de datos se utiliza para almacenar los detalles de los Todo y los usuarios.

### Tecnologías utilizadas:
- **ASP.NET Core** para la creación del API RESTful.
- **Entity Framework Core** para la persistencia de datos en la base de datos.
- **SQL Server** como base de datos.
- **JWT** para autenticación y autorización.

### Arquitectura de la aplicación:
- La aplicación sigue una arquitectura **Clean Architecture**, separando las responsabilidades entre las capas:
  - **Capa de presentación**: Controles HTTP (API Controllers).
  - **Capa de dominio**: Lógica de negocio.
  - **Capa de infraestructura**: Interacción con la base de datos y la inversion de control.
  - **Capa de servicios**: Manejo de la lógica de validación y autenticación.

## Cumplimiento de los Requisitos

La aplicación cumple con los siguientes requisitos planteados por la empresa:

- **Autenticación y autorización**: Se implementó un sistema de login con validación de usuario mediante nombre de usuario y contraseña. La seguridad se refuerza mediante la validación contra una base de datos y el uso de **JWT** para la autorización en endpoints protegidos.
  
- **Interacción con la base de datos**: Utilizando **Entity Framework Core**, la aplicación puede acceder y gestionar los datos de los Todo de forma eficiente.

- **Escalabilidad**: La solución está diseñada para ser escalable, utilizando prácticas de arquitectura limpia y otros principios de codigo limpio y buenas practicas que permiten añadir más funcionalidades sin comprometer el código existente.

- **Mantenibilidad**: La aplicación está diseñada para facilitar su mantenimiento y extensión. La arquitectura modular y la separación de responsabilidades permiten agregar nuevas características y realizar ajustes de manera eficiente.

- **Pruebas unitarias**: Se implementaron pruebas unitarias para garantizar la correcta ejecución de los componentes individuales de la aplicación, asegurando que cada módulo funcione de manera aislada y que el sistema en su conjunto cumpla con los requisitos de la empresa.
  
- **Funcionalidad**: La solucion cuenta con varios endpoint los cuales permiten realizar las operaciones necesarias para los Todo que van desde su creacion, actualizacion, cambio de estados, aceptacion de Todo pendientes y la eliminacion, adicional a esto cuenta con seguridad mediante JWT.

## Instrucciones para ejecutar y probar la aplicación

### Requisitos previos:
- **.NET 8.0**.
- **SQL Server** para la base de datos.
- **Postman** para probar los servicios.

### Configuración del proyecto:

1. **Clonar el repositorio**:

   Clónalo usando Git:

   git clone (https://github.com/carlosriosdes/Todo.git)

2. **Configurar cadena de conexion**:
   
   configurar la cadena SqlConecctionTodoApp en el archivo appsettings.json, importante contar con un login en SQL para poder adicionarlo a la cadena
   
3. **Configurar la base de datos**:
   Por temas de tiempo no alcance a realizar los crud para los estados y usuarios, pero dejo evidencia de como se deberian de ver las tablas, los campos se pueden ingresar por medio del editor de consultas de SQL.
   
   la tabla TodoStates debe contener la siguiente informacion 
   IdTodoState	Description
      1	          Todo
      2	          Doing
      3	          Done
   
   la tabla User debe contener al menos un usuario para poder acceder a la aplicacion
   
   IdUser	Name	Email	UserName	Password	Role
    1	Carlos	carlos@gmail.com	carlos	carlos	Admin

### Probar la aplicación:

1. **Ejecutar la aplicacion**:
   * Luego de ejecutar la aplicacion podras visualizar los endpoints disponibles y podras copiarlos para trabajar con ellos en Postman.
   * Ejecutar el login en enpoint /api/Auth/Login, este es para poder tener acceso al token que permite poder consultar el resto de las acciones de los Todo.
   * Luego de tener el Token se pueden congifurar el resto de enpoints para los Todo y consumirlos con el token que se genero en el paso anterior, se debe de poner en el header con el key "Authorization" y en el value "Bearer (token generado)"

### Comentarios:

1. Para el tema de seguridad como la cadena de conexion o el key para genera el codigo, se puede utilizar herramientas de seguridad como el KeyVault de azure para no tenerlas harcodeadas en el codigo, lo mismo los mensajes.
2. Tambien se podria anadir un nivel mas en los logs y dejarlos en un archivo o en la nube tambien con Azure u otra plataforma devops.
3. En los Commits tambien se puede leer informacion mas detallada del proceso y lo que contiene la aplicaicon.




























   
