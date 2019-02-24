using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PSController:MonoBehaviour
{
    private ParticleSystem system;

    private bool enableEm;

    void Start()
    {
        FindVars();        
    }

    private void FindVars()
    {
        system = GetComponent<ParticleSystem>();
    }

    public void Emit()
    {
        enableEm = !enableEm;

        // Any parameters we assign in emitParams will override the current system's when we call Emit.
        // Here we will override the start color and size.
        var emitParams = new ParticleSystem.EmitParams();
        emitParams.startColor = Color.red;
        emitParams.startSize = 0.2f;
        system.Emit(emitParams, 1);
        system.Play(); // Continue normal emissions
    }
}
