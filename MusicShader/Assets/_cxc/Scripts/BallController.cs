using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(Rotator))]
public class BallController:MonoBehaviour
{    
    private Rotator rotator;
    private Material material;

    private bool oddNote;

    private bool initialized;

    void Start()
    {
        Init();
    }

    #region UTIL
    private void Init()
    {
        if(initialized) return;

        FindVars();

        initialized = true;
    }

    private void FindVars()
    {
        rotator = GetComponent<Rotator>();
        material = GetComponent<Renderer>().material;
    }
    #endregion

    #region UTIL (public)
    public void Show(bool show)
    {
        if(!initialized) Init();

        gameObject.SetActive(show);
    }

    public void SetSize(int size)
    {
        if(!initialized) Init();

        gameObject.transform.localScale = new Vector3(size, size, size);
    }

    public void SetColor(Color c)
    {
        if(!initialized) Init();

        if(!isActiveAndEnabled) return;

        material.SetColor("_Color", c);

        StopAllCoroutines();

        StartCoroutine(ColorChange(oddNote ? Color.black : Color.white, 0.1F));
    }

    public void Rotate(int amount)
    {
        if(!initialized) Init();

        rotator.SetRotateAmount(amount);
    }

    /*
    private IEnumerator FadeOut(float alphaStart, float alphaFinish, float time)
    {
        if (bgTexture == null)
            yield return null;

        float elapsedTime = 0;
        material.alpha = alphaStart;

        while (elapsedTime < time)
        {
        bgTexture.alpha = Mathf.Lerp(material.alpha, alphaFinish, (elapsedTime / time));
            elapsedTime += Time.deltaTime;
        yield return new WaitForEndOfFrame();
        }
    }
   */

   IEnumerator ColorChange(Color newColor, float transitionTime)
    {
        //Infinite loop will ensure our coroutine runs all game
        while(true)
        {
            float transitionRate = 0; //Create and set transitionRate to 0. This is necessary for our next while loop to function

            /* 1 is the highest value that the Color.Lerp function uses for
             * transitioning between two colors. This while loop will execute
             * until transitionRate is incremented to 1 or higher
             */
            while(transitionRate < 1)
            {
                //this next line is how we change our material color property. We Lerp between the current color and newColor
                material.SetColor("_Color", Color.Lerp(material.color, newColor, Time.deltaTime * transitionRate));
                transitionRate += Time.deltaTime / transitionTime; // Increment transitionRate over the length of transitionTime

                yield return null; // wait for a frame then loop again
            }
            yield return null; // wait for a frame then loop again
        }
    }       
    #endregion
}