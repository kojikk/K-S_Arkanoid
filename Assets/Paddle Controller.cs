using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public float speed = 10f; // �������� ��������
    public float stepSize = 0.5f; // ������ ���� (����������� ��������)
    private Vector3 moveDirection;
    private bool canMoveLeft = true;
    private bool canMoveRight = true;
    private float nextMoveTime;

    void Update()
    {
        // ����� �� ���������� ����
        if (Time.time < nextMoveTime) return;

        // �������� ���� ������ (����� ���� ��� �����-�������)
        float horizontal = Input.GetAxisRaw("Horizontal");

        if ((horizontal < 0 && !canMoveLeft) || (horizontal > 0 && !canMoveRight))
        {
            horizontal = 0;
        }

        if (horizontal != 0)
        {
            // ��������� ��������
            moveDirection = new Vector3(horizontal * stepSize, 0, 0);

            // ������� �������
            transform.position += moveDirection;

            // ������������ �������� � �������� �������� ����
            float clampedX = Mathf.Clamp(transform.position.x, -4f, 4f); // ��������� �������
            transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);

            // ������������� ����� ���������� ����
            nextMoveTime = Time.time + (stepSize / speed);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("WallLeft"))
        {
            canMoveLeft = false; // ��������� �������� �����
        }
        else if (collision.gameObject.CompareTag("WallRight"))
        {
            canMoveRight = false; // ��������� �������� ������
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("WallLeft"))
        {
            canMoveLeft = true; // ������� ���������� �������� �����
        }
        else if (collision.gameObject.CompareTag("WallRight"))
        {
            canMoveRight = true; // ������� ���������� �������� ������
        }
    }
}
