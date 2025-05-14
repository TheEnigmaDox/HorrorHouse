using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour, IInteract
{
    [SerializeField]
    bool m_doorState = false;

    Animator m_animator;

    public bool DoorState
    {
        get { return m_doorState; }
        set { m_doorState = value; }
    }

    private void Start()
    {
        m_animator = GetComponent<Animator>();  
    }

    // Update is called once per frame
    void Update()
    {
        m_animator.SetBool("DoorState", m_doorState);
        //Debug.Log($"Door state : {m_doorState}");
    }

    void IInteract.Interact()
    {
        m_doorState = !m_doorState;
    }
}
