using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class NeedInfo : MonoBehaviour
{
    public GameObject target;
    public GameObject preHpBar;
    public GameObject canvas;

    GameObject hpBar;
    RectTransform hpBarTrans;
    Slider hpBarSlider;
    public float height = 1.5f;

    int HP = 20;

    public GameObject PreBullet;

    void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        canvas = GameObject.FindGameObjectWithTag("Canvas");
        hpBar = Instantiate(preHpBar, canvas.transform);
        hpBarTrans = hpBar.GetComponent<RectTransform>();
        hpBarSlider = hpBar.GetComponent<Slider>();

        hpBarSlider.maxValue = HP;
        hpBarSlider.value = HP;


    }

    private void Update()
    {
        Vector3 hpBarPos = Camera.main.WorldToScreenPoint(new Vector3(transform.position.x, transform.position.y + height, 0));
        hpBarTrans.position = hpBarPos;
    }

    private void GetDamage()
    {
        HP -= target.GetComponent<PlayerInfo>().stat.ATK;
        Debug.Log("monsterHP : " + HP);
        hpBarSlider.value = HP;
        if (HP <= 0)
        {
            //적 처치 보상
            target.GetComponent<PlayerAttack>().DeleteGos(gameObject);
            Destroy(hpBar);
            Destroy(gameObject);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerAttack"))
        {
            GetDamage();
        }
    }
}