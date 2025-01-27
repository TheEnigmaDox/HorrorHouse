using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    [SerializeField]
    private Transform m_viewPoint;

    private void Start()
    {
        m_characterController = GetComponent<CharacterController>();
        m_currentSpeed = m_walkSpeed;
    }

    private void Update()
    {
        MoveCharacter(m_viewPoint);
    }
}
