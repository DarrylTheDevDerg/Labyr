using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Button[] botones;  // Un array para los botones
    private int indiceSeleccionado = 0;  // �ndice del bot�n seleccionado

    // Variables para cada acci�n de bot�n
    public Button boton1;  // Para cargar la escena siguiente
    public Button boton2;  // Acci�n compleja
    public Button boton3;  // Men� de niveles
    public Button boton4;  // Men� de opciones
    public Button boton5;  // Cr�ditos
    public Button boton6;  // Salir

    // Variable p�blica para la escena de cr�ditos, configurable desde el Inspector
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

        // Resalta el primer bot�n
        ActualizarSeleccion();
    }

    void Update()
    {
        NavegarMenu();  // Llama a la funci�n que maneja la navegaci�n

        if (Input.GetKeyDown(KeyCode.Return)) // Enter para seleccionar
        {
            EjecutarAccionBotonSeleccionado();
        }
    }

    // Funci�n para navegar entre los botones con teclas de direcci�n o WASD
    void NavegarMenu()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) // Arriba
        {
            indiceSeleccionado--;
            if (indiceSeleccionado < 0)
            {
                indiceSeleccionado = botones.Length - 1;  // Vuelve al �ltimo bot�n
            }
            ActualizarSeleccion();
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S)) // Abajo
        {
            indiceSeleccionado++;
            if (indiceSeleccionado >= botones.Length)
            {
                indiceSeleccionado = 0;  // Vuelve al primer bot�n
            }
            ActualizarSeleccion();
        }
    }

    // Actualiza la selecci�n de los botones (resaltando el activo)
    void ActualizarSeleccion()
    {
        for (int i = 0; i < botones.Length; i++)
        {
            // Desactiva el resaltado de todos los botones
            ColorBlock colors = botones[i].colors;
            colors.normalColor = Color.white; // Color normal
            botones[i].colors = colors;

            // Activa el resaltado en el bot�n seleccionado
            if (i == indiceSeleccionado)
            {
                colors.normalColor = Color.yellow; // Puedes poner cualquier color que prefieras
                botones[i].colors = colors;
            }
        }
    }

    // Ejecuta la acci�n del bot�n seleccionado
    void EjecutarAccionBotonSeleccionado()
    {
        // Aqu� no necesitamos invocar eventos manualmente porque los botones ya tienen sus listeners configurados.
        switch (indiceSeleccionado)
        {
            case 0:
                boton1.onClick.Invoke(); // Ejecuta la acci�n del primer bot�n
                break;
            case 1:
                boton2.onClick.Invoke(); // Ejecuta la acci�n del segundo bot�n
                break;
            case 2:
                boton3.onClick.Invoke(); // Ejecuta la acci�n del tercer bot�n
                break;
            case 3:
                boton4.onClick.Invoke(); // Ejecuta la acci�n del cuarto bot�n
                break;
            case 4:
                boton5.onClick.Invoke(); // Ejecuta la acci�n del quinto bot�n
                break;
            case 5:
                boton6.onClick.Invoke(); // Ejecuta la acci�n del sexto bot�n
                break;
        }
    }

    // Funciones de cada acci�n del bot�n
    public void CargarEscenaSiguiente()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void AccionCompleja()
    {
        Debug.Log("Ejecutando acci�n compleja");
        // Aqu� va la l�gica de la acci�n compleja
    }

    public void DesplegarMenuDeNiveles()
    {
        Debug.Log("Desplegar men� de niveles");
        // Aqu� va el c�digo para desplegar el men� de niveles
    }

    public void DesplegarMenuDeOpciones()
    {
        Debug.Log("Desplegar men� de opciones");
        // Aqu� va el c�digo para desplegar el men� de opciones
    }

    // Funci�n que ahora usa el string configurable desde el Inspector
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
