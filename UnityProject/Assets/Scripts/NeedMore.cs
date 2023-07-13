using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedMore : MonoBehaviour
{
    bool IsChanged = false;
    public GameObject eagle;
    float Stimer = 0;
    int Rand;
    Animator animator;

    public GameObject AttackRange1;
    public GameObject AttackRange2;
    bool IsAttaking = false;

    bool IsOnWarning = false;

    // Start is called before the first frame update
    void Start()
    {
        AttackRange1.SetActive(false);
        AttackRange2.SetActive(false);
        NeedMoreCash();

        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Stimer += Time.deltaTime;
        Debug.Log(Stimer);
        Debug.Log(IsChanged);
        if (Stimer>=4 && IsChanged)
        {
            RandomSkill();
            Stimer = 0;
        }
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
        //TODO변신
        //페이드 인, 아웃
        //
        IsChanged = true;
    }
    void SummonEagle()
    {
        Instantiate(eagle);
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
