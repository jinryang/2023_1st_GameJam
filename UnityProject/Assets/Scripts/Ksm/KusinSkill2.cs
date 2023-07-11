using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KusinSkill2 : MonoBehaviour
{
    [SerializeField] Animation animation;


    public void Skill(Transform targer)
    {
        //shot Bullet
        gameObject.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - 2);
        gameObject.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y + 2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
