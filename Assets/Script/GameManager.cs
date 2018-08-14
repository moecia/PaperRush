using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class GameManager : MonoBehaviour
{
    public bool gameStart = false;
    public GameObject inGamePanel;
    public GameObject startGamePanel;

    public void StartGame()
    {
        gameStart = true;
        inGamePanel.SetActive(true);
        startGamePanel.SetActive(false);
    }

    public void Restart()
    {
        Time.timeScale = 1;
        Application.LoadLevel(0);
    }

    public void BackToMenu()
    {
        Time.timeScale = 1;
        Application.LoadLevel(1);
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
            Application.LoadLevel(1);
        }

        if (GUILayout.Button("Clear Data"))
            GameData.ClearData();
    }
}
