namespace Domus.Hydra.Job
{
    internal interface ICanceledJob : IJob
    {
        void Interrupt();
    }
}
