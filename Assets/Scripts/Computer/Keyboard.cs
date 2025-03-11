using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keyboard : MonoBehaviour
{
    public bool m_displayMessage = false;

    [SerializeField] 
    GameObject m_computerScreen;



    private void Update()
    {
        if(m_displayMessage)
        {
            m_computerScreen.GetComponent<ComputerScreen>().m_isOn = true;
        }
        else
        {
            m_computerScreen.GetComponent<ComputerScreen>().m_isOn = false;
        }
    }
}
