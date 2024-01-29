using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ErrorUIManager : MonoBehaviour
{
    public static ErrorUIManager instance;
    public Text errorTextField;
    public Text errorButtonText;
    public GameObject errorPanel;

    private Dictionary<int, string> errorText = new Dictionary<int, string>
    {
        {0, "Connection to Server Failed" },
        {1, "Invalid Username or Password" },
        {2, "Username already exists" }
    };

    private Dictionary<int, string> buttonText = new Dictionary<int, string>
    {
        {0, "Retry" },
        {1, "Okay" },
        {2, "Okay" }
    };

    private void Awake()
    //initialize the UIManager singleton upon waking up
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Debug.Log("Instance alreasy exists; destroying object!");
            Destroy(this);
        }
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        errorPanel.SetActive(false);
    }

    public void initialize(int _errorType)
    {
        errorTextField.text = errorText[_errorType];
        errorButtonText.text = buttonText[_errorType];
        
        errorPanel.SetActive(true);
    }

    public void RetryButtonClicked()
    {
        errorPanel.SetActive(false);
        ClientSend.ClearCommandQueue();
        ClientSend.AddQueueCommand(new ConnectCommand());
    }

    public void QuitButtonClicked()
    {
        Application.Quit();
    }
}
