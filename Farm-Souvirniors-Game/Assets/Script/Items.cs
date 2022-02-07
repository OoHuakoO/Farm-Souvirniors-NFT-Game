using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName ="Item" , fileName = "New Item")]
public class Items : ScriptableObject
{
   public string itemName;
   public Sprite itemSprite;
   [SerializeField] string textName;
   [SerializeField] string textReward;
   [SerializeField] string textChargeTime;
   [SerializeField] string textEnergy;
   [SerializeField] string textWood;
   [SerializeField] string textfruit;
}
