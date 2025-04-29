using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private float m_alphaShift = 0.01f;
    private float m_currentAlpha = 0f;
    [SerializeField]
    private TMP_Text m_hintText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (m_playerBathroomMessage)
        //{
        //    if(m_currentAlpha < 255)
        //    {
        //        m_currentAlpha += m_alphaShift; 
        //    }
        //}
        //else
        //{
        //    if(m_currentAlpha >= 0)
        //    {
        //        m_currentAlpha -= m_alphaShift;
        //    }
        //}

        //m_hintText.GetComponent<TextMeshPro>().color = new Color(255, 0, 0, m_alphaShift);

        m_currentAlpha = Mathf.Clamp(m_currentAlpha - m_alphaShift, 0, 1);
        m_hintText.color = new Color(1, 0, 0, m_currentAlpha);
    }

    public void SetHint(string hintText)
    {
        if (hintText != m_hintText.text)
        {
            m_hintText.text = hintText;
            m_currentAlpha = 0;
        }
        else
        {
            m_currentAlpha = Mathf.Clamp(m_currentAlpha + m_alphaShift, 0, 1);
        }
        m_hintText.color = new Color(1, 0, 0, m_currentAlpha);
    }
}
