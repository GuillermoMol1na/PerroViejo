using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
     public Rigidbody2D rb; 
     public Collider2D baseColl;
     Vector2 movement;

      public float moveSpeed = 0.2f;
      public Animator anim;
      private GameMaster gm;


 

    // Update is called once per frame
    void Update()
    {


        movement.x =Input.GetAxisRaw("Horizontal");
        movement.y =Input.GetAxisRaw("Vertical");


        if (movement.x > 0.01f || movement.x < -0.01f)
         {
             movement.y = 0;
             anim.SetBool("isMoving", true);
             anim.SetFloat("Horizontal", movement.x);
             //anim.SetFloat("Horizontal", Input.GetAxis("Horizontal"));
             anim.SetFloat("Vertical", movement.y);
             
         }
         else if ( movement.y > 0.01f || movement.y < -0.01f)
         {
             movement.x = 0;
             anim.SetBool("isMoving", true);
             anim.SetFloat("Horizontal", movement.x);
             //anim.SetFloat("Vertical", Input.GetAxis("Vertical"));
             anim.SetFloat("Vertical", movement.y);
        }
        else{
            movement.x = 0;
            movement.y = 0;
            anim.SetFloat("Horizontal", movement.x);
            anim.SetFloat("Vertical", movement.y);
            anim.SetBool("isMoving", false);
        }
        
        
    }

    void FixedUpdate(){
        //Movement
        
             
          
    rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}