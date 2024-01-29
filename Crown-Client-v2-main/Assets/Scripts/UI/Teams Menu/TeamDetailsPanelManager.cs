using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamDetailsPanelManager : MonoBehaviour
{
    //various UI Panels
    public TeamMembersPanel _membersListPanel; //scrollview that lists the team members
    public TeamsDetailMenu _teamDetailsPanel;  //panel that displays overview information about a team
    public MemberDetailsPanel _teamMemberDetailsPanel; //panel that displays overview information about a team member
    



    //data class for current team.
    private TeamDetailsClass _currentTeam;
    //sorted dictionary to hold team members
    SortedDictionary<string, TeamMemberDetailClass> _teamMembers = new SortedDictionary<string, TeamMemberDetailClass>();
    //prefab for team member button
    public GameObject teamMemberButtonPrefab;
    //game object for the scroll view that contains and lists the member buttons
    public GameObject memberScrollRectContainer;

    //initialize the team details panel when called
    public void Initialize(TeamDetailsClass _team, int _context)
    {
       
        //clear all old data and buttons, if it exists
        GameManager.instance.ReturnTeamsMenuUIManager().DeleteOldButtons(memberScrollRectContainer.transform);
        _teamMembers.Clear();
        //populate the Team Details Panel based on Team Details Class.
        _currentTeam = _team;
        _teamDetailsPanel.PopulateTeamDetailsMenu(_team, _context);

        ToggleTeamDetailsPanel();
    }

    //show the UI panel that provides and overview of the team
    public void ToggleTeamDetailsPanel()
    {
        _membersListPanel.gameObject.SetActive(false);
        _teamDetailsPanel.gameObject.SetActive(true);
        _teamMemberDetailsPanel.gameObject.SetActive(false);
    }

    // Show the UI scroll view that lists the teams members
    public void ToggleMembersListPanel()
    {
        
        _membersListPanel.gameObject.SetActive(true);
        _teamDetailsPanel.gameObject.SetActive(false);
        _teamMemberDetailsPanel.gameObject.SetActive(false);
    }

    //show the UI panel that lists detaisl about individual member
    public void ToggleIndividualMemberPanel()
    {
        _membersListPanel.gameObject.SetActive(false);
        _teamDetailsPanel.gameObject.SetActive(false);
        _teamMemberDetailsPanel.gameObject.SetActive(true);
    }

    //called when user clicks the "Members Button" on the Team Details UI
    public void TeamMembersButtonPressed()
    {
        //show the UI panel that lists team members
        ToggleMembersListPanel();
        //if there are no members in the dictionary, then request this data from server. If there are members in the dictionary
        //this means data was already downloaded. TODO: add refresh functionality so that users can re-download data from server
        if (_teamMembers.Count == 0)
        {
            _membersListPanel.RequestTeamMembers(_currentTeam.teamName);
        }
    } 

    //called when player clicks the button corresponding to an individual user in the UI members listing panel
    public void IndividualMemberButtonClicked(TeamMemberDetailClass _member)
    {
        _teamMemberDetailsPanel.Initialize(_member);
        ToggleIndividualMemberPanel();
    }

    //generate a team member button for each team member data packet received from server. By default, sort these alphabetically
    //TO DO implement different tabs / ways to sort. Also figure out what to do if member has same first and last name. I.E. if same person has 2 accounts
    //maybe thing to to in that case is to make master dictionary sorted by user name, since those are unique, then derive from there.
    public void ProcessTeamMemberPacket (TeamMemberDetailClass _member)
    {
        string _wholeName = _member.firstName + " " + _member.lastName;
        _teamMembers.TryAdd(_wholeName, _member);
        CreateTeamMemberButton(_member);
    }
    private void CreateTeamMemberButton(TeamMemberDetailClass _member)
    {
        //Debug.Log("CREATE MEMBER BUTTON CALLED FOR " + _member.firstName);
        
        GameObject _memberButton = Instantiate(teamMemberButtonPrefab);
        _memberButton.transform.SetParent(memberScrollRectContainer.transform);
        TeamMemberButton _buttonScript = _memberButton.GetComponent<TeamMemberButton>();
        _buttonScript.Initialize(_member);
        
    }

        
        
        
}
