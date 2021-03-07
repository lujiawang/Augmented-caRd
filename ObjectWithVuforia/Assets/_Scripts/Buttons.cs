using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{
    private Button[] btns;
    private int count = 0;
    public static string m_message;
    private GameObject slideBar;

    public GameObject HomeGreeting;

    // Start is called before the first frame update
    void Start()
    {
        slideBar = GameObject.FindGameObjectWithTag("slideBar");

        btns = new Button[this.transform.childCount];
        
        for (int i = 0; i < this.transform.childCount; i++ )
        {
            Button btn = transform.GetChild(i).GetComponent<Button>();
            if(btn != null)
            {
                btns[i] = btn;
            }
        }

        m_message = "Home";
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < this.transform.childCount; i++)
        {
            if (i == count)
            {
                btns[i].interactable = false;
                slideBar.transform.position = new Vector3 (btns[i].transform.position.x, slideBar.transform.position.y, slideBar.transform.position.z);
            }
            else
            {
                btns[i].interactable = true;
            }
        }
    }

    public void GetClicked(int index)
    {
        count = index;
        m_message = btns[count].name;
        Debug.Log("You have clicked " + m_message);

    }
}
