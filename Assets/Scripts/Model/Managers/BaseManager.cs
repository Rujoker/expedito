namespace SergeyPchelintsev.Expedito.Model.Managers
{
    public class BaseManager
    {
        protected IGameMediator gameMediator;
        
        public virtual void Initialize() {}
        
        public BaseManager(IGameMediator gameMediator)
        {
            this.gameMediator = gameMediator;
        }
    }
}