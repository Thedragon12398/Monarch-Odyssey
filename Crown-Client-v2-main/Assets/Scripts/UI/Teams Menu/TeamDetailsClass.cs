using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamDetailsClass 
{
    public string teamName { get; set; }
    public string teamOwner { get; set; }
    public int teamCreatedOn { get; set; }
    public int teamEnergy { get; set; }
    public string teamDescription { get; set; }
    public string teamFocus { get; set; }
    public List<TeamMemberDetailClass> teamMembers = new List<TeamMemberDetailClass>();
    public int teamLevel { get; set; }
    public int totalTeamMembers { get; set; }
}
