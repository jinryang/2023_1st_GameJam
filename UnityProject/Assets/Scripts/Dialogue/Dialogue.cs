using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    [SerializeField] public Text textObj;
    [SerializeField] string[] EventText;

    private int num;

    public float time;

    public bool playingDialoue;

    void Start()
    {
        textObj.text = "";
    }

    public void StartTextintg(int n, int team)
    {
        if (!playingDialoue)
        {
            StartCoroutine(Type(EventText[num - 1]));
        }
    }

    IEnumerator Type(object text)
    {
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
    }

    void Update()
    {

    }
}
