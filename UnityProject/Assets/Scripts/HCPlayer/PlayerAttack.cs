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
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
        for (int i = 0; i < projectile.Count; i++)
        {

            //if (!projectile[i].activeSelf)
            //  projectile.RemoveAt(i);\
            //Debug.Log("TLqkf");
            //projectile[i].transform.position = Vector2.MoveTowards(projectile[i].transform.position, FindClosestEnemy().transform.position, 8 * Time.deltaTime);
            //Debug.Log(FindClosestEnemy().ToString());
        }
    }
    
    void Attack()
    {
        //if (gos.Length > 0)
        {
            Projectile temp;
            temp = ObjectPooling.instance.GetPool().GetComponent<Projectile>();
            temp.transform.position = gameObject.transform.position;

            temp.SetTarget(FindClosestEnemy());
            //projectile.Add(temp);
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
