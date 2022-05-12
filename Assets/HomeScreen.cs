using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeScreen : BaseScreen
{
    public void OnChooseCar()
    {
        ScreenManager.ins.Switch(ScreenType.CarSelectionScreen);
    }
    public void OnChooseGun()
    {
        ScreenManager.ins.Switch(ScreenType.GunSelectionScreen);
    }
    public void OnPlayButton()
    {
        GameManager.Inst.StartGamePlay();
        ScreenManager.ins.Switch(ScreenType.GamePlayScreen);
    }

}
