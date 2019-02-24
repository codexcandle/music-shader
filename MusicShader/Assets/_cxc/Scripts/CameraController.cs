using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CameraShaker))]
public class CameraController:MonoBehaviour
{
    private CameraShaker cameraShaker;

    void Start()
    {
        Init();
    }

    #region UTIL
    private void Init()
    {
        FindVars();
    }

    private void FindVars()
    {
        cameraShaker = GetComponent<CameraShaker>();
    }
    #endregion

    #region UTIL (public)
    public void Shake()
    {
        cameraShaker.Shake();
    }
    #endregion
}