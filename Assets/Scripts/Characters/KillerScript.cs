using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class KillerScript : MonoBehaviour
{
    private int m_sanityDrop = 10;

    private float m_alphaShift = 0.1f;
    private float m_activeTime;
    private float m_maxActiveTime = 4f;

    [SerializeField]
    private Transform m_player;

    [SerializeField]
    Material m_killerMat;

    [SerializeField]
    KillerTrigger m_trigger;

    NavMeshAgent m_navAgent;
    
    // Start is called before the first frame update
    void Start()
    {
        m_player = GameObject.FindGameObjectWithTag("Player").transform;
        m_navAgent = GetComponent<NavMeshAgent>();
        m_activeTime = m_maxActiveTime;
        transform.LookAt(m_player);
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(m_player);
        m_activeTime -= Time.deltaTime;

        if(m_alphaShift < 255)
        {
            m_alphaShift += 1f * Time.deltaTime;
        }

        m_killerMat.color = new Color(m_killerMat.color.r, m_killerMat.color.g, m_killerMat.color.b, m_alphaShift);

        if(m_navAgent.destination != m_player.transform.position)
            m_navAgent.destination = m_player.transform.position;

        if(m_activeTime <= 0)
        {
            GameManager.GM_Instance.KillerCount--;
            Destroy(this.gameObject);
        }

        // Debug.Log($" Alpha shift : {m_alphaShift}");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.GM_Instance.KillerCount--;
            other.GetComponent<Player>().ReduceSanity(m_sanityDrop);
            Destroy(this.gameObject);
        }
    }
}
