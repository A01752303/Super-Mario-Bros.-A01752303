// Alberto Gallegos Hernández A01752303
// 22/03/2025

using UnityEngine;
using System.Collections;
using UnityEngine.UIElements;
using System;

// Clase que controla el menú principal
public class Menuview
{
    // Actions para los botones del menú
    public Action OpenAyuda { set => _ayuda.clicked += value; }
    public Action EmpezarJuego { set => _start.clicked += value; }
    public Action Salir { set => _salir.clicked += value; }
    public Action Creditos { set => _creditos.clicked += value; }

    // Variables para los botones del menú
    private Button _start;
    private Button _ayuda;
    private Button _creditos;
    private Button _salir;

    // Constructor de la clase
    public Menuview(VisualElement root)
    {
        _ayuda = root.Q<Button>("ayuda");
        _start = root.Q<Button>("start");
        _creditos = root.Q<Button>("creditos");
        _salir = root.Q<Button>("salir");

        AddLogsButtons();
    }

    // Función para agregar logs a los botones
    private void AddLogsButtons()
    {
        _ayuda.clicked += () => Debug.Log("Ayuda");
        _start.clicked += () => Debug.Log("Start");
        _creditos.clicked += () => Debug.Log("Creditos");
        _salir.clicked += () => Debug.Log("Salir");
    }
}
