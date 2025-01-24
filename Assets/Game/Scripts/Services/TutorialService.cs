namespace Services
{
    public class TutorialService
    {
        private bool _isActive;
        private LevelService _levelService;
        
        public bool IsActive => _isActive;

        public TutorialService(LevelService levelService)
        {
            _levelService = levelService;

            if (_levelService.ID == 0)
            {
                _isActive = true;
            }
        }

        public void Deactivate() => _isActive = false;
    }
}