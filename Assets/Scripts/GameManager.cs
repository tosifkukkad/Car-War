using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Inst;
    public Image healthBar;
    public int savedCarIndex, savedGunIndex;
    public Vector3 SpawnPoint;
    public List<GameObject> cars;
    public List<GameObject> guns;
    public FixedJoystick fixedJoystick;
    public TextMeshProUGUI BulletText;
    public GamePlayScreen GamePlayScreen;
    public CameraFollow camFollow;
    public GameOverScreen GameOverScreen;

    public void StartGamePlay() {
        CarController cc = Instantiate(cars[savedCarIndex], SpawnPoint, Quaternion.identity).GetComponent<CarController>();
        transform.localEulerAngles = Vector3.up * 180;
        cc.fixedJoystick = fixedJoystick;
        GunSystem gs = Instantiate(guns[savedGunIndex], cc.Gunpoint).GetComponent<GunSystem>();
        gs.transform.localPosition = Vector3.zero;
        gs.text = BulletText;
        GamePlayScreen.carController = cc;
        GamePlayScreen.gunSystem = gs;
        camFollow.SetTarget(cc.transform);
    }
    private void Awake()
    {
        Inst = this;
    }
    public int RobotAlive;
    public void KillRobo() {
        RobotAlive--;
        if (RobotAlive == 0) {
            GameOverScreen.setText("You Won!");
            ScreenManager.ins.Switch(ScreenType.GameOverScreen);
        }
    }

    public void GameOver() {
        GameOverScreen.setText("You Lost!");
        ScreenManager.ins.Switch(ScreenType.GameOverScreen);
    }

    public void UpdateBar(float health) {

        healthBar.fillAmount = health;
    }
}
