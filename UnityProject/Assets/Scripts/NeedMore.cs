using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedMore : MonoBehaviour
{
    bool IsChanged = false;
    public GameObject eagle;
    float Stimer = 0;
    int Rand;

    public GameObject AttackRange1;
    public GameObject AttackRange2;

    bool IsOnWarning = false;

    // Start is called before the first frame update
    void Start()
    {
        AttackRange1.SetActive(false);
        AttackRange2.SetActive(false);
        NeedMoreCash();
    }

    // Update is called once per frame
    void Update()
    {
        Stimer += Time.deltaTime;
        if(Stimer %10 == 0 && IsChanged)
        {
            SummonEagle();
        }
    }

    void RandomSkill()
    {
        Rand = Random.Range(0, 3);
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

    }
    void ALook_Start()
    {
        for(int i=0; i<9; i++)
        {
            ALookWarning();
        }
    }
    void ALook_Attack()
    {
        AttackRange2.SetActive(true);
    }

    IEnumerator ALookWarning()
    {
        yield return new WaitForSeconds(0.2f);
        AttackRange2.SetActive(IsOnWarning);
        IsOnWarning = !IsOnWarning;
    }   


}
