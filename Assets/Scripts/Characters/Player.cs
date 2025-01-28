using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    [SerializeField]
    private Transform m_viewPoint;

    [SerializeField]
    GameObject debugSphere;

    private void Start()
    {
        m_characterController = GetComponent<CharacterController>();
        m_currentSpeed = m_walkSpeed;
    }

    private void Update()
    {
        MoveCharacter(m_viewPoint);

        Ray ray = Camera.main.ScreenPointToRay(new Vector2(960, 540));
        ray.origin = Camera.main.transform.position;

        Debug.DrawLine(ray.origin, ray.direction, Color.red);

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out RaycastHit hit, 2))
            {
                debugSphere.transform.position = hit.point;

                Debug.Log("We are looking at : " + hit.collider.gameObject.name);
                DoorController doorController = hit.collider.gameObject.GetComponent<DoorController>();

               

                doorController.DoorState = !doorController.DoorState;
            } 
        }
    }
}
