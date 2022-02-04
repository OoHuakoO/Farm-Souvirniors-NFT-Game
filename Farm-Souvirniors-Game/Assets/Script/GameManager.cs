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

            //update Amount Items
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
                    itemNumbers[i]--;
                    if(itemNumbers[i] == 0){
                        
                        items.Remove(item);
                        itemNumbers.Remove(itemNumbers[i]);
                    }
                }
            }
        }else{
            Debug.Log("No Item in Bag ");
        }
         displayItems();  
    }
}
