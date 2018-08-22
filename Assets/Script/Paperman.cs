using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Paperman : MonoBehaviour
{
    public GameManager gameManager;
    public Transform mainMover;
    public PlayerStatus playerStatus;
    public int healthDamage = -1;
    public int scoreRate = 1;

    [Header("LevelGridLoader")]
    [SerializeField]
    private Object nextGrid = null;
    [SerializeField]
    public GameObject currentGrid;
    [SerializeField]
    private Queue<GameObject> levelQueue = new Queue<GameObject>();
    public int levelQueueCapacity = 3;
	
	// Update is called once per frame
	void Update ()
    {
		if(playerStatus.currentHealth > 0)
            mainMover.Translate(Vector3.forward * Time.deltaTime * playerStatus.currentSpeed);
    }

    private void OnTriggerEnter(Collider other)
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

        else if (other.CompareTag("wall"))
        {
            if (other.GetComponent<WallPlane>() != null)
            {
                WallPlane theWallObject = other.GetComponent<WallPlane>();
                switch (theWallObject.m_planeType)
                {
                    case WallPlane.m_Plane.Block:
                        playerStatus.SetCurrentHealth(healthDamage);
                        break;
                    case WallPlane.m_Plane.Running:
                        if (playerStatus.currentPose == PlayerStatus.PlayerPose.Running)
                            playerStatus.SetPlayerScore(scoreRate);
                        else
                            playerStatus.SetCurrentHealth(healthDamage);
                        break;
                    case WallPlane.m_Plane.PoseUp:
                        if (playerStatus.currentPose == PlayerStatus.PlayerPose.Up)
                            playerStatus.SetPlayerScore(scoreRate);
                        else
                            playerStatus.SetCurrentHealth(healthDamage);
                        break;
                    case WallPlane.m_Plane.PoseDown:
                        if (playerStatus.currentPose == PlayerStatus.PlayerPose.Down)
                            playerStatus.SetPlayerScore(scoreRate);
                        else
                            playerStatus.SetCurrentHealth(healthDamage);
                        break;
                    case WallPlane.m_Plane.PoseLeft:
                        if (playerStatus.currentPose == PlayerStatus.PlayerPose.Left)
                            playerStatus.SetPlayerScore(scoreRate);
                        else
                            playerStatus.SetCurrentHealth(healthDamage);
                        break;
                    case WallPlane.m_Plane.PoseRight:
                        if (playerStatus.currentPose == PlayerStatus.PlayerPose.Right)
                            playerStatus.SetPlayerScore(scoreRate);
                        else
                            playerStatus.SetCurrentHealth(healthDamage);
                        break;
                }
            }
        }

        else if (other.tag == "Jumpwall")
            playerStatus.SetCurrentHealth(healthDamage);      
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "SlowdownArea")
            if (gameManager.currentState == GameManager.GameState.InProgress)
                playerStatus.SlowdownToStartGame();
    }

    private void LoadNextLevelGrp(Object[] myNextLevel)
    {
        nextGrid = myNextLevel[Random.Range(0, myNextLevel.Length)];
        Transform nextSpawnSpot = currentGrid.GetComponent<LevelGrpCode>().nextSpawnPoint;
        Instantiate(nextGrid, nextSpawnSpot.position, Quaternion.identity);
    }
}
