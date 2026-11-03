using System;
using System.Collections.Generic;
using System.Data.Common;

namespace Biblioteca
{
    public class Prestamo
    {
        private Socio socio;
        private Libro libro;
        private DateTime fechaPrestamo;
		private DateTime fechaDevolucionEstimada;
        private DateTime? fechaDevolucionReal;
		
        public Prestamo(Socio socio, Libro libro)
        {
            if(socio==null)
            {
                throw new ArgumentNullException(nameof(socio));
            }

            if(libro==null)
            {
                throw new ArgumentNullException(nameof(libro));
            }
            this.socio=socio;
            this.libro=libro;
            fechaPrestamo=DateTime.Now;
            fechaDevolucionEstimada=fechaPrestamo.AddDays(15);
            fechaDevolucionReal=null;
        }

        public Socio Socio
        {
            get{return socio;}
        }

        public Libro Libro
        {
            get{return libro;}
        }

        public DateTime FechaPrestamo
        {
            get{return fechaPrestamo;}
        }

        public DateTime FechaDevolucionEstimada
        {
            get{return fechaDevolucionEstimada;}
        }

        public DateTime? FechaDevolucionReal
        {
            get{return fechaDevolucionReal;}
        }
    
        public void Devolver()
        {
            if(fechaDevolucionReal==null)
            {
                fechaDevolucionReal=DateTime.Now;
            }
            else
            {
                throw new InvalidOperationException("El prestamo fue devuelto.");
            }
        }
    }
}