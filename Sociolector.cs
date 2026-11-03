/*
 * Creado por SharpDevelop.
 * Usuario: estudiante
 * Fecha: 20/5/2025
 * Hora: 20:13
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.Collections.Generic;

namespace Biblioteca
{
	/// <summary>
	/// Description of Sociolector.
	/// </summary>
	public class Sociolector : Socio
	{ private List<Libro> listaLibroSala;
		
		public Sociolector(int dni, string nombre, string apellido, int telefono,string direccion, int cantLibrospres, Libro libroPres) : base(dni, nombre, apellido, telefono,direccion, cantLibrospres, libroPres)
		{
			this.listaLibroSala = new List<Libro>();
		}
		
		public List<Libro> librosSala()
		{
			return listaLibroSala;
		}
		public void agregarLibro(Libro libro) 
		{
			listaLibroSala.Add(libro);
		}
		
		public void eliminarLibro(Libro libro)
		{
			listaLibroSala.Remove(libro);
		}
		
		public int cantidadLibros()
		{
			return  listaLibroSala.Count;
		}
		
		public bool existeLibro(Libro libro)
		{
			return listaLibroSala.Contains(libro);
		}
		
		public Libro verlibro(int i)   
		{
			return (Libro)listaLibroSala[i];
		}
		
		public List<Libro> todosLibros()
		{
			return listaLibroSala;
		}
		
	}
}
