using System;

namespace Biblioteca
{

    public enum TipoPrestamo
    {
        Domicilio,Sala
    }
    public class Prestamo
    {
        private Socio socio;
        private Libro libro;
        private DateTime fechaPrestamo;
		private DateTime? fechaDevolucionEstimada;
        private DateTime? fechaDevolucionReal;
        private TipoPrestamo tipoPrestamo;
		
        public Prestamo(Socio socio, Libro libro, TipoPrestamo tipo)
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
            fechaDevolucionEstimada=null;
            fechaDevolucionReal=null;
            this.tipoPrestamo=tipo;
            if(tipo==TipoPrestamo.Domicilio)
            {
                fechaDevolucionEstimada=fechaPrestamo.AddDays(15);
            }
           
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

        public DateTime? FechaDevolucionEstimada
        {
            get{return fechaDevolucionEstimada;}
        }

        public DateTime? FechaDevolucionReal
        {
            get{return fechaDevolucionReal;}
        }

        public TipoPrestamo Tipo
        {
            get { return tipoPrestamo; }
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