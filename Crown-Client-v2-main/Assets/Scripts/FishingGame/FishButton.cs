using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishButton : MonoBehaviour
{
    protected GameObject fishManager;
    protected bool successfullyClicked = false;
    protected bool unsuccessfullyClicked = false;
    protected float speedConstant = 2f;
    float destroyTimer = 1f;

    private void Awake() {
        SetPosition();
        fishManager = GameObject.FindGameObjectWithTag("FishManager");
    }
    /// <summary>
    /// Places the button at a random position on the canvas
    /// </summary>
    void SetPosition() {
        int xPosition = Random.Range(-300, 300);
        int yPosition = Random.Range(-150, 150);
        transform.position = new Vector2(xPosition, yPosition);
    }
    /// <summary>
    /// Destroys the object after a certain amount of time
    /// </summary>
    protected void TimedDestroy() {
        destroyTimer -= Time.deltaTime;
        if (destroyTimer <= 0) {
            Destroy(this.gameObject);
        }
    }
}
