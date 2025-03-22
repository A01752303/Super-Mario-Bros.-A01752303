using UnityEngine;
using System.Collections;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
public class allMenu : MonoBehaviour
{
    private VisualElement _ayuda;
    private VisualElement _menu;
    void Start()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        if(root == null)
        {
            Debug.LogError("No se pudo encontrar el rootVisualElement.");
            return;
        }

        _menu = root.Q<TemplateContainer>("menu");
        _ayuda = root.Q<TemplateContainer>("ayuda");
 
        SetupMenu();
        SetupAyuda();
    }

    private void SetupMenu()
    {
        Menuview principalmenu = new Menuview(_menu);
        principalmenu.OpenAyuda = () => ToggleAyuda(true);
        principalmenu.EmpezarJuego = () => StartGame();
        principalmenu.Creditos = () => Credits();
        principalmenu.Salir = () => Exit();
    }

    private void SetupAyuda()
    {
        if (_ayuda == null)
        {
            Debug.LogError("El VisualElement 'ayuda' no está asignado.");
            return;
        }

        Debug.Log("VisualElement 'ayuda' asignado correctamente.");
        Ayuda principalayuda = new Ayuda(_ayuda);
        principalayuda.Salida = () => ToggleAyuda(false);
    }

    private void ToggleAyuda(bool enable)
    {
        if (_ayuda == null || _menu == null)
        {
            Debug.LogError("Uno de los elementos de la UI no está inicializado.");
            return;
        }

        _menu.Display(!enable);
        _ayuda.Display(enable);
    }

    private void StartGame()
    {
        SceneManager.LoadScene("Play");
    }

    private void Credits()
    {
        SceneManager.LoadScene("Credits");
    }

    private void Exit()
    {
        Application.Quit();
        Debug.Log("Saliendo del juego...");
    }

}
public static class VisualElementExtensions
{
    public static void Display(this VisualElement element, bool enabled)
    {
        if (element == null) return;
        element.style.display = enabled ? DisplayStyle.Flex : DisplayStyle.None;
    }
}
