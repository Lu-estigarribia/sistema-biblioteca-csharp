📚 Biblioteca Hedwig
Descripción del proyecto

Biblioteca Hedwig es un sistema de gestión de bibliotecas desarrollado en C# y .NET, mediante una aplicación de consola.

El proyecto surgió inicialmente como un trabajo universitario para la aprobación de una materia. Posteriormente, decidí retomarlo y transformarlo en un proyecto personal para mi portafolio, con el objetivo de mejorar su estructura, incorporar nuevas funcionalidades y aplicar los conocimientos adquiridos durante mi formación en Ingeniería en Informática.

El sistema permite administrar libros, socios, préstamos y devoluciones, aplicando diferentes reglas de negocio para mantener la integridad de los registros.

Funcionalidades

Gestión de libros: registro, consulta y eliminación de libros, con generación automática de códigos únicos.
Gestión de socios: registro y baja de socios, con validación de DNI duplicados.
Préstamos a domicilio: asignación de libros a socios, con un plazo estimado de devolución de 15 días.
Préstamos en sala: gestión de libros destinados a la lectura dentro de la biblioteca.
Control de disponibilidad: actualización de los estados Disponible y Prestado.
Validación de préstamos: control de límites según el tipo de socio y prevención de préstamos no permitidos.
Devoluciones: registro de la fecha real de devolución y actualización de la disponibilidad.
Historial de préstamos: consulta de operaciones realizadas, incluyendo préstamos activos y finalizados.
Manejo de excepciones: validación de datos y control de operaciones inválidas.

Tecnologías y conceptos aplicados

Tecnologías

C#
.NET
Git y GitHub
Visual Studio Code

Conceptos de programación

Programación Orientada a Objetos (POO)
Encapsulamiento
Herencia
Clases, objetos y constructores
Colecciones genéricas
Propiedades y métodos
Manejo de excepciones
Validación de datos
Separación de responsabilidades
Estructura del proyecto

El sistema está organizado en cinco clases principales:
Biblioteca: Administra los libros, socios y préstamos. Coordina las operaciones y valida las reglas del sistema.
Libro: Representa un libro, almacena sus datos y controla su disponibilidad.
Socio: Representa un socio de la biblioteca, incluyendo sus datos personales y límite de préstamos.
LectorSala: Hereda de socio y representa a los usuarios que utilizan los libros dentro de la biblioteca.
Préstamo: Registra la relación entre socio y libro,la modalidad del préstamo y las fechas correspondientes.
Además, Program.cs contiene el menú interactivo y gestiona la comunicación con el usuario.

Instalación y ejecución

Requisitos previos
Para ejecutar el proyecto es necesario tener instalado:
.NET SDK, compatible con la versión del proyecto (actualmente .NET 10).
Un editor de código como Visual Studio Code (opcional).
Git (opcional, para clonar el repositorio).
1. Clonar el repositorio
Abrir una terminal y ejecutar:
git clone https://github.com/Lu-estigarribia/sistema-biblioteca-csharp.git
2. Acceder al proyecto
cd sistema-biblioteca-csharp
Ubicarse en la carpeta que contiene el archivo .csproj.
3. Compilar
dotnet build
4. Ejecutar
dotnet run
El programa mostrará un menú interactivo desde el cual se podrán administrar libros, socios, préstamos y devoluciones.

Estado actual

El proyecto cuenta con una versión funcional de consola, con operaciones de gestión y validaciones de datos.
El sistema almacena los datos temporalmente en memoria. Al iniciar la aplicación, la biblioteca comienza sin registros y permite cargar libros y socios desde el menú interactivo. 

Mejoras futuras

Incorporar una base de datos para almacenar la información de manera persistente.
Implementar una interfaz gráfica para mejorar la experiencia del usuario.
Ampliar las opciones de consulta y administración del sistema.

Sobre el desarrollo
La evolución de Biblioteca Hedwig me permitió retomar un proyecto académico, identificar aspectos que podían mejorarse y aplicar nuevos conocimientos para reorganizar el código y desarrollar una solución más completa.
El proceso representó una oportunidad para fortalecer mis habilidades en C#, programación orientada a objetos, resolución de problemas y mantenimiento de software.
