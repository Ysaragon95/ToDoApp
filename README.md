# Prueba Técnica - Backend .NET 8

Este repositorio contiene la implementación del backend para la aplicación "To-Do List" como parte de la prueba técnica. [cite_start]Se desarrolló utilizando .NET 8 (en lugar de .NET 9 como se especificó en el documento, debido a disponibilidad o preferencia durante el desarrollo), proporcionando una API RESTful para la gestión de tareas y autenticación de usuarios.

## [cite_start]Decisiones Técnicas Tomadas 

* **Framework**: .NET 8 (ASP.NET Core) para el desarrollo de la API RESTful.
* [cite_start]**Autenticación**: Implementación de autenticación basada en JWT (JSON Web Tokens) para asegurar los endpoints.
* [cite_start]**Base de Datos**: Se utilizó Entity Framework Core para la interacción con la base de datos. [cite_start]Para la prueba, se configuró una base de datos en memoria para simplificar la configuración y ejecución inicial, aunque es fácilmente configurable para SQL Server.
* [cite_start]**Validación de Datos**: Se implementó validación de datos en los endpoints para asegurar la integridad de la información.
* [cite_start]**Documentación API**: Se integró Swagger/OpenAPI para documentar los endpoints de la API, facilitando su consumo y prueba.
* [cite_start]**Manejo de Errores**: Implementación de un manejo de errores centralizado para proporcionar respuestas consistentes y útiles al cliente en caso de fallos en la API.
* **Estructura de Proyecto**: Organización del proyecto siguiendo principios de Clean Architecture o Arquitectura en Capas para promover la modularidad, mantenibilidad y escalabilidad.

## [cite_start]Cómo Ejecutar el Proyecto 

### Prerrequisitos

* .NET 8 SDK
* Un IDE como Visual Studio Code o Visual Studio

### Pasos de Ejecución

1.  **Clonar el Repositorio**:
    ```bash
    git clone <URL_DEL_REPOSITORIO_BACKEND>
    cd <NOMBRE_CARPETA_BACKEND>
    ```
2.  **Restaurar Dependencias**:
    ```bash
    dotnet restore
    ```
3.  **Ejecutar la Aplicación**:
    ```bash
    dotnet run
    ```
    La API se iniciará y estará disponible en `https://localhost:70XX` o `http://localhost:5XXX` (los puertos exactos se mostrarán en la consola).

4.  **Acceder a Swagger UI**:
    Una vez que la aplicación esté corriendo, puedes acceder a la documentación interactiva de la API a través de Swagger en:
    `https://localhost:70XX/swagger` (reemplaza 70XX con tu puerto HTTPS)

## [cite_start]Cómo Ejecutar las Pruebas 

[cite_start]Se han implementado pruebas unitarias para al menos un controlador y un servicio.

1.  **Navegar al Directorio de Pruebas**:
    ```bash
    cd <NOMBRE_CARPETA_BACKEND>/<NOMBRE_PROYECTO_PRUEBAS>
    ```
    (Por ejemplo, `cd src/YourApi.Tests` o `cd Tests/YourApi.UnitTests`)
2.  **Ejecutar Pruebas**:
    ```bash
    dotnet test
    ```
