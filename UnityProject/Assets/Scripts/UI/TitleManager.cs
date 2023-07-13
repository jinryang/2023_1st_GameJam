using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleManager : MonoBehaviour
{
    public void GameStart()
    {
        SceneManager.LoadScene("OpeningScene");
    }
    public void GameScene()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void KSM()
    {
        SceneManager.LoadScene("KSMScene");
    }

    public void GameExit()
    {
        Application.Quit();
    }
}
