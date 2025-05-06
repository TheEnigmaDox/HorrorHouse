using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DollCircle : MonoBehaviour
{
    private List<bool> m_posFilled = new List<bool>();

    [SerializeField]
    List<Transform> m_circlePositions = new List<Transform>(); 

    public List<Transform> CirclePositions
    {
        get { return m_circlePositions; }
    }

    public List<bool> PosFilled
    {
        get { return m_posFilled; }
        set { m_posFilled = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            m_posFilled.Add(false);
            m_posFilled.Add(false);
            m_posFilled.Add(false);
            m_posFilled.Add(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
