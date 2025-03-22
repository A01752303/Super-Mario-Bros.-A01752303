using UnityEngine;
using System.Collections;
using UnityEngine.UIElements;
using System;

public class Menuview
{
    public Action OpenAyuda { set => _ayuda.clicked += value; }
    public Action EmpezarJuego { set => _start.clicked += value; }
    public Action Salir { set => _salir.clicked += value; }

    private Button _ayuda;
    private Button _start;
    private Button _creditos;
    private Button _salir;


    public Menuview(VisualElement root)
    {
        _ayuda = root.Q<Button>("ayuda");
        _start = root.Q<Button>("start");
        _creditos = root.Q<Button>("creditos");
        _salir = root.Q<Button>("salir");

        AddLogsButtons();
    }

    private void AddLogsButtons()
    {
        _ayuda.clicked += () => Debug.Log("Ayuda");
        _start.clicked += () => Debug.Log("Start");
        _creditos.clicked += () => Debug.Log("Creditos");
        _salir.clicked += () => Debug.Log("Salir");
    }
}
