using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseCraft : MonoBehaviour
{
   [SerializeField] int buttonId ;

   public void clickButton(){
       GameManager.instance.chooseItemCraft(buttonId);
   }


}
