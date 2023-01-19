using UnityEngine;
using UnityEngine.UI;

public class ListDisplay : MonoBehaviour
{
    public GameObject listItemPrefab;
    public Transform content;
    public PrisonerNames prisonerNames;

    void Start()
    {
        foreach (string name in prisonerNames.currentNames)
        {
            GameObject item = Instantiate(listItemPrefab, content);
            //item.GetComponent<ListItem>().Setup(name, this);
        }
    }

    public void RemoveItem(string name)
    {
        //prisonerNames.RemoveName(name);
        RefreshList();
    }

    public void EditItem(string name)
    {
        // code to edit the name here
    }

    public void RefreshList()
    {
        foreach (Transform child in content)
        {
            Destroy(child.gameObject);
        }
        Start();
    }
}
