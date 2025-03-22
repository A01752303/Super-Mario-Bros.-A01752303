using UnityEngine;
using System.Collections;
using UnityEngine.UIElements;
using System;

public class Ayuda
{
    public Action BackAction { set => _backButton.clicked += value;}

    private Button _backButton;

    public Ayuda(VisualElement root)
    {
        _backButton = root.Q<Button>("salir");
    }
}
