using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class LightSwitch : MonoBehaviour
{
    [SerializeField]
    private bool m_isOn = false;

    [SerializeField]
    List<GameObject> m_bigLight;

    private Animator m_animator;

    public bool IsOn
    {
        get { return m_isOn; }
        set { m_isOn = value; }
    }

    private void Start()
    {
        m_animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        m_animator.SetBool("IsOn", m_isOn);

        if(m_isOn)
        {
            for (int i = 0; i < m_bigLight.Count; i++)
            {
                MainRoomLight mainLight = m_bigLight[i].GetComponent<MainRoomLight>();

                mainLight.SwitchOn(); 
            }
        }
        else
        {
            for (int i = 0; i < m_bigLight.Count; i++)
            {
                MainRoomLight mainLight = m_bigLight[i].GetComponent<MainRoomLight>();

                mainLight.SwitchOff();
            }
        }
    }
}
