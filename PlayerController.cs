using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Text countText;
    public Text winText;
    public Text livesText;
    
    private Rigidbody2D rb2d;
    private int count;
    private int lives;


    void Start()
    {
        rb2d = GetComponent<Rigidbody2D> ();
        count = 0;
        lives = 3;
        winText.text = "";
        SetCountText ();
        SetLivesText ();
    }

    void FixedUpdate () 
    {
        float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis ("Vertical");
        Vector2 movement = new Vector2 (moveHorizontal, moveVertical);
        rb2d.AddForce (movement * speed);

        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.CompareTag ("PickUp"))
        {
            other.gameObject.SetActive (false);
            count = count + 1;
            SetCountText ();
        }

        if (other.gameObject.CompareTag ("Enemy"))
        {
            other.gameObject.SetActive (false);
            lives = lives - 1;
            SetLivesText ();
        }   

        if(lives == 0)
        {
            Destroy(this.gameObject);
            winText.text = "<b>You Lose!</b>\nMade by Austin Owens";
        }
    }

    void SetLivesText () 
    {
        if (lives == 3) {
        livesText.text = "Lives: ♡ ♡ ♡";
        }
        else if (lives == 2) {
        livesText.text = "Lives: ♡ ♡";
        }
        else if (lives == 1) {
        livesText.text = "Lives: ♡";
        }
        else if (lives == 0) {
        livesText.text = "Lives: ☹";
        }
    }

    void SetCountText ()
    {
        countText.text = "<i>Count: </i>" + count.ToString ();
        if (count == 12)
        {
            transform.position = new Vector2(61, 0);
        }
        if (count >= 20)
        {
            Destroy(this.gameObject);
            winText.text = "<b>You Win!</b>\nMade by Austin Owens";
        }
    }

}
