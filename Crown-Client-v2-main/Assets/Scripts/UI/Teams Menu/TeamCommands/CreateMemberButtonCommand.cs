using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateMemberButtonCommand : TeamCommand
{
    private TeamMemberDetailClass member;
    public CreateMemberButtonCommand(TeamMemberDetailClass _member)
    {
        member = _member;
        processing = false;
    }

    public override void Process()
    {
        //set processing to true so that the teammanager does not attempt to repeatidly process command in update loop
        processing = true;
        GameManager.instance.ReturnTeamsMenuUIManager().teamDetailsPanel.ProcessTeamMemberPacket(member);

        
    }
}
