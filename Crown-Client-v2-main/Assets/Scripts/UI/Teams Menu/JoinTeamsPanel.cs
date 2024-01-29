using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoinTeamsPanel : MonoBehaviour
{
    // Start is called before the first frame update
    public void RequestTeams()
    {
        //ClientSend.AddQueueCommand(new RequestTeamsCommand());
    }

    public void CloseClicked()
    {
        //GameManager.instance.ReturnTeamsMenuUIManager().PopulateTeamDetailsPanel(null);
    }
}
