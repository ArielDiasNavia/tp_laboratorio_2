using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClasesAbstractas;
using ClasesInstaciables;
using Excepciones;
namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Excepciones1()
        {
            Universidad gim = new Universidad();
            Alumno a1 = new Alumno(1, "Juan", "Lopez", "12234456", ClasesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion, Alumno.EEstadoDeCuenta.Becado);
            gim += a1;
            try
            {
                Alumno a2 = new Alumno(2, "Juana", "Martinez", "12234458", ClasesAbstractas.Persona.ENacionalidad.Extranjero, Universidad.EClases.Laboratorio, Alumno.EEstadoDeCuenta.Deudor);
                gim += a2;
            }
            catch (NacionalidadInvalidaException e)
            {
                Assert.IsInstanceOfType(e, typeof(NacionalidadInvalidaException));
            }
        }

        [TestMethod]
        public void Excepciones2()
        {
            Universidad gim = new Universidad();
            Alumno a1 = new Alumno(1, "Emanuel", "Dias", "33658852", ClasesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion, Alumno.EEstadoDeCuenta.Becado);
            gim += a1;
            try
            {
                Alumno a3 = new Alumno(3, "Emanuel", "Perez", "33658852", ClasesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion, Alumno.EEstadoDeCuenta.Becado);
                gim += a3;
            }
            catch (AlumnoRepetidoException e)
            {
                Assert.IsInstanceOfType(e, typeof(AlumnoRepetidoException));
            }
        }

        [TestMethod]
        public void Numerico1()
        {
            Universidad gim = new Universidad();
            Alumno a1 = new Alumno(1, "Federico", "Yannazo", "35220822", ClasesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion, Alumno.EEstadoDeCuenta.Becado);
            gim += a1;

            Assert.IsTrue(gim.Alumnos.Count == 1);
        }

        [TestMethod]
        public void noNulo1()
        {
            Universidad gim = new Universidad();
            Alumno a1 = new Alumno(1, "Omar", "Fernandez", "17733307", ClasesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion, Alumno.EEstadoDeCuenta.Becado);
            gim += a1;

            Assert.IsNotNull(gim.Instructores);
        }
    }
}
