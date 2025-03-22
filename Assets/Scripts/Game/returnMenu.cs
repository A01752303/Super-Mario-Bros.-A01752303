using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class returnMenu : MonoBehaviour
{
    private UIDocument regresarJuego;
    private Button regresarboton;

    void Start()
    {
        regresarJuego = GetComponent<UIDocument>();
        var root = regresarJuego.rootVisualElement;
        regresarboton = root.Q<Button>("regresar");

        regresarboton.RegisterCallback<ClickEvent>(ev => RegresarMenu());

    }

    private void RegresarMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
