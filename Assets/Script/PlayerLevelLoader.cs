using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLevelLoader : MonoBehaviour {

    [SerializeField]
    private Object nextGrid = null;
    [SerializeField]
    public GameObject currentGrid;
    [SerializeField]
    private Queue<GameObject> levelQueue = new Queue<GameObject>();
    public int levelQueueCapacity = 3;
    
    public GameManager gameManager;
    public PlayerStatus playerStatus;

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "LevelGrp")
        {
            currentGrid = other.transform.parent.gameObject;
            levelQueue.Enqueue(currentGrid);

            if (levelQueue.Count > levelQueueCapacity)
                Destroy(levelQueue.Dequeue());

            if (gameManager.currentState == GameManager.GameState.InProgress)
            {
                if (Resources.LoadAll("LevelGrp", typeof(LevelGrpCode)) != null)
                {
                    Object[] myNextLevel = Resources.LoadAll("LevelGrp", typeof(LevelGrpCode)) as Object[];
                    print(myNextLevel);
                    LoadNextLevelGrp(myNextLevel);
                }
            }
            else if (gameManager.currentState == GameManager.GameState.StartMenu)
            {
                if (Resources.LoadAll("StartMenuLevelGrp", typeof(LevelGrpCode)) != null)
                {
                    Object[] myNextLevel = Resources.LoadAll("StartMenuLevelGrp", typeof(LevelGrpCode)) as Object[];
                    print(myNextLevel);
                    LoadNextLevelGrp(myNextLevel);
                }
            }
        }
    
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.tag == "SlowdownArea")
        {
            if (gameManager.currentState == GameManager.GameState.InProgress)
            {
                playerStatus.SlowdownToStartGame();
            }
        }
    }

    private void LoadNextLevelGrp(Object[] myNextLevel)
    {
        nextGrid = myNextLevel[Random.Range(0, myNextLevel.Length)];
        Transform nextSpawnSpot = currentGrid.GetComponent<LevelGrpCode>().nextSpawnPoint;
        Instantiate(nextGrid, nextSpawnSpot.position, Quaternion.identity);
    }
}
