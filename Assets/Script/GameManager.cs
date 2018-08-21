using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEditor;

public class GameManager : MonoBehaviour {

    public enum GameState { Initialization, StartMenu, InProgress, GameOver }
    public GameState currentState = GameState.Initialization;

    // Use this for initialization
    void Start ()
    {

	}


	// Update is called once per frame
	void Update ()
    {
		
	}
}

//[CustomEditor(typeof(ButtonCalls))]
//public class GM : Editor
//{
//    public override void OnInspectorGUI()
//    {
//        DrawDefaultInspector();

//        if (GUILayout.Button("Restart"))
//        {
//            Application.LoadLevel(1);
//        }

//        if (GUILayout.Button("Clear Data"))
//            GameData.ClearData();
//    }
//}
