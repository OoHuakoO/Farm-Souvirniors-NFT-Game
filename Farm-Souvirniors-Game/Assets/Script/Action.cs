using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Action : MonoBehaviour
{

    bool clash = false;
    [SerializeField] int checkAreaCrop ;

    [SerializeField] string checkNftId ;
    public Items[] itemData ;

    
    string urlCropNFT = "https://farm-souvirniors-api.herokuapp.com/in-game/plant-nft";
    string urlHavestNFT = "https://farm-souvirniors-api.herokuapp.com/in-game/harvest-nft";
    string addressWallet = "0x629812063124cE2448703B889D754b232B3622BA";
    string itemID ;

    bool selectNftUsed = true;
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
                    //เชคเพื่อการปลูก โดยเช็คว่าพื้นตรงนั้นปลูกไปหรือยัง ถ้ายังให้ปลูกได้
                    if((GameManager.instance.checkClickItem &&  GameManager.instance.itemsCrop[checkAreaCrop].GetComponent<SpriteRenderer>().sprite == null)){
                        Debug.Log("checkCrop");
                        clash = false;
                        for(int i=0;i<GameManager.instance.dataTest.Count;i++){
                            if(selectNftUsed){
                                if(GameManager.instance.dataTest[i].name == GameManager.instance.chooseItem.itemName){
                                    itemID = GameManager.instance.dataTest[i].nft_id;
                                    GameManager.instance.itemsCrop[checkAreaCrop].GetComponent<Action>().checkNftId = GameManager.instance.dataTest[i].nft_id;
                                    selectNftUsed = false;
                                }
                            } 
                        }
                        GameManager.instance.Crop(urlCropNFT,addressWallet,itemID,checkAreaCrop);
                    }
            for(int k=0;k<GameManager.instance.dataTest.Count;k++){ 
                //ถ้าตำแหน่งที่ปลูกที่ดึงมาจาก api ตรงกับช่องที่ปลูกที่ยืนอยู่
                if(GameManager.instance.dataTest[k].position_plant == checkAreaCrop){
                       
                    if((GameManager.instance.items.Count < GameManager.instance.slots.Length) && GameManager.instance.dataTest[k].status == "wait_harvest"){
                        
                        Debug.Log("checkHavest");
                        clash = false;

                        
                        Sprite getSprite = GameManager.instance.itemsCrop[checkAreaCrop].GetComponent<SpriteRenderer>().sprite;
                        string getNft_id = GameManager.instance.itemsCrop[checkAreaCrop].GetComponent<Action>().checkNftId;
                        if(getSprite != null){
                        StartCoroutine(GameManager.instance.HttpHavestPost(urlHavestNFT,addressWallet,itemID,checkAreaCrop));
                    }
                    //ทำให้รูปหาย ไม่ได้ลบแต่เปลี่ยนเปนว่างแทน
                    GameManager.instance.itemsCrop[checkAreaCrop].transform.GetComponent<SpriteRenderer>().sprite = null;
                    //เชคถ้าเก็บเกี่ยวแล้วแต่ยังกดไอเทมในเป๋าอยู่ให้ขึ้นกรอบเขียวให้้ปลูกได้
                    if(GameManager.instance.checkClickItem){
                       GameManager.instance.itemsCrop[checkAreaCrop].transform.GetChild(0).GetComponent<SpriteRenderer>().color = new Color(0,0.5f,0.3f,0.5f);
                    }
                    for(int i=0 ; i<itemData.Length;i++){
                        if(getSprite == itemData[i].itemSprite){
                            GameManager.instance.addItem(itemData[i] , checkAreaCrop);
                        }
                    }
            
                    }
                
                
                }
                      
            }
            
           
            
            //    else if(GameManager.instance.showCrop[checkAreaCrop] == "")
          
        }
      
      }
}
