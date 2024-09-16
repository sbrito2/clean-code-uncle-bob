using MediatorPattern.Interfaces;

namespace MediatorPattern
{
    class Base
    {
        protected IMediator mediator;

        public Base(IMediator mediator = null)
        {
            this.mediator = mediator;
        }

        public void SetMediator(IMediator mediator)
        {
            this.mediator = mediator;
        }
    }
}