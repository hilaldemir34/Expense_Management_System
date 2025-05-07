using ExpenseManagementSystem.Application.Features.Payments.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace ExpenseManagementSystem.Infrastructure.Channels
{
    public interface IEftChannel
    {
        ChannelWriter<EftRequestDto> Writer { get; }
        ChannelReader<EftRequestDto> Reader { get; }
    }
}

