using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedAttackRange : MonoBehaviour
{
    public GameObject Player;
    bool IsDamaged = false;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if(!IsDamaged)
                Player.GetComponent<PlayerInfo>().GetDamage(2);
            IsDamaged = true;
        }
    }
}
