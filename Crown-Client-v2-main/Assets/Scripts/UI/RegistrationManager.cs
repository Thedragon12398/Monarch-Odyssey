using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//this script controls the apps registration scene

public class RegistrationManager : MonoBehaviour
{
    public static RegistrationManager instance;

    public CreateAccountPanel createAccountPanel;
    public DetailsPanel detailsPanel;
    public AttributesPanel attributesPanel;

    private void Awake()
    //initialize the Registration Manager singleton upon waking up
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Debug.Log("Instance already exists; destroying object!");
            Destroy(this);
        }
    }

    private void Start()
    {
        AdvanceAccountCreation(0);
    }
    public void AdvanceAccountCreation (int _step)
    //called from server to step players through registration process
    {
        switch (_step)
        {
            case 0:
                createAccountPanel.TogglePanel(true);
                detailsPanel.TogglePanel(false);
                attributesPanel.TogglePanel(false);
                break;
            case 1:
                createAccountPanel.TogglePanel(false);
                detailsPanel.TogglePanel(true);
                attributesPanel.TogglePanel(false);
                break;
            case 2:
                createAccountPanel.TogglePanel(false);
                detailsPanel.TogglePanel(false);
                attributesPanel.TogglePanel(true);
                break;
            case 3:
                Debug.Log("Registration complete! Send into Game");
                break;
            default:
                break;
        }
    }
}
