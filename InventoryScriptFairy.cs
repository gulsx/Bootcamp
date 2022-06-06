using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryScriptFairy : MonoBehaviour
{
    public GameObject CollectMessagePanel;
    public GameObject canvas;
    public int HowManyPlantsNeedToCollect;
    public GameObject Demon;
    public GameObject TimeLine3;

    public GameObject[] Plants;

    private RectTransform rt;
    private GameObject _triggeredObj;
    private int PortalTubeCount = 0;
    private int PlantCount = 0;

    private void Start()
    {
        rt = canvas.transform.Find("InventoryPanel").GetComponent<RectTransform>();
    }
    public void Update()
    {

        if (Input.GetKeyDown(KeyCode.F))
        {
            
            if (_triggeredObj.CompareTag("Plant"))
            {
                AddPlantToPanel(_triggeredObj);
                _triggeredObj = CollectMessagePanel;
            }
        }

        if(PlantCount == HowManyPlantsNeedToCollect)
        {
            Demon.gameObject.SetActive(false);
            TimeLine3.gameObject.SetActive(true);

        }
      
    }


    public void AddPlantToPanel(GameObject _triggeredObj)
    {
        if (PlantCount == 0)
        {
            rt.sizeDelta = new Vector2(260, 140);
            canvas.transform.Find("InventoryPanel").Find("SlotPlant").gameObject.SetActive(true);
            _triggeredObj.gameObject.SetActive(false);
            PlantCount++;

        }
        else if (PlantCount >= 1 || PlantCount < Plants.Length)
        {
            _triggeredObj.gameObject.SetActive(false);
            PlantCount++;
        }

        canvas.transform.Find("InventoryPanel").Find("SlotPlant").GetChild(0).GetComponent<Text>().text = (PlantCount).ToString() + "/" + HowManyPlantsNeedToCollect;
        CloseMessagePanel(CollectMessagePanel);
    }

   

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Plant"))
        {
            OpenMessagePanel(CollectMessagePanel);
            _triggeredObj = other.gameObject;
        }

       
    }

    public void OnTriggerExit(Collider other)
    {
        CloseMessagePanel(CollectMessagePanel);
        _triggeredObj = CollectMessagePanel;
    }

    public void OpenMessagePanel(GameObject messagePanel)
    {
        messagePanel.SetActive(true);
    }

    public void CloseMessagePanel(GameObject messagePanel)
    {
        messagePanel.SetActive(false);
    }



}
