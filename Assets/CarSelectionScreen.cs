using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSelectionScreen : BaseScreen
{
    public List<Transform> cars;
    public int index = 0;

    public void LeftButton()
    {
        if (index - 1 >= 0)
        {
            cars[index].gameObject.SetActive(false);
            index--;
            cars[index].gameObject.SetActive(true);
        }
    }

    public void RightButton()
    { 
        if (index + 1 < cars.Count)
        {
            cars[index].gameObject.SetActive(false);
            index++;
            cars[index].gameObject.SetActive(true);
        }
    }

    public void Save()
    {
        GameManager.Inst.savedCarIndex = index;
        ScreenManager.ins.Switch(ScreenType.HomeScreen);
    }
}
