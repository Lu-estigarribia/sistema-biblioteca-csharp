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
				Libro l1=new Libro(1,"bridgerton", "julia quinn", "jacobo", new DateTime(2008,5,3),new DateTime(2008,5,18), "prestado", 0);
			biblio.agregarLibro(l1);
			Libro l2=new Libro(2,"el principito", "erika", "unaj", new DateTime(2018,12,5), new DateTime(2018,12,15), "disponible", 45678903);
			biblio.agregarLibro(l2);
			Socio s1=new Socio(45678903,"mauro", "escobar",112345654,"calchaqui",0,null);
			biblio.agregarsocio(s1);
			Socio s2=new Socio(32456900,"laura", "gallo", 1189076579,"belgrano",0,null);
			biblio.agregarsocio(s2);
			
			
			int opcion;
			
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
				opcion = int.Parse(Console.ReadLine());
				
				try
				{
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
			foreach(Libro libri in bibli.todosLibros()){
				if(libri.Codigo>codigo){
					codigo=libri.Codigo;
					
				}
			}
			return codigo +1;
		}
		
		
		//1.5)
		static void agregarnuevoLibro(Biblioteca biblioteca)
		{
			int cod=generadorCodigo(biblioteca );
			Console.Write("Ingrese el titulo del nuevo libro:");
			string titulo=Console.ReadLine();
			Console.Write("Ingrese el autor del nuevo libro:");
			string autor=Console.ReadLine();
			Console.Write("Ingrese la editorial del nuevo libro:");
			string edit= Console.ReadLine();
			//fecha prestamo
			DateTime fp= DateTime.MinValue; //Metodo que da una fcha 0/00/00
			//fecha devolucion
			DateTime fv= DateTime.MinValue;
			string estado=" ";
			while (estado ==" ")
			{
				Console.WriteLine("Estado del libro  ");
				Console.WriteLine("1.Disponible");
				Console.WriteLine("2.Prestado");
				Console.Write("Seleccione una opción (1 o 2): ");
				
				int opcionEstado = int.Parse(Console.ReadLine());
				switch(opcionEstado)
				{
					case 1:
						estado = "disponible";
						Libro libronue= new Libro(cod,titulo,autor,edit,fp,fv,estado,0);
						//Llamo al metdo de la clase para agregar libro
						biblioteca.agregarLibro(libronue);
						Console.WriteLine("El libro fue agregado con exito");
						break;
					case 2:
						estado = "prestado";
						Console.Write("Ingrese el DNI del socioal que se presto: ");
						int dnisocio= int.Parse(Console.ReadLine());
						Libro libronuevo= new Libro(cod,titulo,autor,edit,fp,fv,estado,dnisocio);
						//Llamo al metdo de la clase para agregar libro
						biblioteca.agregarLibro(libronuevo);
						Console.WriteLine("El libro fue agregado con exito");
						break;
					default:
						Console.WriteLine("Opción inválida. Intente de nuevo.");
						break;
				}
				
			}
			
			
		}

		//2)
		public static void eliminarunLibro(Biblioteca biblioteca)
		{
			foreach(Libro libri in biblioteca.todosLibros())
			{
				Console.WriteLine("Libros a eliminar :"+ " "+"codigo: "+ libri.Codigo+" " + "nombre: "+libri.Titulo);
			}
			Console.Write("Ingrese el código del libro a eliminar:");
			int codigoLibro = int.Parse(Console.ReadLine());
			bool libroEncontrado = false;

			foreach (Libro libro in biblioteca.todosLibros())
			{
				if (libro.Codigo == codigoLibro)
				{
					biblioteca.eliminarLibro(libro);
					libroEncontrado = true;
					if(libro.EstadoLibro=="prestado"){
						Console.WriteLine("No se puede eliminar el libro porque esta prestado.");
					}
					else
					{
						biblioteca.eliminarLibro(libro);
						Console.WriteLine("Libro eliminado con exito.");
					}
					break;
				}
			}
			
			if (!libroEncontrado)
			{
				Console.WriteLine("Error: No se encontró el libro con ese código.");
				
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
			Console.Write("Ingrese la cantidad de libros prestados:");
			int librospres=int.Parse(Console.ReadLine());
			Console.Write("¿Es socio lector? (si/no):");
			string esLector = Console.ReadLine();
			
			if(esLector.ToLower() == "si")
			{
				Sociolector sociolec = new Sociolector(dni, nombre, apellido, telefono, direccion, 0, null);
				biblioteca.agregarsocio(sociolec);
				Console.WriteLine("Sociolector agregado con exito.");
			}
			else if(esLector.ToLower() == "no")
			{
				Socio socio = new Socio(dni, nombre, apellido, telefono, direccion, 0, null);
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
			foreach(Socio soci in biblioteca.todosSocios())
			{
				Console.WriteLine("Los D.N.I de los socios:" + " " +soci.Dni);
			}
			Console.WriteLine("Ingrese el D.N.I del socio a dar de baja");
			int documento = int.Parse(Console.ReadLine());
			Socio socito =new Socio(documento,"","",0,"",0,null);
			
			biblioteca.existeSocio(socito);
			foreach (Socio socio in biblioteca.todosSocios())
			{
				if (socio.Dni == documento)
				{
					biblioteca.bajasocio(socio);
					Console.WriteLine("Socio eliminado con exito.");
					break;
				}
			}
		}
		
		//5)
		static void prestarUnlibro(Biblioteca biblioteca)
		{try
			{
				
				
				Console.WriteLine("Ingrese el D.N.I del socio solicitante");
				int docu = int.Parse(Console.ReadLine());
				
				Console.WriteLine("Ingrese el codigo del libro");
				int codigoLibro = int.Parse(Console.ReadLine());
				
				//ENCONTRAR AL SOCIO
				bool socioExiste = false;
				Socio socioEncontrado = null;

				foreach (Socio socio in biblioteca.todosSocios())
				{
					if (socio.Dni == docu)
					{
						socioExiste = true;
						socioEncontrado = socio;
						break;
					}
				}

				if (!socioExiste)
				{
					Console.WriteLine("No se encontró el socio. No se puede prestar el libro.");
					return;
				}
				
				//ENCNTRAR EL LIBRO
				Libro libroEncontrado = null;
				foreach (Libro librito in biblioteca.todosLibros())
				{
					if (librito.Codigo == codigoLibro)
					{
						libroEncontrado = librito;
					}
				}
				
				if (libroEncontrado == null)
				{
					Console.WriteLine("No se encontró el libro.");
					return;
				}
				
				if (libroEncontrado.EstadoLibro.ToLower() == "prestado")
				{
					Console.WriteLine("El libro no está disponible para prestar.");
					return;
				}

				
				Console.WriteLine("Es socio lector? (si/no)");
				string socioLector = Console.ReadLine().ToLower();

				if (socioLector == "no")
				{
					if (libroEncontrado.EstadoLibro.ToLower() == "disponible")
					{
						if (socioEncontrado.CantLibrospres == 0)
						{
							socioEncontrado.CantLibrospres++;
							libroEncontrado.EstadoLibro = "prestado";
							libroEncontrado.FechaPrestamo=DateTime.Now;
							libroEncontrado.FechaDevolucion=DateTime.Now.AddDays(15);
							socioEncontrado.LibroPres=libroEncontrado;
							Console.WriteLine("Libro prestado con éxito.");
						}
						else
						{
							throw new socioprestadoException();
						}
						
					}
				}
				if (socioLector == "si")
				{
					if (libroEncontrado.EstadoLibro.ToLower() == "disponible")
					{
						if (socioEncontrado.CantLibrospres == 0)
						{
							socioEncontrado.CantLibrospres++;
							libroEncontrado.EstadoLibro= "prestado";

							if (socioEncontrado is Sociolector)
							{
								Sociolector lector = (Sociolector)socioEncontrado;
								lector.librosSala().Add(libroEncontrado);
							}

							Console.WriteLine("Libro prestado con éxito al socio lector.");
						}
					}
				}
			}catch(socioprestadoException ex)
			{
				Console.WriteLine(ex.Message);
			}
		}

		//6)
		static void devolverLibro(Biblioteca biblioteca)
		{
			Console.WriteLine("Ingrese el D.N.I del socio solicitante");
			int documento = int.Parse(Console.ReadLine());
			
			Console.WriteLine("Ingrese el codigo del libro");
			int codLibro = int.Parse(Console.ReadLine());
			
			Socio socioEncontrado = null;
			foreach (Socio socio in biblioteca.todosSocios())
			{
				if (socio.Dni == documento)
				{
					socioEncontrado = socio;
				}
			}
			if (socioEncontrado == null)
			{
				Console.WriteLine("No se encontró el socio.");
			}
			
			
			Libro libroEncontrado = null;
			foreach (Libro librito in biblioteca.todosLibros())
			{
				if (librito.Codigo == codLibro)
				{
					libroEncontrado = librito;
				}
			}
			
			if (libroEncontrado == null)
			{
				Console.WriteLine("No se encontró el libro.");
			}
			
			Console.WriteLine("Es socio lector? (si/no)");
			string socioLector = Console.ReadLine().ToLower();

			if (socioLector == "no")
			{
				if (libroEncontrado.EstadoLibro.ToLower() == "prestado")
				{
					if (socioEncontrado.CantLibrospres == 1)
					{
						socioEncontrado.CantLibrospres--;
						libroEncontrado.EstadoLibro = "disponible";
						libroEncontrado.FechaPrestamo=DateTime.MinValue;
						libroEncontrado.FechaDevolucion=DateTime.Now;
						Console.WriteLine("Libro devuelto con éxito.");
					}
				}
			}
			if (socioLector == "si")
			{
				if (libroEncontrado.EstadoLibro.ToLower() == "prestado")
				{
					if (socioEncontrado.CantLibrospres <= 15)
					{
						socioEncontrado.CantLibrospres--;
						libroEncontrado.EstadoLibro = "disponible";

						if (socioEncontrado is Sociolector)
						{
							Sociolector lector = (Sociolector)socioEncontrado;
							lector.librosSala().Add(libroEncontrado);
						}

						Console.WriteLine("Libro devuelto con éxito a la biblioteca.");
					}
				}
			}
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
				Console.WriteLine("4. Volver al menu principal.");
				Console.WriteLine("Ingrese una opcion");
				opcion = int.Parse(Console.ReadLine());

				switch (opcion)
				{
					case 1:
						Console.WriteLine("Libros prestados:");
						bool haypres=false;
						foreach (Libro libros in biblioteca.todosLibros())
						{
							if (libros.EstadoLibro.ToLower()=="prestado")
							{
								Console.WriteLine("Código: " + libros.Codigo + ", Título: " + libros.Titulo + ", Autor: " + libros.Autor + ", Estado: " + libros.EstadoLibro);
								haypres=true;
							}
						}
						if (!haypres)
						{
							Console.WriteLine("No hay libros prestados.");
						}
						break;

					case 2:
						Console.WriteLine("Todos los libros:");
						List<Libro> librosTotales = biblioteca.todosLibros();
						if (librosTotales.Count == 0)
						{
							Console.WriteLine("No hay libros cargados.");
						}
						else
						{
							foreach (Libro libro in biblioteca.todosLibros())
							{
								Console.WriteLine("Código: " + libro.Codigo + ", Título: " + libro.Titulo + ", Autor: " + libro.Autor + ", Estado: " + libro.EstadoLibro);
							}
						}
						break;

					case 3:
						Console.WriteLine("Todos los socios:");
						List<Socio> sociosTotales = biblioteca.todosSocios();
						if (sociosTotales.Count == 0)
						{
							Console.WriteLine("No hay socios cargados.");
						}
						else
						{
							foreach (Socio socio in biblioteca.todosSocios())
							{
								Console.WriteLine("DNI: " + socio.Dni + ", Nombre: " + socio.Nombre + " " + socio.Apellido + ", Teléfono: " + socio.Telefono + ", Libros Prestados: " + socio.CantLibrospres);
							}
						}
						break;
				}
			} while (opcion!= 4);
		}
	}
}