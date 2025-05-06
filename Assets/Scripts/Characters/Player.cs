using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Player : Character
{
    private bool m_isHoldingDoll = false;
    private bool m_mouseControl = false;

    private int m_sanity = 100;

    [SerializeField]
    private Transform m_viewPoint;

    [SerializeField]
    GameObject debugSphere;

    [SerializeField]
    private Slider m_sanityBar;

    [SerializeField]
    private Transform m_handPoint;

    public bool MouseControl
    {
        get { return m_mouseControl; }
        set { m_mouseControl = value; }
    }

    private void Start()
    {
        m_characterController = GetComponent<CharacterController>();
        m_animator = GetComponent<Animator>();
        m_currentSpeed = m_walkSpeed;

        if(m_sanityBar != null)
            m_sanityBar.maxValue = m_sanity;
    }

    private void Update()
    {
        if (m_sanityBar != null)
            m_sanityBar.value = m_sanity;

        if (GameManager.GM_Instance.MouseControl)
            MoveCharacter(m_viewPoint);

        m_animator.SetBool("IsMoving", m_isMoving);

        Ray ray = Camera.main.ScreenPointToRay(new Vector2(960, 540));
        ray.origin = Camera.main.transform.position;

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
                else if (hit.collider.gameObject.GetComponent<LightSwitch>())
                {
                    LightSwitch lightSwitch = hit.collider.gameObject.GetComponent<LightSwitch>();

                    lightSwitch.IsOn = !lightSwitch.IsOn;
                }
                else if (hit.collider.transform.Find("Directional Light"))
                {
                    GameObject light = hit.collider.transform.Find("Directional Light").gameObject;

                    light.SetActive(!light.activeSelf);
                }
                else if (hit.collider.gameObject.GetComponent<Keyboard>())
                {
                    Keyboard keyboard = hit.collider.gameObject.GetComponent<Keyboard>();

                    keyboard.m_displayMessage = !keyboard.m_displayMessage;
                }
                else if (hit.collider.gameObject.GetComponent<Radio>())
                {
                    Radio radio = hit.collider.gameObject.GetComponent<Radio>();

                    radio.TurnRadioOff();
                }
                else if (hit.collider.gameObject.GetComponent<Dolls>())
                {
                    //Debug.Log("Found the doll!");

                    Dolls doll = hit.collider.gameObject.GetComponent<Dolls>();

                    doll.SetTransform(m_handPoint, true);
                    m_isHoldingDoll = true;
                }
                else if (hit.collider.gameObject.GetComponent<DollCircle>())
                {
                    DollCircle dollCircle = hit.collider.gameObject.GetComponent<DollCircle>();

                    for(int i = 0; i < dollCircle.CirclePositions.Count; i++)
                    {
                        if (!dollCircle.PosFilled[i])
                        {
                            Dolls doll = this.GetComponentInChildren<Dolls>();

                            doll.SetTransform(dollCircle.CirclePositions[i], false);
                            dollCircle.PosFilled[i] = true;
                        }
                    }
                }
            } 
        }
    }

    public void ReduceSanity(int sanityDrop)
    {
        m_sanity -= sanityDrop;
    }
}
