using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInfo : MonoBehaviour
{
    public UnitCode unitCode;
    public Stat stat;
    private bool isHit;
    private bool isSlow;
    private Color color;
    public string targetTag;
    private float slowTimer;

    private int nowExp;
    private int level;
    public HpManager myHp;

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
        if (!isSlow && damage == 0)
        {
            if (slowTimer < 0)
                slowTimer = 0;
            slowTimer += 1;
            GetComponent<PlayerAgentScript>().Setspeed(1f);
            isSlow = true;
        }
        else if (isSlow)
        {
            slowTimer -= Time.deltaTime;
            if (slowTimer < 0)
            {
                GetComponent<PlayerAgentScript>().Setspeed(stat.moveSpeed);
                isSlow = false;
            }
        }
        if (!isHit && damage != 0)
        {
            stat.HP -= damage;
            Debug.Log("HP : " + stat.HP);
            gameObject.GetComponent<SpriteRenderer>().color = new Color(color.r, color.g, color.b, 0.5f);
            myHp.UpdateHP();
            if (stat.HP <= 0)
            {
                SceneManager.LoadScene("TitleScene");
            }
            isHit = true;
            StartCoroutine(GetDamage());
        }
    }

    IEnumerator GetDamage()
    {
        gameObject.GetComponent<SpriteRenderer>().color = color;
        yield return new WaitForSeconds(0.25f);
        gameObject.GetComponent<SpriteRenderer>().color = new Color(color.r, color.g, color.b, 0.5f);
        yield return new WaitForSeconds(0.25f);
        gameObject.GetComponent<SpriteRenderer>().color = color;
        yield return new WaitForSeconds(0.25f);
        gameObject.GetComponent<SpriteRenderer>().color = new Color(color.r, color.g, color.b, 0.5f);
        yield return new WaitForSeconds(0.25f);
        gameObject.GetComponent<SpriteRenderer>().color = color;
        isHit = false;
    }
}