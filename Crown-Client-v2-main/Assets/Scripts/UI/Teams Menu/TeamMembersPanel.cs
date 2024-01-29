using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamMembersPanel : MonoBehaviour
{
    // Start is called before the first frame update
    public void RequestTeamMembers(string _teamName)
    {
        ClientSend.AddQueueCommand(new RequestTeamMembersCommand(_teamName));
    }

    public void CloseClicked()
    {
        GameManager.instance.ReturnTeamsMenuUIManager().teamDetailsPanel.ToggleTeamDetailsPanel();
    }
}
