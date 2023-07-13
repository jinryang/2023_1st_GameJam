using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KusinChat : MonoBehaviour
{
    [SerializeField] Dialogue dialogue;
    bool IsEntered;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            dialogue.UI.SetActive(true);
            dialogue.StartTextintg();
        }
    }


    // Update is called once per frame
    void Update()
    {
        if(dialogue.Max)
        {
            dialogue.UI.SetActive(false);
            Instantiate(dialogue.Boss, gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
