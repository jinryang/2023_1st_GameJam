using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KusinSoundWave : MonoBehaviour
{
    PlayerInfo playerInfo;
    public float speed = 0.001f;
    public string direc;
    public float LifeTime = 2f;
    public float spread;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {/*
            playerInfo = collision.GetComponent<PlayerInfo>();
            playerInfo.stat.HP -= 5;*/
        }
    }

    // Update is called once per frame
    void Update()
    {
        speed +=  5 * Time.deltaTime;
        LifeTime -= Time.deltaTime;
        if(LifeTime < 0)
        {
            Destroy(gameObject);
        }
        if (direc == "left")
        {
            gameObject.transform.Translate(new Vector3(-1 * speed, 0, 0) * Time.deltaTime, Space.Self);
            if(transform.localScale.x > 0)
            gameObject.transform.localScale = new Vector3((gameObject.transform.localScale.x + spread * Time.deltaTime), gameObject.transform.localScale.y + spread * Time.deltaTime, gameObject.transform.localScale.z);
            else
            {
                gameObject.transform.localScale = new Vector3((gameObject.transform.localScale.x - spread * Time.deltaTime), gameObject.transform.localScale.y + spread * Time.deltaTime, gameObject.transform.localScale.z);
            }
        }
        else
        {
            gameObject.transform.Translate(new Vector3(speed, 0, 0) * Time.deltaTime, Space.Self);
            gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x + spread * Time.deltaTime, gameObject.transform.localScale.y + spread * Time.deltaTime, gameObject.transform.localScale.z);
        }
    }
}
