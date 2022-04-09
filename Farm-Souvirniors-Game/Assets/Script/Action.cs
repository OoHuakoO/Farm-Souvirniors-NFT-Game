using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Action : MonoBehaviour
{

    public bool clash = false;
    [SerializeField] int checkAreaCrop ;

    public string checkNftId ;
    public string statusNFT ;

    public string typeNFT ;

    private string getNft_id ;

    // private bool checkAlreadyPlant = false;

    public Items[] itemData ;

    private List<string> ok = new List<string>();



    
    string urlCropNFT = "https://farm-souvirniors-api.herokuapp.com/in-game/plant-nft";
    string urlHavestNFT = "https://farm-souvirniors-api.herokuapp.com/in-game/harvest-nft";
    string urlFeedNFT = "https://farm-souvirniors-api.herokuapp.com/in-game/feed-nft";
    
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


            //  GameManager.instance.itemsCrop[checkAreaCrop].transform.GetChild(0).GetComponent<SpriteRenderer>().color = new Color(1,1,1,0);

         
                if(GameManager.instance.checkClickItem && GameManager.instance.chooseItem.type == "plant" && (checkAreaCrop == 0 || checkAreaCrop == 1 || checkAreaCrop == 2 || checkAreaCrop == 3 || checkAreaCrop == 4 || checkAreaCrop == 5 || checkAreaCrop == 6 || checkAreaCrop == 7 || checkAreaCrop == 8 || checkAreaCrop == 9 || checkAreaCrop == 10 || checkAreaCrop == 11) && GameManager.instance.itemsCrop[checkAreaCrop].GetComponent<SpriteRenderer>().sprite == null ){
                    GameManager.instance.itemsCrop[checkAreaCrop].transform.GetChild(0).GetComponent<SpriteRenderer>().color = new Color(0,0.5f,0.3f,0.5f);
                }else if(GameManager.instance.checkClickItem && GameManager.instance.chooseItem.type == "animal" && (checkAreaCrop == 12 || checkAreaCrop == 13 || checkAreaCrop == 14 || checkAreaCrop == 15 || checkAreaCrop == 16 || checkAreaCrop == 17 ) && GameManager.instance.itemsCrop[checkAreaCrop].GetComponent<SpriteRenderer>().sprite == null ){
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

                    // Debug.Log("OnCropAndHavest");
                    //เชคเพื่อการปลูก โดยเช็คว่าพื้นตรงนั้นปลูกไปหรือยัง ถ้ายังให้ปลูกได้
                    if((GameManager.instance.checkClickItem &&  GameManager.instance.itemsCrop[checkAreaCrop].GetComponent<SpriteRenderer>().sprite == null)){
                        // Debug.Log("checkCrop");
                        clash = false;
                        for(int i=0;i<GameManager.instance.dataTest.Count;i++){
                            if(selectNftUsed){
                                // Debug.Log(checkAreaCrop);

                                    if(GameManager.instance.dataTest[i].name == GameManager.instance.chooseItem.itemName && GameManager.instance.dataTest[i].status == "not_plant"){
                                                        itemID = GameManager.instance.dataTest[i].nft_id;
                                                        selectNftUsed = false;
                                                        GameManager.instance.Crop(urlCropNFT,LoadingScreen.same.addressWallet,itemID,checkAreaCrop , i);
                                                     
                                                        // GameManager.instance.actionTimeout = true;
                                                        // GameManager.instance.numberLand = checkAreaCrop;
                                                        // // GameManager.instance.timeStart[checkAreaCrop] = 120f;
                                                        // GameManager.instance.dataTest[i].status = "wait_feed";
                                                        // GameManager.instance.itemsCrop[checkAreaCrop].GetComponent<Action>().typeNFT = GameManager.instance.dataTest[i].type;
                                                        // GameManager.instance.itemsCrop[checkAreaCrop].GetComponent<Action>().checkNftId = GameManager.instance.dataTest[i].nft_id;
                                                        // GameManager.instance.itemsCrop[checkAreaCrop].GetComponent<Action>().statusNFT = "wait_feed";
                                                       
                                         
                                    } 

                          
                                
                               
                               
                            }
                            
                        }
                      
                    }
            for(int k=0;k<GameManager.instance.dataTest.Count;k++){ 
                //ถ้าตำแหน่งที่ปลูกที่ดึงมาจาก api ตรงกับช่องที่ปลูกที่ยืนอยู่
                if(GameManager.instance.dataTest[k].position_plant == checkAreaCrop){
                       
                    if((GameManager.instance.items.Count < GameManager.instance.slots.Length) && (GameManager.instance.itemsCrop[checkAreaCrop].GetComponent<Action>().statusNFT == "wait_harvest" && GameManager.instance.timeStart[checkAreaCrop] <= 0)){
                       
                            // Debug.Log("checkHavest");
                            getNft_id = GameManager.instance.itemsCrop[checkAreaCrop].GetComponent<Action>().checkNftId;
                            clash = false;    
                            StartCoroutine(GameManager.instance.HttpHavestPost(urlHavestNFT,LoadingScreen.same.addressWallet,getNft_id ,checkAreaCrop,k,itemData )); 


                            // Sprite getSprite = GameManager.instance.itemsCrop[checkAreaCrop].GetComponent<SpriteRenderer>().sprite;
                            // if(getSprite != null){
                                 
                            //     GameManager.instance.itemsCrop[checkAreaCrop].GetComponent<Action>().statusNFT = "not_plant";
                            //     GameManager.instance.dataTest[k].status = "not_plant";
                            //     GameManager.instance.showCrop[checkAreaCrop].transform.GetComponent<SpriteRenderer>().sprite = null;
                             
                            // }
                            // //ทำให้รูปหาย ไม่ได้ลบแต่เปลี่ยนเปนว่างแทน
                            // GameManager.instance.itemsCrop[checkAreaCrop].transform.GetComponent<SpriteRenderer>().sprite = null;
                            // //เชคถ้าเก็บเกี่ยวแล้วแต่ยังกดไอเทมในเป๋าอยู่ให้ขึ้นกรอบเขียวให้้ปลูกได้
                            // if(GameManager.instance.checkClickItem){
                            // GameManager.instance.itemsCrop[checkAreaCrop].transform.GetChild(0).GetComponent<SpriteRenderer>().color = new Color(0,0.5f,0.3f,0.5f);
                            // }
                            // for(int i=0 ; i<itemData.Length;i++){
                            //     if(getSprite == itemData[i].itemSprite){
                            //         GameManager.instance.addItem(itemData[i] , checkAreaCrop);
                            //     }
                            // }
                        
                        
                       
            
                    }else if(GameManager.instance.itemsCrop[checkAreaCrop].GetComponent<Action>().statusNFT == "wait_feed" && GameManager.instance.timeStart[checkAreaCrop] <= 0  ){
                       
                        getNft_id = GameManager.instance.itemsCrop[checkAreaCrop].GetComponent<Action>().checkNftId;
                        clash = false;
                        
                        StartCoroutine(GameManager.instance.HttpFeedPost(urlFeedNFT,LoadingScreen.same.addressWallet,getNft_id,checkAreaCrop,k));
                        
                        // if(GameManager.instance.resultResponseStatus == "success" ){
                        //     Debug.Log("right");
                        //      clash = false;
                        //     Sprite getSprite = GameManager.instance.itemsCrop[checkAreaCrop].GetComponent<SpriteRenderer>().sprite;
                        //     getNft_id = GameManager.instance.itemsCrop[checkAreaCrop].GetComponent<Action>().checkNftId;
                        //     if(getSprite != null){
                        //         GameManager.instance.itemsCrop[checkAreaCrop].GetComponent<Action>().statusNFT = "wait_harvest";
                        //         GameManager.instance.dataTest[k].status = "wait_harvest";
                        //         GameManager.instance.showCrop[checkAreaCrop].transform.GetComponent<SpriteRenderer>().sprite = null;
                        //         GameManager.instance.timeStart[checkAreaCrop] = 120f;
                        //         GameManager.instance.actionTimeout = true;
                        //         GameManager.instance.numberLand = checkAreaCrop;
                            
                        //     }
                       
                        
                        // }else if(GameManager.instance.resultResponseStatus == "false"){
                        //     Debug.Log("fail");
                        // }
                    }
                
                
                }
                      
            }
            
           
            
            //    else if(GameManager.instance.showCrop[checkAreaCrop] == "")
          
        }
      
      }
}
