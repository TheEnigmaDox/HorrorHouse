using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    private float m_alphaShift = 0.01f;
    private float m_currentAlpha = 0f;
    [SerializeField]
    private TMP_Text m_hintText;

    public TMP_Text HintText
    {
        get { return m_hintText; }
        set { m_hintText = value; }
    } 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (SceneManager.GetActiveScene().name)
        {
            case "TitleScreen":
                //UpdateTitleScreen();
                break;
            case "GameScreen":
                UpdateGameScreen();
                break;
        }

        
    }

    //private void UpdateTitleScreen()
    //{

    //}

    private void UpdateGameScreen()
    {
        m_currentAlpha = Mathf.Clamp(m_currentAlpha - m_alphaShift, 0, 1);
        m_hintText.color = new Color(1, 0, 0, m_currentAlpha);
    }

    public void SetHint(string hintText)
    {
        Debug.Log($"Hint Text : {hintText}");

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

    public void PlayGame()
    {
        GameManager.GM_Instance.GameTimer = 600;
        SceneManager.LoadScene("GameScreen");
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("TitleScreen");
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("I QUIT!");
    }
}
