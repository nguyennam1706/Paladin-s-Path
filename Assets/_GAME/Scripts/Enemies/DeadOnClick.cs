using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadOnClick : MonoBehaviour
{
    private EnemyControls enemyControls;

    private void Start()
    {
        enemyControls = this.GetComponent<EnemyControls>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && enemyControls.IsAboveEnemy())
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

            if (hit.collider != null)
            {
                if (hit.collider.gameObject == gameObject)
                {
                    CenterGameData.instance.AddExp(1);
                    Destroy(gameObject);
                }
            }
        }
    }
}
