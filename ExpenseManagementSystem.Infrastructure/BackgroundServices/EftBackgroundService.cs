using ExpenseManagementSystem.Application.Interfaces;
using ExpenseManagementSystem.Domain.Entities;
using ExpenseManagementSystem.Domain.Enums;
using ExpenseManagementSystem.Infrastructure.Channels;
using ExpenseManagementSystem.Persistence.Context;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ExpenseManagementSystem.Infrastructure.BackgroundServices
{
    public class EftBackgroundService : BackgroundService
    {
        private readonly IEftChannel _eftChannel;
        private readonly ILogger<EftBackgroundService> _logger;
        private readonly IServiceScopeFactory _scopeFactory;

        public EftBackgroundService(
            IEftChannel eftChannel,
            ILogger<EftBackgroundService> logger,
            IServiceScopeFactory scopeFactory)
        {
            _eftChannel = eftChannel;
            _logger = logger;
            _scopeFactory = scopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await foreach (var req in _eftChannel.Reader.ReadAllAsync(stoppingToken))
            {
                try
                {
                    _logger.LogInformation($"[EFT] Simulating {req.Amount}₺: {req.FromIban} → {req.ToIban}");
                    await Task.Delay(2000, stoppingToken);

                    using var scope = _scopeFactory.CreateScope();
                    var db = scope.ServiceProvider
                                  .GetRequiredService<ApplicationDbContext>();
                    var payment = new Payment
                    {
                        ExpenseRequestId = req.ExpenseRequestId,
                        Amount = req.Amount,
                        PaidAt = DateTime.UtcNow,
                        Status = "Paid",
                        SenderUserId = null!,   
                        ReceiverUserId = db.ExpenseRequests.Find(req.ExpenseRequestId)!.UserId
                    };
                    db.Payments.Add(payment);

                    var er = await db.ExpenseRequests.FindAsync(req.ExpenseRequestId);
                    if (er != null)
                    {
                        er.Status = ApprovalStatus.Pending;
                        er.UpdatedAt = DateTime.UtcNow;
                    }
                    await db.SaveChangesAsync(stoppingToken);

                    _logger.LogInformation($"[EFT] Completed for Request {req.ExpenseRequestId}");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, $"[EFT] Error processing request {req.ExpenseRequestId}");
                }
            }
        }
    }

}
