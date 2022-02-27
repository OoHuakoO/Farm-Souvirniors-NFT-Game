using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using TMPro;



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
    public GameObject showCrop;
    //จำนวนไอเทมที่เลือก
    int indexAmountItem;
    //ไอเทมที่เลือก
    Items chooseItem;
    //เชคว่าคลิกไอเทมในเป่ายุไหม
    public bool checkClickItem = false;
    //object ในช่องปลูก
    public GameObject[] itemsCrop;

    public GameObject[] itemCraft;
    
    public GameObject detailCraft;
    public List<Items> itemsDetailCraft = new List<Items>();

    public GameObject imageItemShowCraft ;





    
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



   private void Start() {
       string url = "https://farm-souvirnior-project.herokuapp.com/in-game/get-owner-nft/0x629812063124cE2448703B889D754b232B3622BA";
        StartCoroutine(HttpGet(url));
        
    }

  
        //getItemNFT
      public IEnumerator HttpGet(string url)
        {
            using(UnityWebRequest webRequest = UnityWebRequest.Get(url))
            {
                yield return webRequest.SendWebRequest();
                var response = webRequest.downloadHandler.text ;
            
                JsonClass result = JsonConvert.DeserializeObject<JsonClass>(response);
                    // int y = 0  ;
                        for(int i=0;i<result.data.Length;i++){
                            for(int y=0;y<AllItem.Length;y++){
                                   if(result.data[i].name == AllItem[y].itemName){
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
                            }
                             
                            
                        }
                   
               
            }
             displayItems();
        }

        //PostCropNFT
           public IEnumerator HttpPost(string url, string address , string itemId)
        {
            var dataObject = new myClass();
            dataObject.address_wallet = address;
            dataObject.nft_id = itemId;
            string json = JsonUtility.ToJson(dataObject);
            Debug.Log(json);
           using(UnityWebRequest webRequest = UnityWebRequest.Post(url, json))
            {
               
                webRequest.uploadHandler = new UploadHandlerRaw(System.Text.Encoding.UTF8.GetBytes(json));
                  webRequest.SetRequestHeader("Content-Type", "application/json");
                yield return webRequest.SendWebRequest();

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

     public void addItem (Items item){
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
                    for(int y=0 ; y<itemsCrop.Length ;y++){
                        if(itemsCrop[y].GetComponent<SpriteRenderer>().sprite == null){
                            itemsCrop[y].transform.GetChild(0).GetComponent<SpriteRenderer>().color = new Color(0,0.5f,0.3f,0.5f);
                        }
                    }
    
                    // showCrop.SetActive(true);

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

    public void Crop (int checkAreaCrop){
            string urlCropNFT = "https://farm-souvirnior-project.herokuapp.com/in-game/plant-nft";

            
           
             Debug.Log("Crop");
             Debug.Log(checkAreaCrop);
       
            if(checkClickItem){
            
                itemsCrop[checkAreaCrop].transform.GetComponent<SpriteRenderer>().sprite =  chooseItem.itemSprite;
                itemsCrop[checkAreaCrop].transform.GetChild(0).GetComponent<SpriteRenderer>().color =  new Color(0,0.5f,0.3f,0);
                 itemNumbers[indexAmountItem]--;
                StartCoroutine(HttpPost(urlCropNFT,"0x629812063124cE2448703B889D754b232B3622BA","1645949068177"));
                
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
            }
      displayItems();
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
