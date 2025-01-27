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
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(0.5f, 0.5f, 0.5f));
        ray.origin = Camera.main.transform.position;

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                Debug.Log("We are looking at : " + hit.collider.gameObject.name);
                DoorController doorController = hit.collider.gameObject.GetComponent<DoorController>();

                doorController.DoorState = !doorController.DoorState;
            } 
        }

        Debug.DrawLine(ray.origin, ray.direction, Color.red);

        MoveCharacter(m_viewPoint);
    }
}
