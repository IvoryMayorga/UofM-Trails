using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class MyEventTriggerOnEnter : MonoBehaviour
{

    [Header("Custom Event")]
    public UnityEvent myEvents;
    public UnityEvent myEventsEnd;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (myEvents == null)
        {
            print("myEventTriggerOnEnter was triggered but myEvents was null");
        }
        else
        {
            print("myEventTriggerOnEnter Activated. Triggering" + myEvents);
            myEvents.Invoke();
        }
      
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (myEventsEnd == null)
        {
            print("myEventTriggerOnEnter was triggered but myEvents was null");
        }
        else
        {
            print("myEventTriggerOnEnter Activated. Triggering " + myEventsEnd);
            myEventsEnd.Invoke();
        }

    }
}