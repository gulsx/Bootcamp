using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryPanelController : MonoBehaviour
{
    public GameObject CollectMessagePanel;
    public GameObject OpenBridgeMessage;
    public GameObject canvas;
    public GameObject bridgeBetweenRoofs;
    public int HowManyWoodsNeedToCollect;
    
    public GameObject[] PortalTubes;
    public GameObject[] Woods;

    private RectTransform rt;
    private GameObject _triggeredObj;
    private int PortalTubeCount = 0;
    private int WoodCount = 0;

    private void Start()
    {
        rt = canvas.transform.Find("InventoryPanel").GetComponent<RectTransform>();
    }
    public void Update()
    {

        if (Input.GetKeyDown(KeyCode.F))
        {
            if (_triggeredObj.CompareTag("PortalTube")){
                AddPortalTubeToPanel(_triggeredObj);
                _triggeredObj = CollectMessagePanel;
            }
            if (_triggeredObj.CompareTag("Wood")){
                AddWoodToPanel(_triggeredObj);
                _triggeredObj = CollectMessagePanel;
            }
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            OpenBridge();
        }
    }


    public void AddPortalTubeToPanel(GameObject _triggeredObj)
    {
        
        if (PortalTubeCount == 0)
        {
            canvas.transform.Find("InventoryPanel").gameObject.SetActive(true);
            _triggeredObj.gameObject.SetActive(false);

            PortalTubeCount++;
           
        }
        else if (PortalTubeCount >= 1 || PortalTubeCount < PortalTubes.Length)
        {
            
            _triggeredObj.gameObject.SetActive(false);
            PortalTubeCount++;
            
            
        }
        canvas.transform.Find("InventoryPanel").Find("SlotTube").GetChild(0).GetComponent<Text>().text = (PortalTubeCount).ToString();
        CloseMessagePanel(CollectMessagePanel);
    }

    public void AddWoodToPanel(GameObject _triggeredObj)
    {
        if (WoodCount == 0)
        {   
            rt.sizeDelta = new Vector2(260, 140);
            canvas.transform.Find("InventoryPanel").Find("SlotWood").gameObject.SetActive(true);
            _triggeredObj.gameObject.SetActive(false);
            WoodCount++;
           
        }
        else if (WoodCount >= 1 || WoodCount < Woods.Length)
        {
            _triggeredObj.gameObject.SetActive(false);
            WoodCount++;
        }
       
        canvas.transform.Find("InventoryPanel").Find("SlotWood").GetChild(0).GetComponent<Text>().text = (WoodCount).ToString() + "/" + HowManyWoodsNeedToCollect;
        CloseMessagePanel(CollectMessagePanel);
    }
            
    public void OpenBridge()
    {
        if (WoodCount == HowManyWoodsNeedToCollect)
        {
            bridgeBetweenRoofs.SetActive(true);
            canvas.transform.Find("InventoryPanel").Find("SlotWood").gameObject.SetActive(false);
            rt.sizeDelta = new Vector2(140, 140);
        }
       
    } 

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PortalTube") || other.CompareTag("Wood"))
        {   
            OpenMessagePanel(CollectMessagePanel);
            _triggeredObj = other.gameObject;
        }

        if (other.CompareTag("OpenBridge") && (WoodCount == HowManyWoodsNeedToCollect))
        {
            OpenMessagePanel(OpenBridgeMessage);
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
