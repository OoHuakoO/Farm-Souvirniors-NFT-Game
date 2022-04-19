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
        public Data[] data ;
         public string status ;
     
 }

 public class Data
 {  
         public string address_wallet ;
        public string nft_id ;
        public string name ;
        
        public string picture ;
        
        public string type;
        
        public string status ;
        
        public int cooldownTime ;

   

        public int position_plant ;
        
       
 }

public class myClass
{
  public string address_wallet ;
  public string nft_id ;
  
  public int position_plant ;
}


public class handleCrop
{
  public ObjectDataCrop data ;
  public string status ;
}
public class ObjectDataCrop{
    public string text;
    public float cooldownTime;
    
}

public class handleFeed
{
  public ObjectDataFeed data ;
  public string status ; 
}
public class ObjectDataFeed{
  public string text;
  public float cooldownTime;
}

public class handleHavest
{
  public ObjectDataHavest data ;
  public string status ;
}

public class ObjectDataHavest
{
  public string text;
}



