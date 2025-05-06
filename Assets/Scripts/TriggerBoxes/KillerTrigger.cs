using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class KillerTrigger : MonoBehaviour
{
    [SerializeField]
    GameObject m_killer;

    [SerializeField]
    Transform m_spawnPoint;
    

    private void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && GameManager.GM_Instance.KillerCount < 1)
        {
            var killer = Instantiate(m_killer, m_spawnPoint.position, Quaternion.identity);
            killer.transform.rotation = m_spawnPoint.rotation;

            GameManager.GM_Instance.KillerCount++;
        }
    }
}
