 /*
 * Creado por SharpDevelop.
 * Usuario: estudiante
 * Fecha: 20/5/2025
 * Hora: 19:46
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;

namespace Biblioteca
{
	/// <summary>
	/// Description of Socio.
	/// </summary>
	public class Socio
	{
		//Atributos
		protected int dni;
		protected string nombre;
		protected string apellido;
		protected int telefono;
		protected string direccion;
		protected int cantLibrospres;
		private Libro libroPres;
		
		//Constructor Socio
		public Socio(int dni, string nombre, string apellido, int telefono, string direccion, int cantLibrospres, Libro libroPres)
		{
			this.dni=dni;
			this.nombre=nombre;
			this.apellido=apellido;
			this.telefono=telefono;
			this.direccion=direccion;
			this.cantLibrospres=cantLibrospres;
			this.libroPres=libroPres;
		}
		
		//Propiedades
		public int Dni
		{
			get{return dni;}
		}

		public int Telefono
		{
			set{telefono=value;}
			get{return telefono;}
		}

		public string Nombre
		{
			set{nombre=value;}
			get{return nombre;}
		}

		public string Apellido
		{
			set{apellido=value;}
			get{return apellido;}
		}

		public string Direccion
		{
			set{direccion=value;}
			get{return direccion;}
		}

		public int CantLibrospres
		{
			get{return cantLibrospres;}//se modifica mediante metodos
		}
		
		public Libro LibroPres
		{
			get{return libroPres;}
		}
		
	}
}
