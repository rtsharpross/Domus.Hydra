using Domus.Hydra.Context;

namespace Domus.Hydra.Job
{
    public interface IJob
    {
        Task Execute(IContext context, CancellationToken cancellationToken);
    }
}
