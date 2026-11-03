/*
 * Creado por SharpDevelop.
 * Usuario: estudiante
 * Fecha: 20/5/2025
 * Hora: 19:30
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
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
			this.codigo=codigo;
			this.titulo=titulo;
			this.autor=autor;
			this.editorial=editorial;
			estadoLibro=EstadoLibro.Disponible;
		}
	
		public int Codigo
		{
			get {return codigo;}
		}

		public string Titulo
		{
			set{titulo=value;}
			get{return titulo;}
		}

		public string Autor
		{
			set{autor=value;}
			get{return autor;}
		}

		public string Editorial
		{
			set{editorial=value;}
			get{return editorial;}
		}

		public EstadoLibro EstadoLibro
		{
			get{return estadoLibro;}
		}
		
		
	}
}
