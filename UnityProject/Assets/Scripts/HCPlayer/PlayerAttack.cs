using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    
    public GameObject Prefab;
    GameObject[] gos;
    public List<GameObject> projectile;
    // Start is called before the first frame update
    void Start()
    {
        gos = GameObject.FindGameObjectsWithTag("Enemy");
        Attack();
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < projectile.Count; i++)
            projectile[i].transform.position = Vector2.MoveTowards(gameObject.transform.position, FindClosestEnemy().transform.position, 8 * Time.deltaTime);
    }
    
    void Attack()
    {
        if (gos.Length > 0)
        {
            projectile.Add(Instantiate(Prefab));           
            Debug.Log(FindClosestEnemy().transform.position);
        }
    }
    
    // Find the name of the closest enemy
    GameObject FindClosestEnemy()
    {

        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector2 diff =  go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;
    }
}
