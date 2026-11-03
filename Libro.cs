/*
 * Creado por SharpDevelop.
 * Usuario: estudiante
 * Fecha: 20/5/2025
 * Hora: 19:30
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;

namespace Biblioteca
{
	/// <summary>
	/// Description of Libro.
	/// </summary>
	public class Libro
	{
		private int codigo;
		private string titulo;
		private string autor;
		private string editorial;
		private DateTime fechaPrestamo;
		private DateTime fechaDevolucion;
		private string estadoLibro;
		private int dnisocioPres;
		
		//Constructor Libro
		public Libro(int codigo, string titulo, string autor, string editorial, DateTime fechaPrestamo, DateTime fechaDevolucion,string estadoLibro, int dnisocioPres)
		{
			this.codigo=codigo;
			this.titulo=titulo;
			this.autor=autor;
			this.editorial=editorial;
			this.fechaPrestamo=fechaPrestamo;
			this.fechaDevolucion=fechaDevolucion;
			this.estadoLibro=estadoLibro;
			this.dnisocioPres=dnisocioPres;
		}
		
		//Propiedades
		public int Codigo
		{
			get { return codigo; }
			set { codigo = value; }  // lo di vuelta orque me provocaba un bucle  
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

		public DateTime FechaPrestamo
		{
			set{fechaPrestamo=value;}
			get{return fechaPrestamo;}
		}

		public DateTime FechaDevolucion
		{
			set{fechaDevolucion=value;}
			get{return fechaDevolucion;}
		}
		
		public string EstadoLibro
		{
			set{estadoLibro=value;}
			get{return estadoLibro;}
		}
		
		public int SocioPres
		{
			set{dnisocioPres=value;}
			get{return dnisocioPres;}
		}
		
	}
}
