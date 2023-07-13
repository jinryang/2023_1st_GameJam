using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerAttack : MonoBehaviour
{
    public List<GameObject> gos;
    public List<GameObject> projectile;

    void Start()
    {
        gos = GameObject.FindGameObjectsWithTag("Enemy").ToList();
    }

    public int GetCount()
    {
        return gos.Count;
    }

    void Attack()
    {
        if (gos.Count > 0 && Vector3.Distance(gameObject.transform.position, FindClosestEnemy().transform.position) < 15)
        {
            Projectile temp;
            temp = ObjectPooling.instance.GetPool().GetComponent<Projectile>();
            temp.transform.position = gameObject.transform.position;

            temp.SetTarget(FindClosestEnemy());
            //projectile.Add(temp);
        }
    }

    public void DeleteGos(GameObject deleteObject)
    {
        Debug.Log("count1 : " + gos.Count);
        gos.Remove(deleteObject);
        Debug.Log("count2 : " + gos.Count);
    }

    public void AddGos(GameObject AddObject)
    {
        gos.Add(AddObject);
    }

    GameObject FindClosestEnemy()
    {
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector2 diff = go.transform.position - position;
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
