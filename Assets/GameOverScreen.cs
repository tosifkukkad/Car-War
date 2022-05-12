using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class GameOverScreen : BaseScreen
{
    public TextMeshProUGUI text;
    public void setText(string s) {
        text.text = s;
    }
    public void RestartButton() {
        SceneManager.LoadScene(0);
    }
}
