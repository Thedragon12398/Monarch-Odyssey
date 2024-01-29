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

    public Text score;

    public TMP_Text win;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer >= 2)
        {
            float randObj = Random.Range(0, 2);

            randX = Random.Range(-2.0f, 2.0f);
            randObj = Random.Range(0.0f, 2.0f);
            Debug.Log(randObj);
            if (randObj <= 1 && randObj >= 0) randObj = 0;
            if (randObj <= 2 && randObj >= 1.1f) randObj = 1;

            Instantiate(fallingObject[(int)randObj], new Vector3(randX, 7.7f, 0.0f), Quaternion.identity);
            /*for (int i = 0; i < fallingObject.Length; i++)
            {
                fallingObject[i].GetComponent<Physics>().;
            }*/
            timer = 0;
        }
        else
            timer += Time.deltaTime;

        score.text = "Score: " + StackerMovement.instance.stacked.ToString();
        if (StackerMovement.instance.stacked == 15)
        {
            Time.timeScale = 0;
            win.gameObject.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Acorn 1(Clone)" || other.gameObject.name == "Apple 1(Clone)")
            Destroy(other.gameObject);
    }
}
