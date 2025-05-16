using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class HintTrigger : MonoBehaviour
{
    [SerializeField]
    private UIManager m_uiManager;

    [SerializeField]
    Radio m_radio;

    [SerializeField]
    Dolls doll;

    private void SetHallHint()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            switch (this.name)
            {
                case "BathroomTrigger":
                    if (!m_radio.PlayerInteraction)
                        m_uiManager.SetHint("She was never a fan of classical music.");
                    else
                        m_uiManager.SetHint("Alas she sank into the silence...");
                    break;
                case "BedroomTrigger":
                    m_uiManager.SetHint("Now in the main bedroom.");
                    break;
                case "HallTrigger":
                    m_uiManager.SetHint("Welcome to where it all ended...");
                    break;
                case "HallCupboardTrigger":
                    if (!doll.IsPickedUp)
                        m_uiManager.SetHint("This became her most use hiding place...");
                    else
                        m_uiManager.SetHint("Return her to her happy place...");
                    break;
                case "KitchenTrigger":
                    m_uiManager.SetHint("The kitchen was her favourite room in the house...");
                    break;
            }
        }
    }
}
