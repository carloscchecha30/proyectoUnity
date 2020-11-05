using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlDanioEnemigo : MonoBehaviour {
      Collider2D colliderEnem = null;
      public int delayBajarPuntosEnemigo=1;

	
	void Start () {
		
	}
	
	void Update () {
        
	
	}
     void OnTriggerEnter2D(Collider2D other){
         if(other.gameObject.name.Equals("enemigo") && colliderEnem==null){
           Debug.Log("Colisión con el enemigo:");
           colliderEnem=other;
           Invoke("BajarPuntosEnemigo",delayBajarPuntosEnemigo);
           }
      } 

     void OnTriggerExit2D(Collider2D other){
         if(other==colliderEnem){
          Debug.Log("Salir de Colisión con el enemigo");
          colliderEnem=null;
           CancelInvoke("BajarPuntosEnemigo");
           }
          
        }
      void BajarPuntosEnemigo(){
        Debug.Log("BajarPuntosEnemigo");
        colliderEnem.gameObject.GetComponent<enemigo>().BajarPuntosPorOrcoCerca();
      }
}
