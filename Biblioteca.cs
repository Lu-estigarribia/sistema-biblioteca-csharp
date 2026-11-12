using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Biblioteca
{
	/// <summary>
	/// Description of Biblioteca.
	/// </summary>
	public class Biblioteca
	{
		private List<Socio> listaSocios;
		private List<Libro>listaLibros;
		private List<Prestamo> listaPrestamos;
		private string nombre;
		
		public Biblioteca(string nombre)
		{
			listaSocios= new List<Socio>();
			listaLibros= new List<Libro>();
			listaPrestamos=new List<Prestamo>();
			Nombre=nombre;
		}
		public string Nombre
		{
			set{nombre=value;}
			get{return nombre;}
		}
		
		public void AgregarLibro(Libro libro)
		{
			if (libro == null)
			{
				throw new ArgumentNullException(nameof(libro));
			}
			
			foreach (Libro lib in listaLibros)
			{
				if (lib.Codigo == libro.Codigo)
				{
					throw new InvalidOperationException("No se puede repetir el código del libro.");
				}
			}
			listaLibros.Add(libro);
		}
		
		public void EliminarLibro(Libro libro)
		{
			if(libro==null)
			{
				throw new ArgumentNullException(nameof(libro));
			}
			if(libro.EstadoLibro==EstadoLibro.Prestado)
			{
				throw new InvalidOperationException("No se pueden eliminar libros prestados.");
			}
			listaLibros.Remove(libro);
		}
		
		
		//propiedad que permite solo leer a lista
		public IReadOnlyList<Libro> ListaLibros
		{
			get{return listaLibros.AsReadOnly();}
		}

		//Metodos socios
		public void AgregarSocio(Socio socio)
		{
			if(socio==null)
			{
				throw new ArgumentNullException(nameof(socio));
			}
			foreach(Socio soc in listaSocios)
			{
				if(soc.Dni==socio.Dni)
				{
					throw new InvalidOperationException("No se puede repetir el DNI del socio.");
				}
			}
			listaSocios.Add(socio);
		}
		
		public void BajaSocio(Socio socio)
		{
			if (ContadorPrestamosActivos(socio) > 0)
            {
                throw new InvalidOperationException("No se puede eliminar el socio porque tiene préstamos activos.");
            }
			listaSocios.Remove(socio);
		}
		
		//propiedad que permite solo leer a lista
		public IReadOnlyList<Socio> ListaSocios
		{
			get{return listaSocios.AsReadOnly();}
		}

        public int CantidadPrestamos()
        {
           return listaPrestamos.Count;
		}

        public IReadOnlyList<Prestamo> ListaPrestamos
        {
            get{return listaPrestamos.AsReadOnly();}
        }       

		public int ContadorPrestamosActivos(Socio socio)
		{
			int contador=0;

			foreach(Prestamo pres in listaPrestamos)
			{
				if(pres.Socio.Dni==socio.Dni)
				{
					if(pres.FechaDevolucionReal==null)
					{
						contador++;
					}
				}
			}

			return contador;
		}

		public Socio BuscarSocio(int dni)
		{
			Socio socioEncontrado=null;
			foreach(Socio soc in listaSocios)
			{
				if(soc.Dni==dni)
				{
					socioEncontrado=soc;
					break;
				}
			}
			if(socioEncontrado==null)
			{
				throw new InvalidOperationException("El socio no esta registrado");			
			}

			return socioEncontrado;
		}

		public Libro BuscarLibro(int codigolibro)
		{
			Libro libroEncontrado=null;

			foreach(Libro lib in listaLibros)
			{
				if(lib.Codigo==codigolibro)
				{
					libroEncontrado=lib;
					break;
				}
			}
			if(libroEncontrado==null)
			{
				throw new InvalidOperationException("El libro no esta registrado.");
			}

			return libroEncontrado;
		}

		public void PrestarLibro(int dni, int codigolibro, TipoPrestamo tipo)
		{
			Socio socioEncontrado=BuscarSocio(dni);
			Libro libroEncontrado=BuscarLibro(codigolibro);
			
			//validaciones reueridas para prestar el libro
			if(ContadorPrestamosActivos(socioEncontrado)>=socioEncontrado.LimiteLibros)
			{
				throw new InvalidOperationException("Limite de prestamos alcanzado.");
			}

			if(libroEncontrado.EstadoLibro==EstadoLibro.Prestado)
			{
			    throw new InvalidOperationException("el libro no esta disponible");		
		    }	

			if(socioEncontrado is LectorSala && tipo==TipoPrestamo.Domicilio)
			{
				throw new InvalidOperationException("Un lector de sala no puede solicitar préstamos a domicilio.");
			}

			if(!(socioEncontrado is LectorSala) && tipo==TipoPrestamo.Sala)
			{
				throw new InvalidOperationException("Un socio común no puede solicitar préstamos de sala.");
            }

			if (tipo != TipoPrestamo.Domicilio && tipo != TipoPrestamo.Sala)
            {
                throw new ArgumentException("Tipo de préstamo inválido.");
            }

			Prestamo pres=new Prestamo(socioEncontrado,libroEncontrado,tipo);
			if (socioEncontrado is LectorSala lector)
            {
               lector.AgregarLibro(libroEncontrado);
            }
			libroEncontrado.MarcarPrestado();
			listaPrestamos.Add(pres);	
		}

		public void DevolverLibro(int dni, int codigolibro)
		{
			Socio socioEncontrado=BuscarSocio(dni);
			Libro libroEncontrado=BuscarLibro(codigolibro);
			Prestamo prestamoEncontrado=null;

			foreach(Prestamo pres in listaPrestamos)
			{
				if(pres.Socio.Dni==dni && pres.Libro.Codigo==codigolibro && pres.FechaDevolucionReal==null)
				{
					prestamoEncontrado=pres;
					break;
				}
			}
			if(prestamoEncontrado==null)
			{
				throw new InvalidOperationException("Prestamo no existe");
			}

			if (libroEncontrado.EstadoLibro != EstadoLibro.Prestado)
            {
               throw new InvalidOperationException("El libro no figura como prestado.");
            }  

			if (socioEncontrado is LectorSala lector)
            {
                lector.EliminarLibro(libroEncontrado);
            }

			prestamoEncontrado.Devolver();
			libroEncontrado.MarcarDisponible();
		}
				
	}
}

