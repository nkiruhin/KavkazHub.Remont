using System.Threading.Tasks;
using KavkazHub.Remont.SharedKernel;

namespace KavkazHub.Remont.SharedKernel.Interfaces
{
    public interface IHandle<in T> where T : BaseDomainEvent
    {
        Task Handle(T domainEvent);
    }
}