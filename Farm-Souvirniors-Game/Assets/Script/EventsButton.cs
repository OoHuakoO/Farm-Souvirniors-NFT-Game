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
           Debug.Log("Craft");

            if(craft.activeInHierarchy == false){
            Debug.Log("a");
            craft.SetActive(true);
        }else{
            Debug.Log("b");
            craft.SetActive(false);
        }
        if(bag.activeInHierarchy){
            bag.SetActive(false);
        }
        
        // if(bag != null){
        //     bag.SetActive(false);
        // }
        // y++;
        // if(y%2 == 0){
        //     craft.SetActive(false);
        // }else if(y%2 != 0){
        //       craft.SetActive(true);
        // }
    }
    void clickBag (){
        Debug.Log("Bag");
        if(bag.activeInHierarchy == false){
            Debug.Log("a");
            bag.SetActive(true);
        }else{
            Debug.Log("b");
            bag.SetActive(false);
        }
        if(craft.activeInHierarchy){
            craft.SetActive(false);
        }
    
        // i++;
        // if(i%2 == 0){
        //     bag.SetActive(false);
        // }else if(i%2 != 0){
        //       bag.SetActive(true);
        // }
        
    }
}
