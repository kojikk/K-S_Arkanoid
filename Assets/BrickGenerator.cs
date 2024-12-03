using UnityEngine;

public class BrickGenerator : MonoBehaviour
{
    public GameObject brickPrefab; // ������ �������
    public int rows = 10; // ���������� ����� ��������
    public int columns = 6; // ���������� �������� ��������
    public float brickWidth = 1.3f; // ������ �������
    public float brickHeight = 0.4f; // ������ �������
    public float spacing = 0.1f; // ���������� ����� ���������
    public Vector3 startPosition = new Vector3(-4.31f, 6.41f, -3.15f); // ��������� ������� ������� �������
    private int totalBricks;

    void Start()
    {
        GenerateBricks();
    }

     public bool AreAllBricksDestroyed()
    {
        return totalBricks <= 0;
    }

    public void BrickDestroyed()
    {
        totalBricks--;
    }

    public void GenerateBricks()
    {
        totalBricks = 0;
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
                // ��������� ������� ������� � ������ ��������
                Vector3 position = startPosition + new Vector3(
                    col * (brickWidth + spacing),
                    -row * (brickHeight + spacing),
                    0
                );

                // ������ ������
                GameObject brick = Instantiate(brickPrefab, position, Quaternion.identity);

                // ��������� ������� �������� (��� �������� ���������� � ��������)
                brick.transform.parent = this.transform;
                totalBricks++;
            }
        }
    }
}
