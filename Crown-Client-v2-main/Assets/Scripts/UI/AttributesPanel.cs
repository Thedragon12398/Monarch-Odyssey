using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttributesPanel : MonoBehaviour
{
    //players use this menu to configure their characters
    
    public Toggle luckToggle;
    public Toggle energyToggle;
    public Toggle gritToggle;
    public Toggle empathyToggle;
    public Toggle nerveToggle;
    public Toggle dexterityToggle;

    private Toggle[] toggles;
    private List<int> togglesClicked = new List<int>();

    private void Start()
    {
        toggles = new Toggle[6];
        toggles[0] = luckToggle;
        toggles[1] = energyToggle;
        toggles[2] = gritToggle;
        toggles[3] = empathyToggle;
        toggles[4] = nerveToggle;
        toggles[5] = dexterityToggle;

        foreach (Toggle _toggle in toggles)
        {
            _toggle.SetIsOnWithoutNotify(false);
        }
        
    }

    public void ToggleClicked(int _toggleNumber)
    {
        //if the player has checked the toggle, add it to the list of 3.
        if (toggles[_toggleNumber].isOn)
        {
            togglesClicked.Add(_toggleNumber);  
        } else
        //if the player has unchecked the toggle (only other option) remove the toggle from the list of 3
        {
            togglesClicked.Remove(_toggleNumber);
        }

        //check to see if checking toggle makes the list longer than 3
        //this means that more than 3 are selected, so one must be deselected
        if (togglesClicked.Count > 3)
        {
            //if so remove the first item in the list
            //turn the toggle off with this command so as to not trigger an event
            toggles[togglesClicked[0]].SetIsOnWithoutNotify(false);
            //remove item from list
            togglesClicked.RemoveAt(0);
        }
        
    }

    public void TogglePanel(bool _onOff)
    //displays or hides the Login Panel; sets its components to inactive or active
    {
        foreach (Toggle _toggle in toggles)
        {
            _toggle.interactable = _onOff;
        }
        gameObject.SetActive(_onOff);
    }
    public void SubmitDetailstoServer()
    {
        bool[] _toggleValues = new bool[6];
        for (int i = 0; i <=5; i++)
        {
            _toggleValues[i] = toggles[i].isOn;
        }
        ClientSend.UpdateAttributes(_toggleValues);
    }

}
