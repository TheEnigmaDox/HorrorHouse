using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private bool m_isPaused = false;

    public bool IsPaused
    {
        get { return m_isPaused; }
    }

    private float m_fadeDuration = 2f;

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

    [SerializeField]
    CanvasGroup m_hintUI;

    [SerializeField]
    CanvasGroup m_pauseMenu;
    [SerializeField]
    CanvasGroup m_objectiveScreen;

    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "GameScene")
        {
            StartCoroutine(FadeAlpha(0));
            m_pauseMenu.gameObject.SetActive(false);
            m_currentCursor.sprite = m_normalCursor;
            m_objectiveScreen.gameObject.SetActive(false);
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
                m_currentCursor.sprite = m_hintCursor;

            //Debug.Log("We are interacting");
        }
        else
        {
            m_currentCursor.sprite = m_normalCursor;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
            ShowPauseMenu();
    }

    private void ShowPauseMenu()
    {
        m_isPaused = true;

        //GameManager.GM_Instance.GameTimer = GameManager.GM_Instance.GameTimer;

        m_pauseMenu.gameObject.SetActive(true);
    }

    public void ResumeGame()
    {
        m_isPaused = false;
        m_pauseMenu.gameObject.SetActive(false);
    }

    public void ShowObjective()
    {
        m_objectiveScreen.gameObject.SetActive(true);
    }

    public void HideObjective()
    {
        m_objectiveScreen.gameObject.SetActive(false);
    }

    public void ExitToMenu()
    {
        GameManager.GM_Instance.GameTimer = 600;
        m_isPaused = false;
        SceneManager.LoadScene(0);
    }

    public void SetHint(string hintText, float duration)
    {
        //Debug.Log($"Hint Text : {hintText}");

        StopAllCoroutines();
        m_hintText.text = hintText;
        StartCoroutine(FadeHint());
    }

    private IEnumerator FadeHint()
    {
        yield return StartCoroutine(FadeAlpha(1f));
        yield return new WaitForSeconds(m_fadeDuration);
        yield return StartCoroutine(FadeAlpha(0f));
    }

    private IEnumerator FadeAlpha(float targetAlpha)
    {
        float startAlpha = m_hintUI.alpha;
        float time = 0;

        while (time < m_fadeDuration)
        {
            time += Time.deltaTime;
            m_hintUI.alpha = Mathf.Lerp(startAlpha, targetAlpha, time / m_fadeDuration);
            yield return null;
        }

        m_hintUI.alpha = targetAlpha;
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
