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
			
			//Datos iniciales de prueba
			Libro l1=new Libro(1,"bridgerton", "julia quinn2", "jacobo");
			biblio.AgregarLibro(l1);
			Libro l2=new Libro(2,"el principito", "erika", "unaj");
			biblio.AgregarLibro(l2);
			Socio s1=new Socio(45678903,"mauro", "escobar",112345654,"calchaqui");
			biblio.AgregarSocio(s1);
			Socio s2=new Socio(32456900,"laura", "gallo", 1189076579,"belgrano");
			biblio.AgregarSocio(s2);
			
			
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
						case 0:
						    Console.WriteLine("Saliendo del sistema...");
						    break;
						case 1:
							AgregarNuevoLibro(biblio);
							break;
						case 2:
							EliminarUnLibro(biblio);
							break;
						case 3:
							AgregarSocio(biblio);
							break;
						case 4:
							DarBajaSocio( biblio);
							break;
						case 5:
							PrestarUnLibro(biblio);
							break;
						case 6:
							DevolverLibro(biblio);
							break;
						case 7:
							Listados(biblio);
							break;
						default:
						Console.WriteLine("Opción inválida. Intente nuevamente.");
						break;
					}
					
				}
				catch(Exception ex)
				{
					Console.WriteLine(ex.Message); 
				}
				
			}while(opcion!=0);
			
			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
		//FUNCIONES FUERA DEL MAIN!!!!
		//1)
		

		static int GeneradorCodigo(Biblioteca bibli)
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
		static void AgregarNuevoLibro(Biblioteca biblioteca)
		{
			int codigo=GeneradorCodigo(biblioteca );
			Console.Write("Ingrese el titulo del nuevo libro:");
			string titulo=Console.ReadLine();
			Console.Write("Ingrese el autor del nuevo libro:");
			string autor=Console.ReadLine();
			Console.Write("Ingrese la editorial del nuevo libro:");
			string editorial= Console.ReadLine();
			
            Libro libroNuevo= new Libro(codigo,titulo,autor,editorial);
			biblioteca.AgregarLibro(libroNuevo);
			Console.WriteLine("El libro fue agregado con exito");
			
		}

		//2)
		public static void EliminarUnLibro(Biblioteca biblioteca)
		{
			foreach(Libro libri in biblioteca.ListaLibros)
			{
				Console.WriteLine("Libros a eliminar :"+ " "+"codigo: "+ libri.Codigo+" " + "nombre: "+libri.Titulo);
			}
			Console.Write("Ingrese el código del libro a eliminar:");
			int codigoLibro = int.Parse(Console.ReadLine());
			
			Libro libroEncontrado=biblioteca.BuscarLibro(codigoLibro);

			biblioteca.EliminarLibro(libroEncontrado);
			Console.WriteLine("Libro eliminado con exito.");
			
		}
		
		
		//3)
		public static void AgregarSocio(Biblioteca biblioteca)
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
				biblioteca.AgregarSocio(lectorSala);
				Console.WriteLine("Lector de sala agregado con exito.");
			}
			else if(esLectorDeSala== "no")
			{
				Socio socio = new Socio(dni, nombre, apellido, telefono, direccion);
				biblioteca.AgregarSocio(socio);
				Console.WriteLine("Socio agregado con exito.");
			}
			else
			{  
				Console.WriteLine("Error ingrese un caracter valido.");
			}
		}
		
		//4)
		public static void DarBajaSocio(Biblioteca biblioteca)
		{
			foreach(Socio soci in biblioteca.ListaSocios)
			{
				Console.WriteLine("Los D.N.I de los socios:" + " " +soci.Dni);
			}
			Console.WriteLine("Ingrese el D.N.I del socio a dar de baja");
			int documento = int.Parse(Console.ReadLine());
			
			Socio socioEncontrado=biblioteca.BuscarSocio(documento);
			
			biblioteca.BajaSocio(socioEncontrado);
			Console.WriteLine("Socio eliminado con exito.");
		}
		
		//5)
		static void PrestarUnLibro(Biblioteca biblioteca)
		{
			Console.WriteLine("Ingrese el D.N.I del socio solicitante");
			int documento = int.Parse(Console.ReadLine());
			biblioteca.BuscarSocio(documento);
			Console.WriteLine("Ingrese el codigo del libro");
			int codigoLibro = int.Parse(Console.ReadLine());
			biblioteca.BuscarLibro(codigoLibro);

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
			biblioteca.PrestarLibro(documento,codigoLibro,tipo);
			Console.WriteLine("Libro Prestado con exito.");
		}

		//6)
		static void DevolverLibro(Biblioteca biblioteca)
		{
			Console.WriteLine("Ingrese el D.N.I del socio solicitante");
			int documento = int.Parse(Console.ReadLine());
			Console.WriteLine("Ingrese el codigo del libro");
			int codigoLibro = int.Parse(Console.ReadLine());

			biblioteca.DevolverLibro(documento,codigoLibro);
			Console.WriteLine("Libro devuelto con exito.");
		}
		
		//7)
		static void Listados(Biblioteca biblioteca)
		{
			int opcion;
			do
			{
				Console.WriteLine("1.Lista con los libros prestados.");
				Console.WriteLine("2.Lista de libros en la biblioteca.");
				Console.WriteLine("3.Lista de socios.");
				Console.WriteLine("4.Historial de prestamos.");
				Console.WriteLine("5.Volver al menu principal.");
				Console.WriteLine("Ingrese una opcion");
				if (!int.TryParse(Console.ReadLine(), out opcion))
                {
					Console.WriteLine("Debe ingresar un número.");
					continue;
				}
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
						Console.WriteLine("Todos los libros:");
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
								Console.WriteLine("DNI: " + socio.Dni + ", Nombre: " + socio.Nombre + " " + socio.Apellido + ", Teléfono: " + socio.Telefono + ", Libros Prestados: " + biblioteca.ContadorPrestamosActivos(socio));
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
					default:
						Console.WriteLine("Opción inválida. Intente nuevamente.");
						break;
				}
			} while (opcion!= 5);
		}
	}
}