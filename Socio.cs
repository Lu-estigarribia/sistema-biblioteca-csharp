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
		protected int limiteLibros;
	
		
		//Constructor Socio
		public Socio(int dni, string nombre, string apellido, int telefono, string direccion)
		{
			if(dni<=0)
			{
				throw new ArgumentOutOfRangeException(nameof(dni),"El dni no puede ser 0");
			}
			this.dni=dni;
			Nombre = nombre;
			Apellido = apellido;
			Telefono = telefono;
			Direccion = direccion;
			this.limiteLibros=1;
		}
		
		//Propiedades
		public int Dni
		{
			get{return dni;}
		}

		public int Telefono
		{
			set{if(value<=0)
				{
					throw new ArgumentOutOfRangeException(nameof(value),"El telefono no debe ser 0.");
				}
				telefono=value;
			}
			get{return telefono;}
		}

		public string Nombre
		{
			set{if(string.IsNullOrWhiteSpace(value))
				{
					throw new ArgumentException("El nombre no puede estar vacío.");
				}
				nombre=value;
			}
			get{return nombre;}
		}

		public string Apellido
		{
			set{if(string.IsNullOrWhiteSpace(value))
				{
					throw new ArgumentException("El apellido no puede estar vacio.");
				}
				apellido=value;
			}
			get{return apellido;}
		}

		public string Direccion
		{
			set{if(string.IsNullOrWhiteSpace(value))
				{
					throw new ArgumentException("La direccion no debe estarvacia");
				}
				direccion=value;
			}
			get{return direccion;}
		}

        public int LimiteLibros
		{
			get{return limiteLibros;}
		}     

		
	}
}
