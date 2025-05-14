using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class MainRoomLight : MonoBehaviour
{
    private bool m_isOn = false;

    [SerializeField]
    GameObject m_mainLight;

    float m_rotSpeed = 5f;

    float m_currRot;

    public bool IsOn
    {
        get { return m_isOn; }
        set { m_isOn = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        m_currRot = transform.rotation.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (m_isOn)
        {
            if (this.gameObject.activeInHierarchy)
            {
                if (this.gameObject.CompareTag("MainBedroomFan"))
                {
                    m_currRot += m_rotSpeed;
                }

                transform.rotation = Quaternion.Euler(transform.rotation.x, m_currRot, transform.rotation.z);
            }   
        }

        m_mainLight.SetActive(m_isOn);
    }

    public void LightSwitch(bool isOn)
    {
        m_isOn = isOn;
    }

    //public void SwitchOff()
    //{
    //    if(m_mainLight.activeSelf)
    //    {
    //        m_mainLight.SetActive(false);
    //    }
    //}

    //public void SwitchOn()
    //{
    //    if(!m_mainLight.activeSelf)
    //    {
    //        m_mainLight.SetActive(true);
    //    }
    //}
}
