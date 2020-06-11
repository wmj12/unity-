using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MainMenuPanel : MonoBehaviour {

    public Button dailyBoundBtn;
    public Text gold;
    public Text ticket;

    public UIManage uiManage;
    public GameObject dailyBoundPanel;

    void Awake()
    {
        dailyBoundBtn.onClick.AddListener(OnClick_OpenDailyPanel);
    }

    void OnEnable()
    {
        gold.text = string.Format("金币X{0}",uiManage.GoldCount );
        ticket.text = string.Format("门票X{0}", uiManage.TicketCount);
    }

    private void OnClick_OpenDailyPanel()
    {
        dailyBoundPanel.SetActive(true);
        gameObject.SetActive(false);
    }
}
