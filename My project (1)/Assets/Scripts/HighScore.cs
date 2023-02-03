using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HighScore : MonoBehaviour
{
    static private TextMeshProUGUI _UI_TEXT;
    static private int _SCORE = 1000;
    private Text txtCom;

    void Awake () {
        _UI_TEXT = GetComponent<TextMeshProUGUI>();
        if (PlayerPrefs.HasKey("HighScore")) { // a
            SCORE = PlayerPrefs.GetInt("HighScore");
        }
        PlayerPrefs.SetInt("HighScore", SCORE); 
    }

    static public int SCORE {
        get { return _SCORE; }
        private set {
            _SCORE = value;
            PlayerPrefs.SetInt("HighScore", value); 
            if ( _UI_TEXT != null ) {
                _UI_TEXT.text = "High Score: " + value.ToString( "#,0" );
            }
        }
    }
    static public void TRY_SET_HIGH_SCORE(int scoreToTry) {
        if (scoreToTry <= SCORE) return;
        SCORE = scoreToTry;
    }
    [Tooltip("Check this box to rese the HighScore")]
    public bool reset = false;

    void onDrawGizmos() {
        if(reset) {
            reset = false;
            PlayerPrefs.SetInt("HighScore", 1000);
            Debug.LogWarning("PlayerPrefs HighScore Reset");
        }
    }
    // Start is called before the first frame update

}
