using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemButton : MonoBehaviour
{
 public int buttonId;
 private Items thisItem;
 private Items getThisItem (){
     for(int i = 0;i<GameManager.instance.items.Count;i++){
         if(buttonId == i){
        
             thisItem = GameManager.instance.items[i];
         }
     }
     return thisItem;
 }

 public void pickItem (){
     GameManager.instance.useItem(getThisItem());
 }


}

