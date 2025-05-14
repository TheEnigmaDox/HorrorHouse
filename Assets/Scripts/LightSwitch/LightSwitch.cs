using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class LightSwitch : MonoBehaviour, IInteract
{
    [SerializeField]
    private bool m_isOn = false;

    [SerializeField]
    List<GameObject> m_bigLight;

    private Animator m_animator;

    private void Start()
    {
        m_animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        m_animator.SetBool("IsOn", m_isOn);

        for(int i = 0; i < m_bigLight.Count; i++)
        {
            MainRoomLight mainLight = m_bigLight[i].GetComponent<MainRoomLight>();

            mainLight.LightSwitch(m_isOn);
        }

        Debug.Log($"Light Switch is on : {m_isOn}");

        //if(m_isOn)
        //{
        //    for (int i = 0; i < m_bigLight.Count; i++)
        //    {
        //        MainRoomLight mainLight = m_bigLight[i].GetComponent<MainRoomLight>();

        //        mainLight.SwitchOn();
        //        mainLight.IsOn = m_isOn;
        //    }
        //}
        //else
        //{
        //    for (int i = 0; i < m_bigLight.Count; i++)
        //    {
        //        MainRoomLight mainLight = m_bigLight[i].GetComponent<MainRoomLight>();

        //        mainLight.SwitchOff();
        //        mainLight.IsOn = m_isOn;
        //    }
        //}
    }

    void IInteract.Interact()
    {
        m_isOn = !m_isOn;
    }
}
