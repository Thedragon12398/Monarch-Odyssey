using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StackingManager : MonoBehaviour
{
    public GameObject[] fallingObject;

    private float randX = 0;
    private float timer = 0;
    private float timeUntilNextObject = 1;
    private int winningScore = 25;

    public Text score;
    public TMP_Text win;

    
    void Update() {
        InstantiateObjects();
        UpdateScore();
    }

    private void UpdateScore() {
        score.text = "Score: " + StackerMovement.instance.stacked.ToString();
        if (StackerMovement.instance.stacked == winningScore) {
            Time.timeScale = 0;
            win.gameObject.SetActive(true);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    void InstantiateObjects() {
        if (timer >= timeUntilNextObject) {
            float randObj = Random.Range(0, 2);

            randX = Random.Range(-10f, 10f); //Range Objects will fall within
            randObj = Random.Range(0f, 2f);
            Debug.Log(randObj);
            if (randObj <= 1 && randObj >= 0) randObj = 0;
            if (randObj <= 2 && randObj >= 1.1f) randObj = 1;

            Instantiate(fallingObject[(int)randObj], new Vector3(randX, 7.7f, 0.0f), Quaternion.identity);
            /*for (int i = 0; i < fallingObject.Length; i++)
            {
                fallingObject[i].GetComponent<Physics>().;
            }*/
            timeUntilNextObject = Random.Range(0.3f, 3f);
            timer = 0;
        } else {
            timer += Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Acorn 1(Clone)" || other.gameObject.name == "Apple 1(Clone)")
            Destroy(other.gameObject);
    }
}
