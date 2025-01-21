using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    protected float m_WalkSpeed = 5f;
    protected float m_CurrentSpeed;
    protected float m_RunSpeed = 10f;

    protected float m_JumpForce = 5f;

    protected Rigidbody m_Rigidbody;
}
