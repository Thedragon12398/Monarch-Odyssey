using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingInfoPanel : MonoBehaviour
{
    //public GameObject panel;
    public GameObject scrollRectContainer;
    public GameObject modelWindow;
    public GameObject infoBox;
    public Text title;


/* Displays building name on panel,
 * depending on the building that is clicked. */
    public void setTitle(string theTitle){
        title.text = theTitle;
    }
   


    public void RemoveButtons()
    {
        foreach (Transform _button in scrollRectContainer.transform)
        {
            Destroy(_button.gameObject);
        }
    }
}

