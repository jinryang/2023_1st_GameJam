using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    [SerializeField] Sprite flowerState;
    [SerializeField] Sprite flowerShot;
    [SerializeField] SpriteRenderer Flower;

    float time = 3;
    float temptime;
    float shotTime = 0.5f;
    float TST;
    bool isshot;
    void Start()
    {
        temptime = time;
        TST = shotTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(!isshot)
        {
            time -= Time.deltaTime;
            if(time < 0)
            {
                Flower.sprite = flowerShot;
                isshot = true;
                time = temptime;
            }
        }
        else
        {
            shotTime -= Time.deltaTime;
            if(shotTime < 0)
            {
                Flower.sprite = flowerState;
                isshot = false;
                shotTime = TST;
            }
        }
    }
}
