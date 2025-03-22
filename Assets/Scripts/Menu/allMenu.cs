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
        _ayuda = root.Q<VisualElement>("ayuda");
        _menu = root.Q<VisualElement>("menu");

        if (_ayuda == null)
        {
            Debug.LogError("No se pudo encontrar el VisualElement 'ayuda'.");
        }

        SetupMenu();
        SetupAyuda();
    }

    private void SetupMenu()
    {
        Menuview principalmenu = new Menuview(_menu);
        principalmenu.OpenAyuda = () => ToggleAyuda(true);
        principalmenu.EmpezarJuego = () => StartGame();
        principalmenu.Salir = () => Exit();
    }

    private void SetupAyuda()
    {
        Ayuda principalayuda = new Ayuda(_ayuda);
        principalayuda.BackAction = () => ToggleAyuda(false);
    }

    private void ToggleAyuda(bool open)
    {
        if (_ayuda == null || _menu == null)
        {
            Debug.LogError("Uno de los elementos de la UI no está inicializado.");
            return;
        }

        _menu.Display(!open);
        _ayuda.Display(open);
    }

    private void StartGame()
    {
        SceneManager.LoadScene("Play");
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
