using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class returnCredits : MonoBehaviour
{
    private UIDocument regresarCreditos;
    private Button regresarboton;

    void Start()
    {
        regresarCreditos = GetComponent<UIDocument>();
        var root = regresarCreditos.rootVisualElement;
        regresarboton = root.Q<Button>("regresar");

        regresarboton.RegisterCallback<ClickEvent>(ev => RegresarMenu());

    }

    private void RegresarMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
