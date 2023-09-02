using Assets.Script.Global;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestBox : TilePath, ITargetShoot
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter3D(Collision2D collision)
    {
        Destroy(this);
    }
    private void OnCollisionEnter(Collision collision)
    {
        Bullet bullet = collision.gameObject.GetComponent<Bullet>();

        Debug.Log(bullet+" collision = " + collision.gameObject.name);
        if (bullet != null)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionStay(Collision collision)
    {
       // Debug.Log("stay collision = "  );
    }

    public void Damage()
    {
        throw new System.NotImplementedException();
    }
}