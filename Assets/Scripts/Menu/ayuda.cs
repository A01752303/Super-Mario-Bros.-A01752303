using UnityEngine;
using UnityEngine.UIElements;
using System;

public class Ayuda
{
    public Action Salida
    {
        set
        {
            if (_salida != null)
            {
                _salida.clicked += value;
            }
            else
            {
                Debug.LogError("El botón 'salida' no está asignado.");
            }
        }
    }

    private Button _salida;

    public Ayuda(VisualElement root)
    {
        _salida = root.Q<Button>("salida");

        if (_salida == null)
        {
            Debug.LogError("No se pudo encontrar el botón 'salida' en el VisualElement.");
        }
    }
}