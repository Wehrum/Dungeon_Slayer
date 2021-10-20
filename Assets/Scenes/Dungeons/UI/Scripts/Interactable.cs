using UnityEngine;

public class Interactable : MonoBehaviour
{
    //Sets radius of object
    //Radius default is 1.536f found with trial and error
    //Can change if needed
    public float radius = 0.1f;
    //variable for player transform used in update method
    private Transform playerTransform;
    //a bool for interactation, sets it to false and then when interaction occurs sets it to true to cause only one interaction
    bool hasInteracted = false;
    private void Update()
    {
        //grabs player position from player
        if(GameObject.Find("Player") != null)
        {
            playerTransform = GameObject.Find("Player").transform;

            float distance = Vector3.Distance(playerTransform.position, transform.position);
            //Debug.Log(distance);
            //Debug.Log(playerTransform.position);
            //If player is at the radius or beyond execute code inside and interacted is set to false call interact method
            if (distance <= radius && hasInteracted == false)
            {
                hasInteracted = true;
                Interact();
            }
        }
    }

    public virtual void Interact()
    {
        Debug.Log($"Interacting with {transform.name}");
    }
    private void OnDrawGizmosSelected()
    {
        /*Used to visually test radius, wasn't much help as this is
         * for 3D objects and the radius bugs as it gets smaller :(
        */
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
