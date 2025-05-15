using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Rendering;

public class ComputerScreen : MonoBehaviour
{
    public bool m_isOn = false;

    float m_typeTime = 0.1f;
    int currLength = 0;

    [SerializeField]
    TMP_Text m_screenText;
    
    [SerializeField]
    string m_message = "She waits where the shadows stretch long, her hollow eyes watching, her tiny hands reaching. " +
        "Forgotten but never alone, she longs for home. Follow the echoes of laughter long lost, " +
        "where dust dances and silence hums. Return her, before she weeps... before she wakes.";

    AudioSource m_audioSource;

    // Start is called before the first frame update
    void Start()
    {
        m_audioSource = GetComponent<AudioSource>();
        m_screenText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (m_isOn && currLength < m_message.Length - 1)
        {
            if(m_typeTime <= 0)
            {
                currLength++;
                m_screenText.text = m_message.Substring(0, currLength);
                if (m_message.Substring(currLength, 1) == " ")
                {
                    m_audioSource.Play();
                    m_typeTime = Random.Range(0.1f, 0.8f);
                }
                else
                    m_typeTime = 0.05f;
            }
            else
            {
                m_typeTime -= Time.deltaTime;
            }
        }
        else
        {
            m_audioSource.Play();
            m_screenText.text = "";
        }
    }
}
