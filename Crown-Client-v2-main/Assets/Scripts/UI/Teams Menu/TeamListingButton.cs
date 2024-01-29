using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeamListingButton : MonoBehaviour
{
    // Start is called before the first frame update
    TeamDetailsClass _teamDetails;
    public Text _teamNameLabel;
    public Text _levelLabel;
    public Text _totalMembersLabel;
    public TeamsMenuUIManager _teamsUIManager;

    //intialize the button
    public void Initialize(TeamDetailsClass _team)
    {
        _teamDetails = _team;
        _teamNameLabel.text = _team.teamName;
        _levelLabel.text = _team.teamLevel.ToString();
        _teamsUIManager = GameManager.instance.ReturnTeamsMenuUIManager();
    }

    /// <summary>
    /// called when the button is pressed
    /// </summary>
    public void ButtonPressed()
    {
        _teamsUIManager.TeamButtonClicked(_teamDetails);
    }
}
