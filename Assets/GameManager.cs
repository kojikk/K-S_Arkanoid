using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int hearts = 3; //  оличество жизней
    public BallController ball; // —сылка на м€ч
    public BrickGenerator brickGenetator; // —сылка на управление кирпичами
    public Transform selectionBox; // —сылка на рамку выделени€
    public Transform title;
    public Transform[] buttons;   // —сылки на кнопки (TextMeshPro)
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
        Debug.Log("ќсталось жизней: " + hearts);

        if (hearts <= 0)
        {
            Debug.Log("»гра окончена!");
            
        }
        else
        {
            // —брасываем м€ч
            ball.ResetBall();
        }
    }

     public void CheckLevelCompletion()
    {
        if (brickGenetator.AreAllBricksDestroyed())
        {
           Debug.Log("”ровень пройден!");
           ball.IncreaseSpeed(); // ”скор€ем м€ч
           brickGenetator.GenerateBricks(); // √енерируем новый уровень
        }
    }
    
}
