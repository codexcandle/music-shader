using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using SonicBloom.Koreo;

public class EventSubscriber:MonoBehaviour
{
    void Start()
    {
        Koreographer.Instance.RegisterForEvents("TestEventID", FireEventDebugLog);
    }

    private void FireEventDebugLog(KoreographyEvent koreoEvent)
    {
        // do stuff...
        Debug.Log("nice! @ eventSubbbbbb");
    }
}
