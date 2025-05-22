using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Player : Character
{
    private int m_posIndex = 0;

    public int PosIndex
    {
        get { return m_posIndex; } 
        set { m_posIndex = value; }
    }

    private bool m_mouseControl = false;

    private int m_sanity = 100;

    public int Sanity
    {
        get { return m_sanity; }
        set { m_sanity = value; }
    }

    [SerializeField]
    private Transform m_viewPoint;

    [SerializeField]
    GameObject debugSphere;

    [SerializeField]
    private Slider m_sanityBar;

    [SerializeField]
    LayerMask m_interactLayer;

    public bool MouseControl
    {
        get { return m_mouseControl; }
        set { m_mouseControl = value; }
    }

    private List<GameObject> m_dollsCollected = new List<GameObject>();

    public List<GameObject> DollsCollected
    {
        get { return m_dollsCollected; }
        set { m_dollsCollected = value; }
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
            if (Physics.Raycast(ray, out RaycastHit hit, 2, m_interactLayer))
            {
                //debugSphere.transform.position = hit.point;

                //Debug.Log("We are looking at : " + hit.collider.gameObject.name);

                IInteract interactable = hit.collider.GetComponent<IInteract>();

                if (interactable != null)
                {
                    interactable.Interact();
                }

                DollCircle dollCircle = hit.collider.gameObject.GetComponent<DollCircle>();

                if (dollCircle != null)
                {
                    for (int i = 0; i < dollCircle.CirclePositions.Count; i++)
                    {
                        if (m_posIndex < dollCircle.CirclePositions.Count && dollCircle.CirclePositions[m_posIndex] != null)
                        {
                            Dolls doll = Camera.main.GetComponentInChildren<Dolls>();

                            doll.SetTransform(dollCircle.CirclePositions[m_posIndex], false);
                            if (m_posIndex < dollCircle.CirclePositions.Count)
                                m_posIndex++;
                            dollCircle.DollsPlaced++;
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
