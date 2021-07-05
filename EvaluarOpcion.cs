using System;


namespace ProyectoIntegrador
{
    public class EvaluarOpcion
    {
        
        public void evaluarOpcion()
        {
            //Leer la opcion ingresada del usuario;
            string[] opcion = opciones();
            opcionValida( opcion[0].ToLower() , opcion );
        }

        public void opcionValida( string opcion , string[] opciones ){

            Program program = new Program();

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
                    if( opciones.Length > 1 ){
                        Console.WriteLine("*** ERROR: mostrar no require ninguna parametro ***");
                        evaluarOpcion();
                    }else {
                        program.funcionesApp( opciones );
                    }
                }


                if( opciones[0] == "filtrar" )
                {
                    if( opciones.Length < 3 )
                    {
                        Console.WriteLine("*** ERROR: filtrar requiere dos parametros.  filtrar[campo][valor] ***");
                        evaluarOpcion();
                    }
                    else if( opciones.Length > 3 )
                    {
                        Console.WriteLine("*** ERROR: filtrar solo requiere dos parametros. filtrar[campo][valor]] ***");
                        evaluarOpcion();
                    }
                    else if( opciones.Length == 3 )
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
            Console.WriteLine("===== ESCRIBE LA OPCION QUE DESEES: ===== \n - mostrar => Mostrar registros. \n - ingresar[placa] => Ingresar registro. \n - borrar[placa] => Borrar registro. \n - actualizar[id][campo][valor] => Actualizar registro. \n - filtrar[campo][valor] => Filtrar registro. \n - guardar => Guardar en XML. \n - salir.");
            string opcion = Console.ReadLine();
            return opcion.Split(" ");
        }

    }

}