using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

public class LoadingScreen : MonoBehaviour
{
   

    public static LoadingScreen same;
    public string addressWallet ;
        
     private void Awake() {
         if(same == null){
            same = this;
        }
   }
   
    // public void SpawnEnemies (string amount) {
    // Debug.Log ($"Your Token Is '{amount}' ");
    // addressWallet = amount;
    // }


    
    public void Testing (string amount) {
    Debug.Log ($"Spawning {amount} enemies!");
    addressWallet = amount;
    Debug.Log(addressWallet);
    }
 
    
    private void Start() {
        Testing("0x629812063124cE2448703B889D754b232B3622BA");
        
        StartCoroutine(cooldowntime());
       
    }



   
  public IEnumerator cooldowntime()
        {
            
            
                yield return new WaitForSecondsRealtime(2f);
                    SceneManager.LoadScene(1);               
                         
        }
}
