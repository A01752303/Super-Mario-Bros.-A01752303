// Alberto Gallegos Hernández A01752303
// 22/03/2025

using UnityEngine;
using System.Collections;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

// Clase que controla el menú principal
public class allMenu : MonoBehaviour
{
    // Variables para los elementos de la UI
    private VisualElement _ayuda;
    private VisualElement _menu;
    void Start()
    {
        // Se obtiene el rootVisualElement del documento de UI
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        // Se verifica si el rootVisualElement se obtuvo correctamente
        if(root == null)
        {
            Debug.LogError("No se pudo encontrar el rootVisualElement.");
            return;
        }

        // Se obtienen los elementos de la UI que son TemplateContainer
        _menu = root.Q<TemplateContainer>("menu");
        _ayuda = root.Q<TemplateContainer>("ayuda");
 
        // Se inicializan los elementos de la UI
        SetupMenu();
        SetupAyuda();
    }

    // Función para inicializar el menú principal y los callbacks de los botones
    private void SetupMenu()
    {
        Menuview principalmenu = new Menuview(_menu);
        principalmenu.OpenAyuda = () => ToggleAyuda(true);
        principalmenu.EmpezarJuego = () => StartGame();
        principalmenu.Creditos = () => Credits();
        principalmenu.Salir = () => Exit();
    }

    // Función para inicializar la ayuda y los callbacks de los botones
    private void SetupAyuda()
    {
        // Se verifica si el elemento de la ayuda se obtuvo correctamente
        if (_ayuda == null)
        {
            Debug.LogError("El VisualElement 'ayuda' no está asignado.");
            return;
        }

        Debug.Log("VisualElement 'ayuda' asignado correctamente.");
        Ayuda principalayuda = new Ayuda(_ayuda);
        principalayuda.Salida = () => ToggleAyuda(false);
    }

    // Función para mostrar u ocultar la ayuda
    private void ToggleAyuda(bool enable)
    {
        // Se verifica si los elementos de la UI se obtuvieron correctamente
        if (_ayuda == null || _menu == null)
        {
            Debug.LogError("Uno de los elementos de la UI no está inicializado.");
            return;
        }

        // Se muestra u oculta la ayuda y el menú principal
        _menu.Display(!enable);
        _ayuda.Display(enable);
    }

    // Función para iniciar el juego
    private void StartGame()
    {
        SceneManager.LoadScene("Play");
    }

    // Función para mostrar los créditos
    private void Credits()
    {
        SceneManager.LoadScene("Credits");
    }

    // Función para salir del juego
    private void Exit()
    {
        Application.Quit();
        Debug.Log("Saliendo del juego...");
    }

}

// Clase que controla el menú principal
public static class VisualElementExtensions
{
    public static void Display(this VisualElement element, bool enabled)
    {
        if (element == null) return;
        element.style.display = enabled ? DisplayStyle.Flex : DisplayStyle.None;
    }
}
