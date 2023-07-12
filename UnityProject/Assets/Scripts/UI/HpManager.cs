using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpManager : MonoBehaviour
{
    PlayerInfo playerInfo;
    public Sprite[] heart;
    public Image[] heartImages;

    void Start()
    {
        playerInfo = GameObject.FindWithTag("Player").GetComponent<PlayerInfo>();
    }

    public void UpdateHP()
    {
        int i;
        for(i = 0; i < playerInfo.stat.HP; i++)
        {
            heartImages[i/2].sprite = heart[i%2];
        }
        for (; i < 10; i++)
        {
            if (i % 2 == 0)
            {
                heartImages[i / 2].sprite = heart[2];
            }
        }
    }
}