
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private float m_gameTimer = 600;

    [SerializeField]
    TMP_Text m_timerText;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);

        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
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

        if (Input.GetButtonDown("Jump"))
        {
            SceneManager.LoadScene(1);
        }
    }
}
