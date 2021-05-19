using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchingLane : MonoBehaviour
{
    [SerializeField] private float speed = 10;
    [SerializeField] private float totalTime = 5;
    [SerializeField] private GameManager gameManager;
    private float currentTime = 0;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void Update()
    {
        if (currentTime <= totalTime && gameManager.currentState == GameManager.GameState.InProgress)
        {
            currentTime += Time.deltaTime;
            var prevPos = transform.position;
            var newY = prevPos.y - speed * Time.deltaTime;
            transform.position = new Vector3(prevPos.x, newY, prevPos.z);
        }
    }
}
