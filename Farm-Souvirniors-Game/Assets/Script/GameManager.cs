using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using TMPro;
using UnityEngine.SceneManagement;
using System.Runtime.InteropServices;



public class GameManager : MonoBehaviour
{
   public static GameManager instance;
   public Items[] AllItem ;
    // type items
    public List<Items> items = new List<Items>();
    //Amount items
    public List<int> itemNumbers = new List<int>();
    //ช่องในกระเป๋า
    public GameObject[] slots ;
    //โชวกรอบรูปเมื่อคลิกไอเทมในเป๋า
    public Sprite imageClick;
    //โชวช่องปลูก
    public GameObject[] showCrop;

    
    //จำนวนไอเทมที่เลือก
    int indexAmountItem;
    //ไอเทมที่เลือก
    public Items chooseItem;
    //เชคว่าคลิกไอเทมในเป่ายุไหม
    public bool checkClickItem = false;
    //object ในช่องปลูก
    public GameObject[] itemsCrop;

    public GameObject[] itemCraft;
    
    public GameObject detailCraft;
    public List<Items> itemsDetailCraft = new List<Items>();

    public GameObject imageItemShowCraft ;

    public ItemShowAction[] itemAction ;

    private string statusAction ;

    public List<float> timeStart = new List<float>() ;


  

    public string urlGetNFT ;
    public TextMesh[] textTime;

    public List<Data> dataTest = new List<Data>();

    public bool checkGetAPIFinish = false ;

    public string resultResponseData ;
    public string resultResponseStatus ;

    public GameObject PopUp; 
    public TextMeshProUGUI textPopUp;



    
 private void Awake() {
        if(instance == null){
            instance = this;
        }
        else{
            if(instance != this){
                Destroy(gameObject);
            }
        }
        DontDestroyOnLoad(gameObject);
   }

    [DllImport("__Internal")]
    private static extern void GameOver (string action);

//   public void SomeMethod () {
//     if(UNITY_WEBGL == true && UNITY_EDITOR == false){
//       GameOver ();
//     } 


  

    

   private void Start() {
           
            // WebGLInput.captureAllKeyboardInput = false;
            PopUp.SetActive(false);
            urlGetNFT = "https://farm-souvirniors-api.herokuapp.com/in-game/get-owner-nft/" + LoadingScreen.same.addressWallet;
       
            StartCoroutine(HttpGet(urlGetNFT));
        
     
            
                timeStart.Add(0);
                timeStart.Add(0);
                 timeStart.Add(0);
                timeStart.Add(0);
                 timeStart.Add(0);
                timeStart.Add(0);
                 timeStart.Add(0);
                timeStart.Add(0);
                 timeStart.Add(0);
                timeStart.Add(0);
                 timeStart.Add(0);
                timeStart.Add(0);
                timeStart.Add(0);
                timeStart.Add(0);
                 timeStart.Add(0);
                timeStart.Add(0);
                 timeStart.Add(0);
                timeStart.Add(0);
                timeStart.Add(0);
                timeStart.Add(0);
                timeStart.Add(0);
                timeStart.Add(0);
                timeStart.Add(0);
                timeStart.Add(0);
                timeStart.Add(0);
                timeStart.Add(0);
                timeStart.Add(0);
                timeStart.Add(0);
                timeStart.Add(0);
                timeStart.Add(0);
                timeStart.Add(0);
                timeStart.Add(0);
              
           
       

    }

    private void Update(){     
        // for(int e=0;e<dataTest.Count;e++){
        //         Debug.Log(dataTest[e].name);
        //         Debug.Log(dataTest[e].status);
        //     }
        // Debug.Log(resultResponseData);
          for(int i = 0 ;i<timeStart.Count;i++){
          
                    timeStart[i] -= Time.deltaTime;
                   TimeSpan timePlaying = TimeSpan.FromSeconds(timeStart[i]);
                  
                   textTime[i].text = timePlaying.ToString("mm':'ss");
                    if(timeStart[i] <= 0 ){                      
                         textTime[i].text = "";
                         timeControl(i);
                    }
                    if(timeStart[i] > 60){
                        // Debug.Log("lol1");
                        string SyntaxTime = timePlaying.ToString("mm':'ss");
                        textTime[i].text = SyntaxTime;
                    }
                    
                   
            }
         
    
      
      
    }

