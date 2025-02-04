using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour
{
    private bool m_isOn = false;

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
    }
}
