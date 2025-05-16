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
            this.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            m_doorController.IsLocked = true;
        }
    }
}
