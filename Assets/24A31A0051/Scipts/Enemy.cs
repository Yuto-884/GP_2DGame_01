using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 2f;

    int dir = 1;
    float timer = 0;

    void Update()
    {
        transform.Translate(Vector2.right * dir * speed * Time.deltaTime);

        timer += Time.deltaTime;

        if (timer >= 2f)
        {
            dir *= -1;
            timer = 0;
        }
    }
}