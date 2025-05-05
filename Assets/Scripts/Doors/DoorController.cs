using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField]
    bool m_doorState = false;

    public bool DoorState
    {
        get { return m_doorState; }
        set { m_doorState = value; } 
    }

    Animator m_animator;

    // Start is called before the first frame update
    void Start()
    {
        m_animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (m_animator == null)
        //    Debug.Log($"{m_animator} is not found!");
        //else
        //    Debug.Log($"{m_animator} has been found!");

        //Debug.Log("DoorState : " + m_doorState);

            m_animator.SetBool("DoorState", m_doorState);
    }
}
