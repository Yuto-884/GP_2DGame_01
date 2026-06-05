using UnityEngine;
using TMPro;
using Cysharp.Threading.Tasks;

public class CountDown : MonoBehaviour
{
    public TextMeshProUGUI text;

    async UniTaskVoid Start()
    {
        text.text = "3";
        await UniTask.Delay(1000);

        text.text = "2";
        await UniTask.Delay(1000);

        text.text = "1";
        await UniTask.Delay(1000);

        text.text = "GO!";
        await UniTask.Delay(1000);

        text.text = "";

        GameManager.Instance.isStarted = true;
    }
}