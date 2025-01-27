using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    GameObject m_playerView;

    private void Start()
    {
        m_playerView = GameObject.FindGameObjectWithTag("PlayerViewpoint");
    }

    private void LateUpdate()
    {
        this.transform.position = m_playerView.transform.position;
        this.transform.rotation = m_playerView.transform.rotation;
    }
}
