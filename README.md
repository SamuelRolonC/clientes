# Clientes

## Requisitos

Para ejecutar la aplicación es necesario tener las siguientes herramientas instaladas.

- SQL Server 2019 (15.X) o superior.
- Microsoft SQL Server Management Studio u otro cliente compatible.
- Visual Studio
- .Net 6.0 o superior
- npm

## Configurar y ejecutar la aplicación

1. Clonar el repositorio.
2. Abrir Microsoft SQL Server Management Studio y conectarse a su instancia de SQL Server.
    - Ejecutar los scripts de la carpeta `.\database\scripts` según el orden del prefijo númerico en el nombre de cada archivo.
3. Abrir el archivo `.\api\Clientes.sln` de proyecto de la API con Visual Studio.
    - Abrir el archivo `app.config` en el proyecto Clientes y configurar el connectionString a la instancia de SQL Server donde está instalada la base de datos 'Clientes'.
    - Asegurarse que el proyecto Clientes sea el `Startup project` y que se ejecute con IIS Express.
    - Ejecutar la solución.
4. Abrir el archivo `.\web-app\src\Utils\useAppParameters.js` y configurar el valor de la variable `apiBaseUrl` con la url de la API de .Net.
5. Abrir una terminal de cmd o powershell y dirigirse al directorio `.\web-app`
    - Ejecutar el comando `npm install` para instalar las dependencias.
    - Ejecutar el comando `npm start` para iniciar la aplicación web.
6. Usar la aplicación
