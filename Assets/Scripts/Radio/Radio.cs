using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radio : MonoBehaviour, IInteract
{
    private bool m_playerInteraction = false;

    public bool PlayerInteraction
    {
        get { return m_playerInteraction; }
    }

    private AudioSource m_radioAudio;

    [SerializeField]
    GameObject m_doll;

    [SerializeField]
    Transform m_spawnPos;

    private void Start()
    {
        m_radioAudio = GetComponent<AudioSource>();
    }

    //public void TurnRadioOff()
    //{
    //    if(m_radioIsOn)
    //        Instantiate(m_doll, m_spawnPos.position, m_spawnPos.rotation);

    //    m_radioIsOn = false;
    //    m_radioAudio.Stop();
    //}

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            m_radioAudio.Play();
        }  
    }

    void IInteract.Interact()
    {
        m_playerInteraction = true;

        if (m_playerInteraction)
            m_doll.SetActive(true);

        //Debug.Log($"{m_doll.name} : is Active");

        m_radioAudio.Stop();
    }
}
