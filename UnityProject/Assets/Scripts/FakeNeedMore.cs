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
    Blink Blink;
    bool IsChanged = false;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        Blink = GetComponent<Blink>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsBossStart)
        {
            Stimer += Time.deltaTime;
            if (Stimer >= 1.0f)
            {
                if (!IsChanged)
                {
                    IsChanged = true;
                    animator.SetBool("IsChanged", true);
                    Debug.Log("ischange");
                    //RealNeedMore = Instantiate(NeedMore);
                    Player.GetComponent<PlayerAttack>().DeleteGos(gameObject);
                    //Player.GetComponent<PlayerAttack>().AddGos(RealNeedMore);
                    //Blink.StartBlink(gameObject);
                }
            }
        }
    }

    void StartStartBlink()
    {
        Debug.Log("ehldjTek");
        Blink.StartBlink(gameObject);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlayerAttack")
        {
            IsBossStart = true;
        }
    }
}