    public void timeControl(int i){
    
            if(itemsCrop[i].GetComponent<Action>().statusNFT == "wait_harvest" && (itemsCrop[i].GetComponent<Action>().typeNFT == "fruit" || itemsCrop[i].GetComponent<Action>().typeNFT == "vegetable")){
            showCrop[i].GetComponent<SpriteRenderer>().sprite =  itemAction[0].itemSprite;
        }
         if(itemsCrop[i].GetComponent<Action>().statusNFT == "wait_harvest" &&  itemsCrop[i].GetComponent<Action>().typeNFT == "animal"){
            showCrop[i].GetComponent<SpriteRenderer>().sprite =  itemAction[1].itemSprite;
        }
         if(itemsCrop[i].GetComponent<Action>().statusNFT == "wait_feed" &&  (itemsCrop[i].GetComponent<Action>().typeNFT == "fruit" || itemsCrop[i].GetComponent<Action>().typeNFT == "vegetable")){
            showCrop[i].GetComponent<SpriteRenderer>().sprite =  itemAction[2].itemSprite;
        }
         if(itemsCrop[i].GetComponent<Action>().statusNFT == "wait_feed" &&  itemsCrop[i].GetComponent<Action>().typeNFT == "animal"){
            showCrop[i].GetComponent<SpriteRenderer>().sprite =  itemAction[3].itemSprite;
        }
        
    }

   

  
        //getItemNFT
      public IEnumerator HttpGet(string url)
        {
      
            using(UnityWebRequest webRequest = UnityWebRequest.Get(url))
            {
                yield return webRequest.SendWebRequest();
                var response = webRequest.downloadHandler.text ;
             
                
            
                JsonClass result = JsonConvert.DeserializeObject<JsonClass>(response);
                    //  Debug.Log(result);
                     
                        for(int i=0;i<result.data.Length;i++){
                            
                                 dataTest.Add(new Data{
                                       address_wallet = LoadingScreen.same.addressWallet,
                                       nft_id = result.data[i].nft_id,
                                       name = result.data[i].name,
                                       type = result.data[i].type,
                                       status = result.data[i].status,
                                       cooldownTime = result.data[i].cooldownTime ,
                                         
                                        position_plant = result.data[i].position_plant
                                    }) ; 
                             
                                 
                               
                              
                       
                                   
                            for(int y=0;y<AllItem.Length;y++){
                                
                                   if(result.data[i].name == AllItem[y].itemName){
                                       if(result.data[i].status == "not_plant"){
                                            if(!items.Contains(AllItem[y])){
                                          
                                            items.Add(AllItem[y]);
                                             itemNumbers.Add(1);
                                             
                                             
 
                                            }else{
                                                for(int m=0;m<items.Count;m++){
                                                    if(items[m] == AllItem[y]){
                                                    itemNumbers[m]++;
                                                    }
                                                }
                                            }
                                       }
                                       else if(result.data[i].status == "wait_feed" ){
                                          
                                                if(result.data[i].type == "vegetable" || result.data[i].type == "fruit"){
                                                    itemsCrop[result.data[i].position_plant].transform.GetComponent<SpriteRenderer>().sprite = AllItem[y].itemSprite;
                                                    if(result.data[i].cooldownTime == 0 ){
                                                   
                                                    showCrop[result.data[i].position_plant].transform.GetComponent<SpriteRenderer>().sprite =  itemAction[2].itemSprite;
                                                    }else if(result.data[i].cooldownTime > 0 ){
                                                    
                                                    timeStart[result.data[i].position_plant] = result.data[i].cooldownTime;
                                                    }   
                                                    
                                                
                                                
                                                    itemsCrop[result.data[i].position_plant].GetComponent<Action>().checkNftId = result.data[i].nft_id;
                                                    itemsCrop[result.data[i].position_plant].GetComponent<Action>().statusNFT = result.data[i].status;
                                                    itemsCrop[result.data[i].position_plant].GetComponent<Action>().typeNFT = result.data[i].type;
                                                
                                                }else if(result.data[i].type == "animal"){
                                                    itemsCrop[result.data[i].position_plant].transform.GetComponent<SpriteRenderer>().sprite = AllItem[y].itemSprite;

                                                    if(result.data[i].cooldownTime == 0 ){
                                               
                                                        showCrop[result.data[i].position_plant].transform.GetComponent<SpriteRenderer>().sprite =  itemAction[3].itemSprite;
                                                    }else if(result.data[i].cooldownTime > 0 ){
                                                 
                                                        timeStart[result.data[i].position_plant] = result.data[i].cooldownTime;
                                                    }   

                                                    itemsCrop[result.data[i].position_plant].GetComponent<Action>().checkNftId = result.data[i].nft_id;
                                                    itemsCrop[result.data[i].position_plant].GetComponent<Action>().statusNFT = result.data[i].status;
                                                    itemsCrop[result.data[i].position_plant].GetComponent<Action>().typeNFT = result.data[i].type;
                                                }
                                         
                                   
                                               
                                           
                                        //    }
                                          
                                       }else if(result.data[i].status == "wait_harvest"  ){
                                            
                                           if(result.data[i].type == "vegetable" || result.data[i].type == "fruit"){
                                                itemsCrop[result.data[i].position_plant].transform.GetComponent<SpriteRenderer>().sprite = AllItem[y].itemSprite;
                                                
                                                if(result.data[i].cooldownTime == 0 ){
                                                 
                                                    showCrop[result.data[i].position_plant].transform.GetComponent<SpriteRenderer>().sprite =  itemAction[0].itemSprite;
                                                }else if(result.data[i].cooldownTime > 0 ){
                                                     
                                                    timeStart[result.data[i].position_plant] = result.data[i].cooldownTime;
                                                }   
                                                
                                                
                                                itemsCrop[result.data[i].position_plant].GetComponent<Action>().checkNftId = result.data[i].nft_id;
                                                itemsCrop[result.data[i].position_plant].GetComponent<Action>().statusNFT = result.data[i].status;
                                                itemsCrop[result.data[i].position_plant].GetComponent<Action>().typeNFT = result.data[i].type;
                                           }else if(result.data[i].type == "animal"){
                                                itemsCrop[result.data[i].position_plant].transform.GetComponent<SpriteRenderer>().sprite = AllItem[y].itemSprite;

                                                if(result.data[i].cooldownTime == 0 ){
                                                    //  Debug.Log("3");
                                                    showCrop[result.data[i].position_plant].transform.GetComponent<SpriteRenderer>().sprite =  itemAction[1].itemSprite;
                                                }else if(result.data[i].cooldownTime > 0 ){
                                                    //  Debug.Log("4");
                                                    timeStart[result.data[i].position_plant] = result.data[i].cooldownTime;
                                                }   
                                                
                                                itemsCrop[result.data[i].position_plant].GetComponent<Action>().checkNftId = result.data[i].nft_id;
                                                itemsCrop[result.data[i].position_plant].GetComponent<Action>().statusNFT = result.data[i].status;
                                                itemsCrop[result.data[i].position_plant].GetComponent<Action>().typeNFT = result.data[i].type;
                                           }
                                           
                                            
                                       }
                                      
    
                                }
                            }
                             
                            
                        }
                  
                       
                     
                         
                                        
            }
             displayItems();
        }

