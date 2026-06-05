using TMPro;
using UnityEngine;

public class LifeUI : MonoBehaviour
{
    public PlayerMove player;
    public TextMeshProUGUI lifeText;

    void Update()
    {
        lifeText.text = "Life : " + player.life;
    }
}