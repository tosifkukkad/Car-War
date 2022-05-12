using UnityEngine;

public enum ScreenType
{
    HomeScreen,
    CarSelectionScreen,
    GamePlayScreen,
    GunSelectionScreen,
    GameOverScreen
    
}

public class ScreenManager : MonoBehaviour
{
    public static ScreenManager ins;
    public BaseScreen[] ScreenObjects;
    public BaseScreen CurrentScreen;
    public ScreenType initScreen;
    public bool IsEnableEscape;

    void Awake()
    {
        ins = this;
    }

    private void Start()
    {
        BackEnable();
        Init();
    }

    public void BackEnable()
    {
        IsEnableEscape = true;
    }

    public void Init()
    {
        //ScreenType initScreen = ScreenType.LoginScreen;

        foreach (BaseScreen scr in ScreenObjects)
        {
            if (scr.screen == initScreen)
            {
                CurrentScreen = scr;
                CurrentScreen.lastScreen = scr.screen;
                scr.Appear();
            }
            else
            {
                scr.canvas.enabled = false;
            }
        }
    }



    public void Switch(ScreenType screenType)
    {
        Switch(screenType, false);
    }

    public void Switch(ScreenType screenType, bool isBack)
    {
        Debug.Log("disappear");

        if (CurrentScreen && CurrentScreen.screen == screenType)
            return;

        IsEnableEscape = false;
        ScreenType lastScreenType = screenType;

        if (CurrentScreen)
        {
            lastScreenType = CurrentScreen.screen;
            //CurrentScreen.lastScreen = lastScreenType;
            CurrentScreen.Disappear();
            Debug.Log("disappear");
        }

        foreach (BaseScreen scr in ScreenObjects)
        {
            if (scr.screen == screenType)
            {
                CurrentScreen = scr;

                CurrentScreen.Invoke("Appear", .15f);

                if (!isBack)
                    CurrentScreen.lastScreen = lastScreenType;
                return;
            }
        }
    }

    public void CloseAllScreen()
    {
        //HUD.Inst.Hide();
        if (CurrentScreen)
            CurrentScreen.OnDeactivate();
        CurrentScreen = null;
    }
}