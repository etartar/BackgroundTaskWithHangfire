using Hangfire.States;

namespace BackgroundTaskWithHangfire.CustomStates
{
    public class WaitingAckStateFilter : IElectStateFilter
    {
        public const string JOB_PARAMETER = "waitingAck";

        public void OnStateElection(ElectStateContext context)
        {
            if (context.CurrentState == ProcessingState.StateName
                && context.CandidateState is SucceededState
                && context.GetJobParameter<bool>(JOB_PARAMETER))
            {
                context.CandidateState = new WaitingAckState();
            }
        }
    }
}
