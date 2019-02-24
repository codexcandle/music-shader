using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplacementControl:MonoBehaviour
{
    public float displacementAmount;
    public ParticleSystem explosionParticles;
    MeshRenderer meshRender;

    private bool allowDisplacement;

    void Start()
    {
        meshRender = GetComponent<MeshRenderer>();
    }

    public void Displace(bool displace)
    {
        allowDisplacement = displace;
    }

    void Update()
    {
        displacementAmount = Mathf.Lerp(displacementAmount, 0, Time.deltaTime);
        meshRender.material.SetFloat("_Amount", displacementAmount);

        if(allowDisplacement)   // if (Input.GetButtonDown("Jump"))
        {
            displacementAmount -= 2f;
            explosionParticles.Play();
        }
    }
}