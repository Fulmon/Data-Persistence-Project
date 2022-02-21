using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{
    public static InputManager Instace;
    public string nameText;

    private void Awake()
    {
        Instace = this;
        DontDestroyOnLoad(gameObject);
    }
}
