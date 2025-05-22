using UnityEngine;

public class HintTrigger : MonoBehaviour
{
    private float m_duration = 2f;

    [SerializeField]
    private UIManager m_uiManager;

    [SerializeField]
    Radio m_radio;

    [SerializeField]
    Dolls doll;

    [TextArea]
    public string m_hint;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            m_uiManager.SetHint(m_hint, m_duration);
        }
    }
}
