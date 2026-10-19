/*
 * Creado por SharpDevelop.
 * Usuario: estudiante
 * Fecha: 20/5/2025
 * Hora: 19:26
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.Collections;
namespace Biblioteca
{
	/// <summary>
	/// Description of Biblioteca.
	/// </summary>
	public class Biblioteca
	{
		//atributos
		private ArrayList listaSocios;
		private ArrayList listaLibros;
		
		public string nombre;
		
		//Constructor de clase
		public Biblioteca(string nombre)
		{
			listaSocios= new ArrayList();
			listaLibros= new ArrayList();
			Nombre=nombre;
		}
		//Propiedad Nombre
		public string Nombre
		{
			set{nombre=value;}
			get{return nombre;}
		}
		
		//Metodos de libros
		public void agregarLibro(Libro libro) //Recibe un objeto de tipo libro
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
		
		public Libro verlibro(int i)   /*   retorna el libro iesimo*/
		{
			return (Libro)listaLibros[i];
		}
		
		public ArrayList todosLibros()
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
			return listaLibros.Contains(socio);
		}
		
		public Socio verSocios(int k)
		{
			return (Socio)listaSocios[k];
		}
		
		public ArrayList todosSocios()
		{
			return listaSocios;
		}
	}
}

