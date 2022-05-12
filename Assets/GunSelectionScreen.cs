using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSelectionScreen : BaseScreen
{
    public List<Transform> Guns;
    public int index = 0;
    public void LeftButton()
    {
        if (index - 1 >= 0)
        {
            Guns[index].gameObject.SetActive(false);
            index--;
            Guns[index].gameObject.SetActive(true);
        }
    }

    public void RightButton()
    {
        if (index + 1 < Guns.Count)
        {
            Guns[index].gameObject.SetActive(false);
            index++;
            Guns[index].gameObject.SetActive(true);
        }
    }

    public void Save() {
        GameManager.Inst.savedGunIndex = index;
        ScreenManager.ins.Switch(ScreenType.HomeScreen);
    }
}
