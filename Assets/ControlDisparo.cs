using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlDisparo : MonoBehaviour {
    Collider2D disparandoA = null;
    public float probabilidadDeDisparo = 10f;
    enemigo ctr;
   
    // Use this for initialization
    void Start() {
        ctr = GameObject.Find("enemigo").GetComponent<enemigo>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name.Equals("arbol") && disparandoA == null)
        {
            DecidaSiDispara(other);
        }
        if (other.gameObject.name.Equals("orc") && disparandoA == null)
        {
           Disparar();
           disparandoA = other;
        }
    }

    private void OnTriggerExit2D (Collider2D other)
    {
        if (other == disparandoA)
        {
            disparandoA = null;
        }
    }

    void DecidaSiDispara(Collider2D other)
    {
        if (Random.value < probabilidadDeDisparo)
        {
            Disparar();
            disparandoA = other;
        }
    }
    void Disparar()
    {
        ctr.Disparar();
     
    }


    // Update is called once per frame
    void Update () {
		
	}
}
