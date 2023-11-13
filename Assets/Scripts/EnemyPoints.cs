using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPoints : MonoBehaviour
{
    public Transform[] spawnPoints;

    public List<EnemyMovePoints> enemyMovePoints = new List<EnemyMovePoints>();

    public EnemyMovePoints GetRandomMovePoint() { 
    
        List<EnemyMovePoints> freePoints = new List<EnemyMovePoints>();
        foreach (EnemyMovePoints movePoint in enemyMovePoints) {

            if (movePoint.isFree()) { 
            
                freePoints.Add(movePoint);
            
            }
        }

        if (freePoints.Count > 0) {

            return freePoints[ Random.Range(0, freePoints.Count)];

        }
        else { 
        
            return null;
        }

    }


    public Transform GetRandomSpwanPoint() { 
    
        return spawnPoints[Random.Range(0,spawnPoints.Length)];
        
    
    }




}
