using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemigo : MonoBehaviour {
    public float vel = -1f;
    Rigidbody2D rgb;
    Animator anim;
    public GameObject bulletPrototype;
    int energy = 100;
    public Slider slider;
    public Text txt;
     AudioSource aSource;
    public AudioClip sonidoBala;
    // Use this for initialization
    void Start () {
        
        rgb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        aSource = GetComponent<AudioSource>();

	}

    private void Update()
    {
        if (energy <= 0)
        {
            energy = 0;
            anim.SetTrigger("morir");
        }
        slider.value = energy;
        txt.text = energy.ToString();
    }
    // Update is called once per frame
    void FixedUpdate () {
        Vector2 v = new Vector2(vel, 0);
        rgb.velocity = v;
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("caminando") && Random.value < 1f / (20f * 3f))
        {
            anim.SetTrigger("apuntar");
        }
        else if (anim.GetCurrentAnimatorStateInfo(0).IsName("apuntando") )
        {
            
                anim.SetTrigger("disparar");
            
        }
        else if (anim.GetCurrentAnimatorStateInfo(0).IsName("disparando"))
        {
            anim.SetTrigger("caminar");
        }



    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Flip();
    }
    void Flip()
    {
        vel *= -1;
        var s = transform.localScale;
        s.x *= -1;
        transform.localScale = s;
    }

    public void Disparar()
    {
        anim.SetTrigger("apuntar");
    }

     public void EmitirBala()
    {
        GameObject bulletCopy = Instantiate(bulletPrototype);
        bulletCopy.transform.position = new Vector3(transform.position.x, transform.position.y, -1f);
        bulletCopy.GetComponent<ControlBala1>().direccion = new Vector3(-1, 0, 0);
        aSource.PlayOneShot(sonidoBala);
         energy--;
      
    }
    
   public void BajarPuntosPorOrcoCerca(){
    energy-=10;
    }
}
