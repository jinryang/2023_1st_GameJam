using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    public UnitCode unitCode;
    public Stat stat;
    private bool isHit;
    private Color color;
    public string targetTag;

    void Awake()
    {
        stat = new Stat();
        stat = stat.SetUnitStat(unitCode);
        isHit = false;
        color = gameObject.GetComponent<SpriteRenderer>().color;
        targetTag = "Enemy";

    }

    public void GetDamage(int damage)
    {
        if (!isHit)
        {
            stat.HP -= damage;
            Debug.Log("HP : " + stat.HP);
            gameObject.GetComponent<SpriteRenderer>().color = new Color(color.r, color.g, color.b, 0.5f);
            if (stat.HP <= 0)
            {
                //게임오버
            }
            isHit = true;
            StartCoroutine(GetDamage());
        }
    }

    IEnumerator GetDamage()
    {
        yield return new WaitForSeconds(1f);
        gameObject.GetComponent<SpriteRenderer>().color = color;
        isHit = false;
    }
}