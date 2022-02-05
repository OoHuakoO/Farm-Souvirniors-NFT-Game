using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PickupItems : MonoBehaviour
{ 

        bool clash = false;
        public Items itemData ;
        
   private void OnTriggerEnter2D(Collider2D other) {
      if(other.tag == "Player"){
      clash = true;
      }
   }

 
   
       void OnHavest (InputValue value){
         if(clash){
           if(GameManager.instance.items.Count < GameManager.instance.slots.Length){
              Destroy(gameObject);
              clash = false;
              GameManager.instance.addItem(itemData);
           }else{
             Debug.Log("Slot Full");
           }
         
         }
      
      }
     
  }

