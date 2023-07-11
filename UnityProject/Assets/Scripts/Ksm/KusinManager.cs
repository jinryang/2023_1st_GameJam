using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KusinManager : MonoBehaviour
{
    public float time;
    float temptime;
    EnemyAgentScript enemy = new EnemyAgentScript();
    KusinSkill1 kusinSkill1;
    KusinSkill2 kusinSkill2;

    void Start()
    {
        temptime = time;
    }

    void Update()
    {
        if (time < 0)
        {
            int a =  Random.Range(0, 2);
            if(a == 0)
            {
                kusinSkill1.Skill(enemy.GetTarget());
            }
            if (a == 1)
            {
                kusinSkill2.Skill(enemy.GetTarget());
            }
            time = temptime;
        }
    }
}
