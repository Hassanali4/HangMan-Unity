using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddObjectToList : MonoBehaviour
{
    public GameObject itemTemplate;

    public GameObject content;
    int count = 0;
    float yvalue;

    // Start is called before the first frame update
    public void AddButton_Click()
    {
        
        if (count == 0)
        {
            //Transform tr = content.transform;
            //tr = new Vector3(tr.x - 50, tr.y, tr.z);

            //var copy = Instantiate(itemTemplate, GetComponent<RectTransform>().position = content.transform.position, itemTemplate.transform.rotation, content.transform);
            var copy = Instantiate(itemTemplate);
            //copy.GetComponent<RectTransform>().localScale = Vector2.one;
            //copy.GetComponent<RectTransform>.localScale = Vector3;
            copy.transform.SetParent(content.transform, false);
            copy.transform.localPosition = new Vector3(170, -42, 0);
             yvalue=copy.transform.localPosition.y;

        }else if(count > 0)
        {
            //Transform tr = content.transform;
            //tr = new Vector3(tr.x - 50, tr.y, tr.z);

            //var copy = Instantiate(itemTemplate, GetComponent<RectTransform>().position = content.transform.position, itemTemplate.transform.rotation, content.transform);
            var copy = Instantiate(itemTemplate);
            //copy.GetComponent<RectTransform>().localScale = Vector2.one;
            //copy.GetComponent<RectTransform>.localScale = Vector3;
            copy.transform.SetParent(content.transform, false);
            yvalue += ((float)-50.85);
            copy.transform.localPosition = new Vector3(170,yvalue , 0);
        }
        count++;
    }
}
