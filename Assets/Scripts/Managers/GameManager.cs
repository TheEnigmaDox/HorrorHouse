
using System.Collections;
using System.Reflection;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool m_hasKeys = false;

    private int m_killerCount = 0;

    private int m_puzzlesComplete = 0;

    private bool m_mouseControl;
    public bool MouseControl
    {
        get { return m_mouseControl; }
    }

    public bool HasKeys
    {
        get { return m_hasKeys; }
        set { m_hasKeys = value; }
    }

    private float m_gameTimer = 600;

    public static GameManager GM_Instance;

    [SerializeField]
    TMP_Text m_timerText;

    public int KillerCount
    {
        get { return m_killerCount; }
        set { m_killerCount = value; }
    }

    public int PuzzlesCompleted
    {
        get { return m_puzzlesComplete; }
        set { m_puzzlesComplete = value; }
    }

    private void Awake()
    {
        if (GM_Instance == null)
            GM_Instance = this;
        else if (GM_Instance != this)
            Destroy(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);

        Application.targetFrameRate = 60;
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
            case "GameOver":
                UpdateGameOver();
                break;
        }

        if (m_killerCount < 0)
            m_killerCount = 0;

        Debug.Log(m_hasKeys);

        //Debug.Log($"Current Killer Count : {m_killerCount}");
        //Debug.Log($"Puzzles Complete : {m_puzzlesComplete}");
    }

    private void UpdateTitleScreen()
    {
        m_mouseControl = false;

        Cursor.lockState = CursorLockMode.None;
    }

    private void UpdateGameScreen()
    {
        m_mouseControl = true;

        if (m_timerText == null)
            m_timerText = GameObject.FindGameObjectWithTag("Timer").GetComponent<TMP_Text>();

        m_gameTimer -= Time.deltaTime;

        int minutes = Mathf.FloorToInt(m_gameTimer / 60f);
        int seconds = Mathf.FloorToInt(m_gameTimer - minutes * 60f);

        string gameTime = string.Format("{0:0}:{1:00}", minutes, seconds);

        m_timerText.text = "Time Left : " + gameTime;

        if (m_gameTimer <= 0)
        {
            SceneManager.LoadScene(1);
        }

        if (Input.GetMouseButtonDown(0))
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else if (Input.GetKeyDown("escape"))
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }

    private void UpdateGameOver()
    {
        m_mouseControl = false;

        Cursor.lockState = CursorLockMode.None;
    }
}
