namespace demo.correct
{
    public class Interruptor
    {
        private readonly IDispositivo _dispositivo;
        
        public void AcionarDispositivo()
        {
            _dispositivo.Acionar();
        }
    }
}