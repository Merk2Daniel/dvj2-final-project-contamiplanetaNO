using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetsInteraction : MonoBehaviour
{
    public bool isLoaded = false;

    public void GrabObject()
    {
        isLoaded = true;
    }

    private void FixedUpdate()
    {
        if (isLoaded)
        {
            isLoaded = false;
        }
    }

    void Start()
    {
        
    }


    void Update()
    {
        
    }
}
