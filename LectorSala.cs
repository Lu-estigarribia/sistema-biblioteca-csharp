using System;
using System.Collections.Generic;

namespace Biblioteca
{
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

		public void AgregarLibro(Libro libro) 
		{
			if(libro == null)
            {
                throw new ArgumentNullException(nameof(libro));
            }
			if(listaLibroSala.Contains(libro))
			{
				throw new InvalidOperationException("Ya tiene ese libro prestado.");
			}
			else
			{
				if(listaLibroSala.Count < limiteLibros)
				{
					listaLibroSala.Add(libro);
				}
				else
				{
					throw new InvalidOperationException("No se puede prestar el libro.");
				}
			}
		}
		
		public void EliminarLibro(Libro libro)
		{
			if(libro == null)
            {
                throw new ArgumentNullException(nameof(libro));
            }
			if(listaLibroSala.Contains(libro))
			{
				listaLibroSala.Remove(libro);
			}
			else
			{
				throw new InvalidOperationException("El lector no tiene ese libro.");
			}
			
		}

	}
}
