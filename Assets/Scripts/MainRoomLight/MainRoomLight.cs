using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class MainRoomLight : MonoBehaviour
{
    [SerializeField]
    GameObject m_mainLight;

    float m_rotSpeed = 5f;

    float m_currRot;

    // Start is called before the first frame update
    void Start()
    {
        m_currRot = transform.rotation.y;
    }

    // Update is called once per frame
    void Update()
    {
        m_currRot += m_rotSpeed;

        transform.rotation = Quaternion.Euler(transform.rotation.x, m_currRot, transform.rotation.z);
    }

    public void SwitchOff()
    {
        if(m_mainLight.activeSelf)
        {
            m_mainLight.SetActive(false);
        }
    }

    public void SwitchOn()
    {
        if(!m_mainLight.activeSelf)
        {
            m_mainLight.SetActive(true);
        }
    }
}
