using System.Collections.Generic;
using UnityEngine;

public class Dolls : MonoBehaviour, IInteract
{
    static int index = 0;
    private bool m_pickedUp = false;

    [SerializeField]
    private Transform m_handPoint;

    [SerializeField]
    private List<Transform> m_storage = new List<Transform>();

    private Animator m_animator;

    private DollCircle m_dollCircle;

    public bool IsPickedUp
    {
        get { return m_pickedUp; }
    }

    private void Start()
    {
        m_animator = GetComponent<Animator>();
        m_dollCircle = FindObjectOfType<DollCircle>();
    }

    public void SetTransform(Transform targetTransform, bool isPickedUp)
    {
        transform.SetParent(targetTransform);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
        
        m_pickedUp = isPickedUp;

        if(this.CompareTag("Keys"))
            GameManager.GM_Instance.HasKeys = true;

        if (m_animator != null)
            m_animator.SetBool("IsPickedUp", true);

        Debug.Log($"Index : {index}");
    }

    void IInteract.Interact()
    {
        if (this.CompareTag("Doll"))
        {
            if (index >= m_storage.Count)
            {
                index = 0;
                SetTransform(m_storage[index].transform, true);
                index++;
            }
            else
            {
                SetTransform(m_storage[index].transform, true);
                index++;
            }
        }
        else if (this.CompareTag("Keys"))
        {
            SetTransform(m_handPoint, true);
            GameManager.GM_Instance.HasKeys = true;
        }   
    }
}
