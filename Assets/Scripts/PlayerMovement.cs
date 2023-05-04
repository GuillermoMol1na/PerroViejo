using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
     public Rigidbody2D rb; 
     public Collider2D baseColl;
     Vector2 movement;
     public float moveSpeed = 0.2f;
     public bool talkonThePhone=false;
     public Animator anim;
     /*public int theDay;
     public int completed;*/

    void Start(){
        /*PlayerPrefs.SetInt("day",theDay);
        PlayerPrefs.SetInt("dayCompleted",completed);*/
        Debug.Log("LOS MINUTOS: "+PlayerPrefs.GetFloat("minutes")+":"+PlayerPrefs.GetFloat("seconds"));
        anim.SetBool("onThePhone", talkonThePhone);
    }
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
    public void PickHangPhone(){
        talkonThePhone = !talkonThePhone;
        anim.SetBool("onThePhone", talkonThePhone);
        if(talkonThePhone){
            anim.SetLayerWeight(1,1f);
        }else{
            anim.SetLayerWeight(1,0f);
        }
    }
}