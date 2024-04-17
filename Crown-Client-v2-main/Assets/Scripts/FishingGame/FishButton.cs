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

        //To-Do: find a solution to overlapping buttons;
        //Below is the attempted solution that doesn't quite work
        Collider2D collider = Physics2D.OverlapCircle(new Vector2(xPosition, yPosition), 100f, LayerMask.GetMask("UI"));
        while (collider) {
            if (collider == this.GetComponent<Collider2D>()) break;
            Debug.Log("Blocked by " + collider.name);
            xPosition = Random.Range(-300, 300);
            yPosition = Random.Range(-150, 150);
            collider = Physics2D.OverlapCircle(new Vector2(xPosition, yPosition), 100f, LayerMask.GetMask("UI"));
        }
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
    private void OnDrawGizmos() {
        Gizmos.DrawWireSphere(transform.position, 50f);
    }
}
