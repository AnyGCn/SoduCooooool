using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SodukuElement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        EventTrigger eventTrigger = GetComponent<EventTrigger>();
        eventTrigger.triggers = new List<EventTrigger.Entry>
        {

        };
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnClick()
    {
        
    }
}
