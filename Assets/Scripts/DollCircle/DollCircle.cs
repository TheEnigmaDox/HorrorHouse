using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DollCircle : MonoBehaviour
{
    private int m_dollsPlaced = 0;

    [SerializeField]
    List<Transform> m_circlePositions = new List<Transform>();

    [SerializeField]
    GameObject m_doorKeys;
    [SerializeField]
    GameObject m_sceneChanger;

    public List<Transform> CirclePositions
    {
        get { return m_circlePositions; }
    }

    public int DollsPlaced
    {
        get { return m_dollsPlaced; }
        set { m_dollsPlaced = value; }
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log($"Dolls placed : {m_dollsPlaced}");

        if(m_dollsPlaced == 4)
        {
            m_doorKeys.SetActive(true);
            m_doorKeys.transform.position = new Vector3(4.5f, 3, 5);
            m_sceneChanger.SetActive(true);
        }
    }
}
