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

    public float speedVirus;
    void Start()
    {
        score = 0;
        score = PlayerPrefs.GetInt("Score+", score);
        virusScore = 0;
        virusScore = PlayerPrefs.GetInt("VirusScore+", virusScore);
        StartCoroutine("UpVirus");
    }

   
    void Update()
    {
        clickText.text = score.ToString();
        virusText.text = virusScore.ToString();
        //if (virusScore < 0) virusScore++;

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
        while (score < 1000) { 
            virusScore = virusScore + Random.Range(-2, 4);
            
            PlayerPrefs.SetInt("VirusScore+", virusScore);
            virusText.text = virusScore.ToString();
            if (virusScore <= 0) virusScore=1;
            speedVirus = (2.0f / virusScore) + 0.0006f * score;
            yield return new WaitForSeconds(speedVirus);
        }
    }

    
}
