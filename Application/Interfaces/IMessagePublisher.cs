using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IMessagePublisher
    {
        Task PublishAsync<T>(string queue, T message, CancellationToken cancellationToken = default);

    }
}
