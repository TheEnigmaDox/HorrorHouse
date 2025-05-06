using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillBox : MonoBehaviour
{
    [SerializeField]
    KillerTrigger m_killerTrigger;

    private void OnTriggerEnter(Collider other)
    {
        if (other != null && other.CompareTag("Killer"))
        {
            Destroy(other.gameObject);
            GameManager.GM_Instance.KillerCount--;
        }
            
    }
}
