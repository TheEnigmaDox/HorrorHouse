using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class LightSwitch : MonoBehaviour
{
    [SerializeField]
    private bool m_isOn = false;

    [SerializeField]
    GameObject m_bigLight;

    private Animator m_animator;

    public bool IsOn
    {
        get { return m_isOn; }
        set { m_isOn = value; }
    }

    private void Start()
    {
        m_animator = GetComponent<Animator>();

        m_bigLight = GameObject.FindGameObjectWithTag("MainBedroomFan");
    }

    // Update is called once per frame
    void Update()
    {
        m_animator.SetBool("IsOn", m_isOn);

        if(m_isOn)
        {
            MainRoomLight mainLight = m_bigLight.GetComponent<MainRoomLight>();

            mainLight.SwitchOn();
        }
        else
        {
            MainRoomLight mainLight = m_bigLight.GetComponent<MainRoomLight>();

            mainLight.SwitchOff();
        }
    }
}
