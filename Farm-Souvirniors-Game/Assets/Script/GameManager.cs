using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
   public static GameManager instance;
    // type items
    public List<Items> items = new List<Items>();
    //Amount items
    public List<int> itemNumbers = new List<int>();
    public GameObject[] slots ;
    public Sprite imageClick;
    public GameObject showCrop;

    int indexAmountItem;
    Items nameItem;

    bool checkClickItem = false;


    
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
        displayItems();
    }

    void displayItems(){
     
            for(int i=0 ; i<slots.Length; i++){
                if(i < items.Count){
                     //update slot image
            slots[i].transform.GetChild(1).GetComponent<Image>().color = new Color(1,1,1,1);
            slots[i].transform.GetChild(1).GetComponent<Image>().sprite = items[i].itemSprite;

            //update Amount Items
            slots[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = new Color(0,0,0,1);
            slots[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = itemNumbers[i].ToString();
            }  
            else{
             //update slot image
            slots[i].transform.GetChild(1).GetComponent<Image>().color = new Color(1,1,1,0);
            slots[i].transform.GetChild(1).GetComponent<Image>().sprite = null;

            //update Amount Item
            slots[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = new Color(0,0,0,0);
            slots[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = null;

            
                } 
            }
           

        
    }

     public void addItem (Items item){
         if(!items.Contains(item)){
             items.Add(item);
             itemNumbers.Add(1);
         }else{
             Debug.Log("you already have this item");
             for(int i=0;i<items.Count;i++){
                 if(items[i] == item){
                     itemNumbers[i]++;
                 }
             }
         }
         displayItems();
    }

    public void useItem (Items item){
     
        if(items.Contains(item)){
            for(int i=0 ; i < items.Count; i++){
                if(item == items[i]){
                    //ClickChangeColor
                    slots[i].transform.GetComponent<Image>().sprite = imageClick;
                    slots[i].transform.GetComponent<Image>().color = new Color(1,1,1,1);
                    showCrop.SetActive(true);
                    indexAmountItem = i;
                    nameItem = item;
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

    public void Crop (){
            if(checkClickItem){
                 itemNumbers[indexAmountItem]--;
            if(itemNumbers[indexAmountItem] == 0){   
                items.Remove(nameItem);
                itemNumbers.Remove(itemNumbers[indexAmountItem]);
                checkClickItem = false;
                slots[indexAmountItem].transform.GetComponent<Image>().sprite = null;
                slots[indexAmountItem].transform.GetComponent<Image>().color = new Color(1,1,1,0);
            }
            }
      displayItems();
    } 
}
