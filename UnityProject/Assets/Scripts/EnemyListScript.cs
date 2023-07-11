using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyListScript : MonoBehaviour
{
    public List<GameObject> EnemyList;
    // Start is called before the first frame update
    void Start()
    {
        EnemyList = new List<GameObject> (GameObject.FindGameObjectsWithTag("Enemy"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
