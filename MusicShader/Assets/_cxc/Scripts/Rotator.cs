using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] private float yPos;

    private float rotateAmount;

    void Update()
    {
        // sanitize
        if(rotateAmount <= 0) return;

        // Rotate the object around its local X axis at 1 degree per second
        transform.Rotate(0, yPos, 0);

        // ...also rotate around the World's Y axis
       //  transform.Rotate(0, Time.deltaTime, 0, Space.World);
    }

    public void SetRotateAmount(int amount)
    {
        rotateAmount = amount;
    }
}