        //PostCropNFT
        
           public IEnumerator HttpCropPost(string url, string address , string itemId , int checkAreaCrop , int i)
        {
            Debug.Log(i);
            var dataCrop = new myClass();
            dataCrop.address_wallet = address;
            dataCrop.nft_id = itemId;
            dataCrop.position_plant = checkAreaCrop;
           
            string json = JsonUtility.ToJson(dataCrop);
            // Debug.Log( json);
            using(UnityWebRequest webRequest = UnityWebRequest.Post(url, json))
               {
                webRequest.uploadHandler = new UploadHandlerRaw(System.Text.Encoding.UTF8.GetBytes(json));
                webRequest.SetRequestHeader("Content-Type", "application/json");
                yield return webRequest.SendWebRequest();
                var responseCrop = webRequest.downloadHandler.text;
                handleCrop Crop = JsonConvert.DeserializeObject<handleCrop>(responseCrop);
                if(Crop.status == "success"){
                    // GameOver("Crop");
                        
                     timeStart[checkAreaCrop] = Crop.data.cooldownTime; 
                   
                            dataTest[i].position_plant = checkAreaCrop;
                          itemsCrop[checkAreaCrop].transform.GetComponent<SpriteRenderer>().sprite =  chooseItem.itemSprite;
                        itemsCrop[checkAreaCrop].transform.GetChild(0).GetComponent<SpriteRenderer>().color =  new Color(0,0.5f,0.3f,0);
                         dataTest[i].status = "wait_feed";
                        itemsCrop[checkAreaCrop].GetComponent<Action>().typeNFT = dataTest[i].type;
                        itemsCrop[checkAreaCrop].GetComponent<Action>().checkNftId = dataTest[i].nft_id;
                        itemsCrop[checkAreaCrop].GetComponent<Action>().statusNFT = "wait_feed";
                       
                        itemNumbers[indexAmountItem]--;
                    if(itemNumbers[indexAmountItem] == 0){   
                            items.Remove(chooseItem);
                            itemNumbers.Remove(itemNumbers[indexAmountItem]);
                            checkClickItem = false;
                            slots[indexAmountItem].transform.GetComponent<Image>().sprite = null;
                            slots[indexAmountItem].transform.GetComponent<Image>().color = new Color(1,1,1,0);
                        //ถ้าตรงไหนไม่ได้ปลูกให้ช่องเขียวหายไป
                        for(int y=0 ; y<itemsCrop.Length ;y++){
                            if(itemsCrop[y].GetComponent<SpriteRenderer>().sprite == null){
                                itemsCrop[y].transform.GetChild(0).GetComponent<SpriteRenderer>().color = new Color(1,1,1,0);
                            }
                        }
                        
                            
                    }
                    
                      displayItems(); 
                }
                else if(Crop.status == "false"){
                    Debug.Log("Cropfail");
                    textPopUp.transform.GetComponent<TextMeshProUGUI>().text =  Crop.data.text;
                    PopUp.SetActive(true);
                }
                                                        
               }
            
        }

