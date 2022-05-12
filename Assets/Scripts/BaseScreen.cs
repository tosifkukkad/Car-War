using UnityEngine;
using System.Collections;
//using DG.Tweening;

public class BaseScreen : MonoBehaviour
{
    [HideInInspector]
    public ScreenType lastScreen;
    public ScreenType screen;

    [HideInInspector]
    public BaseScreen CurrentScreen;

    public bool EnableEscape;
    public delegate void OnComplete();

    [HideInInspector]
    public Canvas canvas;

    public virtual void Awake()
    {
        canvas = GetComponent<Canvas>();
    }

    public virtual void OnBack()
    {
        ScreenManager.ins.Switch(lastScreen, true);
    }

    public void Appear()
    {
        OnActivate();
        //CommonTween.Ins.ScreenFadeOut(() =>
        //{

        //});
    }

    public virtual void OnActivate()
    {
        canvas.enabled = true;
    }

    public void Disappear()
    {
        canvas.enabled = false;
        OnDeactivate();
        // CommonTween.Ins.ScreenFadeIn(() =>
        //{
        //  
        //});
    }

    public virtual void OnDeactivate()
    {
        Debug.Log("deactivate : " + gameObject.name);
        canvas.enabled = false;
    }

}
