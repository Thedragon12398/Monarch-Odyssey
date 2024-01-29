using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeamMemberButton : MonoBehaviour
{
    // controls the individual button that shows up in the team member listing
    TeamMemberDetailClass teamMember;
    public Text nameLabel;
    public Text rankLabel;
    public TeamsMenuUIManager teamsUIManager;
    
    //intialize the button
    public void Initialize(TeamMemberDetailClass _member)
    {
        teamMember = _member;
        nameLabel.text = _member.firstName + " " + _member.lastName;
        rankLabel.text = _member.rank.ToString();
        teamsUIManager = GameManager.instance.ReturnTeamsMenuUIManager();
    }

    /// <summary>
    /// called when the button is pressed
    /// </summary>
    public void ButtonPressed()
    {
        //teamsUIManager.MemberButtonClicked(teamMember);
        teamsUIManager.teamDetailsPanel.IndividualMemberButtonClicked(teamMember);
    }
}
