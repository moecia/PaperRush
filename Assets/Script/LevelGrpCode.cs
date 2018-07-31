using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGrpCode : MonoBehaviour {

    private Transform m_nextSpawnPoint = null;
    public Transform nextSpawnPoint
    { get { return m_nextSpawnPoint; } }

	// Use this for initialization
	private void Start ()
    {
        m_nextSpawnPoint = this.transform.Find("NextLevelSpawnPoint");

    }
}
