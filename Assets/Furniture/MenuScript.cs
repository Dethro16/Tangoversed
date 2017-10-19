using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

    GameObject[] allChildren;

    public bool isSpawning = false;

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
                if (button.name == "Restart" || button.name == "Delete")
                {
                    button.transform.localScale = new Vector3(1, 1, 1);
                }
                else
                {
                    button.transform.localScale = new Vector3(5, 3, 1);
                }

            }

        }
    }


    void hideUI()
    {
        canvas.SetActive(false);
    }

    void showUI()
    {
        canvas.SetActive(true);
    }


    IEnumerator waiting()
    {
        string currentTime = System.DateTime.Now.ToString().Trim();

        currentTime = currentTime.Replace(" ", "");
        currentTime = currentTime.Replace("/", "");
        currentTime = currentTime.Replace(":", "");

        //hide ui

        string filename = "Tangoversed-" + currentTime + ".png";

        Debug.Log("Going to Capture!");
        Debug.Log(filename);
        hideUI();
        yield return new WaitForSeconds(0.25f);

        string Path = "../../../../ddwpics/" + filename;

        Application.CaptureScreenshot(Path);
        Debug.Log("CaptureScreenshot done!");

        yield return new WaitForSeconds(0.25f);

        showUI();
    }

    public void ScreenShot()
    {
        List<GameObject> temp = GameObject.FindGameObjectsWithTag("Item").ToList();

        foreach (var item in temp)
        {
            item.GetComponent<SetAllScripts>().ToggleAll();
        }

        if (currentItem != null)
        {
            currentItem.GetComponent<Lean.Touch.LeanSelectable>().IsSelected = false;
        }
        currentItem = null;
        //ToggleAll(false);
        StartCoroutine(waiting());
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AssignCurrentItem()
    {
        currentItem = ObjectList[currentItemId];
        isSpawning = true;
    }

    public void DeleteItem()
    {
        if (currentItem == null)
        {
            return;
        }

        Destroy(currentItem);
        currentItem = null;
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
