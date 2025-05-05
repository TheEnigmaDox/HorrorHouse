using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dolls : MonoBehaviour
{
    private bool m_pickedUp = false;

    private Transform m_transform;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (m_pickedUp)
        {
            transform.SetPositionAndRotation(m_transform.position, m_transform.localRotation);
        }
    }

    public void SetTransform(Transform targetTransform, bool isPickedUp)
    {
        m_transform = targetTransform;
        //transform.SetParent(targetTransform);
        m_pickedUp = isPickedUp;
    }
}
