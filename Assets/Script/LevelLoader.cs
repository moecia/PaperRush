using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour {

    private bool m_isGameOver = false;
    public bool isGameOver
    {
        get { return m_isGameOver; }
        set { m_isGameOver = value; }
    }
    public void Update()
    {
        if (m_isGameOver && Input.GetKeyDown(KeyCode.R))
        {
            print("pressButton");
            Restart("PaperRush");
        }
    }
    public void Restart(string levelName)
    {
        m_isGameOver = false;
        SceneManager.LoadScene(levelName);
    }
}
