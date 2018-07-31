using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallObject : MonoBehaviour {

    [SerializeField] private bool m_twoWallMode = false;
    [SerializeField] private List<GameObject> m_threeWall = null;
    [SerializeField] private List<GameObject> m_wallToPass = null;
    
    // Use this for initialization
    private void Start ()
    {
        for (int i = 0; i < this.transform.childCount; i++)
            {
            Transform newWall = this.transform.GetChild(i);
            m_threeWall.Add(newWall.gameObject);
            }
        if(m_twoWallMode)
        {
            for (int i = 0; i < 2; i++)
            {
                AddWall();
            }
        }
        else
        {
            AddWall();
        }
    }
    private void AddWall()
    {
        int picknum = Random.Range(0, m_threeWall.Count);
        m_wallToPass.Add(m_threeWall[picknum]);
        for(int i = 0; i < m_wallToPass.Count; i++)
        {
            if (m_wallToPass[i].GetComponent<WallPlane>() != null)
            {
                m_wallToPass[i].GetComponent<WallPlane>().SetWall();
            }
        }
    }
}
