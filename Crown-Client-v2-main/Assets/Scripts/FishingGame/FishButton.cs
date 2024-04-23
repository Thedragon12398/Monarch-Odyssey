using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FishButton : MonoBehaviour
{
    protected GameObject fishManager;
    protected bool successfullyClicked = false;
    protected bool unsuccessfullyClicked = false;
    protected float speedConstant = 2f;
    float destroyTimer = 1f;
    int buttonNum;
    int xPosition, yPosition;

    private void Awake() {
        fishManager = GameObject.FindGameObjectWithTag("FishManager");
        buttonNum = fishManager.GetComponent<FishManager>().currentButtons;
        SetPosition();
    }
    /// <summary>
    /// Places the button at a random position on the canvas
    /// </summary>
    void SetPosition() {
        xPosition = Random.Range(-300, 300);
        yPosition = Random.Range(-150, 150);
        Vector2 location = new Vector2(xPosition, yPosition);

        //For each button in the buttonLocations dictionary, if this button is within 5 units of one reset its position
        if (fishManager.GetComponent<FishManager>().buttonLocations.Count > 0) {
            foreach (Vector2 loc in fishManager.GetComponent<FishManager>().buttonLocations.Values.ToList()) {
                if (Vector2.Distance(loc, location) < 150) {
                    SetPosition();
                }
            }
        }
        if (!fishManager.GetComponent<FishManager>().buttonLocations.ContainsKey(buttonNum)) {
            fishManager.GetComponent<FishManager>().buttonLocations.Add(buttonNum, location);

        }
        transform.position = new Vector2(xPosition, yPosition);

        //To-Do: find a solution to overlapping buttons;
        //Below is the attempted solution that doesn't quite work
        /*Collider[] collider = Physics.OverlapSphere(new Vector2(xPosition, yPosition), 100f, LayerMask.GetMask("UI"));
        while (collider.Length > 0) {
            Debug.Log("Blocked");
            xPosition = Random.Range(-300, 300);
            yPosition = Random.Range(-150, 150);
            collider = Physics.OverlapSphere(new Vector2(xPosition, yPosition), 100f, LayerMask.GetMask("UI"));
        }
        transform.position = new Vector2(xPosition, yPosition);*/
    }
    /// <summary>
    /// Destroys the object after a certain amount of time
    /// </summary>
    protected void TimedDestroy() {
        destroyTimer -= Time.deltaTime;
        if (destroyTimer <= 0) {
            fishManager.GetComponent<FishManager>().buttonLocations.Remove(buttonNum);
            Destroy(this.gameObject);
        }
    }
    private void OnDrawGizmos() {
        Gizmos.DrawWireSphere(transform.position, 50f);
    }
}
