using System.Linq;
using UnityEngine;

public class PrisonerNames : MonoBehaviour
{
    private string[] wordsLocal = { " MATT ", " JOANNE ", " ROBERT ", " MARRY JANE ", " DENIS " }; // Commented it out to use the file system to get names from a file inside assets folder
    private string[] currentNames;

    public string[] CurrentNames { get => currentNames; private set => currentNames = value; }

    // Start is called before the first frame update
    void Start()
    {
        if (CurrentNames.Length == 0)
        {
            CurrentNames = wordsLocal;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Default()
    {
        CurrentNames = wordsLocal;
    }

    public void EditName(string newName)
    {
        int index = 0;

        for (int i = 0; i < CurrentNames.Length; i++)
        {
            if (CurrentNames[i] == newName)
            {
                index = i;
            }
            else
            {
                Debug.Log("Cannot Change the Name because the is no Name in list as : " + newName);
                return;
            }
        }

        CurrentNames[index] = newName;
    }

    public void AddName(string newName)
    {
        CurrentNames = CurrentNames.Append(newName).ToArray();
    }


}
