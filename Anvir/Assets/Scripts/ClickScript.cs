using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickScript : MonoBehaviour
{
    public int score;
    public Text clickText;
    void Start()
    {
        score = 0;
        score = PlayerPrefs.GetInt("Score+", score);
    }

   
    void Update()
    {
        clickText.text = score.ToString();
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
    }
}
