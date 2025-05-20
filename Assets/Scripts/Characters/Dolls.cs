using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Dolls : MonoBehaviour, IInteract
{
    int index = 0;
    private bool m_pickedUp = false;

    [SerializeField]
    private Transform m_handPoint;

    [SerializeField]
    private List<Transform> m_storage = new List<Transform>();

    public bool IsPickedUp
    {
        get { return m_pickedUp; }
    }

    public void SetTransform(Transform targetTransform, bool isPickedUp)
    {
        index++;

        transform.SetParent(targetTransform);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
        
        m_pickedUp = isPickedUp;

        if(this.CompareTag("Keys"))
            GameManager.GM_Instance.HasKeys = true;

        Debug.Log($"Index : {index}");
    }

    void IInteract.Interact()
    {
        if (this.CompareTag("Doll"))
            SetTransform(m_storage[index].transform, true);
        else if (this.CompareTag("Keys"))
            SetTransform(m_handPoint, true);
    }
}
