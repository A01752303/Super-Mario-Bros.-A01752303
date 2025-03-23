// Alberto Gallegos Hernández A01752303
// 22/03/2025

using UnityEngine;
using UnityEngine.UIElements;
using System;

// Clase que controla la ventana ayuda del menú principal
public class Ayuda
{
    // Action para el botón de salida
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

    // Variable para el botón de salida
    private Button _salida;

    // Constructor de la clase
    public Ayuda(VisualElement root)
    {
        // Se obtiene el botón de salida
        _salida = root.Q<Button>("salida");

        // Se verifica si el botón de salida se obtuvo correctamente
        if (_salida == null)
        {
            Debug.LogError("No se pudo encontrar el botón 'salida' en el VisualElement.");
        }
    }
}