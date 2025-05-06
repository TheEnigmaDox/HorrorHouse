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
        m_computerScreen.GetComponent<ComputerScreen>().m_isOn = m_displayMessage;
    }
}
