using System.Threading.Tasks;
using KavkazHub.Remont.SharedKernel;

namespace KavkazHub.Remont.SharedKernel.Interfaces
{
    public interface IDomainEventDispatcher
    {
        Task Dispatch(BaseDomainEvent domainEvent);
    }
}