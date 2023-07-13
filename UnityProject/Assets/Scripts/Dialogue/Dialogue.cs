using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    public GameObject Boss;
    [SerializeField] Text textObj;
    [SerializeField] string[] EventText;
    [SerializeField] Image Player;
    [SerializeField] Image DialogueTarget;
    public GameObject UI;

    int playTime = 0;

    public int maxText;

    int now;

    private int num = 0;

    public float time;

    public bool playingDialoue;

    public bool SpawnBoss;

    public bool Max;

    void Start()
    {
        textObj.text = "";
    }

    public void StartTextintg()
    {
        if(num == EventText.Length)
        {
            if(SpawnBoss)
            {
                Instantiate(Boss, gameObject.transform.position, Quaternion.identity);
                UI.SetActive(false);
                Destroy(gameObject);
            }
            else
            {
                UI.SetActive(false);
                Destroy(gameObject);
            }
        }
        else if (!playingDialoue)
        {
            StartCoroutine(Type(EventText[num++], playTime % 2));
        }
    }

    IEnumerator Type(object text, int Who)
    {
        textObj.text = "";
        if(Who == 1)
        {
            DialogueTarget.color = new Color(0.5f, 0.5f, 0.5f, 1);
            Player.color = new Color(1, 1, 1, 1);
        }
        else
        {
            Player.color = new Color(0.5f, 0.5f, 0.5f, 1);
            DialogueTarget.color = new Color(1, 1, 1, 1);
        }
        WaitForSeconds waitForSeconds = new WaitForSeconds(time);
        playingDialoue = true;
        string SText = text.ToString();
        foreach (char i in SText.ToCharArray())
        {
            textObj.text += i;
            yield return waitForSeconds;
        }
        textObj.text += "\n";
        playingDialoue = false;
        playTime++;
    }

    void Update()
    {

    }
}