         //PostHavestNFT

         public IEnumerator HttpHavestPost(string url, string address , string itemId , int checkAreaCrop , int k , Items[] itemData)
        {
            var dataHavest = new myClass();
            dataHavest.address_wallet = address;
            dataHavest.nft_id = itemId;
            
            string json = JsonUtility.ToJson(dataHavest);
            // Debug.Log(json);
           using(UnityWebRequest webRequest = UnityWebRequest.Post(url, json))
            {
                webRequest.uploadHandler = new UploadHandlerRaw(System.Text.Encoding.UTF8.GetBytes(json));
                  webRequest.SetRequestHeader("Content-Type", "application/json");
                yield return webRequest.SendWebRequest();
                 var responseHavest = webRequest.downloadHandler.text;
               
                handleHavest Havest = JsonConvert.DeserializeObject<handleHavest>(responseHavest);
                 if(Havest.status == "success" ){
                        // GameOver("Havest");
                        timeStart[checkAreaCrop] = 0f; 
                         Sprite getSprite = itemsCrop[checkAreaCrop].GetComponent<SpriteRenderer>().sprite;
                            if(getSprite != null){
                                 
                                itemsCrop[checkAreaCrop].GetComponent<Action>().statusNFT = "not_plant";
                                dataTest[k].status = "not_plant";
                                // dataTest[k].position_plant = null;
                                showCrop[checkAreaCrop].transform.GetComponent<SpriteRenderer>().sprite = null;
                                itemsCrop[checkAreaCrop].GetComponent<Action>().typeNFT = "";
                                itemsCrop[checkAreaCrop].GetComponent<Action>().checkNftId = "";
                            }
                            //ทำให้รูปหาย ไม่ได้ลบแต่เปลี่ยนเปนว่างแทน
                            itemsCrop[checkAreaCrop].transform.GetComponent<SpriteRenderer>().sprite = null;
                            //เชคถ้าเก็บเกี่ยวแล้วแต่ยังกดไอเทมในเป๋าอยู่ให้ขึ้นกรอบเขียวให้้ปลูกได้
                            if(checkClickItem){
                            itemsCrop[checkAreaCrop].transform.GetChild(0).GetComponent<SpriteRenderer>().color = new Color(0,0.5f,0.3f,0.5f);
                            }
                            for(int i=0 ; i<itemData.Length;i++){
                                if(getSprite == itemData[i].itemSprite){
                                    addItem(itemData[i] , checkAreaCrop);
                                }
                            }
                       displayItems();     
                }else if(Havest.status == "false"){
                    Debug.Log("Havestfail");
                    textPopUp.transform.GetComponent<TextMeshProUGUI>().text =  Havest.data.text;
                    PopUp.SetActive(true);
                }

            }
        }
        
