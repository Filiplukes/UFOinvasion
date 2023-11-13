using UnityEngine;

public class EnemyMovePoints : MonoBehaviour
{
    // Start is called before the first frame update
    private bool isThereEnemy = false;

    public bool isFree() { 
    
        return !isThereEnemy;
    
    }

    public void SetIsEnemyOnPoint(bool enemy) { 
    
        isThereEnemy = enemy; 
    
    
    }

}
