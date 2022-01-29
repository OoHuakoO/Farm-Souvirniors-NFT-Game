using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventsButton : MonoBehaviour
{
    public Button buttonCraft;
    void Start()
    {
        Button button = buttonCraft.GetComponent<Button>();
        button.onClick.AddListener(click);
    }
    void Update()
    {
        
    }

    void click (){
        Debug.Log("hello");
    }
}
