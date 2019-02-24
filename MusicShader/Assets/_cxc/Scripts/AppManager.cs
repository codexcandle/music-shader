using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SonicBloom.Koreo;

public class AppManager:MonoBehaviour
{
    // [SerializeField] private CameraController camController;
    [SerializeField] private PSController pSController;
    // [SerializeField] private BallController ballController;
    // [SerializeField] private VidController vidController;
    [SerializeField] private DisplacementControl displacementControl;


    private const string EVENT_ID = "DrippleEventID";

    private int callCount;
    private bool oddNote;

    void Start()
    {
        Init();
    }

    #region UTIL
    private void Init()
    {
        // ballController.Show(false);
        // vidController.Show(false);

        Koreographer.Instance.RegisterForEvents(EVENT_ID, FireEventDebugLog);
    }

    private void FireEventDebugLog(KoreographyEvent koreoEvent)
    {
        Debug.Log("__callCount: " + callCount);

        callCount++;

        displacementControl.Displace(oddNote);

        oddNote = !oddNote;
        
        AnimateByCallCount(callCount);


        /* 
        if(callCount < 4)
        {
            return;
        }
        else if(callCount == 29)
        {
            // ...
        }        
        else if(callCount == 52)
        {
            ballController.SetSize(4);
        }
        else if(callCount < 37)
        {
            ballController.SetSize(oddNote ? 4 : 1);

            ballController.Rotate(20);    
        }
        else
        {
             ballController.SetSize(oddNote ? 1 : 4);     
             ballController.Rotate(60);      
        }

        if(callCount > 8 && callCount < 28)
        {
            vidController.Trigger();
        }

        switch(callCount)
        {
            case 5:
                ballController.Show(true);
                break;
            case 17:
                vidController.Show(true);
                break;
            case 29:
                vidController.Show(true);

                camController.Shake();
                break;
            case 37:
                vidController.Show(false);
                break;
            case 51:
                ballController.SetColor(Color.green);
                break;
            default:
                ballController.SetColor(Color.black);
                break;
        }

    

        if(callCount == 51)
        {
            ballController.SetColor(Color.green);
        }
        else if(callCount > 37)
        {
            ballController.SetColor(Color.blue);
        }

        // pSController.Emit();
        */
    }

    private void AnimateByCallCount(int count)
    {
        if(count < 34) return;

        if(count % 2 == 0)
        {
            pSController.Emit();
        }
    }
    #endregion
}