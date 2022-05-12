using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayScreen : BaseScreen
{
    public CarController carController;
    public GunSystem gunSystem;

    public void OnBreakStay() {
        carController.isBreaking = true;
    }
    public void OnBreakExit() {
        carController.isBreaking = false;
    }

    public void ExelartionStay() {
        carController.verticalInput = 1;
    }

    public void ExelartionExit() {
        carController.verticalInput = 0;
    }

    public void ReloadButton() {
        gunSystem.Reload();
    }

    public void OnFireStay() {
        gunSystem.shooting = true; 
    }

    public void OnFireExit() {
        gunSystem.shooting = false;
    }
}
