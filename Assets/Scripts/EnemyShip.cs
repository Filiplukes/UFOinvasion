using UnityEngine;

public class EnemyShip : MonoBehaviour
{

    public int hp;
    public HeatlhBar hpBar;
    private InGameManager gameManager;
    

    protected virtual void Start()
    {
        hpBar.setMaxHealth(hp);
        gameManager = FindAnyObjectByType<InGameManager>();

    }

    protected void checkHP(int hp) {

        if (hp <= 0) {

            DestoyShip();
 
        }
    
    
    }
    public void TakeDamage(int Damage)
    {


        hp -= Damage;
        hpBar.setHealth(hp);
        checkHP(hp);


    }

   protected virtual void DestoyShip()
    {

        Destroy(gameObject);

        try
        {
            gameManager.GetComponent<InGameManager>().plusKills();
        }
        catch {
            Debug.Log("chyba souctu");
        }
       
        

    }

}
