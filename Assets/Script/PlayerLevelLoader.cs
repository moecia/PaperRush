using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLevelLoader : MonoBehaviour {

    [SerializeField]private Object n_nextLevel = null;
    [SerializeField]private GameObject n_lastLevel = null;


    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "LevelGrp")
        {
            if (n_lastLevel == null)
            { n_lastLevel = other.transform.parent.gameObject; }
            else
            {
                Destroy(n_lastLevel);
                n_lastLevel = other.transform.parent.gameObject;
            }
            if (Resources.LoadAll("LevelGrp", typeof(LevelGrpCode)) != null)
            {
                Object[] myNextLevel = Resources.LoadAll("LevelGrp", typeof(LevelGrpCode)) as Object[];
                print(myNextLevel);
                n_nextLevel = myNextLevel[Random.Range(0, myNextLevel.Length)];
                Transform nextSpawnSpot = n_lastLevel.GetComponent<LevelGrpCode>().nextSpawnPoint;
                Instantiate(n_nextLevel, nextSpawnSpot.position, Quaternion.identity);

            }
        }
    }
}
