using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DailyBoundPanel : MonoBehaviour {

    public Button[] getITs;

    public CoolTime[] coolTime;

    public UIManage uiManage;

    public Button goBackBtn;

    public GameObject mainMenuPanel;
    void Awake()
    {
        getITs[0].onClick.AddListener(OnClick_Day1);
        getITs[1].onClick.AddListener(OnClick_Day2);
        getITs[2].onClick.AddListener(OnClick_Day3);
        getITs[3].onClick.AddListener(OnClick_Day4);
        goBackBtn.onClick.AddListener(Onclick_GoBack);
    }

    private void OnClick_Day1()
    {
        getITs[0].gameObject.SetActive(false);
        coolTime[0].gameObject.SetActive(true);
        coolTime[0].Play();
        uiManage.GoldCount += 0;
        uiManage.TicketCount += 1;
        
    }
    private void OnClick_Day2()
    {
        getITs[1].gameObject.SetActive(false);
        coolTime[1].gameObject.SetActive(true);
        coolTime[1].Play();
        uiManage.GoldCount += 2000;
        uiManage.TicketCount += 1;
    }
    private void OnClick_Day3()
    {
        getITs[2].gameObject.SetActive(false);
        coolTime[2].gameObject.SetActive(true);
        coolTime[2].Play();
        uiManage.GoldCount += 5000;
        uiManage.TicketCount += 1;
    }
    private void OnClick_Day4()
    {
        getITs[3].gameObject.SetActive(false);
        coolTime[3].gameObject.SetActive(true);
        coolTime[3].Play();
        uiManage.GoldCount += 7000;
        uiManage.TicketCount += 2;

    }

    private void Onclick_GoBack()
    {
        mainMenuPanel.SetActive(true);
        gameObject.SetActive(false);
    }
}
