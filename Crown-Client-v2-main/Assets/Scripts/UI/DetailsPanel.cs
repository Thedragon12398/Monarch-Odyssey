using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetailsPanel : MonoBehaviour
{
    public InputField firstNameField;
    public InputField lastNameField;
    public InputField tagLineField;


    // Start is called before the first frame update
    public void TogglePanel(bool _toggle)
    //displays or hides the Login Panel; sets its components to inactive or active
    {
        firstNameField.interactable = _toggle;
        lastNameField.interactable = _toggle;
        tagLineField.interactable = _toggle;
        gameObject.SetActive(_toggle);
    }



    public void SubmitDetailstoServer()
    {
        ClientSend.UpdateProfileDetails(firstNameField.text, lastNameField.text, tagLineField.text);
    }
    

    
}
