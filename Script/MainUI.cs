using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;


public class MainUI : MonoBehaviour
{
    [SerializeField]GameObject MainPanel, SelectBookPanel;
    void Start()
    {
        MainPanel.SetActive(true);
        SelectBookPanel.SetActive(true);
    }

    public void TapToContinue()
    {
        SelectBookPanel.GetComponent<RectTransform>().DOAnchorPos(new Vector2(0, 0), 0.5f);
    }
}
