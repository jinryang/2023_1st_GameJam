using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeNeedMore : MonoBehaviour
{
    bool IsBossStart = false;
    float Stimer = 0;
    public GameObject NeedMore;
    public GameObject Player;
    GameObject RealNeedMore;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (IsBossStart)
        {
            Stimer += Time.deltaTime;
            if (Stimer >= 1.0f)
            {
                RealNeedMore = Instantiate(NeedMore);
                Player.GetComponent<PlayerAttack>().DeleteGos(gameObject);
                Player.GetComponent<PlayerAttack>().AddGos(RealNeedMore);
                Destroy(gameObject);
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlayerAttack")
        {
            IsBossStart = true;
        }
    }
}
