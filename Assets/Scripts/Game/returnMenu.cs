// Alberto Gallegos Hernández A01752303
// 22/03/2025

using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

// Clase que controla el regreso al menú principal
public class returnMenu : MonoBehaviour
{
    // Variables para el documento de UI y el botón de regresar
    private UIDocument regresarJuego;
    private Button regresarboton;

    // Función que se ejecuta al iniciar el script
    void Start()
    {
        regresarJuego = GetComponent<UIDocument>();
        var root = regresarJuego.rootVisualElement;
        regresarboton = root.Q<Button>("regresar");

        // Se agrega un callback al botón de regresar
        regresarboton.RegisterCallback<ClickEvent>(ev => RegresarMenu());

    }

    // Función para regresar al menú principal
    private void RegresarMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
