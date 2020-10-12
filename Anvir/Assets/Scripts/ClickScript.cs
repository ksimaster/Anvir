using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ClickScript : MonoBehaviour
{
    public int score;
    public Text clickText;

    public int virusScore;
    public Text virusText;

    public GameObject StartPanel;

    public GameObject WinLosePanel;
    public Text winLoseText;

    public GameObject ExitPanel;

    public Button AdButton;

    public float speedVirus;

    public bool paused = false;

    public int MaxScore = 1000;
    void Start()
    {
        if(!StartPanel.activeSelf) StartPanel.SetActive(true);
    }
   
   
    void Update()
    {
       /* clickText.text = score.ToString() + " / 1000";
        virusText.text = virusScore.ToString(); */

        //if (virusScore < 0) virusScore++;
        WinOrLose();
        PauseGame();
    }

    private void FixedUpdate()
    {
        clickText.text = score.ToString() + " / 1000";
        virusText.text = virusScore.ToString();
    }
    
    public void BonusClick()
    {
        score += 50;
    }

    public void ClikerScore()
    {
        score++;    
        PlayerPrefs.SetInt("Score+", score);
    }

    public void Reset()
    {
        PlayerPrefs.DeleteAll();
        score = 0;
        virusScore = 0;
    }

    IEnumerator UpVirus()
    {
        while (score < MaxScore || virusScore< MaxScore) { 
            virusScore = virusScore + Random.Range(-1, 3);
            
            PlayerPrefs.SetInt("VirusScore+", virusScore);
            virusText.text = virusScore.ToString();
            if (virusScore <= 0) virusScore=1;
            
            speedVirus = (3.7f / virusScore) + 0.009f * score;
            yield return new WaitForSeconds(speedVirus);
        }
    }

    public void WinOrLose()
    {
       
        if (score >= MaxScore)
        {
            OpenWinLose();
            winLoseText.text = "Ты победил! Ещё раз?";
        }

        if (virusScore >= MaxScore)
        {
            OpenWinLose();
            winLoseText.text = "Не получилось... Попробуешь еще?";
        }
    }

    public void NewGame()
    {
        score = 0;
        score = PlayerPrefs.GetInt("Score+", score);
        virusScore = 0;
        virusScore = PlayerPrefs.GetInt("VirusScore+", virusScore);
        StartCoroutine("UpVirus");
    }

    public void OpenStartPanel()
    {
        StopCoroutine("UpVirus");
        if (!StartPanel.activeSelf) StartPanel.SetActive(true);
       
    }

    public void CloseStartPanel()
    {
        StartCoroutine("UpVirus");
        if (StartPanel.activeSelf) StartPanel.SetActive(false);
    }

    public void OpenWinLose()
    {
        StopCoroutine("UpVirus");
        if (!WinLosePanel.activeSelf) WinLosePanel.SetActive(true);
    }


    public void OpenExitPanel()
    {
        StopCoroutine("UpVirus");
        if (!ExitPanel.activeSelf) ExitPanel.SetActive(true);
    }

    public void CloseExitPanel()
    {
        StartCoroutine("UpVirus");
        if (ExitPanel.activeSelf) ExitPanel.SetActive(false);
    }

    public void CloseWinLose()
    {
        if (WinLosePanel.activeSelf) WinLosePanel.SetActive(false);
    }

    public void PauseGame()
    {
        if(ExitPanel.activeSelf || StartPanel.activeSelf || WinLosePanel.activeSelf)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    public void CloseGame()
    {
        Application.Quit();
    }
    
}
