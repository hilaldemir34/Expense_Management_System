using ExpenseManagementSystem.Application.Features.Payments.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace ExpenseManagementSystem.Infrastructure.Channels
{
    public class EftChannel : IEftChannel
    {
        private readonly Channel<EftRequestDto> _channel;

        public EftChannel()
        {
            _channel = Channel.CreateUnbounded<EftRequestDto>();
        }

        public ChannelWriter<EftRequestDto> Writer => _channel.Writer;
        public ChannelReader<EftRequestDto> Reader => _channel.Reader;
    }
}
