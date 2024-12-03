using UnityEngine;

public class BallController : MonoBehaviour
{
    public float speed = 5f; // Скорость мяча
    private Vector3 direction = new Vector3(1, -1, 0).normalized; // Направление движения

    void Update()
    {
        // Перемещаем мяч каждый кадр
        transform.position += direction * speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject hitObject = collision.gameObject;

        if (hitObject.CompareTag("WallLeft") || hitObject.CompareTag("WallRight"))
        {
            // Рикошет от боковых стен
            direction.x = -direction.x;
        }
        else if (hitObject.CompareTag("Ceiling"))
        {
            // Рикошет от потолка
            direction.y = -direction.y;
        }
        else if (hitObject.CompareTag("Paddle"))
        {
            // Рикошет от ракетки
            float hitPoint = collision.contacts[0].point.x - hitObject.transform.position.x;
            direction = new Vector3(hitPoint, Mathf.Abs(direction.y), 0).normalized;
        }
        else if (hitObject.CompareTag("Brick"))
        {
            // Рикошет от кирпича
            ContactPoint contact = collision.contacts[0];
            if (Mathf.Abs(contact.normal.x) > Mathf.Abs(contact.normal.y))
            {
                direction.x = -direction.x;
            }
            else
            {
                direction.y = -direction.y;
            }

            Destroy(hitObject); // Удаляем кирпич
            FindObjectOfType<GameManager>().CheckLevelCompletion();
        }
        else if (hitObject.CompareTag("Floor"))
        {
            // Потеря жизни
            FindObjectOfType<GameManager>().LoseHeart();
            ResetBall();
        }
    }

    public void ResetBall()
    {
        // Возвращаем мяч в начальную позицию
        transform.position = new Vector3(0f, -0.5f, -3f);
        direction = Vector3.down; // Падает вниз
    }

    public void IncreaseSpeed()
    {
        // Увеличиваем скорость
        speed += 1f;
    }
}