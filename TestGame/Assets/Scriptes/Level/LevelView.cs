using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class LevelView : MonoBehaviour {

    public GameObject PlayerStartPosition;//Player Start Position

    public PlayerController Player;//Player

    public EnemyController Enemy;//Enemy

    public List<EnemyController> CreatedEnemies;//Created Enemies   

    public void Start() {
            
        CreatedEnemies = new List<EnemyController>();

    }

}
