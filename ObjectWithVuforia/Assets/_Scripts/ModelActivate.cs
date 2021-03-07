using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelActivate : MonoBehaviour
{
    private static string message;
    public int index;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        message = Buttons.m_message;
        if (Infos.index == index && message == "Home")
        {
            foreach (Renderer r in this.gameObject.GetComponentsInChildren<Renderer>())
                r.enabled = true;
        }
        else
        {
            foreach (Renderer r in this.gameObject.GetComponentsInChildren<Renderer>())
                r.enabled = false;
        }
    }
}
