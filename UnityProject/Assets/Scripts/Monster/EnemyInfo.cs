using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInfo : MonoBehaviour
{
    public UnitCode unitCode;
    public Stat stat;
    private Color color;
    public GameObject target;

    void Awake()
    {
        stat = new Stat();
        stat = stat.SetUnitStat(unitCode);
        color = gameObject.GetComponent<SpriteRenderer>().color;
        target = GameObject.FindGameObjectWithTag("Player");

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        
    }
}
