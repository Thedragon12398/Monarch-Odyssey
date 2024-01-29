using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MemberDetailsPanel : MonoBehaviour
{
    public Text memberName;
    public Text memberTagline;
    public Text memberRank;
    public Text memberLevel;
    public Text memberXP;
    public Text memberLuck;
    public Text memberEnergy;
    public Text memberGrit;
    public Text memberEmpathy;
    public Text memberNerve;
    public Text memberDexterity;

    private TeamMemberDetailClass member;

    public void Initialize(TeamMemberDetailClass _member)
    {
        member = _member;
        memberName.text = member.firstName + " " + member.lastName;
        memberTagline.text = member.tagLine;
        memberRank.text = "Rank: " + member.rank;
        memberLevel.text = "Level: " + member.level;
        memberXP.text = "Energy: " + member.xp;
        memberLuck.text = member.luck.ToString();
        memberEnergy.text = member.energy.ToString();
        memberGrit.text = member.grit.ToString();
        memberEmpathy.text = member.empathy.ToString();
        memberNerve.text = member.nerve.ToString();
        memberDexterity.text = member.dexterity.ToString();


    }

    public void CloseClicked()
    {
        //GameManager.instance.ReturnTeamsMenuUIManager().TeamMembersClicked(null);
        GameManager.instance.ReturnTeamsMenuUIManager().teamDetailsPanel.ToggleTeamDetailsPanel();
    }


}
