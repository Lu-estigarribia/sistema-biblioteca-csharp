/*
 * Creado por SharpDevelop.
 * Usuario: estudiante
 * Fecha: 20/5/2025
 * Hora: 19:26
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.Collections.Generic;
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
		
		public void agregarLibro(Libro libro) 
		{
			listaLibros.Add(libro);
		}
		
		public void eliminarLibro(Libro libro)
		{
			listaLibros.Remove(libro);
		}
		
		public int cantidadLibros()
		{
			return  listaLibros.Count;
		}
		
		public bool existeLibro(Libro libro)
		{
			return listaLibros.Contains(libro);
		}
		
		public Libro verlibro(int i)   
		{
			return listaLibros[i];
		}
		
		//propiedad que permite solo leer a lista
		public IReadOnlyList<Libro> ListaLibros
		{
			get{return listaLibros.AsReadOnly();}
		}

		//Metodos socios
		public void agregarsocio(Socio socio)
		{
			listaSocios.Add(socio);
		}
		
		public void bajasocio(Socio socio)
		{
			listaSocios.Remove(socio);
		}
		
		public int cantidadSocios()
		{
			return listaSocios.Count;
		}
		
		public bool existeSocio(Socio socio)
		{
			return listaSocios.Contains(socio);
		}
		
		public Socio verSocios(int k)
		{
			return listaSocios[k];
		}
		
		//propiedad que permite solo leer a lista
		public IReadOnlyList<Socio> ListaSocios
		{
			get{return listaSocios.AsReadOnly();}
		}

		public void agregarPrestamo(Prestamo prestamo)
        {
            listaPrestamos.Add(prestamo);
        }

        public int cantidadPrestamos()
        {
           return listaPrestamos.Count;
		}

        public IReadOnlyList<Prestamo> ListaPrestamos
        {
            get{return listaPrestamos.AsReadOnly();}
        }       

		public int contadorPrestamosActivos(Socio socio)
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

		public Socio buscarSocio(int dni)
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

		public Libro buscarLibro(int codigolibro)
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

		public void prestarLibro(int dni, int codigolibro, TipoPrestamo tipo)
		{
			Socio socioEncontrado=buscarSocio(dni);
			Libro libroEncontrado=buscarLibro(codigolibro);
			
			//validaciones reueridas para prestar el libro
			if(contadorPrestamosActivos(socioEncontrado)>=socioEncontrado.LimiteLibros)
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
               lector.agregarLibro(libroEncontrado);
            }
			libroEncontrado.MarcarPrestado();
			listaPrestamos.Add(pres);	
		}

		public void DevolverLibro(int dni, int codigolibro)
		{
			Socio socioEncontrado=buscarSocio(dni);
			Libro libroEncontrado=buscarLibro(codigolibro);
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
                lector.eliminarLibro(libroEncontrado);
            }

			prestamoEncontrado.Devolver();
			libroEncontrado.MarcarDisponible();
		}
				
	}
}

