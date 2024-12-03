using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public float speed = 10f; // Скорость движения
    public float stepSize = 0.5f; // Размер шага (ступенчатое движение)
    private Vector3 moveDirection;
    private bool canMoveLeft = true;
    private bool canMoveRight = true;
    private float nextMoveTime;

    void Update()
    {
        // Время до следующего шага
        if (Time.time < nextMoveTime) return;

        // Получаем ввод игрока (сырой ввод для ретро-эффекта)
        float horizontal = Input.GetAxisRaw("Horizontal");

        if ((horizontal < 0 && !canMoveLeft) || (horizontal > 0 && !canMoveRight))
        {
            horizontal = 0;
        }

        if (horizontal != 0)
        {
            // Вычисляем движение
            moveDirection = new Vector3(horizontal * stepSize, 0, 0);

            // Двигаем ракетку
            transform.position += moveDirection;

            // Ограничиваем движение в пределах игрового поля
            float clampedX = Mathf.Clamp(transform.position.x, -4f, 4f); // Настройте границы
            transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);

            // Устанавливаем время следующего шага
            nextMoveTime = Time.time + (stepSize / speed);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("WallLeft"))
        {
            canMoveLeft = false; // Блокируем движение влево
        }
        else if (collision.gameObject.CompareTag("WallRight"))
        {
            canMoveRight = false; // Блокируем движение вправо
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("WallLeft"))
        {
            canMoveLeft = true; // Снимаем блокировку движения влево
        }
        else if (collision.gameObject.CompareTag("WallRight"))
        {
            canMoveRight = true; // Снимаем блокировку движения вправо
        }
    }
}
