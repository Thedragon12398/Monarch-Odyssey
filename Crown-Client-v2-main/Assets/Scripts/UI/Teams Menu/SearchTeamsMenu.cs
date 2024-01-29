using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class SearchTeamsMenu : MonoBehaviour
{
    //this script aggregates input from the team search menu into a network command, which it then transmits to the server.

    public InputField teamNameField;
    public Dropdown teamFocusDropdown;
    public GameObject dropdownPlaceholder;
    public GameObject dropdownLabel;
    public InputField keywordOneField;
    public InputField keywordTwoField;
    public InputField keywordThreeField;

    private string teamFocusText;

    private void Start()
    {
        //set the dropdown placeholder image to visible and hide the dropdown label
        dropdownLabel.SetActive(false);
        dropdownPlaceholder.SetActive(true);
        //set the dropdown's start option to the final option, "Clear Selection"; If users select any other option then the ReplaceDropDownPlaceholder method
        //displays the dropdown label rather than the placeholder.
        teamFocusDropdown.SetValueWithoutNotify(teamFocusDropdown.options.Count - 1);
        teamFocusText = "";
    }

    public void SendSearchCommand()
    {
        
       

        SearchTeamsCommand _searchTeamsCommand = new SearchTeamsCommand(teamNameField.text, teamFocusText, keywordOneField.text, keywordTwoField.text, keywordThreeField.text);
        ClientSend.AddQueueCommand(_searchTeamsCommand);
        
    }

    //toggle the placeholder label in the dropdown menu off when an option is selected, or back on when the "clear selection" option is selected
    public void ReplaceDropdownPlaceholder()
    {
        //check to see if the option selected is not the final clear selection option, if not, then display the dropdown lable with the option the user selected
        //and set the string value to be sent to the server.
        if (teamFocusDropdown.value != teamFocusDropdown.options.Count -1)
        {
            int index = teamFocusDropdown.value;
            dropdownLabel.SetActive(true);
            dropdownPlaceholder.SetActive(false);
            teamFocusText = teamFocusDropdown.options[index].text;

        } else {
            //"Clear Selection," which is last in the list, has been selected, so toggle the placeholder label and set the value of the text string to empty
            dropdownLabel.SetActive(false);
            dropdownPlaceholder.SetActive(true);
            teamFocusText = "";
        }
        
        
    }

    private void ParseInput()
    {

    }

}
