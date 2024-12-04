SkyJet Airlines

Descripción del Proyecto

SkyJet Airlines es un sistema diseñado para gestionar de manera eficiente las operaciones de una aerolínea. El proyecto incluye funcionalidades que requieren una base de datos configurada correctamente y un ajuste personalizado de la cadena de conexión en el código fuente.

Configuración del Proyecto

Paso 1: Importar la Base de Datos

Navega a la carpeta BD en la raíz del proyecto.

Encuentra el archivo de la base de datos (por ejemplo, SkyJet.sql).

Importa este archivo a tu gestor de bases de datos (como MySQL Workbench o SQL Server Management Studio).

Asegúrate de que la base de datos importada tenga el nombre exacto SkyJet.

Paso 2: Configurar la Cadena de Conexión

Localiza la clase Conexión en el proyecto, dentro de la biblioteca de clases DLL Datos.

Abre el archivo correspondiente.

Busca la cadena de conexión predeterminada.

Reemplázala con los valores que correspondan a tu entorno local (servidor, usuario, contraseña, etc.). Por ejemplo:

public string connectionString = "Server=localhost;Database=SkyJet;User Id=tu_usuario;Password=tu_contraseña;";

Guarda los cambios y recompila el proyecto si es necesario.

Requisitos Previos

Gestor de bases de datos compatible: MySQL, SQL Server u otro según el script de la base de datos.

Entorno de desarrollo: Visual Studio o similar.

Conexión a internet: Opcional, para descargar dependencias.

Ejecución del Proyecto

Importa la base de datos como se indica en el Paso 1.

Configura la cadena de conexión como se detalla en el Paso 2.

Compila y ejecuta el proyecto desde tu entorno de desarrollo.

Verifica que la conexión a la base de datos sea exitosa antes de usar las funcionalidades del sistema.
