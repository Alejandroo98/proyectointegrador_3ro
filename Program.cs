using System;
using System.Collections.Generic;
using System.Linq;

namespace ProyectoIntegrador
{
    class Program
    {
        public Program( List<string> registros ){
            

            // List<Vehiculo> registros = new List<Vehiculo>();
            // List<String> registrosPlacas;
            List<String> registrosPlacas = registros;
        }

           public static List<String> registrosPlacas = new List<String>();

        static void Main(string[] args)
        {
            start();
        }

     


        public static void start(  )
        {
            foreach (var item in registrosPlacas)
            {
                Console.WriteLine( $"Desde start: {item}" );
            }
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

        public void funcionesApp(string[] opcion) //=========================================================================================
        {
            if ( opcion[0] == "mostrar" )
            {
                
                mostrarRegistros();
                
            }
            else if (opcion[0] == "ingresar")
            {
                Console.WriteLine("Ingresa el numero de placa: ");
                string placa = Console.ReadLine();
                registrosPlacas.Add( placa );

                
                deseasContinuar();
              
                
                // Console.WriteLine("Ingresa el numero de matricula: ");
                // string matricula = Console.ReadLine();

                // Console.WriteLine("Ingresa la fecha de emision : ");
                // DateTime fechaEmision = DateTime.Parse(Console.ReadLine());

                // Console.WriteLine("Ingresa la fecha de caducidad : ");
                // DateTime fechaCaducidad = DateTime.Parse(Console.ReadLine());
                
                // List<Vehiculo> registroVehiculo = new List<Vehiculo>(){
                //     new Vehiculo(){ Placa = placa, MatriculaId = new Matricula(){ 
                //         NumeroMatricula = matricula,
                //         FechaEmisiónMatricula = fechaEmision,
                //         FechaCaducidadMatricula = fechaCaducidad
                //     }}
                // };

                // List<Vehiculo> registroVehiculo = new List<Vehiculo>();
                // this.registros.Add( new Vehiculo(){ Placa = placa } );


                 
                // Console.WriteLine("Ingrese Placa");
                // string placa = Console.ReadLine();
                // Vehiculo vehiculo = new Vehiculo()
                // {
                //     Placa = placa
                // };

                // Console.WriteLine("Ingrese el numero de matricula");
                // string matricula = Console.ReadLine();

                // Console.WriteLine("Ingrese La fecha de Emision de su Matricula");
                // string fechaDeEmisionMatricula = Console.ReadLine();
                // DateTime fechaDeEmisionMatricula1 = DateTime.Parse(fechaDeEmisionMatricula);

                // Console.WriteLine("Ingrese la fecha de Caducidad de su Matricula");
                // string fechaDeCaducidadMatricula = Console.ReadLine();
                // DateTime fechaDeCaducidadMatricula1 = DateTime.Parse(fechaDeCaducidadMatricula);

                // Matricula matriculaVehiculo = new Matricula()
                // {
                //     NumeroMatricula = matricula,
                //     FechaEmisiónMatricula = fechaDeEmisionMatricula1,
                //     FechaCaducidadMatricula = fechaDeCaducidadMatricula1
                // };

            }
            else if (opcion[0] == "borrar")
            {
                //funcion para borrar registros
                Console.Write("ingrese un numero de matricula a ser borrado del sistema: ");
                string numeroMatricula = Console.ReadLine();

                Matricula matricula = new Matricula()
                {
                    NumeroMatricula = numeroMatricula
                };

                matricula.NumeroMatriculas = new List<string>
                {
                   "P25132",
                   "P22512",
                   "P87924"
                };

                VerificarExisteMatricula();

                void VerificarExisteMatricula()
                {

                    if (matricula.NumeroMatriculas.Contains(numeroMatricula))
                    {

                        BorrarMatricula();
                    }
                    else
                    {
                        Console.WriteLine("el numero de matricula que ingreso no esta registrado en el sistema");

                    }
                    
                }

                void BorrarMatricula()
                {

                    if (matricula.NumeroMatriculas.Remove(numeroMatricula))
                    {
                        Console.WriteLine($"El numero de matricula borrado es {numeroMatricula}");
                    };

                }

                List<String> vacio = new List<String>();
                deseasContinuar(  );
            }


            else if (opcion[0] == "actualizar")
            {
                //funcion para acualiar registros 
                Console.WriteLine("funcion para actualizar registros ");
                
                Console.WriteLine("Ingrese el numero de matricula que desea actualizar ");
                string numeroMatricula = Console.ReadLine();

                Matricula matricula = new Matricula()
                {
                    NumeroMatricula = numeroMatricula
                };

               List<string> MumeroMatriculas = new List<string>
                {
                   "P25132",
                   "P22512",
                   "P87924"
                };
                
                var indice = matricula.NumeroMatriculas.IndexOf(numeroMatricula);
                matricula.NumeroMatriculas.RemoveAt(indice);
                
                Console.WriteLine("Ingrese el nuevo valor: ");
                string numeroMatriculaActualizar = Console.ReadLine();
                
                matricula.NumeroMatriculas.Insert(indice, numeroMatriculaActualizar);
                
                Console.WriteLine($"el valor cambio de {numeroMatricula} a {numeroMatriculaActualizar}");

                foreach (var actual in matricula.NumeroMatriculas)
                {
                    Console.WriteLine(actual);
                }
                
                deseasContinuar();
                
            }
            else if (opcion[0] == "filtrar")
            {
                //funcion para filtrar registros 
                Console.WriteLine("funcion para filtrar registros");
                List<String> vacio = new List<String>();
                deseasContinuar();
            }
            else if (opcion[0] == "guardar")
            {
                //funcion para gurdar en XML
                Console.WriteLine("funcion para gurdar en XML");
                List<String> vacio = new List<String>();
                deseasContinuar();
            }
            else if( opcion[0] == "salir")
            {
                List<String> vacio = new List<String>();
                deseasContinuar();
            }
        }

        List<Vehiculo> getRegistros()
        {
            //  Console.WriteLine("las matriculas en la lista son las siguientes: ");
                
            //     foreach (var actual in matricula.NumeroMatriculas)
            //     {
            //         Console.WriteLine(actual);
            //     }
            
            return new List<Vehiculo>();
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
