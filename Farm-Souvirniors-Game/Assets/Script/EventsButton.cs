using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventsButton : MonoBehaviour
{
    public Button buttonCraft;
    public Button buttonBag;

    public GameObject craft; 
    public GameObject bag; 


  
 
    void Start()
    {   
      
        bag.SetActive(false);
        craft.SetActive(false);
        Button button1 = buttonCraft.GetComponent<Button>();
        Button button2 = buttonBag.GetComponent<Button>();
        button1.onClick.AddListener(() => clickCraft());
        button2.onClick.AddListener(() => clickBag());
     
    }

    void clickCraft (){
      

            if(craft.activeInHierarchy == false){
        
            craft.SetActive(true);
        }else{
    
            craft.SetActive(false);
        }
        if(bag.activeInHierarchy){
            bag.SetActive(false);
        }
        
    }
    void clickBag (){
 
        if(bag.activeInHierarchy == false){
      
            bag.SetActive(true);
        }else{
        
            bag.SetActive(false);
        }
        if(craft.activeInHierarchy){
            craft.SetActive(false);
        }
        
    }
}
