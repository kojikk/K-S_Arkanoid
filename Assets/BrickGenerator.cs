using UnityEngine;

public class BrickGenerator : MonoBehaviour
{
    public GameObject brickPrefab; // Префаб кирпича
    public int rows = 10; // Количество рядов кирпичей
    public int columns = 6; // Количество столбцов кирпичей
    public float brickWidth = 1.3f; // Ширина кирпича
    public float brickHeight = 0.4f; // Высота кирпича
    public float spacing = 0.1f; // Расстояние между кирпичами
    public Vector3 startPosition = new Vector3(-4.31f, 6.41f, -3.15f); // Начальная позиция первого кирпича
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
                // Вычисляем позицию кирпича с учётом отступов
                Vector3 position = startPosition + new Vector3(
                    col * (brickWidth + spacing),
                    -row * (brickHeight + spacing),
                    0
                );

                // Создаём кирпич
                GameObject brick = Instantiate(brickPrefab, position, Quaternion.identity);

                // Назначаем кирпичу родителя (для удобства управления в иерархии)
                brick.transform.parent = this.transform;
                totalBricks++;
            }
        }
    }
}
