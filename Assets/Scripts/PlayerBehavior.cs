using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBehavior : MonoBehaviour
{
    [SerializeField] private float pushStrengh;
    [SerializeField] private float maxpush;
    [SerializeField] private float maDirection;

    private Player inputs;
    //fonctionne
    private Vector2 direction;
    //test
    //Vector3 myVector;
   

    private Rigidbody myRigidbody;
    //private GameObject joueur;

    private void Start()
    {
        Quaternion myRotation = Quaternion.identity;
        //print rotation info
        // Debug.Log (joueur.transform.rotation.eulerAngles.x);
        Debug.Log(myRotation.eulerAngles);
    }

    private void OnEnable()
    {
        //recup la liste des inputs
        inputs = new Player();
        inputs.Enable();
        //recuperer l'action "quand le joueur appui sur les boutons d'actions move"
        inputs.Character.Move.performed += OnMovePerformed;
        //recuperer l'action "quand le joueur n'appui pas sur les boutons d'actions move"
        inputs.Character.Move.canceled += OnMoveCanceled;
        

        //recup mon rigidbody et lui donne le nom d'une variable + facile a utiliser
        myRigidbody = GetComponent<Rigidbody>();
    }

    //quand on utilise l'action move : 
    private void OnMovePerformed(InputAction.CallbackContext obj)
    {
        //fonctionne
        direction = obj.ReadValue<Vector2>();
        //test
        //myVector = obj.ReadValue<Vector2>();

    }

    private void OnMoveCanceled(InputAction.CallbackContext obj)
    {
        //fonctione
        direction = Vector2.zero;
        //test
        //myVector = Vector2.zero;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Dead")
        {
            Debug.Log("touche");
        }
            
    }

    void FixedUpdate()
    {
        //celui qui marche
        direction.y = 0;
        //celui que je test
        //myVector = new Vector3(0.0f, 0.0f, 0.0f);

        //je limite ma force de poussée max
        if (myRigidbody.velocity.sqrMagnitude < maxpush)
        {
            //celle qui fonctionne mais je choisi pas la direction.
            
           
            myRigidbody.AddTorque(direction * pushStrengh);

            //celle qui devrait marcher mais t'as pas compris un truc
            //myRigidbody.AddTorque(myVector* pushStrengh);
            //la version addforceatposition de flore

        }

        /*
         //ne marche pas forcement il manque un truc
        Quaternion myRotation = Quaternion.identity;
        //print rotation info
        // Debug.Log (joueur.transform.rotation.eulerAngles.x);
        Debug.Log(myRotation.eulerAngles);
        */
    }
}
