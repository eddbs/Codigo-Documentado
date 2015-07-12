using System; // Se carga la librería System la cual sirve para clases fundamentales, tipos de datos, entre otras funciones basicas.
using System.IO; // Se carga la librería System.IO para admitir la entrada y salida de datos haciendo posible la lectura y escritura de archivos.

class Demo // Iniciamos la clase 'Demo' donde se albergara nuestro código principal.
{ // Se abre con llave de apertura la clase 'Demo'.
    static Alumno[] alumno = new Alumno[10]; // Declaramos un objeto estático llamado 'alumno' con un espacio de 10 posiciones.
    static Carrera[] carrera = new Carrera[6]; // Declaramos un objeto estático llamado 'carrera' con un espacio de 6 posiciones.
    static string fileName = "Definir ruta"; // Declaramos una variable estática de tipo string llamada 'fileName' en la cual se deberá sustituir su valor por la ruta donde se creará el archivo de texto de salida.
    static StreamWriter escribir; // Se declara un objeto 'StreamWriter' estático llamado 'escribir' el cuál sirve para crear el archivo de texto.

    struct Alumno // Iniciamos un bloque de estructura llamado 'Alumno' el cuál almacenará nombres de variables y tipos de datos.
    { // Se abre con llave de apertura el bloque 'Alumno'.
        public string Nombre { get; set; } // Se declara una propiedad pública de tipo string llamada 'Nombre'.
        public string ApellidoPaterno { get; set; } // Se declara una propiedad pública de tipo string llamada 'ApellidoPaterno'.
        public string ApellidoMaterno { get; set; } // Se declara una propiedad pública de tipo string llamada 'ApellidoMaterno'.
        public byte Edad { get; set; } // Se declara una propiedad pública de tipo byte llamada 'Edad'.
        public Carrera Carrera { get; set; } // Se declara una propiedad pública de tipo Carrera llamada 'Carrera'.
    } // Se cierra con llave de clausura el bloque 'Alumno'.

    struct Carrera // Iniciamos un bloque de estructura llamado 'Carrera' el cuál almacenará nombres de variables y tipos de datos.
    { // Se abre con llave de apertura el bloque 'Carrera'.
        public int Id { get; set; } // Se declara una propiedad pública de tipo integer llamada 'Id'.
        public string Nombre { get; set; } // Se declara una propiedad pública de tipo string llamada 'Nombre'.
    } // Se abre con llave de apertura el bloque 'Carrera'.

    static Carrera[] LoadDataCarreras() // Se declara un método estático llamado 'LoadDataCarreras()' el cuál invóca las propiedades de la estructura 'Carrera'.
    { // Se abre con llave de apertura el método 'LoadDataCarreras'.
        string[] carreras = { // Se declara un objeto de tipo string llamado 'carreras' y se le asignan datos (iniciando con llave de apertura y separando cada dato por una coma ",").
			"Licenciatura en Administración y Gestión de PYMES",
			"Ingeniería en Animación y Efectos Visuales",
			"Ingeniería en Energía",
			"Ingeniería Mecatrónica",
			"Ingeniería en Tecnologías de Manufactura",
			"Ingeniería en Tecnologías de la Información"
		}; // Termina sentencia para declarar el objeto (cerrando con llave clausura).

        for (int i = 0; i < carrera.Length; i++) // Se declara un ciclo for el cual recorrerá desde 0 hasta la cantidad de datos almacenados en el objeto 'Carrera' (en este caso se realizaran 6 ciclos).
        { // Se abre con llave de apertura el ciclo for.
            carrera[i] = new Carrera(); // Se inicializa el objeto 'Carrera' para cada una de las posiciones del objeto 'carrera' (desde 0 al 5).
            carrera[i].Id = i + 1; // Se le asigna a cada posición del objeto 'carrera' con la propiedad 'Id' el indice de cada ciclo + 1 (es decir del 1 al 6).
            carrera[i].Nombre = carreras[i]; // Se le asigna a cada posición del objeto 'carrera' con propiedad 'Nombre' el valor de cada dato dentro del objeto 'carreras' (desde la posición 0 al 5). 
        } // Se cierra con llave de clausura el ciclo for.

        return carrera; // Retorna el valor de 'carrera' a donde fué invocado el método.
    } // Se cierra con llave de clausura el método 'LoadDataCarreras'.

    static void Main() // Iniciamos la clase 'Main' la cuál es la clase principal que será invocada una vez se inicie la ejecución del programa.
    { // Se abre con llave de apertura la clase 'Main'.
        try // Se declara el bloque 'try' de la instrucción 'try-catch' la cuál sirve para controlar expeciones en caso de fallas o de eventos inesperados.
        { // Se inicia con llave de apertura la parte del bloque 'try'.
            escribir = new StreamWriter(fileName, true); // Se inicializa el objeto 'StreamWriter' el cual abre el archivo dado por la variable 'fileName' para poder hacer uso del mismo.

            foreach (Carrera c in LoadDataCarreras()) // Se declara un ciclo 'foreach' en el cual recorremos en cada ciclo los valores de todo el objeto 'Carrera' invocando el método 'LoadDataCarreras()'.
            { // Se abre con llave de apertura el ciclo 'foreach'.
                escribir.WriteLine(string.Format("{0}. {1}.", c.Id, c.Nombre)); // En cada instancia del ciclo esta instrucción concatena los datos del objeto con la propiedad 'Id' junto con los datos del objeto con la propiedad 'Nombre', escribiendo la concatenación en el archivo de texto dado en la variable 'fileName'.
            } // Se cierra con llave de clausura el ciclo 'foreach'.
            escribir.Close(); // Se cierra el archivo por medio la instrucción '.Close()' una vez que sale del ciclo 'foreach' para despues salir del programa (Siempre debe cerrarse el archivo despues de utilizarse).
        } // Se cierra con llave de clausura la parte del bloque 'try'.
        catch (FileNotFoundException e) // Se declara el bloque 'catch' de la instrucción 'try-catch' la cuál sirve para controlar expeciones en caso de fallas o de eventos inesperados.
        { // Se inicia con llave de apertura la parte del bloque 'catch'
            Console.WriteLine("The file '{0}' is not found.", fileName); // Se muestra un mensaje de error en caso de que no se pueda encontrar el archivo dado por la variable 'fileName'.
        } // Se cierra con llave de clausura la parte del bloque 'catch'.
    } // se cierra con llave de clausura la clase 'Main'.
} // Se cierra con llave de clausura la clase 'Demo'.