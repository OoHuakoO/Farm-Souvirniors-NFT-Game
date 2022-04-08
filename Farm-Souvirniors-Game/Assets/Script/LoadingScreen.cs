using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

public class LoadingScreen : MonoBehaviour
{
   
    
   
 
 
    
    private void Start() {
      
        StartCoroutine(cooldowntime());
       
    }



   
  public IEnumerator cooldowntime()
        {
            
            
                yield return new WaitForSecondsRealtime(2f);
                    SceneManager.LoadScene(1);               
                         
        }
}
