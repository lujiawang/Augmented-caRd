/**************************************************************************
* Copyright (C) echoAR, Inc. 2018-2020.                                   *
* echoAR, Inc. proprietary and confidential.                              *
*                                                                         *
* Use subject to the terms of the Terms of Service available at           *
* https://www.echoar.xyz/terms, or another agreement                      *
* between echoAR, Inc. and you, your company or other organization.       *
***************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomBehaviour : MonoBehaviour
{
    [HideInInspector]
    public Entry entry;
    
    private static string message;
    private int ind;

    /// <summary>
    /// EXAMPLE BEHAVIOUR
    /// Queries the database and names the object based on the result.
    /// </summary>

    // Use this for initialization
    void Start()
    {
        // Add RemoteTransformations script to object and set its entry
        this.gameObject.AddComponent<RemoteTransformations>().entry = entry;

        // Qurey additional data to get the name
        string value = "";
        if (entry.getAdditionalData() != null && entry.getAdditionalData().TryGetValue("name", out value))
        {
            // Set name
            this.gameObject.name = value;
        }

        if (this.transform.parent.parent.name.Equals("ImageTarget-00"))
        {
            ind = 0;
        } else if (this.transform.parent.parent.name.Equals("ImageTarget-01"))
        {
            ind = 1;
        }
        Debug.Log(this.name + " " + ind);
    }

    // Update is called once per frame
    void Update()
    {

        message = Buttons.m_message;
        //fetch the message from the dropdown UI
        //message = DropdownChangeText.m_Message;
        //render the selected model 
        if (Infos.index == ind && message == this.gameObject.name)
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