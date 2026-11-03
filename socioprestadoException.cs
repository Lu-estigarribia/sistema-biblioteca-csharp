/*
 * Creado por SharpDevelop.
 * Usuario: estudiante
 * Fecha: 22/5/2025
 * Hora: 09:17
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.Runtime.Serialization;


public class socioprestadoException : Exception
{
    public socioprestadoException() 
        : base("El socio ya tiene un libro prestado, no se pueden prestar más.") 
    { 
    }

    public socioprestadoException(string message) 
        : base(message) 
    { 
    }

    public socioprestadoException(string message, Exception innerException) 
        : base(message, innerException) 
    { 
    }

}
