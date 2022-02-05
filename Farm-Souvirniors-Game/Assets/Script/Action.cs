using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Action : MonoBehaviour
{

    bool clash = false;
    [SerializeField] int checkAreaCrop ;
    public Items[] itemData ;
     private void OnTriggerEnter2D(Collider2D other) {
      if(other.tag == "Player"){
        
          clash = true;
      }
   }

   void OnCropAndHavest (InputValue value){
         if(clash){
       
            if(GameManager.instance.checkClickItem &&  GameManager.instance.itemsCrop[checkAreaCrop].GetComponent<SpriteRenderer>().sprite == null){
                Debug.Log("Test1");
                clash = false;
                GameManager.instance.Crop(checkAreaCrop);
            }
              else if(GameManager.instance.items.Count < GameManager.instance.slots.Length ){ 
                          Debug.Log("Test2");
                          clash = false;
                        Sprite getSprite = GameManager.instance.itemsCrop[checkAreaCrop].GetComponent<SpriteRenderer>().sprite;
                        Debug.Log(getSprite);
                        for(int i=0 ; i<itemData.Length;i++){
                            if(getSprite == itemData[i].itemSprite){
                                  GameManager.instance.addItem(itemData[i]);
                            }
                        }
            GameManager.instance.itemsCrop[checkAreaCrop].transform.GetComponent<SpriteRenderer>().sprite = null;
            
            
           }else{
             Debug.Log("Slot Full");
           }
          
         }
      
      }
}
