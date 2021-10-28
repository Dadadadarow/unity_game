using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;


public class PlayerController : MonoBehaviour
{
    public float speed = 0;
    public TextMeshProUGUI countText;
    public TextMeshProUGUI timeText;
    public GameObject winTextObject;

    private Rigidbody rb;
    //private 
    private int count;
    private int minute;
    private float seconds;
    private float oldSeconds;
    private float startTime;

    private float movementX;
    private float movementY;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("i am alive!");
        rb = GetComponent<Rigidbody>();
        count = 0;
        oldSeconds = 0;
        startTime = Time.time;

        SetCountText();
        winTextObject.SetActive(false);
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if(count >= 9)
        {
            winTextObject.SetActive(true);
        }
    }
/*
    void SetTimeText()
    {
        seconds = Time.time - startTime;
        minute = (int)seconds / 60;

        if((int)seconds != (int)oldSeconds)
        {
            timeText.text = minute.ToString("00") + ":" + ((int)(seconds % 60)).ToString("00");
        }
        oldSeconds = seconds;

        if (Input.GetMouseButtonDown(0))
        {
            Time.timeScale = Mathf.Approximately(Time.timeScale, 0f) ? 1f : 0f;

        }
    }
*/

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        rb.AddForce(movement * speed);
        //SetTimeText();

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count++;

            SetCountText();
        }
    }
}
