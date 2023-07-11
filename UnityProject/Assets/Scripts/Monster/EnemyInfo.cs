using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyInfo : MonoBehaviour
{
    public UnitCode unitCode;
    public Stat stat;
    private Color color;
    public GameObject target;

    float timer = 0f;
    bool isCrash = false;

    void Awake()
    {
        stat = new Stat();
        stat = stat.SetUnitStat(unitCode);
        color = gameObject.GetComponent<SpriteRenderer>().color;
        target = GameObject.FindGameObjectWithTag("Player");

    }

    private void Update()
    {
        if (isCrash)
        {
            if (timer > 0.2f)
            {
                target.GetComponent<PlayerInfo>().GetDamage(stat.ATK);
                timer = 0f;
            }
            else
                timer += Time.deltaTime;
        }
    }

    private void GetDamage()
    {
        stat.HP -= target.GetComponent<PlayerInfo>().stat.ATK;
        if (stat.HP <= 0)
        {
            //적 처치 보상

            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(target.tag))
        {
            timer = 1f;
            isCrash = true;
        }
        if (collision.CompareTag("PlayerAttack"))
        {
            GetDamage();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(target.tag))
            isCrash = false;
    }
}