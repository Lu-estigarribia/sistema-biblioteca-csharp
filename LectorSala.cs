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
	public class LectorSala : Socio
	{ private List<Libro> listaLibroSala;
		
		public LectorSala(int dni, string nombre, string apellido, int telefono,string direccion) : base(dni, nombre, apellido, telefono,direccion)
		{
			this.listaLibroSala = new List<Libro>();
			this.limiteLibros=5;
		}
		
		public IReadOnlyList<Libro> LibrosSala
        {
            get { return listaLibroSala.AsReadOnly(); }
        }

		public void agregarLibro(Libro libro) 
		{
			if(listaLibroSala.Contains(libro))
			{
				Console.Write("Ya tiee ese libro prestado");
			}
			else
			{
				if(listaLibroSala.Count < limiteLibros)
				{
					listaLibroSala.Add(libro);
				}
				else
				{
					Console.Write("no puede prestarse");
				}
			}
		}
		
		public void eliminarLibro(Libro libro)
		{
			if(listaLibroSala.Contains(libro))
			{
				listaLibroSala.Remove(libro);
			}
			else
			{
				Console.Write("El socio no tiene ese libro");
			}
			
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

	}
}
