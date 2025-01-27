using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    //Movement
    protected float m_currentSpeed;
    protected float m_walkSpeed = 5f;
    protected float m_runSpeed = 10f;
    protected Vector3 m_moveDirection;
    protected Vector3 m_movement;
    protected CharacterController m_characterController;

    //Camera
    protected float m_mouseSensitivity = 1f;
    protected float m_vertRotationStore;
    protected Vector2 m_mouseInput;

    protected void MoveCharacter(Transform viewPoint)
    {
        m_mouseInput = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y")) * m_mouseSensitivity;

        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x,
            transform.rotation.eulerAngles.y + m_mouseInput.x,
            transform.rotation.eulerAngles.z);

        m_vertRotationStore += m_mouseInput.y;

        m_vertRotationStore = Mathf.Clamp(m_vertRotationStore, -60, 60);

        viewPoint.rotation = Quaternion.Euler(-m_vertRotationStore,
            viewPoint.rotation.eulerAngles.y,
            viewPoint.rotation.z);

        m_moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));

        float yVel = m_movement.y;
        m_movement = (transform.forward * m_moveDirection.z) + (transform.right * m_moveDirection.x).normalized;
        m_movement.y = yVel;

        if (m_characterController.isGrounded)
        {
            m_movement.y = 0f;
        }

        m_movement.y += Physics.gravity.y * Time.deltaTime;

        m_characterController.Move(m_currentSpeed * Time.deltaTime * m_movement);
    }

    protected void CharacterRun()
    {
        m_currentSpeed = m_runSpeed;
    }

    protected void CharacterWalk()
    {
        m_currentSpeed = m_walkSpeed;
    }
}
