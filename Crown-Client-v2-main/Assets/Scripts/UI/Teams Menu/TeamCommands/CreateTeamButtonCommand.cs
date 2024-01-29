using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateTeamButtonCommand : TeamCommand
{
    private TeamDetailsClass team;

    public CreateTeamButtonCommand(TeamDetailsClass _team)
    {
        team = _team;
        processing = false;
    }

    public override void Process()
    {
        //set processing to true so that the teammanager does not attempt to repeatidly process command in update loop
        processing = true;
        GameManager.instance.ReturnTeamsMenuUIManager().CreateTeamButton(team);


    }
}
