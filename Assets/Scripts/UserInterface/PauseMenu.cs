using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private bool m_isPaused = false;

    public bool IsPaused
    {
        get { return m_isPaused; }
    }

    [SerializeField]
    GameObject m_pauseMenu;

    [SerializeField]
    GameObject m_objectiveScreen;

    // Start is called before the first frame update
    void Start()
    {
        m_pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            ShowPauseScreen();
        }
    }

    private void ShowPauseScreen()
    {
        m_isPaused = true;

        m_pauseMenu.SetActive(true);
    }

    public void ResumeGame()
    {
        m_isPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        m_pauseMenu.SetActive(false);
    }

    public void ShowObjective()
    {
        m_objectiveScreen.SetActive(true);
    }

    public void CloseObjective()
    {
        m_objectiveScreen.SetActive(false);
    }

    public void ReturnToMenu()
    {
        m_isPaused = false;
        m_pauseMenu.SetActive(false);
        SceneManager.LoadScene("TitleScreen");
    }
}
