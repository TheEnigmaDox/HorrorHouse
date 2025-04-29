using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BabyTrigger : MonoBehaviour
{
    private int m_babyCount = 0;

    [SerializeField]
    GameObject m_baby;

    [SerializeField]
    Transform m_spawnPoint;
    
    public int BabyCount
    {
        get { return m_babyCount; }
        set { m_babyCount = value; }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && m_babyCount < 1)
        {
            var baby = Instantiate(m_baby, m_spawnPoint.position, Quaternion.identity);
            baby.transform.rotation = m_spawnPoint.rotation;

            m_babyCount++;

            Debug.Log("Player entered trigger");
        }
    }
}
