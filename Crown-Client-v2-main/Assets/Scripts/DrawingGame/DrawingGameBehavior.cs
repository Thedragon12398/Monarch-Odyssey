using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class DrawingGameBehavior : MonoBehaviour
{
    private static int score;
    public float timeRemaining = 40;
     public bool timerIsRunning = false;
     public TMP_Text timeText;

    public GameObject Line1, Line2, Line3, Line4, Line5, Line6, Line7, Line8, Line9, Line10, Line11, Line12, Line13, Line14, Line15, Line16, Line17;
    public GameObject s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11, s12, s13, s14, s15, s16, s17;
    public bool square = false;
    public bool triangle = false;
    public bool star = false;


    void Start()
    {
        timerIsRunning = true;

        Line1.SetActive(false);
        Line2.SetActive(false);
        Line3.SetActive(false);
        Line4.SetActive(false);

        Line5.SetActive(false);
        Line6.SetActive(false);
        Line7.SetActive(false);

        Line8.SetActive(false);
        Line9.SetActive(false);
        Line10.SetActive(false);
        Line11.SetActive(false);
        Line12.SetActive(false);
        Line13.SetActive(false);
        Line14.SetActive(false);
        Line15.SetActive(false);
        Line16.SetActive(false);
        Line17.SetActive(false);
    }
    
    void Update()
    {
        score = SpawnSphere.currentScore;
        
        ///square
        if (s1.activeSelf == true && s2.activeSelf == true)
        { 
            Line1.SetActive(true);
        }
        if (s2.activeSelf == true && s3.activeSelf == true)
        {
            Line2.SetActive(true);
        }
        if (s1.activeSelf == true && s4.activeSelf == true)
        {
            Line3.SetActive(true);
            Line4.SetActive(true);
            if (Line1 == true && Line2 == true && Line3 == true && Line4 == true)
            {
                square = true;
            }
        }

        ///triangle
        if (s5.activeSelf == true && s6.activeSelf == true )
        {
            Line5.SetActive(true);
        }
        if (s6.activeSelf == true && s7.activeSelf == true)
        {
            Line6.SetActive(true);
            Line7.SetActive(true);
            if (Line5 == true && Line6 == true && Line7 == true)
            {
                triangle = true;
            }
        }

        ///star
        if (s8.activeSelf == true && s9.activeSelf == true)
        {
            Line8.SetActive(true);
        }
        if (s9.activeSelf == true && s10.activeSelf == true)
        {
            Line9.SetActive(true);
        }
        if (s10.activeSelf == true && s11.activeSelf == true)
        {
            Line10.SetActive(true);
        }
        if (s11.activeSelf == true && s12.activeSelf == true)
        {
            Line11.SetActive(true);
        }
        if (s12.activeSelf == true && s13.activeSelf == true)
        {
            Line12.SetActive(true);
        }
        if (s13.activeSelf == true && s14.activeSelf == true)
        {
            Line13.SetActive(true);
        }
        if (s14.activeSelf == true && s15.activeSelf == true)
        {
            Line14.SetActive(true);
        }
        if (s15.activeSelf == true && s16.activeSelf == true)
        {
            Line15.SetActive(true);
        }
        if (s16.activeSelf == true && s17.activeSelf == true)
        {
            Line16.SetActive(true);
        }
        if (s17.activeSelf == true && s8.activeSelf == true)
        {
            Line17.SetActive(true);
            if (Line8 == true && Line9 == true && Line10 == true && Line11 == true && Line12 == true && Line13 == true && Line14 == true && Line15 == true && Line16 == true && Line17 == true)
            {
                star = true;
            }
        }

        if (score == 17)
        {
            WinGame();
        }

        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                Debug.Log("Time has run out!");
                timeRemaining = 0;
                timerIsRunning = false;
                LoseGame();
            }
        }
    }

    void WinGame()
    {
        ///if (all pointPrefab have been clicked then game win and give points to the player)
        Debug.Log("Win Game!");

        //SceneManager.LoadScene("GameScene");
    }

    void LoseGame()
    {
        ///go back to main screen without xp
        Debug.Log("LOSE GAME :(");

        //SceneManager.LoadScene("GameScene");
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = string.Format("{00}", seconds);
    }
}
    