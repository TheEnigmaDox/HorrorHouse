using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dolls : MonoBehaviour
{
    private bool m_pickedUp = false;

    private Transform m_transform;

    public bool IsPickedUp
    {
        get { return m_pickedUp; }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetTransform(Transform targetTransform, bool isPickedUp)
    {
        transform.SetParent(targetTransform);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
        m_pickedUp = isPickedUp;

        if(this.CompareTag("Keys"))
            GameManager.GM_Instance.HasKeys = true;
    }
}
