using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    public static ObjectPooling instance;
    

    public GameObject Prefab;
    private Queue<GameObject> projectileQueue = new Queue<GameObject>();

    void Start()
    {
        if (instance == null) instance = this;
        for (int i = 0; i < 10; i++)
        {
            GameObject temp = Instantiate(Prefab);
            temp.gameObject.SetActive(false);
            projectileQueue.Enqueue(temp);
        }
    }

    public void InsertPool(GameObject gameObject)
    {
        gameObject.SetActive(false);
        projectileQueue.Enqueue(gameObject);
    }
    public GameObject GetPool()
    {
        GameObject temp;
        if(projectileQueue.Count == 0)
        {
            temp = Instantiate(Prefab);
            temp.SetActive(true);
            return temp;
        }
        temp = projectileQueue.Dequeue();
        temp.SetActive(true);
        return temp;
    }
}
