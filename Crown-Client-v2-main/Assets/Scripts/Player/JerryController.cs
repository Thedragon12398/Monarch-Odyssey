using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class JerryController : MonoBehaviour
{
    public float speed = 0;
    public TextMeshProUGUI scoreText;
    public GameObject winTextObject;

    float jumpCooldown = 2.0f;
    float timeSince = 2.0f;

    private Rigidbody rb;
    private int score;
    private float movementX;
    private float movementY;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>(); 
        score = 0;

        SetScoreText();
        winTextObject.SetActive(false);
    }

    void Update()
    {
        timeSince += Time.deltaTime;
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    //public bool IsGrounded()
    //{
    //    RaycastHit hit;
    //    float rayLength = 1.1f; // Adjust based on your character's size
    //    if (Physics.Raycast(transform.position, Vector3.down, out hit, rayLength))
    //    {
    //        return true;
    //    }
    //    return false;
    //}

    void OnJump(InputValue jumpValue)
    {
        if(timeSince > jumpCooldown)
        {
            rb.AddForce(Vector3.up * 6f, ForceMode.Impulse);
            timeSince = 0;
        }

        
    }

    void SetScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
        if (score >= 4)
        {
            winTextObject.SetActive(true);
        }
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Book"))
        {
            other.gameObject.SetActive(false);
            score = score + 1;
            SetScoreText();
        }
    }
}
