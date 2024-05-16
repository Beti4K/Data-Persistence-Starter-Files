using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.IO;

public class MenuHandler : MonoBehaviour
{
    public TextMeshPro playerName;
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); 
#endif
    }

    public void setName()
    {
        MainManager.Instance.playerName = playerName.text;
    }
}
