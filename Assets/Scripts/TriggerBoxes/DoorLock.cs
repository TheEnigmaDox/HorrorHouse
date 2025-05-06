using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLock : MonoBehaviour
{
    [SerializeField]
    DoorController m_doorController;

    private void Update()
    {
        if (GameManager.GM_Instance.HasKeys)
            Destroy(this.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (GameManager.GM_Instance.HasKeys)
                m_doorController.DoorState = true;
            else
                m_doorController.DoorState = false;
        }
    }
}
