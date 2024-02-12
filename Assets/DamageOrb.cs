using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOrb : MonoBehaviour
{
    public Transform player;

    void RotateAroundPlayer()
    {
        transform.RotateAround(player.position, player.up, 300 * Time.deltaTime);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        RotateAroundPlayer();
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.GetComponent<EnemyController>() != null)
        {
            collider.gameObject.GetComponent<EnemyController>().Die();
        }
    }
}
