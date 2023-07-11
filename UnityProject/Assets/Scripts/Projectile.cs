using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    //private float LifeTime = 2f;
    private Vector2 TargetPoint;


    public int rotateSpeed;
    //public Transform target;


    private bool isReset = false;

    private Vector3 dir;

    // Use this for initialization
    void Start()
    {

    }

    public void SetTarget(GameObject Target)
    {
        TargetPoint = Target.transform.position;
        SetDirection();
    }

    //private void OnEnable()
    //{
    //    isReset = false;
    //}

    // Update is called once per frame
    void Update()
    {
        //if(!isReset)
        //    ResetRotation();
        //gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position,TargetPoint, 8*Time.deltaTime);
        //if(new Vector2(transform.position.x, transform.position.y) == TargetPoint)
        //{
        //    ObjectPooling.instance.InsertPool(gameObject);
        //}
        Debug.Log("dk");
        transform.Translate(dir*10*Time.deltaTime);
    }

    private void SetDirection()
    {
        dir = new Vector3(TargetPoint.x, TargetPoint.y, 0) - this.transform.position;
        dir.Normalize();
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
