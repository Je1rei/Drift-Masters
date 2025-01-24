using DG.Tweening;

namespace Inputs
{
    public class InputPause
    {
        private Sequence _sequence;
        
        public bool CanInput { get; private set; } 

        public InputPause()
        {
            CanInput = false;
        }

        public void ActivateInput() => CanInput = true;

        public void DeactivateInput() => CanInput = false;
    }
}