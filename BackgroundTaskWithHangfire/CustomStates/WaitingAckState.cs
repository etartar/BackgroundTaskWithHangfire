using Hangfire.States;
using Hangfire.Storage;
using System.Collections.Generic;

namespace BackgroundTaskWithHangfire.CustomStates
{
    public class WaitingAckState : IState
    {
        public string Name => StateName;

        public string Reason => "Waiting for acknowledgement from an external service.";

        public bool IsFinal => false;

        public bool IgnoreJobLoadException => true;

        private static readonly string StateName = "WaitingAck";

        public Dictionary<string, string> SerializeData() => new Dictionary<string, string>();

        public class Handler : IStateHandler
        {
            public const string STATE_STAT_KEY = "stats:waitingack";
            public string StateName => WaitingAckState.StateName;

            public void Apply(ApplyStateContext context, IWriteOnlyTransaction transaction)
            {
                transaction.IncrementCounter(STATE_STAT_KEY);
            }

            public void Unapply(ApplyStateContext context, IWriteOnlyTransaction transaction)
            {
                transaction.DecrementCounter(STATE_STAT_KEY);
            }
        }
    }
}
