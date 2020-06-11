using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class SpecialEffects : MonoBehaviour {

    /// <summary>
    /// 左侧进入，左侧出去，变大进入，变小出去
    /// </summary>
    public enum Anim
    {
        LeftInto,
        LeftOut,
        BiggerInto,
        SmallerOut
    }

    public Anim intoAnim = Anim.LeftInto;
    public Anim outAnim = Anim.LeftOut;

    public Ease ease;
    public float time;

    public Button ChangPanelBtn;
    public GameObject openPanel;


    private RectTransform rectTransform;

    private Rect rect;

    private Vector2 startAnchoredPosition;
    private Vector3 startScale;


    public TweenCallback MyStart;
    public TweenCallback MyComplete;

    
    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        rect = rectTransform.rect;
        startAnchoredPosition = rectTransform.anchoredPosition;
        startScale = rectTransform.localScale;
    }

    void OnEnable()
    {
        MyComplete += Reset;
        MyComplete += ChangePanel;
        GetInto();
    }

    void Start()
    {
        ChangPanelBtn.onClick.AddListener(OnClick_OpenPanel);
    }

    private void OnClick_OpenPanel()
    {
        GetOut();
    }

    private void GetInto()
    {
        Vector2 pos=new Vector2(startAnchoredPosition.x-rect.width,0);
        if (intoAnim == Anim.LeftInto)
        {
            rectTransform.DOAnchorPos(pos, time)
                .From()
                .SetEase(ease)
                .Play();
        }
        else if (intoAnim == Anim.BiggerInto)
        {
            rectTransform.DOScale(Vector3.zero, time)
                .From()
                .SetEase(ease)
                .Play();
        }
    }

    private void GetOut()
    {
        Vector2 pos = new Vector2(startAnchoredPosition.x - rect.width, 0);
        Tween tween = null;
        if (outAnim == Anim.LeftOut)
        {
            tween = rectTransform.DOAnchorPos(pos, time)
                .SetEase(ease);
        }
        else if (outAnim == Anim.SmallerOut)
        {
            tween = rectTransform.DOScale(Vector3.zero, time)
                .SetEase(ease);
        }
        tween.OnComplete(MyComplete).Play();
    }

    private void ChangePanel()
    {
        MyComplete -= ChangePanel;
        MyComplete -= Reset;
        openPanel.SetActive(true);
        gameObject.SetActive(false);
    }

    private void Reset()
    {
        Debug.Log("Reset");
        rectTransform.anchoredPosition = startAnchoredPosition;
        rectTransform.localScale = startScale;
    }
}
