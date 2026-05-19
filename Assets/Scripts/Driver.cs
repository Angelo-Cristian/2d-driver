using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 1f;
    [SerializeField] float movingSpeed = 1f;
    float movingSpeed_cpy;
    float rotation;
    float moving;
    float slowSpeed = 5f;
    float boostSpeed = 20f;

    void Start()
    {
        movingSpeed_cpy = movingSpeed;
    }
    // Update is called once per frame
    void Update()
    {
        rotation = Input.GetAxis("Horizontal");
        moving = Input.GetAxis("Vertical");

        transform.Rotate(0, 0, rotationSpeed * -rotation * Time.deltaTime);
        transform.Translate(0, movingSpeed * moving * Time.deltaTime, 0);
    }

    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Obstacle")
            movingSpeed = slowSpeed;
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        movingSpeed = movingSpeed_cpy;      
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
         if(other.gameObject.tag == "SpeedBoost")
         {
            movingSpeed = boostSpeed;
            movingSpeed_cpy = movingSpeed;
         }
            
    }
}
