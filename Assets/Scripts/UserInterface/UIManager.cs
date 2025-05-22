using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
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
    GameObject m_objectiveScreen;

    //public static UIManager UI_Instance;

    private void Awake()
    {
        //if (UI_Instance == null)
        //    UI_Instance = this;
        //else if (UI_Instance != this)
        //    Destroy(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        //DontDestroyOnLoad(this);

        if (SceneManager.GetActiveScene().name == "GameScreen")
        {
            StartCoroutine(FadeAlpha(0));
            m_currentCursor.sprite = m_normalCursor;
            Cursor.lockState = CursorLockMode.Locked;
        } 
    }

    // Update is called once per frame
    void Update()
    {
        switch (SceneManager.GetActiveScene().name)
        {
            case "TitleScreen":
                UpdateTitleScreen();
                break;
            case "GameScreen":
                UpdateGameScreen();
                break;
        }
    }

    private void UpdateTitleScreen()
    {
        //m_currentCursor.sprite = m_normalCursor;
    }

    private void UpdateGameScreen()
    {
        if (m_currentCursor.isActiveAndEnabled)
            m_currentCursor.sprite = m_normalCursor;

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
        GameManager.GM_Instance.KillerCount = 0;
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

    public void ShowControls()
    {
        m_objectiveScreen.SetActive(true);
    }

    public void CloseControls()
    {
        m_objectiveScreen.SetActive(false);
    }
}
