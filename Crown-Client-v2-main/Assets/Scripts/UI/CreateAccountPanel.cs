using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateAccountPanel : MonoBehaviour
{
    public InputField userNameField;
    public InputField passwordField;
    public GameObject userNamePanel;
    public Text errorText;

    // Start is called before the first frame update
    void Start()
    {
        errorText.gameObject.SetActive(false);
    }

    public void TogglePanel(bool _toggle)
    //displays or hides the Login Panel; sets its components to inactive or active
    {
        userNameField.interactable = _toggle;
        passwordField.interactable = _toggle;
        gameObject.SetActive(_toggle);
    }

    public void ToggleErrorText(bool _toggle)
    //displays or hides the error text box. Might eventually have this method
    //change the text
    {
        errorText.gameObject.SetActive(_toggle);
    }

    public void ResetInputFields()
    //resets the texts on both input fields
    {
        userNameField.text = "";
        passwordField.text = "";
    }
    public void LoginToServer()
    //called when player press the "connect" button
    {
        Client.instance.username = userNameField.text;
        Client.instance.password = passwordField.text;
        Client.instance.ConnectToServer();
    }
}
