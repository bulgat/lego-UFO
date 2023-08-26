using UnityEngine;
using System.Collections;

public class Bolt : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Destroy(gameObject, 25);
	}
	
	// Update is called once per frame
	void Update () {
		//transform.Translate(new Vector3(0,-1,0)*0.5f*Time.deltaTime);
	}
    void OnCollisionEnter(Collision myCollision)
    {
        Debug.Log("Hit Something "+myCollision.gameObject.name);  // Передаем сообщение в консоль Unity  


        // Если ригид вровень с объектом, увы у нас не так. Еслии только не ввести стену.
       var k = myCollision.transform.Find("NEW_lEGO"); 

        
        if (k != null)
        {
            
            transform.GetComponent<Rigidbody>().velocity = Vector3.zero;
            
            transform.position = new Vector3(k.transform.position.x-1- Random.Range(0, 1), k.transform.position.y+1+ Random.Range(0, 2), k.transform.position.z+ Random.Range(0, 1));
            transform.SetParent(k.transform);
           // transform.position = new Vector3(transform.position.x+2, transform.position.y, transform.position.z);
        } 
Destroy(transform.GetComponent<Rigidbody>());
       
    }

    /*
     - при ударе отключаем физику флагом isKinetic = true 
- привязываем стрелу к объекту, в чей коллайдер она ударилась:
myTransform.parent = myHit.collider.transform;

myTransform - это трансформ стрелы, и сам скрипт срабатывает в ней
myHit - это типа тот RaycastHit, который вы получаете с трассировки или коллизии с ригидом
Сама операция парентит стрелу к объекту, в который она воткнулась.
    */
}