        //PostFeed
          public IEnumerator HttpFeedPost(string url, string address , string itemId , int checkAreaCrop , int k)
        {
            var dataFeed = new myClass();
            dataFeed.address_wallet = address;
            dataFeed.nft_id = itemId;
            string json = JsonUtility.ToJson(dataFeed);
            // Debug.Log(json);
           using(UnityWebRequest webRequest = UnityWebRequest.Post(url, json))
            {
               
                webRequest.uploadHandler = new UploadHandlerRaw(System.Text.Encoding.UTF8.GetBytes(json));
                  webRequest.SetRequestHeader("Content-Type", "application/json");
                yield return webRequest.SendWebRequest();
                  var responseFeed = webRequest.downloadHandler.text;
                  
                handleFeed Feed = JsonConvert.DeserializeObject<handleFeed>(responseFeed);
                Debug.Log(Feed);
                if(Feed.status == "success" ){
                            // GameOver("Feed");
                           
                            Sprite getSprite = itemsCrop[checkAreaCrop].GetComponent<SpriteRenderer>().sprite;
                            if(getSprite != null){
                                Debug.Log("in");

                                itemsCrop[checkAreaCrop].GetComponent<Action>().statusNFT = "wait_harvest";
                                dataTest[k].status = "wait_harvest";
                                showCrop[checkAreaCrop].transform.GetComponent<SpriteRenderer>().sprite = null;

                                timeStart[checkAreaCrop] = Feed.data.cooldownTime;
                          
                       
                            }
                            
                }else if(Feed.status == "false"){
                    Debug.Log("Feedfail");
                    textPopUp.transform.GetComponent<TextMeshProUGUI>().text = Feed.data.text;
                    PopUp.SetActive(true);
                }

                            
            }
        }
    
    

   

