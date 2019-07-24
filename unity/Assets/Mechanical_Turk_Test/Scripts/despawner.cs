using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class despawner : MonoBehaviour
{
    public float lifeTime = 10f;

    // Update is called once per frame
    void Update()
    {
        if (lifeTime > 0)
        {
            lifeTime -= Time.deltaTime;
            if (lifeTime <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

}