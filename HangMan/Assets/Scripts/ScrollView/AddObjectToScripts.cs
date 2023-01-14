using UnityEngine;

public class AddObjectToScripts : MonoBehaviour
{
    public GameObject itemTemplate;

    public GameObject content;

    // Start is called before the first frame update
    public void AddButton_Click()
    {
        var copy = Instantiate(itemTemplate);
        //copy.transform.parent = content.transform;// Parent of this object is the transform of this current object
        copy.transform.SetParent(content.transform);// Parent of this object is the transform of this current object tried SetParent method lets see if it works or not
    }
}
