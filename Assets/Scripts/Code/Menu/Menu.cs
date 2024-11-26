using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Button[] botones;  // Un array para los botones
    private int indiceSeleccionado = 0;  // Índice del botón seleccionado

    // Variables para cada acción de botón
    public Button boton1;  // Para cargar la escena siguiente
    public Button boton2;  // Acción compleja
    public Button boton3;  // Menú de niveles
    public Button boton4;  // Menú de opciones
    public Button boton5;  // Créditos
    public Button boton6;  // Salir

    // Variable pública para la escena de créditos, configurable desde el Inspector
    public string nombreEscenaCreditos = "5_Creditos";  // Default: "5_Creditos"

    void Start()
    {
        // Inicializamos los botones y asignamos las funciones
        boton1.onClick.AddListener(CargarEscenaSiguiente);
        boton2.onClick.AddListener(AccionCompleja);
        boton3.onClick.AddListener(DesplegarMenuDeNiveles);
        boton4.onClick.AddListener(DesplegarMenuDeOpciones);
        boton5.onClick.AddListener(CargarCreditos);
        boton6.onClick.AddListener(SalirDelJuego);

        // Resalta el primer botón
        ActualizarSeleccion();
    }

    void Update()
    {
        NavegarMenu();  // Llama a la función que maneja la navegación

        if (Input.GetKeyDown(KeyCode.Return)) // Enter para seleccionar
        {
            EjecutarAccionBotonSeleccionado();
        }
    }

    // Función para navegar entre los botones con teclas de dirección o WASD
    void NavegarMenu()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) // Arriba
        {
            indiceSeleccionado--;
            if (indiceSeleccionado < 0)
            {
                indiceSeleccionado = botones.Length - 1;  // Vuelve al último botón
            }
            ActualizarSeleccion();
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S)) // Abajo
        {
            indiceSeleccionado++;
            if (indiceSeleccionado >= botones.Length)
            {
                indiceSeleccionado = 0;  // Vuelve al primer botón
            }
            ActualizarSeleccion();
        }
    }

    // Actualiza la selección de los botones (resaltando el activo)
    void ActualizarSeleccion()
    {
        for (int i = 0; i < botones.Length; i++)
        {
            // Desactiva el resaltado de todos los botones
            ColorBlock colors = botones[i].colors;
            colors.normalColor = Color.white; // Color normal
            botones[i].colors = colors;

            // Activa el resaltado en el botón seleccionado
            if (i == indiceSeleccionado)
            {
                colors.normalColor = Color.yellow; // Puedes poner cualquier color que prefieras
                botones[i].colors = colors;
            }
        }
    }

    // Ejecuta la acción del botón seleccionado
    void EjecutarAccionBotonSeleccionado()
    {
        // Aquí no necesitamos invocar eventos manualmente porque los botones ya tienen sus listeners configurados.
        switch (indiceSeleccionado)
        {
            case 0:
                boton1.onClick.Invoke(); // Ejecuta la acción del primer botón
                break;
            case 1:
                boton2.onClick.Invoke(); // Ejecuta la acción del segundo botón
                break;
            case 2:
                boton3.onClick.Invoke(); // Ejecuta la acción del tercer botón
                break;
            case 3:
                boton4.onClick.Invoke(); // Ejecuta la acción del cuarto botón
                break;
            case 4:
                boton5.onClick.Invoke(); // Ejecuta la acción del quinto botón
                break;
            case 5:
                boton6.onClick.Invoke(); // Ejecuta la acción del sexto botón
                break;
        }
    }

    // Funciones de cada acción del botón
    public void CargarEscenaSiguiente()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void AccionCompleja()
    {
        Debug.Log("Ejecutando acción compleja");
        // Aquí va la lógica de la acción compleja
    }

    public void DesplegarMenuDeNiveles()
    {
        Debug.Log("Desplegar menú de niveles");
        // Aquí va el código para desplegar el menú de niveles
    }

    public void DesplegarMenuDeOpciones()
    {
        Debug.Log("Desplegar menú de opciones");
        // Aquí va el código para desplegar el menú de opciones
    }

    // Función que ahora usa el string configurable desde el Inspector
    public void CargarCreditos()
    {
        SceneManager.LoadScene(nombreEscenaCreditos);
    }

    public void SalirDelJuego()
    {
        Debug.Log("Salir...");
        Application.Quit();
    }
}
