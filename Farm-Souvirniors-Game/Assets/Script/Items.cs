using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName ="Item" , fileName = "New Item")]
public class Items : ScriptableObject
{
   public string itemName;
   public string type;
   public Sprite itemSprite;
   public string textName;
   public string textReward;
   public string textChargeTime;
   public string textEnergy;
   public string textWood;
   public string textfruit;

   public List<string> test = new List<string>();

}
