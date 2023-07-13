using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedMore : MonoBehaviour
{
    bool IsChanged = false;
    public GameObject eagle;
    float Stimer = 1;
    int Rand;
    Animator animator;
    Blink Blink;

    public GameObject AttackRange1;
    public GameObject AttackRange2;
    bool IsAttaking = false;

    bool IsOnWarning = false;
    GameObject Player;

    float HP;

    // Start is called before the first frame update
    void Start()
    {
        AttackRange1.SetActive(false);
        AttackRange2.SetActive(false);
        Blink = GetComponent<Blink>();
        NeedMoreCash();
        

        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Stimer += Time.deltaTime;
        if (Stimer>=4 && IsChanged)
        {
            RandomSkill();
            Stimer = 0;
        }
        if(Player == null)
            Player = GameObject.Find("Player");
    }

    void RandomSkill()
    {
        Rand = Random.Range(0, 2);
        switch(Rand)
        {
            case 0:
                SummonEagle();
                break;
            case 1:
                ALook();
                break;
        }
    }

    void NeedMoreCash()
    {
        //페이드 인, 아웃
        //
        //Blink.StartBlink();
        IsChanged = true;
    }
    void SummonEagle()
    {
        Player.GetComponent<PlayerAttack>().AddGos(Instantiate(eagle));
        Player.GetComponent<PlayerAttack>().AddGos(Instantiate(eagle));
    }
    void ALook()
    {
        if (!IsAttaking)
        {
            animator.SetBool("IsALook", true);
            ALook_Start();
            IsAttaking = true;
        }
    }
    void ALook_Start()
    {
        //for(int i=0; i<4; i++)
        //{
            StartCoroutine(ALookWarning());
            //if (i == 4)
              //  StartCoroutine(ALookEnd());
        //}
    }
    void ALook_Attack()
    {
        AttackRange2.SetActive(true);
        StartCoroutine(ALookEnd());
    }

    IEnumerator ALookWarning()
    {
        for (int i = 0; i < 5; i++)
        {
            yield return new WaitForSeconds(0.2f);
            AttackRange1.SetActive(IsOnWarning);
            IsOnWarning = !IsOnWarning;
        }
        ALook_Attack();

        IsOnWarning = false;

    }
    IEnumerator ALookEnd()
    {
        animator.SetBool("IsALook", false);
        yield return new WaitForSeconds(1f);
        AttackRange2.SetActive(false);
        IsAttaking = false;
    }


}
