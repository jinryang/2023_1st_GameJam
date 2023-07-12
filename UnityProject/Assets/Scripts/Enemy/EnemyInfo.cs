using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class EnemyInfo : MonoBehaviour
{
    public UnitCode unitCode;
    public Stat stat;
    private Color color;
    public GameObject target;
    public GameObject preHpBar;
    public GameObject canvas;

    GameObject hpBar;
    RectTransform hpBarTrans;
    Slider hpBarSlider;
    public float height = 1.5f;

    public GameObject PreBullet;

    float timer = 0f;
    bool isCrash = false;

    void Awake()
    {
        stat = new Stat();
        stat = stat.SetUnitStat(unitCode);
        color = gameObject.GetComponent<SpriteRenderer>().color;
        target = GameObject.FindGameObjectWithTag("Player");
        canvas = GameObject.FindGameObjectWithTag("Canvas");
        hpBar = Instantiate(preHpBar, canvas.transform);
        hpBarTrans = hpBar.GetComponent<RectTransform>();
        hpBarSlider = hpBar.GetComponent<Slider>();

        hpBarSlider.maxValue = stat.maxHp;
        hpBarSlider.value = stat.maxHp;


    }

    private void Update()
    {
        if (target.transform.position.x < transform.position.x)
            transform.localScale = new Vector3(1, 1, 1);
        else if (target.transform.position.x > transform.position.x)
            transform.localScale = new Vector3(-1, 1, 1);

        Vector3 hpBarPos = Camera.main.WorldToScreenPoint(new Vector3(transform.position.x, transform.position.y + height, 0));
        hpBarTrans.position = hpBarPos;

        if (isCrash && stat.moveSpeed != 0)
        {
            if (timer > stat.AttackSpeed)
            {
                target.GetComponent<PlayerInfo>().GetDamage(stat.ATK);
                timer = 0f;
            }
            else
                timer += Time.deltaTime;
        }
        if (stat.moveSpeed == 0)
        {
            if (timer > stat.AttackSpeed)
            {
                Attack();
                timer = 0f;
            }
            else
                timer += Time.deltaTime;
        }
    }

    private void GetDamage()
    {
        stat.HP -= target.GetComponent<PlayerInfo>().stat.ATK;
        Debug.Log("monsterHP : " + stat.HP);
        hpBarSlider.value = stat.HP;
        if (stat.HP <= 0)
        {
            target.GetComponent<PlayerInfo>().GetEXP(stat.EXP);
            //적 처치 보상
            target.GetComponent<PlayerAttack>().DeleteGos(gameObject);
            Destroy(hpBar);
            Destroy(gameObject);
        }
    }

    void Attack()
    {
        if (Vector3.Distance(gameObject.transform.position, GetComponent<EnemyInfo>().target.transform.position) < 13)
        {
            GameObject bullet = Instantiate(PreBullet, transform.position, Quaternion.identity);
            bullet.GetComponent<EnemyBullet>().target = target;
            bullet.GetComponent<EnemyBullet>().speed = stat.ShotSpeed;
            bullet.GetComponent<EnemyBullet>().damage = stat.ATK;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(target.tag))
        {
            timer = 10f;
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