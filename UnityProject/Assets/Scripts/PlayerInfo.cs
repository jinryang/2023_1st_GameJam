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

    private int nowExp;
    private int level;

    void Awake()
    {
        stat = new Stat();
        stat = stat.SetUnitStat(unitCode);
        isHit = false;
        color = gameObject.GetComponent<SpriteRenderer>().color;
        targetTag = "Enemy";
        level = 1;

    }

    public void GetEXP(int value)
    {
        nowExp += value;
        Debug.Log("Lv. " + level + "    exp : " + nowExp + "/" + stat.EXP);
        if (nowExp >= stat.EXP)
        {
            nowExp -= stat.EXP;

            //레벨업 템주기



            level++;
            stat.EXP += (int)(stat.EXP * 0.5f);
        }
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