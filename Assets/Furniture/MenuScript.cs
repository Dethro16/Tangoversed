using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{

    public GameObject Chair, Coffee, Couch, PotA, PotB, Rack, Rug, Table;
    // Use this for initialization
    Dictionary<string, GameObject> ObjectList = new Dictionary<string, GameObject>();

    string currentItemId = "";
    public GameObject currentItem = null;
    public GameObject canvas = null;
    public List<GameObject> uiList = new List<GameObject>();

    GameObject[] allChildren;

    bool uiShow = true;
    void Start()
    {
        ObjectList.Add("Chair", Chair);
        ObjectList.Add("Coffee", Coffee);
        ObjectList.Add("Couch", Couch);
        ObjectList.Add("PotA", PotA);
        ObjectList.Add("PotB", PotB);
        ObjectList.Add("Rack", Rack);
        ObjectList.Add("Rug", Rug);
        ObjectList.Add("Table", Table);
        allChildren = new GameObject[canvas.transform.childCount];
        //= GetComponentsInChildren<Transform>();



        for (int i = 0; i < canvas.transform.childCount; i++)
        {
            allChildren[i] = canvas.transform.GetChild(i).gameObject;
        }

        Debug.Log("Hello");

    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // loads current scene
    }

    public void ToggleUI()
    {
        uiShow = !uiShow;

        foreach (GameObject button in allChildren)
        {

            if (!uiShow && button.name != "HideUI")
            {
                button.SetActive(uiShow);
                button.transform.localScale = new Vector3(0, 0, 0);
            }
            if (uiShow && button.name != "HideUI")
            {
                button.SetActive(uiShow);
                if (button.name == "Restart")
                {
                    button.transform.localScale = new Vector3(1, 1, 1);
                }
                else
                {
                    button.transform.localScale = new Vector3(6, 3, 1);
                }

            }

        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void AssignCurrentItem()
    {
        currentItem = ObjectList[currentItemId];
    }

    public void SpawnItem()
    {

        //Instantiate(currentItem);
    }

    public void SpawnChair()
    {
        currentItemId = "Chair";
        AssignCurrentItem();
    }
    public void SpawnCouch()
    {
        currentItemId = "Couch";
        AssignCurrentItem();
    }
    public void SpawnPotA()
    {
        currentItemId = "PotA";
        AssignCurrentItem();
    }
    public void SpawnPotB()
    {
        currentItemId = "PotB";
        AssignCurrentItem();
    }
    public void SpawnRack()
    {
        currentItemId = "Rack";
        AssignCurrentItem();
    }
    public void SpawnCoffee()
    {
        currentItemId = "Coffee";
        AssignCurrentItem();
    }
    public void SpawnRug()
    {
        currentItemId = "Rug";
        AssignCurrentItem();
    }
    public void SpawnTable()
    {
        currentItemId = "Table";
        AssignCurrentItem();
    }
}
