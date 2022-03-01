using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// public class Data
// {
//   public ArrayList data {get;set;}
//    public string status {get;set;}
//     public string name {get;set;}
// }

 public class JsonClass
 {
        public Data[] data {get ; set;}
         public string status {get ; set;}
     
 }

 public class Data
 {  
         public string address_wallet {get ; set;}
        public string nft_id {get ; set;}
        public string name {get ; set;}
        
        public string picture {get ; set;}
        
        public string type {get ; set;}
        
        public string status {get ; set;}
        
        public string cooldownFeedTime {get ; set;}

        public string cooldownHarvestTime {get ; set;}
        
       
 }

public class myClass
{
  public string address_wallet {get ; set;}
  public string nft_id {get ; set;}
  
  public int checkAreaCrop {get ; set ;}
}


// public class OJO
// {
//       public string address_wallett {get ; set;}
//        public string nft_idt {get ; set;}
//   public float timeStart {get ; set;}
 
// }