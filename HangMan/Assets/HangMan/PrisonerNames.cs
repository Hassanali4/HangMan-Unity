using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class PrisonerNames : MonoBehaviour
{
    //the default name list
    public string[] wordsLocal = {"MATT","JOANNE","ROBERT","MARRY JANE","DENIS"}; // Commented it out to use the file system to get names from a file inside assets folder
    //the name list the user can manipulate
    public string[] currentNames;// = { "Hang" , "Man" };
    //the Name Text Container
    public Text nameListText;
    public InputField inputField;
    public Text ErrorText;

    //UpdateFeatureEnablerFunctions_Required_Field                                                               
    public InputField updateInputField;
    public Button[] buttons;

    private void Awake()
    {
        LoadNames();
        if (currentNames.Length == 0)
        {
            currentNames = wordsLocal;
        }
        UpdateNameList();
    }

    public void UpdateNameList()
    {
        nameListText.text = String.Join(",", currentNames);
    }

    public void Default()
    {
        currentNames = wordsLocal;
    }

    public void UpdateName()
    {
        bool found = false;
        for (int i = 0; i < currentNames.Length; i++)
        {
            if (currentNames[i] == updateInputField.text.ToString())
            {
                currentNames[i] = inputField.text;
                SaveNames();
                UpdateNameList();
                found = true;
            }
            
        } 
        if (!found)
        {
            ErrorText.text = "!! Cannot Change the Name because there is no Name in list as : " + updateInputField.text + " !!";
            Debug.Log("!! Cannot Change the Name because there is no Name in list as : " + updateInputField.text + " !!");
        }
    }

    public void AddName()
    {
        if (!NameExists(inputField.text))
        {
            currentNames = currentNames.Append(inputField.text).ToArray();
            SaveNames();
            UpdateNameList();
        }
        else
        {
            ErrorText.text = $"The name :<b>{inputField.text}<b> you are trying to Add to the list already exists. Try a new one !!!";
            Debug.Log($"The name :<b>{inputField.text}<b> you are trying to Add to the list already exists. Try a new one !!!");
        }
    }
    public void RemoveName()
    {
        if (NameExists(inputField.text))
        {
            currentNames = currentNames.Where(n => n != inputField.text).ToArray();
            SaveNames();
            UpdateNameList();
        }
        else
        {
            ErrorText.text = "!! Name does not exist in the list : " + inputField.text +"!!";
            Debug.Log("Name does not exist in the list : " + inputField.text);
        }
    }

    public void AddNames()
    {
        string tempstring = inputField.text;
        string[] newNames = tempstring.Split(',');
        if (newNames.Length != 0 && newNames.Length > 1)
        {
            bool check_If_OneName_is_Saved_At_Least = false;
            foreach (string name in newNames)
            {
                if (!NameExists(name))
                {
                    currentNames = currentNames.Concat(newNames).ToArray();
                    check_If_OneName_is_Saved_At_Least = true;
                }
            }
            if (check_If_OneName_is_Saved_At_Least)
            {
                UpdateNameList();
                SaveNames();
            }
        }else
        {
            Debug.Log("!!  he list cannot be empty you have to type at least 2 names in the list.  !!\n " +
                       "!! If you want to add a single name then use Add button to add a single name. !!");
        }
        

    }

    public bool NameExists(string name)
    {
        return currentNames.Contains(name);
    }

    public void SaveNames()
    {
        string namesString = String.Join(",", currentNames);
        PlayerPrefs.SetString("currentNames", namesString);
        PlayerPrefs.Save();
    }

    public void LoadNames()
    {
        if (PlayerPrefs.HasKey("currentNames"))
        {
            string namesString = PlayerPrefs.GetString("currentNames");
            currentNames = namesString.Split(',');
        }
    }

    public void NameUpdatingFeaturesEnabler(bool toggler)
    {
        string oldMainInputFieldMessage = inputField.placeholder.ToString();
        
        updateInputField.gameObject.SetActive(toggler);
        buttons[2].gameObject.SetActive(toggler);
        if (toggler)
        {
            inputField.placeholder.GetComponent<Text>().text = "Enter New Name";
            foreach (Button b in buttons)
            {
                if (b.name == "Edit_Or_Update_value_in_List_Button") 
                    b.gameObject.SetActive(true);
                else 
                    b.gameObject.SetActive(false);                    
            }
         //   inputField.SetTextWithoutNotify("Enter New Name");
        }
        else
        {
            inputField.placeholder.GetComponent<Text>().text = "Enter a Name...";
            foreach (Button b in buttons)
            {
                if (b.name == "Edit_Or_Update_value_in_List_Button")
                    b.gameObject.SetActive(false);
                else
                    b.gameObject.SetActive(true);
            }
            //inputField.SetTextWithoutNotify(oldMainInputFieldMessage);
        }
    }

}
