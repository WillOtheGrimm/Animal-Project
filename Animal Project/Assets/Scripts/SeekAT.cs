using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class SeekAT : ActionTask {
        
        
        
        
        //This section is for the debug
        public Color scanColour;
        public int numberOfScanCirclePoints;





        public BBParameter<float> detectionRadius;
        public LayerMask foodLayerMask;
        public BBParameter<Transform> foodTransform;


        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit()
        {
            detectionRadius.value = agent.GetComponent<Blackboard>().GetVariableValue<float>("initialScanRadius");

            return null;
        }

        //This is called once each time the task is enabled.
        //Call EndAction() to mark the action as finished, either in success or failure.
        //EndAction can be called from anywhere.
        protected override void OnExecute()
        {

        }

        //Called once per frame while the action is active.
        protected override void OnUpdate()
        {
            DrawCircle(agent.transform.position, detectionRadius.value, scanColour, numberOfScanCirclePoints);


            Collider[] detectedColliders = Physics.OverlapSphere(agent.transform.position, detectionRadius.value, foodLayerMask);




            if (detectedColliders.Length > 0)
            {
            foodTransform.value = detectedColliders[0].transform;
            EndAction(true);
            }




          
        }

        private void DrawCircle(Vector3 center, float radius, Color colour, int numberOfPoints)
        {
            Vector3 startPoint, endPoint;
            int anglePerPoint = 360 / numberOfPoints;
            for (int i = 1; i <= numberOfPoints; i++)
            {
                startPoint = new Vector3(Mathf.Cos(Mathf.Deg2Rad * anglePerPoint * (i - 1)), 0, Mathf.Sin(Mathf.Deg2Rad * anglePerPoint * (i - 1)));
                startPoint = center + startPoint * radius;
                endPoint = new Vector3(Mathf.Cos(Mathf.Deg2Rad * anglePerPoint * i), 0, Mathf.Sin(Mathf.Deg2Rad * anglePerPoint * i));
                endPoint = center + endPoint * radius;
                Debug.DrawLine(startPoint, endPoint, colour);
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