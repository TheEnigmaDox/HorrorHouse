using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

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
                
                if (hit.collider.gameObject.GetComponent<DoorController>())
                {
                    DoorController doorController = hit.collider.gameObject.GetComponent<DoorController>();

                    doorController.DoorState = !doorController.DoorState;
                }
                else if (hit.collider.transform.Find("Directional Light").gameObject)
                {
                    GameObject light = hit.collider.transform.Find("Directional Light").gameObject;

                    if (light.activeSelf)
                    {
                        light.SetActive(false);
                    }
                    else
                    {
                        light.SetActive(true);
                    }
                }
            } 
        }
    }

    IEnumerable Wait(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
    }
}
