using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimedButton : FishButton
{
    public GameObject ring;
    float xScale = 2.5f;
    float yScale = 2.5f;
    bool unsuccessfullyClicked = false;

    private void Update() {
        if (successfullyClicked || unsuccessfullyClicked) {
            TimedDestroy();
        } else {
            Shrink();
        }
    }
    void Shrink() {
        xScale -= Time.deltaTime / speedConstant;
        yScale -= Time.deltaTime / speedConstant;
        ring.GetComponent<Transform>().localScale = new Vector2(xScale, yScale);
        //Once ring becomes too small, automatically count it as a miss
        if (xScale <= 0.3f) {
            unsuccessfullyClicked = true;
            ring.GetComponent<Image>().color = Color.red;
            fishManager.GetComponent<FishManager>().ButtonMissed();
        }
    }
    public void Clicked() {
        //Only count the button if it is clicked within specific range
        if (xScale <= 1.1f && xScale >= 0.5f) {
            successfullyClicked = true;
            ring.GetComponent<Image>().color = Color.green;
            fishManager.GetComponent<FishManager>().ButtonClicked();
        } else {
            unsuccessfullyClicked = true;
            ring.GetComponent<Image>().color = Color.red;
            fishManager.GetComponent<FishManager>().ButtonMissed();
        }
    }
}
