using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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

    [SerializeField]
    private LayerMask m_interactLayer;

    [SerializeField]
    private Image m_currentCursor;

    [SerializeField]
    private Sprite m_normalCursor;

    [SerializeField]
    private Sprite m_hintCursor;

    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "GameScene")
        {
            m_currentCursor.sprite = m_normalCursor;
        } 
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

    private void UpdateGameScreen()
    {
        Ray ray = Camera.main.ScreenPointToRay(new Vector2(960, 540));
        ray.origin = Camera.main.transform.position;

        if (Physics.Raycast(ray, out RaycastHit hit, 2, m_interactLayer))
        {
            if (hit.collider.gameObject.layer == 7)
                Debug.Log("We are interacting");

            m_currentCursor.sprite = m_hintCursor;
        }
        else
        {
            m_currentCursor.sprite = m_normalCursor;
        }
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
            m_hintText.color = new Color(1, 0, 0, m_currentAlpha);
        }
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
