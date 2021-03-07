using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Infos : MonoBehaviour
{
    public static int index;

    // Start is called before the first frame update
    void Start()
    {
        index = -1;
    }

    // Update is called once per frame
    void Update()
    {
           
    }

    public void GetData(int ind)
    {
        index = ind;
    }
}
