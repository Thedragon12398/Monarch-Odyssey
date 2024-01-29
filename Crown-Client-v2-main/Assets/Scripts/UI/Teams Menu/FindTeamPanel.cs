using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindTeamPanel : MonoBehaviour
{
    public GameObject searchTeamsPanel;
    public GameObject listTeamsPanel;

    // Start is called before the first frame update

    private void Start()
    {
        searchTeamsPanel.SetActive(true);
        listTeamsPanel.SetActive(false);
    }
    public void Initialize()
    {
        searchTeamsPanel.SetActive(true);
        listTeamsPanel.SetActive(false);

        
    }

    public void ToggleTeamListingPanel ()
    {
        searchTeamsPanel.SetActive(false);
        listTeamsPanel.SetActive(true);
        
    }

    
}
