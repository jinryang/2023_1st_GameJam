using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    //private float LifeTime = 2f;
    private Vector2 TargetPoint;

    // Use this for initialization
    void Start()
    {

    }

    public void SetTarget(GameObject Target)
    {
        TargetPoint = Target.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position,TargetPoint, 8*Time.deltaTime);
        if(new Vector2(transform.position.x, transform.position.y) == TargetPoint)
        {

        }
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.tag != "floor" && collision.tag != "Player")
        if(collision.tag == "Enemy")
        {
            
            ObjectPooling.instance.InsertPool(gameObject);
        }
    }
}
