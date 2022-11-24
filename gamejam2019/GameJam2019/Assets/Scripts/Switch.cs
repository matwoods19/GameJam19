using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    //GameObjects
    private GameObject player;
    private TrainMovement trainMovement;
    [SerializeField] private GameObject mySwitch;
    //turning variables
    [SerializeField] private float trackAngleRight;
    [SerializeField] private float trackAngleLeft;
    [SerializeField] private bool isRight = false;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        trainMovement = player.GetComponent<TrainMovement>();
    }

    public void AngleSelect(bool aIsRight)
    {
        mySwitch.GetComponent<Switch>().isRight = aIsRight;
    }

    private void OnTriggerEnter(Collider other)
    {
        trainMovement.SetTurn(isRight);//set the train to right/left
        switch (other.tag)
        {
            case "Player":
                if (!isRight)
                {
                    trainMovement.SetAngle(trackAngleLeft);//pass angle left
                }
                if (isRight)
                {
                    trainMovement.SetAngle(trackAngleRight);//pass angle right
                }
                break;
        }//end switch
    }//end on trigger enter

    #region Removed
    //public void AngleSelect(bool turnRight)
    //{
    //    if (turnRight)
    //    {
    //        trackAngleTurn = trackAngleRight;
    //    }

    //    if (!turnRight)
    //    {
    //        trackAngleTurn = trackAngleLeft;
    //    }

    //   Debug.Log(trackAngleTurn);
    //}
    #endregion
}//end class
