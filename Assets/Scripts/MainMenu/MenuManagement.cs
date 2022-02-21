using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

#if UNITY_EDITOR
using UnityEditor;
#endif 

public class MenuManagement : MonoBehaviour
{
    [SerializeField] InputField nameText;

    public void NewGame()
    {
        if (nameText.text == "")
        {
            nameText.placeholder.color = new Color(255, 0, 0, 255);
        }
        else
        {
            InputManager.Instace.nameText = nameText.text;
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
