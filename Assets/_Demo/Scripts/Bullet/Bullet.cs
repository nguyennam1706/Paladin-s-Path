using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private readonly float timeToDestroy = 1f;

    // Start is called before the first frame update
    private void Awake()
    {
        Destroy(this.gameObject, timeToDestroy);
    }
    private void OnEnable()
    {
        transform.localScale = new Vector3(PlayerMovement.Instance.FaceTo().x * -1, PlayerMovement.Instance.FaceTo().y, PlayerMovement.Instance.FaceTo().z);
    }
}
