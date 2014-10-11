#pragma strict

/*function OnCollisionEnter (info : Collider) 
{
	if(info.tag == "Player")
	{
		Debug.Log("Collectible picked up !");
		Destroy(gameObject);
	}
}*/

function OnCollisionEnter(collision: Collision)
{
Debug.Log("Destroy: " + collision.gameObject.name);
    if(collision.gameObject.tag == "Player") //find the object tag with inventory
      //or do I tag my "Player"
    {
         //if yes remove from scene and add to inventory
         Debug.Log("Destroy: " + collision.gameObject.name);
    }
}