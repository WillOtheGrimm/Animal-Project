using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.AI;


namespace NodeCanvas.Tasks.Actions {

	public class WanderAT : ActionTask {


        public float walkRadius;

        private Vector3 randomDirection;
        private NavMeshAgent navMeshAgent;
        Blackboard agentBlackBoard;
        Vector3 finalPosition;




        //to set the energy rate
        public float energyRate;




        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit()
        {
            //get component reference
            agentBlackBoard = agent.GetComponent<Blackboard>();

            navMeshAgent = agent.GetComponent<NavMeshAgent>();


            return null;
        }

        //This is called once each time the task is enabled.
        //Call EndAction() to mark the action as finished, either in success or failure.
        //EndAction can be called from anywhere.
        protected override void OnExecute()
        {
            //find random point in radius
            randomDirection = Random.insideUnitSphere * walkRadius;

            //random location is set around the player
            randomDirection += agent.transform.position;
            NavMeshHit hit;
            NavMesh.SamplePosition(randomDirection, out hit, walkRadius, 1);
            finalPosition = hit.position;

            //Makes the duck go toward the final destination
            navMeshAgent.destination = finalPosition;


        }

        //Called once per frame while the action is active.
        protected override void OnUpdate()
        {

            //set the energy level to the the blackboard variable
            float energyLevel =  agentBlackBoard.GetVariableValue<float>("energy");



            //energy goes down over time during this task
            energyLevel -= energyRate * Time.deltaTime;
            //update the blackboard variable to the last value
            agentBlackBoard.SetVariableValue("energy", energyLevel);



            //If duck reach destination, end task
            if (Vector3.Distance(agent.transform.position, finalPosition) <= 0.5f)
            {

            EndAction(true);
            }



        }

        //Called when the task is disabled.
        protected override void OnStop()
        {

        }

        //Called when the task is paused.
        protected override void OnPause()
        {

        }
    }
}