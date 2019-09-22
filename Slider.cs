using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slider : MonoBehaviour
{

    private bool goRight = true;

    private float speed = 4.0f;
 
     void FixedUpdate () 
    {
         if (goRight)
            {
            transform.Translate (Vector2.right * speed * Time.deltaTime);
            }
         else
            {
            transform.Translate (-Vector2.right * speed * Time.deltaTime);
            }
         
         if(transform.position.x >= 11.8f) 
            {
            goRight = false;
            }
         
         if(transform.position.x <= -9.75f) 
            {
            goRight = true;
            }

        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }

}
