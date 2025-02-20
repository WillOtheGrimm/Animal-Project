using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.AI;


namespace NodeCanvas.Tasks.Actions {

	public class ApproachAT : ActionTask {

        //To get the food transform
        public BBParameter<Transform> foodTransform;
		


        private NavMeshAgent navMeshAgent;
        Vector3 finalPosition;



        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {
            //get reference to component
            navMeshAgent = agent.GetComponent<NavMeshAgent>();
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {

            //Set the destination to the food transform
			navMeshAgent.destination = foodTransform.value.position;





            //Once food is detected set the food transform to the destination
            NavMeshHit hit;
            NavMesh.SamplePosition(foodTransform.value.position, out hit, 10, 1); 
            finalPosition = hit.position;

            //Makes the duck go toward the final destination
            navMeshAgent.destination = finalPosition;





            //EndAction(true);
        }

        //Called once per frame while the action is active.
        protected override void OnUpdate() {

            //End the action once close to the food
            if (Vector3.Distance(agent.transform.position, foodTransform.value.position) <= 0.5f)
            {
                EndAction(true);
            }




        }

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}