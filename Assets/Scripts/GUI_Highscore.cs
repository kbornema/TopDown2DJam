using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUI_Highscore : MonoBehaviour
{
    [SerializeField]
    private TMPro.TextMeshProUGUI _text = default;

    private void Start()
    {
        var player = Player.Instance;

    }

    public void SetPoints(int points)
    {
        _text.text = "H  ghscore: " + points.ToString();
    }
}
