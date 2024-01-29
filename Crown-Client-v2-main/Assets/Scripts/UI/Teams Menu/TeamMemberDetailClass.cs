using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamMemberDetailClass 
{
    /// <summary>
    /// identical to class onserver. these valuse are set based on packet sent from server.
    /// </summary>
    public string userName { get; set; }
    public string firstName { get; set; }
    public string lastName { get; set; }
    public string tagLine { get; set; }
    public int joinDate { get; set; }
    public int level { get; set; }
    public int xp { get; set; }
    public int rank { get; set; }
    public int luck { get; set; }
    public int energy { get; set; }
    public int grit { get; set; }
    public int empathy { get; set; }
    public int nerve { get; set; }
    public int dexterity { get; set; }

   
}
