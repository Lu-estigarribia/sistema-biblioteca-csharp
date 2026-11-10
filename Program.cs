/*
 * Creado por SharpDevelop.
 * Usuario: estudiante
 * Fecha: 20/5/2025
 * Hora: 19:25
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.Collections.Generic;

namespace Biblioteca
{
	class Program
	{
		public static void Main(string[] args)
		{
			Biblioteca biblio=new Biblioteca("Biblioteca Hedwig");
			Console.WriteLine(biblio.Nombre);
			
			/*/CREACION DE OBJETOS PARA EJECUTAR
				/*/
			Libro l1=new Libro(1,"bridgerton", "julia quinn2", "jacobo");
			biblio.agregarLibro(l1);
			Libro l2=new Libro(2,"el principito", "erika", "unaj");
			biblio.agregarLibro(l2);
			Socio s1=new Socio(45678903,"mauro", "escobar",112345654,"calchaqui");
			biblio.agregarsocio(s1);
			Socio s2=new Socio(32456900,"laura", "gallo", 1189076579,"belgrano");
			biblio.agregarsocio(s2);
			
			
			int opcion=-1;
			
			do
			{
				Console.WriteLine("MENU DE OPCIONES");
				Console.WriteLine("1. Agregar un nuevo libro");
				Console.WriteLine("2. Eliminar un libro");
				Console.WriteLine("3. Alta socio");
				Console.WriteLine("4. Baja socio");
				Console.WriteLine("5. Prestar libro");
				Console.WriteLine("6. Devolver libro");
				Console.WriteLine("7. Listados");
				Console.WriteLine("0. Salir");
				
				
				try
				{
					opcion = int.Parse(Console.ReadLine());
					switch(opcion)
					{
						case 1:
							agregarnuevoLibro(biblio);
							break;
						case 2:
							eliminarunLibro(biblio);
							break;
						case 3:
							agregarSocio(biblio);
							break;
						case 4:
							darBajasocio( biblio);
							break;
						case 5:
							prestarUnlibro(biblio);
							break;
						case 6:
							devolverLibro(biblio);
							break;
						case 7:
							listados(biblio);
							break;
							
							
					}
					
				}
				catch(Exception ex)
				{
					Console.WriteLine(ex.Message); //mostrar el error
				}
				
			}while(opcion!=0);
			
			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
		//FUNCIONES FUERA DEL MAIN!!!!
		//1)
		

		static int generadorCodigo(Biblioteca bibli)
		{
			int codigo=0;
			foreach(Libro libri in bibli.ListaLibros){
				if(libri.Codigo>codigo){
					codigo=libri.Codigo;
					
				}
			}
			return codigo +1;
		}
		
		
		//1.5)
		static void agregarnuevoLibro(Biblioteca biblioteca)
		{
			int codigo=generadorCodigo(biblioteca );
			Console.Write("Ingrese el titulo del nuevo libro:");
			string titulo=Console.ReadLine();
			Console.Write("Ingrese el autor del nuevo libro:");
			string autor=Console.ReadLine();
			Console.Write("Ingrese la editorial del nuevo libro:");
			string editorial= Console.ReadLine();
			
            Libro libroNuevo= new Libro(codigo,titulo,autor,editorial);
			biblioteca.agregarLibro(libroNuevo);
			Console.WriteLine("El libro fue agregado con exito");
			
		}

		//2)
		public static void eliminarunLibro(Biblioteca biblioteca)
		{
			foreach(Libro libri in biblioteca.ListaLibros)
			{
				Console.WriteLine("Libros a eliminar :"+ " "+"codigo: "+ libri.Codigo+" " + "nombre: "+libri.Titulo);
			}
			Console.Write("Ingrese el código del libro a eliminar:");
			int codigoLibro = int.Parse(Console.ReadLine());
			
			Libro libroEncontrado=biblioteca.buscarLibro(codigoLibro);

			if(libroEncontrado.EstadoLibro==EstadoLibro.Prestado)
			{
				Console.WriteLine("No se puede eliminar el libro porque esta prestado.");
			}
			else
			{
				biblioteca.eliminarLibro(libroEncontrado);
				Console.WriteLine("Libro eliminado con exito.");
			}
		}
		
		
		//3)
		public static void agregarSocio(Biblioteca biblioteca)
		{
			Console.Write("Ingrese D.N.I:");
			int dni = int.Parse(Console.ReadLine());
			Console.Write("Ingrese su nombre:");
			string nombre = Console.ReadLine();
			Console.Write("Ingrese apellido:");
			string apellido = Console.ReadLine();
			Console.Write("Ingrese telefono:");
			int telefono = int.Parse(Console.ReadLine());
			Console.Write("Ingrese direccion:");
			string direccion = Console.ReadLine();
			Console.Write("¿Es lector de sala? (si/no): ");
			string esLectorDeSala=Console.ReadLine().ToLower();
			
			if(esLectorDeSala=="si")
			{
				LectorSala lectorSala = new LectorSala(dni, nombre, apellido, telefono, direccion);
				biblioteca.agregarsocio(lectorSala);
				Console.WriteLine("Lector de sala agregado con exito.");
			}
			else if(esLectorDeSala== "no")
			{
				Socio socio = new Socio(dni, nombre, apellido, telefono, direccion);
				biblioteca.agregarsocio(socio);
				Console.WriteLine("Socio agregado con exito.");
			}
			else
			{  
				Console.WriteLine("Error ingrese un caracter valido.");
			}
		}
		
		//4)
		public static void darBajasocio(Biblioteca biblioteca)
		{
			foreach(Socio soci in biblioteca.ListaSocios)
			{
				Console.WriteLine("Los D.N.I de los socios:" + " " +soci.Dni);
			}
			Console.WriteLine("Ingrese el D.N.I del socio a dar de baja");
			int documento = int.Parse(Console.ReadLine());
			
			Socio socioEncontrado=biblioteca.buscarSocio(documento);
			
			biblioteca.bajasocio(socioEncontrado);
			Console.Write("Socio eliminado con exito.");
		}
		
		//5)
		static void prestarUnlibro(Biblioteca biblioteca)
		{
			Console.WriteLine("Ingrese el D.N.I del socio solicitante");
			int documento = int.Parse(Console.ReadLine());
			biblioteca.buscarSocio(documento);
			Console.WriteLine("Ingrese el codigo del libro");
			int codigoLibro = int.Parse(Console.ReadLine());
			biblioteca.buscarLibro(codigoLibro);

			Console.WriteLine("Seleccione el tipo de prestamo:");
			Console.WriteLine("1. Prestamo a domicilio.");
			Console.WriteLine("2. Prestamo en sala.");
			int opcion=int.Parse(Console.ReadLine());

			TipoPrestamo tipo;
			switch(opcion)
			{
				case 1:
					tipo=TipoPrestamo.Domicilio;
					break;
				case 2:
					tipo=TipoPrestamo.Sala;
					break;
				default:
					throw new ArgumentException("Opcion invalida.");
			}
			biblioteca.prestarLibro(documento,codigoLibro,tipo);
			Console.WriteLine("Libro Prestado con exito.");
		}

		//6)
		static void devolverLibro(Biblioteca biblioteca)
		{
			Console.WriteLine("Ingrese el D.N.I del socio solicitante");
			int documento = int.Parse(Console.ReadLine());
			Console.WriteLine("Ingrese el codigo del libro");
			int codigoLibro = int.Parse(Console.ReadLine());

			biblioteca.DevolverLibro(documento,codigoLibro);
			Console.WriteLine("Libro devuelto con exito.");
		}
		
		//7)
		static void listados(Biblioteca biblioteca)
		{
			int opcion;
			do
			{
				Console.WriteLine("1.Lista con los libros prestados.");
				Console.WriteLine("2.Lista de libros en la biblioteca.");
				Console.WriteLine("3.Lista de socios.");
				Console.WriteLine("4.Historial de prestamos.");
				Console.WriteLine("5. Volver al menu principal.");
				Console.WriteLine("Ingrese una opcion");
				opcion = int.Parse(Console.ReadLine());

				switch (opcion)
				{
					case 1:
						bool haypres = false;

                        foreach (Libro libro in biblioteca.ListaLibros)
                        {
                           if (libro.EstadoLibro == EstadoLibro.Prestado)
                           {
                                Console.WriteLine("Código: " + libro.Codigo +
                                                ", Título: " + libro.Titulo +
                                                ", Autor: " + libro.Autor);
												haypres = true;
							}
						}
						if (!haypres)
						{
							Console.WriteLine("No hay libros prestados.");
						}
						break;
					case 2:
						Console.WriteLine("Todos los libros:");;
						if (biblioteca.ListaLibros.Count == 0)
						{
							Console.WriteLine("No hay libros cargados.");
						}
						else
						{
							foreach (Libro libro in biblioteca.ListaLibros)
							{
								Console.WriteLine("Código: " + libro.Codigo + ", Título: " + libro.Titulo + ", Autor: " + libro.Autor + ", Estado: " + libro.EstadoLibro);
							}
						}
						break;

					case 3:
						Console.WriteLine("Todos los socios:");
						if (biblioteca.ListaSocios.Count == 0)
						{
							Console.WriteLine("No hay socios cargados.");
						}
						else
						{
							foreach (Socio socio in biblioteca.ListaSocios)
							{
								Console.WriteLine("DNI: " + socio.Dni + ", Nombre: " + socio.Nombre + " " + socio.Apellido + ", Teléfono: " + socio.Telefono + ", Libros Prestados: " + biblioteca.contadorPrestamosActivos(socio));
							}
						}
						break;
					case 4:
					Console.WriteLine("Historial de préstamos:");
					foreach (Prestamo pres in biblioteca.ListaPrestamos)
					{
						Console.WriteLine(
							"Socio: " + pres.Socio.Dni +
							" - Libro: " + pres.Libro.Titulo +
							" - Fecha préstamo: " + pres.FechaPrestamo +
							" - Fecha devolución: " +
							(pres.FechaDevolucionReal?.ToString() ?? "Pendiente"));
					}
                    break;
				}
			} while (opcion!= 5);
		}
	}
}