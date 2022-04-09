using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventHandlePopUp : MonoBehaviour
{

     public Button buttonX;
     [SerializeField] GameObject PopUp;

    // Start is called before the first frame update
    void Start()
    {
        Button buttonXX = buttonX.GetComponent<Button>();
        buttonXX.onClick.AddListener(() => clickButtonX());
    }

    // Update is called once per frame
    void clickButtonX (){
 
       PopUp.SetActive(false);
        
    }
}
