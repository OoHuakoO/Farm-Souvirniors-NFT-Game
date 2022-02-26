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

         GameManager.instance.itemsCrop[checkAreaCrop].transform.GetChild(0).GetComponent<SpriteRenderer>().color = new Color(1,1,1,0.28f);
    
          clash = true;
      }
   }
     private void OnTriggerExit2D(Collider2D other) {
        if(other.tag == "Player"){
            clash = false;
         
                if(GameManager.instance.checkClickItem && GameManager.instance.itemsCrop[checkAreaCrop].GetComponent<SpriteRenderer>().sprite == null ){
                    GameManager.instance.itemsCrop[checkAreaCrop].transform.GetChild(0).GetComponent<SpriteRenderer>().color = new Color(0,0.5f,0.3f,0.5f);
                }
                else
                {
                      GameManager.instance.itemsCrop[checkAreaCrop].transform.GetChild(0).GetComponent<SpriteRenderer>().color = new Color(1,1,1,0);
                }
      
               
            
            
        }
    }

   void OnCropAndHavest (InputValue value){
          
        //ถ้าชน
         if(clash){
               Debug.Log("OnCropAndHavest");
            //  Debug.Log(checkAreaCrop);
             //เชคเพื่อการปลูก โดยเช็คว่าพื้นตรงนั้นปลูกไปหรือยัง ถ้ายังให้ปลูกได้
            if(GameManager.instance.checkClickItem &&  GameManager.instance.itemsCrop[checkAreaCrop].GetComponent<SpriteRenderer>().sprite == null){
                Debug.Log("checkCrop");
                clash = false;
                GameManager.instance.Crop(checkAreaCrop);
            }
             //เช็คเพื่อเก็บเกี่ยว ถ้าปลูกไปแล้ว ถ้าไอเทมยังน้อยกว่าช่องในกระเป๋าให้เก็บไอเทมเข้ากระเป๋าได้
              else if(GameManager.instance.items.Count < GameManager.instance.slots.Length ){ 
                          Debug.Log("Havest");
                          clash = false;
                        Sprite getSprite = GameManager.instance.itemsCrop[checkAreaCrop].GetComponent<SpriteRenderer>().sprite;
                             //ทำให้รูปหาย ไม่ได้ลบแต่เปลี่ยนเปนว่างแทน
            GameManager.instance.itemsCrop[checkAreaCrop].transform.GetComponent<SpriteRenderer>().sprite = null;
                 //เชคถ้าเก็บเกี่ยวแล้วแต่ยังกดไอเทมในเป๋าอยู่ให้ขึ้นกรอบเขียวให้้ปลูกได้
            if(GameManager.instance.checkClickItem){
                Debug.Log("Havest1");
                   GameManager.instance.itemsCrop[checkAreaCrop].transform.GetChild(0).GetComponent<SpriteRenderer>().color = new Color(0,0.5f,0.3f,0.5f);
            }
            Debug.Log("Havest2");
                        for(int i=0 ; i<itemData.Length;i++){
                            if(getSprite == itemData[i].itemSprite){
                                  GameManager.instance.addItem(itemData[i]);
                            }
                        }
       
            
           }
          
         }
      
      }
}
