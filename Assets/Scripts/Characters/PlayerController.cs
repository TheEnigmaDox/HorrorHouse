using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Character
{
    [SerializeField]
    private Transform m_ViewPoint;

    [SerializeField]
    private float m_MouseSensitivity = 1f;

    private float m_VRotStore;
    private Vector2 m_mouseInput;

    private Vector3 m_MoveDir; 
    private Vector3 m_Movement;

    private void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();        
        m_CurrentSpeed = m_WalkSpeed;
    }

    private void Update()
    {
        MoveCharacter();
    }

    private void MoveCharacter()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            m_CurrentSpeed = m_RunSpeed;
        }
        else
        {
            m_CurrentSpeed = m_WalkSpeed;
        }

        m_mouseInput = new Vector2(Input.GetAxisRaw("Mouse X"), -Input.GetAxisRaw("Mouse Y")) * m_MouseSensitivity;

        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + m_mouseInput.x, transform.rotation.eulerAngles.z);

        m_VRotStore += m_mouseInput.y;
        m_VRotStore = Mathf.Clamp(m_VRotStore, -60f, 60f);

        m_ViewPoint.rotation = Quaternion.Euler(m_VRotStore, m_ViewPoint.rotation.eulerAngles.y, m_ViewPoint.rotation.eulerAngles.z);

        m_MoveDir = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));

        m_Movement = ((transform.forward * m_MoveDir.z) + (transform.right * m_MoveDir.x)).normalized;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            m_Rigidbody.AddForce(Vector2.up * m_JumpForce, ForceMode.Impulse);
        }

        transform.position += m_Movement * m_CurrentSpeed * Time.deltaTime;
    }
}
