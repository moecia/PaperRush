using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class GameManager : MonoBehaviour
{
    public void Restart()
    {
        Time.timeScale = 1;
        Application.LoadLevel(0);
    }

    public void BackToMenu()
    {
        print("Under construction...");
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
    }
}

[CustomEditor(typeof(GameManager))]
public class GSM : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        if (GUILayout.Button("Restart"))
        {
            Application.LoadLevel(0);
        }

        if (GUILayout.Button("Clear Data"))
            GameData.ClearData();
    }
}
