using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.IO;
using System.Text;

namespace ProyectoIntegrador
{
    class Program
    {
        public Program( List<Vehiculo> registros ){
            List<Vehiculo> registrosPlacas = registros;
        }

        public static List<Vehiculo> registrosPlacas = new List<Vehiculo>();

        static void Main(string[] args)
        {
            start();
        }

        public static void start()
        {

            EvaluarOpcion evaluarOpcion = new EvaluarOpcion( registrosPlacas );
            evaluarOpcion.evaluarOpcion();
            
        }

        public void deseasContinuar()
        {
            Console.WriteLine("=== ¿Deseas continuar? Si[s] No[AnyKey] ===");

            string respuesta = Console.ReadLine();

            if (respuesta == "s")
            {
                start();
            }
            else if (respuesta != "s")
            {
                Console.WriteLine("=== GRACIAS POR USAR NUSETRA APP ===");
            }
        }

        public void mostrarRegistros()
        {

            Console.WriteLine($"Numero de registros: { registrosPlacas.Count }");

            if( registrosPlacas.Count > 0 ) Console.WriteLine("=============== REGISTROS =================");
            
            for (int i = 0; i < registrosPlacas.Count; i++)
            {
                Console.WriteLine( $"{ i + 1 }. { registrosPlacas[i] }" );
            }

            deseasContinuar();
            
        }

        public void guardarXml()
        {
            
            string ruta = "C:\\Users\\USER\\Desktop\\PROYECTO_INTEGRADOR_3RO_VA\\";
            
            string nombreArchivo = "registros";
            
            var archivo = $"{ruta}\\{nombreArchivo}.xml";
            
            FileStream fileStream = File.Create( archivo  );
            
            var contenido = $"<?xml version='1.0' encoding='utf-8'?> \n";
            
            string data = "";
            
            for (int i = 0; i < registrosPlacas.Count; i++)
            {
                data += $"<registro>{ i + 1 }. { registrosPlacas[i] } </registro> \n ";
            }
            
            byte[] buffer  = Encoding.UTF8.GetBytes( contenido + data );
            
            fileStream.Write( buffer );
            
            fileStream.Flush();

            fileStream.Close(); 

            Console.WriteLine("====== REGISTRO GUARDADO ======");
            
        }

        public void funcionesApp(string[] opcion)
        {
            
            if ( opcion[0] == "mostrar" )
            {
                mostrarRegistros();
            }
            else if (opcion[0] == "ingresar")
            {
                Console.WriteLine("Ingresa el numero de placa: ");
                string placa = Console.ReadLine();

                Console.WriteLine("Ingresa el numero de matricula: ");
                string matricula = Console.ReadLine();

                Console.WriteLine("Ingresa la fecha de emision: ");
                DateTime fechaEmision = DateTime.Parse(Console.ReadLine());

                Console.WriteLine("Ingresa la fecha de caducidad: ");
                DateTime fechaCaducidad = DateTime.Parse(Console.ReadLine());
                
                registrosPlacas.Add( new Vehiculo(){ Placa = placa, MatriculaId = new Matricula(){ 
                    NumeroMatricula = matricula,
                    FechaEmisiónMatricula = fechaEmision,
                    FechaCaducidadMatricula = fechaCaducidad
                 }});

                deseasContinuar();
            }
            else if (opcion[0] == "borrar")
            {
                try
                {
                    var itemToRemove = registrosPlacas.Single( data => data.Placa == opcion[1]);

                    registrosPlacas.Remove(itemToRemove);
                    
                    Console.WriteLine("SUCCESS: REGISTRO BORRADO");
                }
                catch (System.Exception)
                {
                    Console.WriteLine("==== ERROR: Numero de placa no encontrada. ===== ");   
                }

                deseasContinuar();
            }
            else if (opcion[0] == "actualizar")
            {
                string numeroPlaca = opcion[1];

                var placaUpdate = registrosPlacas.Where( placa =>  placa.Placa == numeroPlaca );

                if( placaUpdate.Count() < 1 )
                {
                    Console.WriteLine($"No se encontro ningun vehiculo con la placa: { numeroPlaca }");
                    deseasContinuar();
                }else
                {
                    Console.WriteLine("===== Vehiculo encontrado =====");

                    foreach (var item in placaUpdate)
                    {
                        Console.WriteLine(  item );
                    }

                    Console.WriteLine("=== Ingresa el campo a actualizar =====\n 1. Placa. \n 2. Matricula \n 3. Fecha emision matricula \n 4. Fecha caducidad matricula ====");
                    string campoActualizar = Console.ReadLine();

                    Console.WriteLine("==== Ingresa el nuevo valor ====");
                    string nuevoValor = Console.ReadLine();

                    foreach (var vehiculo in registrosPlacas.Where( placa =>  placa.Placa == numeroPlaca ))
                    {

                        if( campoActualizar == "1" )
                        {
                            vehiculo.Placa = nuevoValor;
                        }else if ( campoActualizar == "2" )
                        {
                            vehiculo.MatriculaId.NumeroMatricula = nuevoValor;
                        }else if ( campoActualizar == "3" )
                        {
                            vehiculo.MatriculaId.FechaEmisiónMatricula = DateTime.Parse( nuevoValor );
                        }else if ( campoActualizar == "4" )
                        {
                            vehiculo.MatriculaId.FechaCaducidadMatricula = DateTime.Parse( nuevoValor );
                        }
                        
                    }
                        Console.WriteLine("==== INFORAMCION ACTULIZADA ====");
                        
                        deseasContinuar();
                }

                
            }
            else if (opcion[0] == "filtrar")
            {
                var filtrarPlaca = registrosPlacas.Where( data => data.Placa == opcion[1] );

                if( filtrarPlaca.LongCount() < 1 ){
                    Console.WriteLine( "======= PLACA NO ENCONTRADA ======== " );
                }else 
                {
                    foreach (var item in filtrarPlaca)
                    {
                        Console.WriteLine(item);
                    }
                }

                deseasContinuar();
            }
            else if (opcion[0] == "guardar")
            {
                guardarXml();
                deseasContinuar();
            }
            else if( opcion[0] == "salir")
            {
                List<String> vacio = new List<String>();
                deseasContinuar();
            }
            
        }

    }
    
}

/* Govtech Programa para ayudar a recordar los dias de circulacion de un vehiculo y fecha de matriculacion
1. Mostrar => Mostrar todos los elementos que se hayan ingresado - Alava
2. Ingresar [Elemento]=> ingresar un elemento  - Mosquera
3. Borrar [Name]=> en funcion de la placa - Balarezo
4. Actualizar [id] [campo] [valor]
5. Filtrar [campo] [valor] => mostrar los elementos cuyo [campo] sea igual al [valor]
6. Archivo => guardar en un archivo XML
7. Recuperar => archivo XML
8. BorrarArchivo*/
