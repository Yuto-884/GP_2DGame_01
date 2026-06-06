using UnityEngine;
using TMPro;
using Cysharp.Threading.Tasks;
using System.Threading;

public class Countdown : MonoBehaviour
{
    public TMP_Text text;

    async UniTaskVoid Start()
    {
        Debug.Log("Countdown Start");

        CancellationToken ct = this.GetCancellationTokenOnDestroy();

        GameManager.Instance.isStarted = false;

        text.text = "3";
        await UniTask.Delay(
            1000,
            ignoreTimeScale: true,
            cancellationToken: ct
        );

        text.text = "2";
        await UniTask.Delay(
            1000,
            ignoreTimeScale: true,
            cancellationToken: ct
        );

        text.text = "1";
        await UniTask.Delay(
            1000,
            ignoreTimeScale: true,
            cancellationToken: ct
        );

        text.text = "GO!";

        GameManager.Instance.isStarted = true;
        Debug.Log("isStarted = " + GameManager.Instance.isStarted);

        await UniTask.Delay(
            1000,
            ignoreTimeScale: true,
            cancellationToken: ct
        );

        text.text = "";
    }
}