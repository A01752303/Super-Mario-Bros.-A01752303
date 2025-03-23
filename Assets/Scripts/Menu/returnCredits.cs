// Alberto Gallegos Hernández A01752303
// 22/03/2025

using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

// Clase que controla el regreso a los créditos
public class returnCredits : MonoBehaviour
{
    // Variables para el documento de UI y el botón de regresar
    private UIDocument regresarCreditos;
    private Button regresarboton;

    // Función que se ejecuta al iniciar el script
    void Start()
    {
        // Se obtiene el documento de UI
        regresarCreditos = GetComponent<UIDocument>();
        var root = regresarCreditos.rootVisualElement;
        regresarboton = root.Q<Button>("regresar");

        // Se agrega un callback al botón de regresar
        regresarboton.RegisterCallback<ClickEvent>(ev => RegresarMenu());

    }

    // Función para regresar a los créditos
    private void RegresarMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
