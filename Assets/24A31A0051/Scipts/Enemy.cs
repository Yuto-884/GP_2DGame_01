using UnityEngine;
using Cysharp.Threading.Tasks;

public class Slime : MonoBehaviour
{
    public float speed = 2f;
    public float moveDistance = 3f;

    int dir = 1;
    float startX;

    async UniTaskVoid Start()
    {
        startX = transform.position.x;

        await UniTask.WaitUntil(
            () => GameManager.Instance.isStarted
        );
    }

    void Update()
    {
        if (!GameManager.Instance.isStarted)
            return;

        transform.Translate(
            Vector2.right * dir * speed * Time.deltaTime
        );

        if (transform.position.x >= startX + moveDistance)
        {
            dir = -1;
        }

        if (transform.position.x <= startX - moveDistance)
        {
            dir = 1;
        }
    }
}