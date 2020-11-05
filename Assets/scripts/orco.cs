using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class orco : MonoBehaviour {
    Rigidbody2D rgb;
    Animator anim;
    public float maxVel  = 5f;
   // bool isOnTheFloor=false;
    bool haciaDerecha = true;
    

	// Use this for initialization
	void Start () {
        rgb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
     
	}
	
	// Update is called once per frame
	void FixUpdate () {
        float v=Input.GetAxis("Horizontal");
        Vector2 vel = new Vector2(0, rgb.velocity.y);
        v *= maxVel;
        vel.x = v;
        rgb.velocity = vel;

        anim.SetFloat("speed", vel.x);

        if(haciaDerecha && v < 0)
        {
            haciaDerecha = false;
            Flip();
        }
        else if (!haciaDerecha && v>0)
        {
            haciaDerecha = true;
            Flip();
        }

       
	}
  /*  private void VerificarInputParaSaltar(){
       isOnTheFloor=rgb.velocity.y==0;
       if(Input.GetAxis("Jump")>0.01f){
         if(!jumping&& isOnTheFloor){
           jumping=true;
           jumpForce.x=0f;
           jumpForce.y=yJumpForce;
           rgb.AddForce(jumpForce);
             
          }
         }else
           jumping=false;
     } 
   
*/
     


    void Flip()
    {
        var s = transform.localScale;
        s.x *= -1;
        transform.localScale = s;
    }
}
