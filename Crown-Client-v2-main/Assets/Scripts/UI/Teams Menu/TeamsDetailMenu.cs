using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeamsDetailMenu : MonoBehaviour
{
    public Text teamNameText;
    public Text teamFocusText;
    public Text teamLevelText;
    public Text teamXPText;
    public Text teamDescriptionText;
    public Text currentMembersTeamEnergyText;
    public Text currentMembersTeamMembersText;
    public Text prospectiveMembersTeamEnergyText;
    public Text prospectiveMembersTeamMembersText;

    public GameObject _currentMemberButtonPanel;
    public GameObject _prospectiveMemberButtonPanel;

    private TeamDetailsClass teamDetails;
    private string teamName;

    public void PopulateTeamDetailsMenu(TeamDetailsClass _teamDetails, int _context)
    {
        teamDetails = _teamDetails;
        if (_context == 0)
        {
            _currentMemberButtonPanel.SetActive(true);
            _prospectiveMemberButtonPanel.SetActive(false);
        } else if (_context == 1)
        {
            _currentMemberButtonPanel.SetActive(false);
            _prospectiveMemberButtonPanel.SetActive(true);
        }
        
        teamName = _teamDetails.teamName;
        teamNameText.text = _teamDetails.teamName;
        
        teamFocusText.text = _teamDetails.teamFocus;
        teamLevelText.text = "Level: " + _teamDetails.teamLevel;
        teamDescriptionText.text = _teamDetails.teamDescription;
        currentMembersTeamEnergyText.text = "Energy: " + _teamDetails.teamEnergy;
        currentMembersTeamMembersText.text = "Members: " + _teamDetails.totalTeamMembers;

        prospectiveMembersTeamEnergyText = currentMembersTeamEnergyText;
        prospectiveMembersTeamMembersText = currentMembersTeamMembersText;
    }

    public void JoinLeavePressed(string _requestType)
    {
        ClientSend.AddQueueCommand(new JoinLeaveTeamCommand(teamDetails.teamName, _requestType));
    }
        

   
}