    void displayItems(){
     
            for(int i=0 ; i<slots.Length; i++){
                if(i < items.Count){
             
                     //ถ้าจำนวนไอเทมน้อยกว่าช่องกระเป๋าโชวรูปไอเทมขึ้นมา
            slots[i].transform.GetChild(1).GetComponent<Image>().color = new Color(1,1,1,1);
            slots[i].transform.GetChild(1).GetComponent<Image>().sprite = items[i].itemSprite;

            //   //ถ้าจำนวนไอเทมน้อยกว่าช่องกระเป๋าโชวจำนวนไอเทมขึ้นมา
            slots[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = new Color(0,0,0,1);
            slots[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = itemNumbers[i].ToString();
            }  
            else{
           // ถ้าช่องมากกว่าไอเทม ให้ช่องที่เหลือซ่อนรูปไอเทมทั้งหมด
            slots[i].transform.GetChild(1).GetComponent<Image>().color = new Color(1,1,1,0);
            slots[i].transform.GetChild(1).GetComponent<Image>().sprite = null;

                  // ถ้าช่องมากกว่าไอเทม ให้ช่องที่เหลือซ่อนจำนวนไอเทมทั้งหมด
            slots[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = new Color(0,0,0,0);
            slots[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = null;

            
                } 
            }
           

        
    }

     public void addItem (Items item ,int checkAreaCrop){

      

         Debug.Log("Additem");
         //ถ้าไม่มีไอเทมชิ้นนี้อยู่ในกระเป็าให้เพิ่มไอเทมนี้เข้าไป แล้วให้จำนวนเป็น 1
         if(!items.Contains(item)){
             items.Add(item);
             itemNumbers.Add(1);
               //แต่ถ้ามีไอเทมนี้ ให้เพิ่มจำนวนเข้าไป1
         }else{
             Debug.Log("you already have this item");
             for(int i=0;i<items.Count;i++){
                 if(items[i] == item){
                     itemNumbers[i]++;
                 }
             }
         }
           //rerender 
         displayItems();
    }

    public void useItem (Items item){
             Debug.Log("UseItem");
      // ถ้่าไอเทมที่กดใช้ มีอยู่
        if(items.Contains(item)){
            for(int i=0 ; i < items.Count; i++){
            
                if(item == items[i]){
                    //เปลี่ยนสีกรอบเวลาคลิก
                    slots[i].transform.GetComponent<Image>().sprite = imageClick;
                    slots[i].transform.GetComponent<Image>().color = new Color(1,1,1,1);
                    
                     //เชคว่ามีต้นปลูกยุแล้วไหมถ้าไม่มีให้ขึ้นสีเขียว

                    if(item.type == "plant"){
                        for(int j=16 ; j<32 ;j++){
                            if(itemsCrop[j].GetComponent<SpriteRenderer>().sprite == null){
                                itemsCrop[j].transform.GetChild(0).GetComponent<SpriteRenderer>().color = new Color(1,1,1,0);
                            }
                        }
                        for(int y=0 ; y<16  ;y++){
                            if(itemsCrop[y].GetComponent<SpriteRenderer>().sprite == null){
                                itemsCrop[y].transform.GetChild(0).GetComponent<SpriteRenderer>().color = new Color(0,0.5f,0.3f,0.5f);
                            }
                    }
                    }
                    else if(item.type == "animal"){
                        for(int y=0 ; y<16  ;y++){
                            if(itemsCrop[y].GetComponent<SpriteRenderer>().sprite == null){
                                itemsCrop[y].transform.GetChild(0).GetComponent<SpriteRenderer>().color = new Color(1,1,1,0);
                            }
                        }
                        for(int j=16 ; j<32 ;j++){
                            if(itemsCrop[j].GetComponent<SpriteRenderer>().sprite == null){
                                itemsCrop[j].transform.GetChild(0).GetComponent<SpriteRenderer>().color = new Color(0,0.5f,0.3f,0.5f);
                            }
                        }
                    }
                    
    

                    // setเพื่อเก็บค่า item กดใช้ไปใช้ต่อในฟังชันอื่น
                    indexAmountItem = i;
                    chooseItem = item;
                    checkClickItem = true;
                }else{
                         slots[i].transform.GetComponent<Image>().sprite = null;
                    slots[i].transform.GetComponent<Image>().color = new Color(1,1,1,0);
                }
            }
        }else{
            Debug.Log("No Item in Bag ");
        }
         displayItems();  
    }

    public void Crop (string urlCropNFT, string addressWallet ,string itemID ,int checkAreaCrop,int i ){
          
            if(checkClickItem){
            //    Debug.Log(checkAreaCrop);
                if(chooseItem.type == "plant" && (checkAreaCrop == 0 || checkAreaCrop == 1 || checkAreaCrop == 2 || checkAreaCrop == 3 || checkAreaCrop == 4 || checkAreaCrop == 5 || checkAreaCrop == 6 || checkAreaCrop == 7 || checkAreaCrop == 8 || checkAreaCrop == 9 || checkAreaCrop == 10 || checkAreaCrop == 11 || checkAreaCrop == 12 || checkAreaCrop == 13 || checkAreaCrop == 14 || checkAreaCrop == 15 )){
                StartCoroutine(HttpCropPost(urlCropNFT,addressWallet,itemID,checkAreaCrop,i));
                // itemsCrop[checkAreaCrop].transform.GetComponent<SpriteRenderer>().sprite =  chooseItem.itemSprite;
                // itemsCrop[checkAreaCrop].transform.GetChild(0).GetComponent<SpriteRenderer>().color =  new Color(0,0.5f,0.3f,0);
                // itemNumbers[indexAmountItem]--;
                }

                else if(chooseItem.type == "animal" && (checkAreaCrop == 16 || checkAreaCrop == 17 || checkAreaCrop == 18 || checkAreaCrop == 19 || checkAreaCrop == 20 || checkAreaCrop == 21 || checkAreaCrop == 22 || checkAreaCrop == 23 || checkAreaCrop == 24 || checkAreaCrop == 25 || checkAreaCrop == 26 || checkAreaCrop == 27 || checkAreaCrop == 28 || checkAreaCrop == 29 || checkAreaCrop == 30 || checkAreaCrop == 31  ))
                {
                StartCoroutine(HttpCropPost(urlCropNFT,addressWallet,itemID,checkAreaCrop,i));
                // itemsCrop[checkAreaCrop].transform.GetComponent<SpriteRenderer>().sprite =  chooseItem.itemSprite;
                // itemsCrop[checkAreaCrop].transform.GetChild(0).GetComponent<SpriteRenderer>().color =  new Color(0,0.5f,0.3f,0);
                // itemNumbers[indexAmountItem]--;
                }
               
                 
            
                
                // if(itemNumbers[indexAmountItem] == 0){   
                //     items.Remove(chooseItem);
                //     itemNumbers.Remove(itemNumbers[indexAmountItem]);
                //     checkClickItem = false;
                //     slots[indexAmountItem].transform.GetComponent<Image>().sprite = null;
                //     slots[indexAmountItem].transform.GetComponent<Image>().color = new Color(1,1,1,0);
                //     //ถ้าตรงไหนไม่ได้ปลูกให้ช่องเขียวหายไป
                //         for(int y=0 ; y<itemsCrop.Length ;y++){
                //             if(itemsCrop[y].GetComponent<SpriteRenderer>().sprite == null){
                //                 itemsCrop[y].transform.GetChild(0).GetComponent<SpriteRenderer>().color = new Color(1,1,1,0);
                //             }
                //         }
             
                // }
            }
    } 

    public void chooseItemCraft (int buttonId){
               for(int i=0 ; i<itemCraft.Length;i++){
                   if( itemCraft[i] == itemCraft[buttonId]){
                        itemCraft[i].transform.GetChild(2).GetComponent<Image>().color = new Color(0.7686275f,0.7686275f,0.7686275f,0);

                   }else{
                       itemCraft[i].transform.GetChild(2).GetComponent<Image>().color = new Color(0.7686275f,0.7686275f,0.7686275f,0.6313726f);
                      
                   }
               }
                detailCraft.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = itemsDetailCraft[buttonId].textName;
                detailCraft.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = itemsDetailCraft[buttonId].textReward;
                detailCraft.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = itemsDetailCraft[buttonId].textChargeTime;
                detailCraft.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = itemsDetailCraft[buttonId].textEnergy;
                detailCraft.transform.GetChild(4).GetChild(2).GetComponent<TextMeshProUGUI>().text = itemsDetailCraft[buttonId].textWood;
                detailCraft.transform.GetChild(4).GetChild(4).GetComponent<TextMeshProUGUI>().text = itemsDetailCraft[buttonId].textfruit;
                imageItemShowCraft.transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = itemsDetailCraft[buttonId].itemSprite;
                  imageItemShowCraft.transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().text = itemsDetailCraft[buttonId].textName;

    }

    

}
