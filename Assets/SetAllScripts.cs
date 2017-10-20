using cakeslice;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetAllScripts : MonoBehaviour
{

    List<GameObject> allChildren;
    GameObject[] allObjects;
    // Use this for initialization
    void Start()
    {
        allChildren = new List<GameObject>();

        recursive(gameObject);
    }

    void recursive(GameObject gameObject)
    {
        if (gameObject != null)
        {
            foreach (Transform child in gameObject.GetComponentInChildren<Transform>())
            {
                Debug.Log("This object is: " + child.gameObject.name);

                if (child.gameObject != null && child.gameObject.GetComponent<MeshRenderer>() != null)
                {
                    Outline tempOutline = child.gameObject.AddComponent<Outline>();
                    child.gameObject.GetComponent<Outline>().color = 2;
                    child.gameObject.GetComponent<Outline>().enabled = false;


                    Toggle tempToggle = child.gameObject.AddComponent<Toggle>();
                    allChildren.Add(child.gameObject);
                    recursive(child.gameObject);
                }
                else
                {
                    recursive(child.gameObject);
                }

            }
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            allObjects = GameObject.FindGameObjectsWithTag("Item");
            recursive(allObjects[0]);
        }
    }

    public void ToggleAll()
    {

        allObjects = GameObject.FindGameObjectsWithTag("Item");

        foreach (GameObject item in allObjects)
        {
            item.GetComponent<SetAllScripts>().ToggleOutline(false);
        }

    }


    public void ToggleOutline(bool val)
    {

        foreach (GameObject child in allChildren)
        {
            child.GetComponent<Outline>().enabled = val;
        }
    }
}
