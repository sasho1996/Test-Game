using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

    [SerializeField] private BulletModel _bm;//Bullet Model
    [SerializeField] private BulletView _bv;//Bullet View

    //Function Shoot 
    public void Shoot(GameObject target){

        transform.DOMove(target.transform.position, 1);        

        if (_bm.CoroutineWaitAndDastroy == null) {

            _bm.CoroutineWaitAndDastroy = WaitAndDestroy();

            StartCoroutine(_bm.CoroutineWaitAndDastroy);

        } else {

            StopCoroutine(_bm.CoroutineWaitAndDastroy);

            _bm.CoroutineWaitAndDastroy = null;

            _bm.CoroutineWaitAndDastroy = WaitAndDestroy();

            StartCoroutine(_bm.CoroutineWaitAndDastroy);

        }

    }

    //Set Enemy Value
    public void SetEnemyValue(EnemyController objectEnemy) {

        _bv.ObjectEnemy = objectEnemy;

    }

    //Set Player Value
    public void SetPlayerValue(PlayerController objectPlayer) {

        _bv.ObjectPlayer = objectPlayer;

    }

    //Set Value Is Enemy Bullet
    public void SetValueIsEnemyBullet(bool isEnemyBullet) {

        _bm.IsEnemyBullet = isEnemyBullet;

    }

    //Get Value Is Enemy Bullet
    public bool GetValueIsEnemyBullet() {

        return _bm.IsEnemyBullet;

    }

    private void OnTriggerEnter(Collider other) {

        if (other.gameObject.tag == "Player") {

            other.gameObject.GetComponent<PlayerController>().ChangeLifeCount(2.0f);

            if(other.gameObject.GetComponent<PlayerController>().GetLifeCount() == 0.0f) {                

                _bv.ObjectEnemy.DeactiveCoroutine();

                other.gameObject.GetComponent<PlayerController>().DiePlayer();

                other.gameObject.GetComponent<PlayerController>().WaitAndDestroyPlayer();

                other.gameObject.GetComponent<PlayerController>().DestroyAllEnemy();

                other.gameObject.GetComponent<PlayerController>().SetValueIsLose(true);

            }

        }

        if (other.gameObject.tag == "Enemy" && !other.gameObject.GetComponent<EnemyController>().GetValueIsDie() && !_bm.IsEnemyBullet) {

            other.gameObject.GetComponent<EnemyController>().ChangeLifeCount(10.0f);

            if (other.gameObject.GetComponent<EnemyController>().GetLifeCount() == 0.0f) {                

                other.gameObject.GetComponent<EnemyController>().SetValueIsDie(true);

                other.gameObject.GetComponent<EnemyController>().DeactiveCoroutine();
                
                other.gameObject.GetComponent<EnemyController>().CreateBonus();                

                other.gameObject.GetComponent<EnemyController>().GetPlayerProperty().ShowNextTarget();

                other.gameObject.GetComponent<EnemyController>().GetPlayerProperty().SetValueIsLose(false);

            }

        }

    }   

    public IEnumerator WaitAndDestroy() {
        
        yield return new WaitForSeconds(2.0f);
        
        Destroy(gameObject);

    }

}
