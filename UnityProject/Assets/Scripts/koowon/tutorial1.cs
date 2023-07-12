using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class tutorial1 : MonoBehaviour
{
    public GameObject tutorialArea;
    public Text tutorialText;
    public Move playerMove;
    public bool isTutorialActive = true;

    public void Start()
    {
        playerMove = FindObjectOfType<Move>();
        playerMove.enabled = true;

        tutorialText.text = "마우스를 클릭하여 움직이고 하얀 네모 박스를 찾으세요";
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (isTutorialActive && collision.gameObject == tutorialArea)
        {
            CompleteTutorial();
        }
    }

    public void CompleteTutorial()
    {
        isTutorialActive = false;
        tutorialText.text = "";
        Debug.Log("Tutorial completed!");
    }
}
