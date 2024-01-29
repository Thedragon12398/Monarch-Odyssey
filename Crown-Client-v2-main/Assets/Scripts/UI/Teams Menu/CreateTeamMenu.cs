using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateTeamMenu : MonoBehaviour
{
    public InputField teamNameField;
    public Dropdown teamFocusDropdown;
    public InputField teamDescriptionField;
    public InputField keywordOneField;
    public InputField keywordTwoField;
    
    
    

    // Start is called before the first frame update

    
    //called when create team button pressed
    public void SendCreateCommand()
    {
        if (!VerifyInput())
        {
            return;
        }
        
        int index = teamFocusDropdown.value;
        string teamFocusText = teamFocusDropdown.options[index].text;

        CreateTeamCommand _createTeamCommand = new CreateTeamCommand(teamNameField.text, teamFocusText, teamDescriptionField.text, keywordOneField.text, keywordTwoField.text);
        ClientSend.AddQueueCommand(_createTeamCommand);
    }

    private bool VerifyInput()
    {
        bool _inputVerified = true;
        Text _placeholderText;
        if (teamNameField.text == "" || teamNameField.text == null)
        {
            _placeholderText = teamNameField.placeholder.GetComponent<Text>();
            _placeholderText.color = Color.red;
            _placeholderText.text = "Team Name Missing!";
            _inputVerified = false;
        }

        if (teamDescriptionField.text == "" || teamDescriptionField.text == null)
        {
            _placeholderText = teamDescriptionField.placeholder.GetComponent<Text>();
            _placeholderText.color = Color.red;
            _placeholderText.text = "Team Description Missing!";
            _inputVerified = false;
        }

        if (keywordOneField.text == "" || keywordOneField.text == null)
        {
            _placeholderText = keywordOneField.placeholder.GetComponent<Text>();
            _placeholderText.color = Color.red;
            _placeholderText.text = "Missing!";
            _inputVerified = false;
        }

        if (keywordTwoField.text == "" || keywordTwoField.text == null)
        {
            _placeholderText = keywordTwoField.placeholder.GetComponent<Text>();
            _placeholderText.color = Color.red;
            _placeholderText.text = "Missing!";
            _inputVerified = false;
        }

        return _inputVerified;
    }

    
}
