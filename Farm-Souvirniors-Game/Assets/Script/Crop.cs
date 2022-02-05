using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Crop : MonoBehaviour
{

    bool clash = false;
     private void OnTriggerEnter2D(Collider2D other) {
      if(other.tag == "Player"){
          Debug.Log("test");
          clash = true;
      }
   }

   void OnCrop (InputValue value){
         if(clash){
            clash = false;
            GameManager.instance.Crop();
         }
      
      }
}
