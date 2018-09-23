using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float jumpSpeed;
    public float speed;
    public Text countText;
    public Text winText;
    private Rigidbody rb;
    public int count;
    public float disToG = 0.5f;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = "";
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);

        Debug.Log(isGround());

        
        if (Input.GetKeyDown(KeyCode.Space) && isGround())
        {
            GetComponent<Rigidbody>().velocity = Vector3.up * jumpSpeed;
        }
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Object"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
    }
    public void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 12)
        {
            winText.text = "You Win!";
        }
    }
    bool isGround()
    {
        return Physics.Raycast(transform.position, Vector3.down, disToG);
    }

     
    

}