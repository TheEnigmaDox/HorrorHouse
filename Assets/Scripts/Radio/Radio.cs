using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radio : MonoBehaviour
{
    private bool m_radioIsOn = true;

    private AudioSource m_radioAudio;

    public bool IsRadioOn
    {
        get { return m_radioIsOn; }
    }

    private void Start()
    {
        m_radioAudio = GetComponent<AudioSource>();
        m_radioAudio.Play();
    }

    public void TurnRadioOff()
    {
        m_radioIsOn = false;
        GameManager.GM_Instance.PuzzlesCompleted++;
        m_radioAudio.Stop();
    }
}
