using NodeCanvas.Framework;
using ParadoxNotion.Design;


namespace NodeCanvas.Tasks.Conditions {


	public class CheckEnergyCT : ConditionTask {




		public float energyThreshold;

        Blackboard agentBlackBoard;




        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit(){
			//get reference to component
            agentBlackBoard = agent.GetComponent<Blackboard>();


            return null;
		}

		//Called whenever the condition gets enabled.
		protected override void OnEnable() {
		}

		//Called whenever the condition gets disabled.
		protected override void OnDisable() {
			
		}

		//Called once per frame while the condition is active.
		//Return whether the condition is success or failure.
		protected override bool OnCheck() {
			//set the energy level to the blackboard variable
            float energyLevel = agentBlackBoard.GetVariableValue<float>("energy");


			//Check if energy level is below threshold
			if (energyLevel <= energyThreshold)
			{
				return true;

			}
			else return false;
		}
	}
}