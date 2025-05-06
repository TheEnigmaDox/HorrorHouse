using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DollCircle : MonoBehaviour
{
    private int m_dollsPlaced = 0;

    private List<bool> m_posFilled = new List<bool>();

    [SerializeField]
    List<Transform> m_circlePositions = new List<Transform>();

    [SerializeField]
    GameObject m_doorKeys;
    

    public List<Transform> CirclePositions
    {
        get { return m_circlePositions; }
    }

    public int DollsPlaced
    {
        get { return m_dollsPlaced; }
        set { m_dollsPlaced = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log($"{m_dollsPlaced}");

        if(m_dollsPlaced == 4)
        {
            GameObject keys = Instantiate(m_doorKeys, this.transform.parent.position, Quaternion.identity);
            keys.transform.parent = this.transform;
            keys.transform.localPosition = new Vector3(4.5f, 2, 4.5f);
            keys.transform.localRotation = Quaternion.identity;
            m_dollsPlaced++;

        }
    }
}
