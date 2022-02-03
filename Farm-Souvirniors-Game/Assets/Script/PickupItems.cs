using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PickupItems : MonoBehaviour
{ 

        bool havest = false;
        bool clash = false;
        public Items itemData ;
        
   private void OnTriggerEnter2D(Collider2D other) {
      if(other.tag == "Player"){
      clash = true;
      }
   }

 
   
       void OnHavest (InputValue value){
         if(clash){
          Destroy(gameObject);
          clash = false;
          GameManager.instance.addItem(itemData);
         }
      
      }
     
  }

