using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour, IInteract
{
    [SerializeField]
    private bool m_isLocked = false;
    [SerializeField]
    private bool m_doorState = false;

    [SerializeField]
    private float m_lockTimer = 10f;
   
    private Animator m_animator;
    private BoxCollider m_boxCollider;

    public bool IsLocked
    {
        set {  m_isLocked = value; }    
    }

    public bool DoorState
    {
        get { return m_doorState; }
        set { m_doorState = value; }
    }

    private void Start()
    {
        m_animator = GetComponent<Animator>();  
        m_boxCollider = GetComponentInParent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_isLocked)
        {
            m_lockTimer -= Time.deltaTime;

            if (m_lockTimer <= 0)
                m_doorState = false;
        }

        m_animator.SetBool("DoorState", m_doorState);
        //Debug.Log($"Door state : {m_doorState}");
    }

    void IInteract.Interact()
    {
        if(!m_isLocked)
            m_doorState = !m_doorState;
    }
}
