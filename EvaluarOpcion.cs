using System;
using System.Collections.Generic;

namespace ProyectoIntegrador
{
    public class EvaluarOpcion
    {

        public EvaluarOpcion( List<Vehiculo> registros ){
            Registros = registros;
        }
        
        public void evaluarOpcion(  )
        {
            string[] opcion = opciones();
            opcionValida( opcion[0].ToLower() , opcion );
        }

        List<Vehiculo> Registros = new List<Vehiculo>();

        public void opcionValida( string opcion , string[] opciones ){

            Program program = new Program( Registros );

            if( opcion == "mostrar" || opcion == "ingresar" || opcion == "borrar" || opcion == "actualizar" || opcion == "filtrar" || opcion == "guardar" ||  opcion == "salir" )
            {
                if( opciones[0] == "mostrar" )
                {
                    if( opciones.Length > 1 ){
                        Console.WriteLine("*** ERROR: mostrar no require ninguna parametro ***");
                        evaluarOpcion();
                    }else {
                        program.funcionesApp( opciones );
                    }
                }


                if( opciones[0] == "ingresar" )
                {
                    if( opciones.Length > 1 )
                    {
                        Console.WriteLine("*** ERROR: ingresar no requiere un parametro. ingresar[placa] ***");
                        evaluarOpcion();
                    }
                    else {
                        program.funcionesApp( opciones );
                    }
                }
                
                
                if( opciones[0] == "borrar" )
                {
                    if( opciones.Length < 2 )
                    {
                        Console.WriteLine("*** ERROR: borrar requiere un parametro. borrar[placa] ***");
                        evaluarOpcion();
                    }
                    else if( opciones.Length > 2 )
                    {
                        Console.WriteLine("*** ERROR: borrar requiere un solo parametro. borrar[placa] ***");
                        evaluarOpcion();
                    }
                    else if( opciones.Length == 2 )
                    {
                        program.funcionesApp( opciones );
                    }
                }


                if( opciones[0] == "actualizar" )
                {
                    if( opciones.Length > 2 ){
                        Console.WriteLine("*** ERROR: atualizar require de un solo parametro.  actualizar[placa] ***");
                        evaluarOpcion();
                    }else if( opciones.Length < 2 ){
                        Console.WriteLine("*** ERROR: atualizar require un parametro.  actualizar[placa] ***");
                        evaluarOpcion();
                    }else if ( opciones.Length == 2 ){
                        program.funcionesApp( opciones );
                    }
                }


                if( opciones[0] == "filtrar" )
                {
                    if( opciones.Length < 2 )
                    {
                        Console.WriteLine("*** ERROR: filtrar requiere un parametro.  filtrar[placa] ***");
                        evaluarOpcion();
                    }
                    else if( opciones.Length > 2 )
                    {
                        Console.WriteLine("*** ERROR: filtrar solo requiere un parametro. filtrar[placa] ***");
                        evaluarOpcion();
                    }
                    else if( opciones.Length == 2 )
                    {
                        program.funcionesApp( opciones );
                    }
                }


                if( opciones[0] == "guardar" )
                {
                    if( opciones.Length > 1 ){
                        Console.WriteLine("*** ERROR: guardar no require ninguna parametro ***");
                        evaluarOpcion();
                    }else {
                        program.funcionesApp( opciones );
                    }
                }

                
                if( opciones[0] == "salir" )
                {
                    if( opciones.Length > 1 ){
                        Console.WriteLine("*** ERROR: salir no require ninguna parametro ***");
                        evaluarOpcion();
                    }else {
                        program.funcionesApp( opciones );
                    }
                }
                
            }
            else
            {
                Console.WriteLine("===== ERROR: INGRESA UNA OPCION VALIDA EH INTENTA DE NUEVO =====");
                evaluarOpcion();
            }
        }

        public string[] opciones()
        {
            Console.WriteLine("===== ESCRIBE LA OPCION QUE DESEES: ===== \n - mostrar => Mostrar registros. \n - ingresar => Ingresar registro. \n - borrar[placa] => Borrar registro. \n - actualizar[id][campo][valor] => Actualizar registro. \n - filtrar[placa] => Filtrar registro. \n - guardar => Guardar en XML. \n - salir.");
            string opcion = Console.ReadLine();
            return opcion.Split(" ");
        }

    }

}