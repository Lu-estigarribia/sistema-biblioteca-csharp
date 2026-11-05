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
			return (Libro)listaLibros[i];
		}
		
		public List<Libro> todosLibros()
		{
			return listaLibros;
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
			return (Socio)listaSocios[k];
		}
		
		public List<Socio> todosSocios()
		{
			return listaSocios;
		}

		public void agregarPrestamo(Prestamo prestamo)
        {
            listaPrestamos.Add(prestamo);
        }

        public int cantidadPrestamos()
        {
           return listaPrestamos.Count;
		}

        public List<Prestamo> todosPrestamos()
        {
            return listaPrestamos;
        }       
	}
}

