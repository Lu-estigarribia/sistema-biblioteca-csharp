using System;
using System.Runtime.CompilerServices;

namespace Biblioteca
{
	public enum EstadoLibro
	{
		Disponible,Prestado
	}
	public class Libro
	{
		private int codigo;
		private string titulo;
		private string autor;
		private string editorial;
		private EstadoLibro estadoLibro;
		
		public Libro(int codigo, string titulo, string autor, string editorial)
		{   
			if(codigo<=0)
			{
				throw new ArgumentOutOfRangeException(nameof(codigo),"El código debe ser mayor que cero.");
			}
			this.codigo=codigo;
			Titulo=titulo;
			Autor=autor;
			Editorial=editorial;
			estadoLibro=EstadoLibro.Disponible;
		}
	
		public int Codigo
		{
			get {return codigo;}
		}

		public string Titulo
		{
			get
			{
				return titulo;
			}
			set
			{
				if(string.IsNullOrWhiteSpace(value))
				{
					throw new ArgumentException("El título no puede estar vacío.");
				}
				titulo=value;
		    }
        }

		public string Autor
		{
			get{return autor;}
			set{
				if(string.IsNullOrWhiteSpace(value))
			    {
				   throw new ArgumentException("El autor no debe ser nulo ni vacio");
			    }
				autor=value;
			   }
			
		}

		public string Editorial
		{
			set{
				if(string.IsNullOrWhiteSpace(value))
			    {
				throw new ArgumentException("La editorial no debe ser nulo ni vacio");
			    }
				editorial=value;
			   }
			get{return editorial;}
		}

		public EstadoLibro EstadoLibro
		{
			get{return estadoLibro;}
		}
		
		public void MarcarPrestado()
		{
			if(estadoLibro==EstadoLibro.Disponible)
			{
				estadoLibro=EstadoLibro.Prestado;
			}
			else
			{
				throw new InvalidOperationException("El libro se encuentra prestado.");
			}
		
	    }

		public void MarcarDisponible()
		{
			if(estadoLibro==EstadoLibro.Prestado)
			{
				estadoLibro=EstadoLibro.Disponible;
			}
			else
			{
				throw new InvalidOperationException("El libro se encuentra disponible.");
			}

		}
	}
}
