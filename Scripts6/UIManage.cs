using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManage : MonoBehaviour
{

    public int GoldCount { get; set; }
    public int TicketCount { get; set; }

    void Awake()
    {
        GoldCount = 0;
        TicketCount = 0;
    }
}
