using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

public class LoadingScreen : MonoBehaviour
{
    string urlGetNFT = "https://farm-souvirniors-api.herokuapp.com/in-game/get-owner-nft/0x629812063124cE2448703B889D754b232B3622BA";

    private void Start() {
        StartCoroutine(HttpGet(urlGetNFT));
    }
   
  public IEnumerator HttpGet(string url)
        {
      
            using(UnityWebRequest webRequest = UnityWebRequest.Get(url))
            {
                yield return webRequest.SendWebRequest();
                var response = webRequest.downloadHandler.text ;
            
                JsonClass result = JsonConvert.DeserializeObject<JsonClass>(response);
                     Debug.Log(result);
                yield return new WaitForSecondsRealtime(5f);
                    SceneManager.LoadScene(1);               
                       
                         
                                        
            }
            
        }
}
