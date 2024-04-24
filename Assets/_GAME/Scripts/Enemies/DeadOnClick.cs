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
            Vector3 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            RaycastHit2D hit = Physics2D.Raycast(clickPosition, Vector2.zero);

            if (hit.collider != null)
            {
                if (hit.collider.gameObject == gameObject)
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}
