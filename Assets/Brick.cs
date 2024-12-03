using UnityEngine;

public class Brick : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            FindObjectOfType<BrickGenerator>().BrickDestroyed();
            // ���������� ������ ��� ������������ � �����
            Destroy(gameObject);
        }
    }
}
