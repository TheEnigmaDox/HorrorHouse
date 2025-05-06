using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radio : MonoBehaviour
{
    private bool m_radioIsOn = true;

    private AudioSource m_radioAudio;

    [SerializeField]
    GameObject m_doll;

    [SerializeField]
    Transform m_spawnPos;

    public bool IsRadioOn
    {
        get { return m_radioIsOn; }
        set { m_radioIsOn = value; }
    }

    private void Start()
    {
        m_radioAudio = GetComponent<AudioSource>();
        m_radioAudio.Play();
    }

    public void TurnRadioOff()
    {
        if(m_radioIsOn)
            Instantiate(m_doll, m_spawnPos.position, m_spawnPos.rotation);

        m_radioIsOn = false;
        m_radioAudio.Stop();
    }
}
