using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlOrco : MonoBehaviour {
	Rigidbody2D rgb;
	Animator anim;
	public float maxVel = 5f;
	bool haciaDerecha = true;
    public Slider slider;
    public Text text;

    public float energy = 100;
    bool enFire1 = false;
    ControlArbol ctrArbol = null;
    public GameObject hacha = null;

    public int costoGolpeAlAire = 1;
    public int costoGolpeAlArbol = 3;
    public int premioArbol = 15;
    public int costoBala = 20;
     AudioSource aSource;
    public AudioClip cortandoUnArbol;
  
    public AudioClip ouch;
    public AudioClip dying;

    public bool jumping = false;
    public float yJumpForce = 300;
    Vector2 jumpForce;
	// Use this for initialization
	void Start () {
		rgb = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
       aSource = GetComponent<AudioSource>();
         hacha=GameObject.Find("/orc/orc_body/orc _R_arm/orc _R_hand/orc_weapon");
        energy = 100;

        jumpForce = new Vector2(0, 0);
	}


    private void Update()
    {
     if(!anim.GetCurrentAnimatorStateInfo(0).IsName("Muriendo")){
       if(energy<=0){
          energy=0;
          anim.SetTrigger("morir");
          aSource.PlayOneShot(dying);
         }
         
      }else
          return;
         
        if (Input.GetMouseButtonDown(1) & Random.Range(0f, 1.0f) > 0.5f)
        {

            if (enFire1 == false)
                enFire1 = true;
                anim.SetTrigger("attack");
                if (ctrArbol != null)
                {
                    if (ctrArbol.golpeOrco())
                    {
                        energy += premioArbol;
                        if (energy > 100)
                        {
                            energy = 100;
                        }

                    }
                    else
                    {
                        energy -= costoGolpeAlArbol;
                        aSource.PlayOneShot(cortandoUnArbol);
                    }

                }
                else
                {
                    energy -= costoGolpeAlAire;
                }

        }
        else
        {
            enFire1 = false;
        }
        slider.value = energy;
        text.text = energy.ToString();

    }


    void FixedUpdate () {
		float v = Input.GetAxis ("Horizontal");
		Vector2 vel = new Vector2 (0, rgb.velocity.y);
		v*= maxVel;
		vel.x = v;
		rgb.velocity = vel;

		anim.SetFloat ("speed", vel.x);

		if (haciaDerecha && v < 0) {
			haciaDerecha = false;
			flip ();
		} else if (!haciaDerecha && v > 0) {
			haciaDerecha = true;
			flip ();
		}
                if(Input.GetAxis("Jump")>0.01){
                    if(!jumping){
                    jumping=true;
                    jumpForce.x=0f;
                    jumpForce.y=yJumpForce;
                    rgb.AddForce(jumpForce);
                        }        

               }else{
                 jumping=false;

                }
	}
	void flip(){
		var s = transform.localScale;
		s.x *= -1;
		transform.localScale = s;
	}

    public void SetControlArbol(ControlArbol ctr)
    {

        ctrArbol = ctr;

    }

    public void HabilitarTriggerHacha()
    {
        hacha.GetComponent<CircleCollider2D>().enabled = true;
    }

    public void RecibirBala(){
       energy-=costoBala;
       aSource.PlayOneShot(ouch);
     }
}
