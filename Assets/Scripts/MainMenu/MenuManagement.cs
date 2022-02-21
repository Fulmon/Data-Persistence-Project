using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

#if UNITY_EDITOR
using UnityEditor;
#endif 

[DefaultExecutionOrder(1000)]
public class MenuManagement : MonoBehaviour
{
    [SerializeField] InputField nameText;

    private void Awake()
    {
        if (InputManager.Instace.nameText != "")
        {
            nameText.text = InputManager.Instace.nameText;
        }
    }

    public void NewGame()
    {
        if (nameText.text == "")
        {
            nameText.placeholder.color = new Color(255, 0, 0, 255);
        }
        else
        {
            InputManager.Instace.nameText = nameText.text;
            InputManager.Instace.SavePlayer();
            SceneManager.LoadScene(1);
        }
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
