using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BathroomTrigger : MonoBehaviour
{
    [SerializeField]
    private UIManager m_uiManager;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            switch (this.name)
            {
                case "BathroomTrigger":
                    m_uiManager.SetHint("She was never a fan of classical music.");
                    break;
                case "BedroomTrigger":
                    m_uiManager.SetHint("Now in the main bedroom.");
                    break;
            }

            //m_uiManager.SetHint("She was never a fan of classical music.");
        }
    }
}
