using Assets.Script.Global;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public string Name = "Bullet";
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        ITargetShoot targetShoot = collision.gameObject.GetComponent<ITargetShoot>();
        
        Debug.Log( "0000 collision = " + collision.gameObject.name);
        if (targetShoot != null)
       {
            targetShoot.Damage();
            Destroy(gameObject);
        }
    }
}
