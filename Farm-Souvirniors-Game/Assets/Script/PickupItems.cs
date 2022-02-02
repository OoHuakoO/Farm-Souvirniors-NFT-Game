using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PickupItems : MonoBehaviour
{ 
  //  private void Update() {
  //  if (Input.GetKey(KeyCode.Space))
  //       {
  //           Debug.Log("space key was pressed");
  //       }
  // }
        bool havest = false;
        bool clash = false;
   private void OnTriggerEnter2D(Collider2D other) {
      if(other.tag == "Player"){
      clash = true;
      }
   }
       void OnHavest (InputValue value){
         if(clash){
          Destroy(gameObject);
          clash = false;
         }
      
      }
     
  }

