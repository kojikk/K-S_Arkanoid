using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int hearts = 3; // ���������� ������
    public BallController ball; // ������ �� ���
    public BrickGenerator brickGenetator; // ������ �� ���������� ���������
    public Transform selectionBox; // ������ �� ����� ���������
    public Transform title;
    public Transform[] buttons;   // ������ �� ������ (TextMeshPro)
    private int selection = 0;
    
    void Start (){
        Instantiate(title, new Vector3(-1.6f,4.7f,-3.3f), Quaternion.identity);
    
    }
    void Update()
    {
        float vertical = Input.GetAxisRaw("Vertical");
        if (vertical == -1){ }

    }




    public void LoseHeart()
    {
        hearts--;
        Debug.Log("�������� ������: " + hearts);

        if (hearts <= 0)
        {
            Debug.Log("���� ��������!");
            
        }
        else
        {
            // ���������� ���
            ball.ResetBall();
        }
    }

     public void CheckLevelCompletion()
    {
        if (brickGenetator.AreAllBricksDestroyed())
        {
           Debug.Log("������� �������!");
           ball.IncreaseSpeed(); // �������� ���
           brickGenetator.GenerateBricks(); // ���������� ����� �������
        }
    }
    
}
